using System.Text.Json;
using System.Text.Json.Serialization;
using Org.BouncyCastle.Asn1.Ocsp;
using StellarGK.Database;
using StellarGK.Host;
using StellarGK.Host.Middlewares;

namespace StellarGK2
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

            builder.WebHost.ConfigureKestrel(options =>
            {
                options.AllowSynchronousIO = true;
            });


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

            //app.Services.CreateAsyncScope();

            //app.MapPost("/checkData.php", PacketHandler.ProcessRequest);
            app.MapPost("/checkData", (HttpContext context, IServiceProvider provider) =>
            {
                return PacketHandler.ProcessRequest(context, provider);
            });
            //app.MapGet("get", PacketHandler.Packet);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseHttpLogging();
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<CustomExceptionHandlerMiddleware>();

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
}

class Status
{
    public string Message { get; set; }
    public List<string> CommandsLoaded { get; set; }
}