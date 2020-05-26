using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebScrapperLibrary;

namespace FlightsWebScrapper
{
    public class FlightsETL
    {
        private static WebScrapper scrapper;
        private readonly CurrentOptions m_options;

        public FlightsETL(CurrentOptions options)
        {
            m_options = options;
        }

        public void Run()
        {
            //  Extraction and Transform
            scrapper = new WebScrapper(m_options.Flight, "pqrhot2016@gmail.com", "Cerbero666", "https://www.flightradar24.com/21.33,-94.49/6",true);
            if(scrapper.Run())
            {
                LoadDataIntoDatabase();
            }
        }

        /// <summary>
        ///  Load data into database from the result in the web scrapper.
        /// </summary>
        private void LoadDataIntoDatabase()
        {
            try
            {
                var options = new DbContextOptionsBuilder<FlightsWebScrapperDbContext>()
                           .UseSqlServer(@"Server=localhost;Database=FlightsHistorical;uid=sa;pwd=Cuba1234;Integrated Security=True")
                           .Options;
                using (var ctx = new FlightsWebScrapperDbContext(options))
                {
                    foreach (var item in scrapper.Models)
                    {
                        ctx.Flights.Add(item);
                    }

                    //  Persist model into DB
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }          
        }
    }
}
