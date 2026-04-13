using CommanderCS.Library;
using CommanderCS.Library.Cryptography;
using CommanderCS.Library.Regulation;
using CommanderCS.MongoDB;
using CommanderCS.Packets;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CommanderCS
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Thread thread = new(static () =>
            {
                string[] args = [];
                HTTPServer(args);
            });

            thread.Start();
        }

        private static void HTTPServer(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration iConfigurationRoot = configurationBuilder.Build();

            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddConfiguration(iConfigurationRoot);

            var iLoggerFactory = LoggerFactory.Create((iLoggingBuilder) =>
            {
                iLoggingBuilder.AddConfiguration(iConfigurationRoot);
                iLoggingBuilder.AddConsole();
            });

            builder.Services.AddSingleton(iLoggerFactory);

            builder.Services.ConfigureHttpJsonOptions((configureOptions) =>
            {
                var options = configureOptions.SerializerOptions;
                options.AllowTrailingCommas = true;
                options.ReadCommentHandling = JsonCommentHandling.Skip;
                options.UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement;
                options.WriteIndented = true;
            });


            builder.Services.AddDistributedMemoryCache(); // Required for session
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(5);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.Name = "?Session";
            });

            builder.Services.AddRazorPages();

            var app = builder.Build();

            app.MapPost("/checkData.php", async (HttpContext context, IServiceProvider provider) =>
            {
                if (!context.Request.Headers.UserAgent.Contains("BestHTTP"))
                {
                    return;
                }

                string responseData = await PacketHandler.ProcessRequest(context, provider);

                context.Response.ContentType = "application/json";
                context.Response.ContentLength = responseData.Length;

                await context.Response.WriteAsync(responseData);
            });


            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            app.UseSession();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.MapRazorPages(); // For Razor Pages


            SetupGKCronScheduler();

            app.Run();
        }


        public static void SetupGKCronScheduler()
        {

            DatabaseManager.Init();

            RemoteObjectManager.instance.regulation = Regulation.Create();

            CronScheduler scheduler = new();

            // 1. Register handlers (the actual logic)
            scheduler.RegisterHandler("DailyReset", () => { /* reset logic */ });
            scheduler.RegisterHandler("WeeklyReset", () => { /* weekly logic */ });

            scheduler.RegisterHandler("6HourResetForShootOutArenaOnWeekends", () => { /* reset logic */ });
            scheduler.RegisterHandler("12HourResetForShootOutArenaOnWeekdays", () => { /* reset logic */ });

            // 2. Load saved state from cronschedule.json (restores LastRunUtc, catches missed runs)
            scheduler.LoadFromFile();

            // 3. If first run, register the jobs (this saves to file automatically)
            // On subsequent runs, LoadFromFile already loaded them
            scheduler.Register("DailyReset", "0 16 * * *", () => { /* reset logic */ });
            scheduler.Register("WeeklyReset", "0 16 * * 1", () => { });
            scheduler.Register("6HourResetForShootOutArenaOnWeekends", "0 16 * * 1", () => { });
            scheduler.Register("12HourResetForShootOutArenaOnWeekdays", "0 16 * * 1", () => { });
            // 4. Start
            scheduler.Start();
        }

    }

}