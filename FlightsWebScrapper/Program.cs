using CommandLine;
using CommandLine.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;

namespace FlightsWebScrapper
{
    class Program
    {
        private static Parser parser;
        private static FlightsETL m_etl;

        public static Parsed<CurrentOptions> parserResult;        
        public static IConfigurationRoot configuration;

        static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            parser = new CommandLine.Parser(with => with.HelpWriter = null);
                    
            var result = parser.ParseArguments<CurrentOptions, HistoricalOptions>(args)
                .WithParsed<HistoricalOptions>(opts => RunHistorical(opts))
                .WithParsed<CurrentOptions>(opts => RunCurrent(opts))
                .WithNotParsed(err => ErrorsHandler(err));
        }

        private static void DisplayHelp<T>(ParserResult<T> result, IEnumerable<Error> errs)
        {
            var helpText = HelpText.AutoBuild(result, h =>
            {
                h.AutoVersion = false;
                h.AutoHelp = false;
                h.AdditionalNewLineAfterOption = false;
                h.Heading = "ETL de Facturacion 1.0.0-beta"; //change header
                h.Copyright = "Copyright (c) 2020 FisterraEnergy.com"; //change copyright text
                return HelpText.DefaultParsingErrorsHandler(result, h);
            }, e => e);
            Console.WriteLine(helpText);
        }

        private static int RunCurrent(CurrentOptions options)
        {   
            if (!string.IsNullOrEmpty(options.Flight))
            {
                m_etl = new FlightsETL(options);
                m_etl.Run();
            }
                        
            return 0;
        }

        private static int RunHistorical(HistoricalOptions options)
        {
            if (!string.IsNullOrEmpty(options.Flight))
            {
                m_etl = new FlightsETL(options);
                m_etl.Run();
            }

            return 0;
        }

        private static int ErrorsHandler(IEnumerable<Error> errors)
        {
            return 1;
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Build configuration
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            // Add access to generic IConfigurationRoot
            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);

            // Add app
            serviceCollection.AddTransient<Program>();
        }
    }
}
