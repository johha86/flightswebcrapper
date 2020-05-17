using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace FlightsWebScrapper
{
    class Program
    {
        public static IConfiguration Configuration;
        static void Main(string[] args)
        {
             Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }
    }
}
