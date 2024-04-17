using CommanderCS.Host;
using CommanderCS.MongoDB;
using CommanderCSLibrary.Shared;
using CommanderCSLibrary.Shared.Regulation;
using Microsoft.Extensions.FileProviders;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CommanderCS
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration iConfigurationRoot = configurationBuilder.Build();

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

            builder.Services.AddHttpClient();

            var app = builder.Build();

            var status = new Status()
            {
                Message = "Started Sucessfully!",
                CommandsLoaded = PacketHandler.CommandsMapped,
            };

            JsonSerializerOptions stausStringOptions = new()
            {
                WriteIndented = true,
            };

            var statusString = JsonSerializer.Serialize(status, stausStringOptions);

            app.MapGet("/", () => statusString);

            app.MapPost("/checkData.php", async (HttpContext context, IServiceProvider provider) =>
            {
                //Check if the request contains the user agent BestHTTP
                if (!context.Request.Headers.UserAgent.Contains("BestHTTP"))
                {
                    return;
                }

                // The Response
                string responseData = await PacketHandler.ProcessRequest(context, provider);

                // Set the Response Contenttype and length
                context.Response.ContentType = "application/json";
                context.Response.ContentLength = responseData.Length;

                // Write response to the response body stream
                await context.Response.WriteAsync(responseData);
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.UseHttpLogging();
                app.UseDeveloperExceptionPage();
            }

            //app.UseMiddleware<CustomExceptionHandlerMiddleware>();

            //PROBABLY SHOULD BE MOVED TO A CDN SERVER

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

            // app.UseWebSockets(new WebSocketOptions() {
            //     KeepAliveInterval = TimeSpan.FromSeconds(60),
            //});

            #endregion StaticFileServer

            //app.UseCors((policyBuilder) =>
            //{
            //    policyBuilder.AllowAnyHeader();
            //    policyBuilder.AllowAnyMethod();
            //    policyBuilder.AllowAnyOrigin();
            //});

            //app.UseAuthorization();

            DatabaseManager.Init();

            RemoteObjectManager.instance.regulation = Regulation.Create();

            app.Run();
        }
    }

    internal class Status
    {
        public string Message { get; set; }
        public List<string> CommandsLoaded { get; set; }
    }
}