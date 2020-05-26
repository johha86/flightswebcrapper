using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsWebScrapper
{
    [Verb("current",HelpText ="Obtiene los datos del dia actual")]
    public class CurrentOptions
    {
        [Option('f', "flight",  Required = true, HelpText = "Flight code to track data.", SetName = "flight")]
        public string Flight { get; set; }
    }

    [Verb("history", HelpText = "Obtiene los datos de forma historica")]
    public class HistoricalOptions
    {
        [Option('f', "flight", Required = true, HelpText = "Flight code to track data.", SetName = "flight")]
        public string Flight { get; set; }
    }
}
