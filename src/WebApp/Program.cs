using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace WebApp
{
    #pragma warning disable CS1591
    public class Program
    {
        public static void Main(string[] args)
        {
            // var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            // var configuration = new ConfigurationBuilder()
            //     .AddJsonFile("appsettings.json", optional: true)
            //     .AddJsonFile(String.Format("appsettings.{0}.json",envName), optional: true)
            //     .AddEnvironmentVariables()
            //     .Build();

            // Log.Logger = new LoggerConfiguration()  
            //     .ReadFrom.Configuration(configuration)
            //     .Enrich.FromLogContext()  
            //     .CreateLogger();  
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((context, configuration) =>
                {
                    configuration.Enrich.FromLogContext()
                        .Enrich.WithMachineName()
                        .WriteTo.Console()
                        .WriteTo.Elasticsearch(
                            new ElasticsearchSinkOptions(new Uri(context.Configuration["ElasticConfiguration:Uri"]))
                            {
                                IndexFormat = $"{context.Configuration["ApplicationName"]}-logs-{context.HostingEnvironment.EnvironmentName.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                                AutoRegisterTemplate = true,
                                NumberOfShards = 2,
                                NumberOfReplicas = 1
                            }
                        )
                        .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                        .ReadFrom.Configuration(context.Configuration);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
    #pragma warning restore CS1591
}
