using CommandLine;
using CommandLine.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace FlightsWebScrapper
{
    class Program
    {
        private static Parser parser;
        public static Parsed<CurrentOptions> parserResult;
        public static IConfiguration Configuration;
        static void Main(string[] args)
        {
            parser = new CommandLine.Parser(with => with.HelpWriter = null);
            var result = parser.ParseArguments<CurrentOptions>(args)
                .MapResult(
                    (CurrentOptions current) => Run(current),
                    (err) => ErrorsHandler(err)
                    );

            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();            
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

        private static int Run(CurrentOptions options)
        {
            if (string.IsNullOrEmpty(options.Flight))
            {

            }

            return 0;
        }

        private static int ErrorsHandler(IEnumerable<Error> errors)
        {
            return 1;
        }
    }
}
