using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared
{
    [JsonObject]
    public class TimeData
    {
        public double start { get; set; }

        public double end { get; set; }

        public double duration { get; set; }

        public static TimeData Create()
        {
            return Create(0.0, 0.0);
        }

        public static TimeData Create(double start, double end)
        {
            TimeData timeData = new();
            timeData.Set(start, end);
            return timeData;
        }

        public static TimeData CreateByDuration(double start, double duration)
        {
            TimeData timeData = new();
            timeData.SetByDuration(start, duration);
            return timeData;
        }

        public void SetInvalidValue()
        {
            Set(0.0, 0.0);
        }

        public void Set(TimeData timeData)
        {
            start = timeData.start;
            end = timeData.end;
            duration = timeData.duration;
        }

        public void Set(double end)
        {
            start = GetCurrentTime();
            this.end = end;
            duration = end - start;
        }

        public void Set(double start, double end)
        {
            this.start = start;
            this.end = end;
            duration = end - start;
        }

        public void SetByDuration(double duration)
        {
            if (duration < 0.0)
            {
                SetInvalidValue();
            }
            else
            {
                SetByDuration(GetCurrentTime(), duration);
            }
        }

        public void SetByDuration(double start, double duration)
        {
            this.start = start;
            end = start + duration;
            this.duration = duration;
        }

        public string DebugString()
        {
            return $"start = {start}, end = {end}, duration = {duration}";
        }

        public void SetDelay(double delay)
        {
            Set(start, end + delay);
        }

        public float GetCurrentProgress()
        {
            double currentTime = GetCurrentTime();
            return (float)((currentTime - start) / duration);
        }

        public double GetRemain()
        {
            double currentTime = GetCurrentTime();
            return end - currentTime;
        }

        public bool IsValid()
        {
            return start > 0.0 && end > 0.0;
        }

        public bool IsProgress()
        {
            if (!IsValid())
            {
                return false;
            }
            float currentProgress = GetCurrentProgress();
            return currentProgress >= 0f && currentProgress < 1f;
        }

        public bool IsEnd()
        {
            if (!IsValid())
            {
                return false;
            }
            float currentProgress = GetCurrentProgress();
            return currentProgress > 1f;
        }

        public static double GetCurrentTime()
        {
            return TimeManager.GetCurrentTime();
        }
    }

}
