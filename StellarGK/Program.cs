using Microsoft.Extensions.FileProviders;
using StellarGK.Database;
using StellarGK.Host;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StellarGK
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true);
            var iConfigurationRoot = configurationBuilder.Build();

            var builder = WebApplication.CreateBuilder(args);

            // Configure & Add services to the container.

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

            //builder.WebHost.ConfigureKestrel(options =>
            //{
            //    options.AllowSynchronousIO = true;
            //});

            builder.Services.AddHttpClient();

            //            // To be replaced with mongodb
            //            builder.Services.AddSqlite<DatabaseContext>(iConfigurationRoot.GetConnectionString(nameof(DatabaseContext)));
            //            builder.Services.AddDbContext<DatabaseContext>((dbContextOptionsBuilder) =>
            //            {
            //#if DEBUG
            //                dbContextOptionsBuilder.EnableDetailedErrors();
            //                dbContextOptionsBuilder.EnableSensitiveDataLogging();
            //                dbContextOptionsBuilder.UseLoggerFactory(iLoggerFactory);
            //#endif
            //            });

            var app = builder.Build();

            var status = new Status()
            {
                Message = "Started Sucessfully!",
                CommandsLoaded = PacketHandler.CommandsMapped,
            };

            var statusString = JsonSerializer.Serialize(status, new JsonSerializerOptions()
            {
                WriteIndented = true,
            });

            app.MapGet("/", () => statusString);

            app.MapPost("/checkData.php", (HttpContext context, IServiceProvider provider) =>
            {
                return PacketHandler.ProcessRequest(context, provider);
            });

            var wsOptions = new WebSocketOptions()
            {
                KeepAliveInterval = TimeSpan.FromMilliseconds(1000),
            };

            //app.UseWebSockets(wsOptions);

            //app.MapGet("/chat.php", async (HttpContext context) =>
            //{
            //    await PacketHandler.ProcessChatRequest(context);
            //});

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseHttpLogging();
                app.UseDeveloperExceptionPage();
            }

            //app.UseMiddleware<CustomExceptionHandlerMiddleware>();

            #region StaticFileServer

            const string StaticFilesPath = "FileCDN";
            const string SlashStaticFilesPath = $"/{StaticFilesPath}";

            //// Working Directory path
            // var BasePath = builder.Environment.ContentRootPath;
            // Executable file path
            var BasePath = AppDomain.CurrentDomain.BaseDirectory;
            var staticFilesProviderPath = Path.Combine(BasePath, StaticFilesPath);
            var fileProvider = new PhysicalFileProvider(staticFilesProviderPath);

            app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = fileProvider,
                RedirectToAppendTrailingSlash = true,
                RequestPath = SlashStaticFilesPath,
            });

            // https://stackoverflow.com/questions/50381490/what-is-the-difference-between-usestaticfiles-and-usefileserver-in-asp-net-c
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = fileProvider,
                RequestPath = SlashStaticFilesPath,
                HttpsCompression = Microsoft.AspNetCore.Http.Features.HttpsCompressionMode.Compress,
                ServeUnknownFileTypes = true
            });

            #endregion StaticFileServer

            //app.UseCors((policyBuilder) =>
            //{
            //    policyBuilder.AllowAnyHeader();
            //    policyBuilder.AllowAnyMethod();
            //    policyBuilder.AllowAnyOrigin();
            //});

            //app.UseAuthorization();

            //DatabaseManager.FirstCreate();

            app.Run();
        }
    }

    internal class Status
    {
        public string Message { get; set; }
        public List<string> CommandsLoaded { get; set; }
    }
}