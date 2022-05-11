using api_netcore_recommendacion_espacios.Data;
using api_netcore_recommendacion_espacios.Servicios;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_netcore_recommendacion_espacios
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task.Run(MqttPublisherService.RunAsync);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
