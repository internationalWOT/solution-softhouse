using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using solution_softhouse.TranslatorEngine.Interfaces;

namespace solution_softhouse
{
    public class Program
    {
        private static ILogger<Program> _logger;
        private readonly ITranslatorEngine _translatorEngine;
        private static string _result = "";

        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var program = host.Services.GetRequiredService<Program>();

            Console.WriteLine("Please input the search path to a txt file...");
            string filePath = Console.ReadLine();

            try
            {
                string src = File.ReadAllText(filePath);
                _result = program._translatorEngine.DoTranslation(src);
                Console.WriteLine(_result);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message);
            }
        }

        public Program(ILogger<Program> logger, ITranslatorEngine translatorEngine)
        {
            _logger = logger;
            _translatorEngine = translatorEngine;
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            /*
            *  using some dependency injection in order to generate our translator service.
            * in the future you can make more implementations of the service with other
            * fileformats and generate a small factory method/structure for initiating
            * the different implementations.
            */
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddScoped<Program>();
                    services.AddTransient<ITranslatorEngine, XmlTranslatorEngine.XmlTranslatorEngine>();
                });
        }

    }
}
