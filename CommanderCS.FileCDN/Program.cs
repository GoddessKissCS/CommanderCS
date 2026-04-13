using System.Collections.Concurrent;
using System.Text.Json;
using Microsoft.Extensions.FileProviders;

namespace CommanderCS.FileCDN
{
    public class Program
    {
        private const int MaxNotFoundBeforeBan = 10;
        private const string BannedIpsFile = "banned_ips.json";

        private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };
        private static readonly ConcurrentDictionary<string, int> NotFoundTracker = new();
        private static readonly ConcurrentDictionary<string, bool> BannedIps = new();

        private static bool IsBanned(string ip)
        {
            return BannedIps.ContainsKey(ip);
        }

        private static void Track404(string ip)
        {
            var count = NotFoundTracker.AddOrUpdate(ip, 1, (_, existing) => existing + 1);

            if (count >= MaxNotFoundBeforeBan)
            {
                BannedIps.TryAdd(ip, true);
                SaveBannedIps();
            }
        }

        private static void LoadBannedIps()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, BannedIpsFile);

            if (!File.Exists(path))
            {
                return;
            }

            var json = File.ReadAllText(path);
            var ips = JsonSerializer.Deserialize<List<string>>(json);

            if (ips == null)
            {
                return;
            }

            foreach (var ip in ips)
            {
                BannedIps.TryAdd(ip, true);
            }
        }

        private static void SaveBannedIps()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, BannedIpsFile);
            var ips = BannedIps.Keys.ToList();
            var json = JsonSerializer.Serialize(ips, JsonOptions);
            File.WriteAllText(path, json);
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            const string StaticFilesPath = "FileCDN";
            const string SlashStaticFilesPath = $"/{StaticFilesPath}";

            var BasePath = AppDomain.CurrentDomain.BaseDirectory;
            var staticFilesProviderPath = Path.Combine(BasePath, StaticFilesPath);

            if (!Directory.Exists(staticFilesProviderPath))
            {
                Directory.CreateDirectory(staticFilesProviderPath);
            }

            var fileProvider = new PhysicalFileProvider(staticFilesProviderPath);

            var contentTypeProvider = new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider();
            // Add any custom content types the game client needs
            contentTypeProvider.Mappings[".unity3d"] = "application/octet-stream";
            contentTypeProvider.Mappings[".png"] = "application/octet-stream";
            contentTypeProvider.Mappings[".webp"] = "application/octet-stream";
            contentTypeProvider.Mappings[".assetbundle"] = "application/octet-stream";
            contentTypeProvider.Mappings[".json"] = "application/json";

            LoadBannedIps();

            var logger = app.Services.GetRequiredService<ILoggerFactory>().CreateLogger("FileCDN");

            app.Use(async (context, next) =>
            {
                var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";

                if (IsBanned(ip))
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    return;
                }

                logger.LogInformation("Request: {Method} {Path}", context.Request.Method, context.Request.Path);

                foreach (var header in context.Request.Headers)
                {
                    logger.LogInformation("  {Key}: {Value}", header.Key, header.Value);
                }

                bool hasGzip = context.Request.Headers.AcceptEncoding.ToString().Contains("gzip");
                bool hasUnityVersion = context.Request.Headers["X-Unity-Version"] == "5.6.5p3";

                if (!hasGzip || !hasUnityVersion)
                {
                    logger.LogWarning("Rejected request: {Path} (gzip={Gzip}, unity={Unity})", context.Request.Path, hasGzip, hasUnityVersion);
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    return;
                }

                await next();
            });

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = fileProvider,
                RequestPath = SlashStaticFilesPath,
                HttpsCompression = Microsoft.AspNetCore.Http.Features.HttpsCompressionMode.Compress,
                ContentTypeProvider = contentTypeProvider,
                ServeUnknownFileTypes = false,
            });

            // Ban IPs that hit too many non-existing paths (file probing/enumeration)
            app.Run(async context =>
            {
                var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";

                Track404(ip);
                logger.LogWarning("Not found: {Path} from {IP} ({Count}/{Max})", context.Request.Path, ip, NotFoundTracker.GetValueOrDefault(ip, 0), MaxNotFoundBeforeBan);

                if (IsBanned(ip))
                {
                    logger.LogWarning("Banned IP: {IP} after {Max} 404s", ip, MaxNotFoundBeforeBan);
                }

                context.Response.StatusCode = StatusCodes.Status404NotFound;
            });

            app.Run();
        }
    }
}
