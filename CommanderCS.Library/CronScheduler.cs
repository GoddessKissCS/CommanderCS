using System.Collections.Concurrent;
using System.Reflection;
using System.Text.Json;

namespace CommanderCS.MongoDB
{
    /// <summary>
    /// A lightweight in-process cron scheduler that executes registered jobs
    /// on a recurring schedule using standard 5-field cron expressions.
    /// Job schedules are persisted to a JSON file so missed runs can be detected after restarts.
    /// </summary>
    public class CronScheduler
    {
        private static readonly string basePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),"Resources");

        private static readonly string SavePath = Path.Combine(basePath, "cronschedule.json");

        private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

        private readonly ConcurrentDictionary<string, CronJob> _jobs = new();
        private readonly ConcurrentDictionary<string, Action> _handlers = new();
        private Timer _timer;
        private bool _running;

        /// <summary>
        /// Registers an action handler by name. Call this before LoadFromFile.
        /// </summary>
        public void RegisterHandler(string name, Action action)
        {
            _handlers[name] = action;
        }

        /// <summary>
        /// Registers a new cron job and saves to file.
        /// </summary>
        /// <param name="name">Unique name identifying the job. Must have a handler registered via RegisterHandler.</param>
        /// <param name="cronExpression">Standard 5-field cron expression (minute hour day-of-month month day-of-week).</param>
        /// <param name="action">The action to execute when the job fires.</param>
        public void Register(string name, string cronExpression, Action action)
        {
            _handlers[name] = action;

            var now = DateTime.UtcNow;

            var job = new CronJob
            {
                Name = name,
                CronExpression = cronExpression,
                Action = action,
                Enabled = true,
                LastRunUtc = null,
                RegisteredAtUtc = now,
                NextRunUtc = CalculateNextRunAfter(cronExpression, now),
            };

            _jobs[name] = job;
            Save();
        }

        /// <summary>
        /// Loads job definitions from the JSON file and wires them to registered handlers.
        /// Jobs without a matching handler are skipped with a warning.
        /// </summary>
        public void LoadFromFile()
        {
            if (!File.Exists(SavePath))
                return;

            var json = File.ReadAllText(SavePath);
            var entries = JsonSerializer.Deserialize<List<CronJobEntry>>(json);

            if (entries is null)
                return;

            foreach (var entry in entries)
            {
                if (!_handlers.TryGetValue(entry.Name, out var action))
                {
                    Console.WriteLine($"[CronScheduler] No handler registered for '{entry.Name}', skipping.");
                    continue;
                }

                var job = new CronJob
                {
                    Name = entry.Name,
                    CronExpression = entry.CronExpression,
                    Action = action,
                    Enabled = entry.Enabled,
                    LastRunUtc = entry.LastRunUtc,
                    RegisteredAtUtc = entry.RegisteredAtUtc,
                    NextRunUtc = entry.NextRunUtc,
                };

                _jobs[entry.Name] = job;
            }
        }

        /// <summary>
        /// Saves current job state to the JSON file.
        /// </summary>
        public void Save()
        {
            var entries = _jobs.Values.Select(j => new CronJobEntry
            {
                Name = j.Name,
                CronExpression = j.CronExpression,
                Enabled = j.Enabled,
                LastRunUtc = j.LastRunUtc,
                RegisteredAtUtc = j.RegisteredAtUtc,
                NextRunUtc = j.NextRunUtc,
            }).ToList();

            var json = JsonSerializer.Serialize(entries, _jsonOptions);
            File.WriteAllText(SavePath, json);
        }

        /// <summary>
        /// Removes a registered job by name and saves to file.
        /// </summary>
        public bool Unregister(string name)
        {
            var removed = _jobs.TryRemove(name, out _);
            if (removed)
                Save();

            return removed;
        }

        /// <summary>
        /// Enables or disables a job by name and saves to file.
        /// </summary>
        public void SetEnabled(string name, bool enabled)
        {
            if (_jobs.TryGetValue(name, out var job))
            {
                job.Enabled = enabled;
                Save();
            }
        }

        /// <summary>
        /// Returns all registered jobs.
        /// </summary>
        public List<CronJob> GetAll()
        {
            var result = _jobs.Values.ToList();
            return result;
        }

        /// <summary>
        /// Starts the scheduler. Checks for due jobs every 60 seconds.
        /// </summary>
        public void Start()
        {
            if (_running)
                return;

            _running = true;
            _timer = new Timer(Tick, null, TimeSpan.Zero, TimeSpan.FromSeconds(60));
        }

        /// <summary>
        /// Stops the scheduler and saves state to file.
        /// </summary>
        public void Stop()
        {
            _running = false;
            _timer?.Dispose();
            _timer = null;
            Save();
        }

        private void Tick(object state)
        {
            var now = DateTime.UtcNow;

            foreach (var job in _jobs.Values)
            {
                if (!job.Enabled)
                    continue;

                bool isDueNow = MatchesCron(now, job.CronExpression);

                // Check if a scheduled run was missed while the server was offline
                bool wasMissed = false;
                if (!isDueNow && job.LastRunUtc.HasValue)
                {
                    var nextRun = CalculateNextRunAfter(job.CronExpression, job.LastRunUtc.Value);
                    if (nextRun.HasValue && nextRun.Value < now)
                        wasMissed = true;
                }

                if (!isDueNow && !wasMissed)
                    continue;

                // Prevent firing the same job more than once in the same minute
                if (job.LastRunUtc.HasValue
                    && job.LastRunUtc.Value.Year == now.Year
                    && job.LastRunUtc.Value.Month == now.Month
                    && job.LastRunUtc.Value.Day == now.Day
                    && job.LastRunUtc.Value.Hour == now.Hour
                    && job.LastRunUtc.Value.Minute == now.Minute)
                {
                    continue;
                }

                if (wasMissed)
                    Console.WriteLine($"[CronScheduler] Job '{job.Name}' was missed while offline, running now.");

                job.LastRunUtc = now;
                job.NextRunUtc = CalculateNextRunAfter(job.CronExpression, now);
                Save();

                try
                {
                    job.Action.Invoke();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[CronScheduler] Job '{job.Name}' failed: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Finds the first cron-matching minute after the given time, scanning up to 48 hours ahead.
        /// Used to detect missed runs.
        /// </summary>
        private static DateTime? CalculateNextRunAfter(string cronExpression, DateTime after)
        {
            var parts = cronExpression.Trim().Split(' ');
            if (parts.Length != 5)
                return null;

            var candidate = new DateTime(after.Year, after.Month, after.Day, after.Hour, after.Minute, 0, DateTimeKind.Utc).AddMinutes(1);
            var limit = candidate.AddHours(48);

            while (candidate < limit)
            {
                if (FieldMatches(parts[0], candidate.Minute, 0, 59)
                    && FieldMatches(parts[1], candidate.Hour, 0, 23)
                    && FieldMatches(parts[2], candidate.Day, 1, 31)
                    && FieldMatches(parts[3], candidate.Month, 1, 12)
                    && FieldMatches(parts[4], (int)candidate.DayOfWeek, 0, 6))
                {
                    return candidate;
                }

                candidate = candidate.AddMinutes(1);
            }

            return null;
        }

        /// <summary>
        /// Checks whether a DateTime matches a 5-field cron expression.
        /// Supports: exact numbers, wildcards (*), comma-separated lists, ranges (1-5), and step values (*/5).
        /// </summary>
        private static bool MatchesCron(DateTime dt, string cronExpression)
        {
            var parts = cronExpression.Trim().Split(' ');

            if (parts.Length != 5)
                return false;

            return FieldMatches(parts[0], dt.Minute, 0, 59)
                && FieldMatches(parts[1], dt.Hour, 0, 23)
                && FieldMatches(parts[2], dt.Day, 1, 31)
                && FieldMatches(parts[3], dt.Month, 1, 12)
                && FieldMatches(parts[4], (int)dt.DayOfWeek, 0, 6);
        }

        /// <summary>
        /// Evaluates a single cron field against a value.
        /// </summary>
        private static bool FieldMatches(string field, int value, int min, int max)
        {
            foreach (var segment in field.Split(','))
            {
                if (segment == "*")
                    return true;

                // Step value: */n or start/n
                if (segment.Contains('/'))
                {
                    var stepParts = segment.Split('/');
                    if (stepParts.Length == 2 && int.TryParse(stepParts[1], out int step) && step > 0)
                    {
                        int start = stepParts[0] == "*" ? min : int.Parse(stepParts[0]);
                        if ((value - start) >= 0 && (value - start) % step == 0)
                            return true;
                    }
                }
                // Range: n-m
                else if (segment.Contains('-'))
                {
                    var rangeParts = segment.Split('-');
                    if (rangeParts.Length == 2
                        && int.TryParse(rangeParts[0], out int rangeStart)
                        && int.TryParse(rangeParts[1], out int rangeEnd))
                    {
                        if (value >= rangeStart && value <= rangeEnd)
                            return true;
                    }
                }
                // Exact value
                else if (int.TryParse(segment, out int exact) && exact == value)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Represents a registered cron job.
        /// </summary>
        public class CronJob
        {
            public string Name { get; set; }
            public string CronExpression { get; set; }
            public Action Action { get; set; }
            public bool Enabled { get; set; }
            public DateTime? LastRunUtc { get; set; }
            public DateTime? RegisteredAtUtc { get; set; }
            public DateTime? NextRunUtc { get; set; }
        }

        /// <summary>
        /// JSON-serializable entry for persisting job state to file.
        /// </summary>
        private class CronJobEntry
        {
            public string Name { get; set; }
            public string CronExpression { get; set; }
            public bool Enabled { get; set; }
            public DateTime? LastRunUtc { get; set; }
            public DateTime? RegisteredAtUtc { get; set; }
            public DateTime? NextRunUtc { get; set; }
        }
    }
}
