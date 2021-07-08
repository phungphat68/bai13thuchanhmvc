using Confluent.Kafka;
using DnsClient;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApplication2
{
    public class Program
    {
       
             

        public static void Main(string[] args)
        {
            CreateWebHostBuider(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuider(string[] args)
        {
            var builder = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile(path: "appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile(path: $"appsettings.{ env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    if (env.IsDevelopment())
                    {
                        var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
                        if (appAssembly != null)
                        {
                            config.AddUserSecrets(appAssembly, optional: true);
                        }
                    }
                    config.AddEnvironmentVariables();
                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                .ConfigureLogging((hostingContext, loggin) =>
                {
                    loggin.AddConfiguration(hostingContext.Configuration.GetSection(key: "Logging"));
                    loggin.AddConsole();
                    loggin.AddDebug();
                })
                .UseIISIntegration()
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                });
            return builder;
        }
    }
}
