﻿using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;
using WebScrapperLibrary;

namespace FlightsWebScrapper
{
    public class FlightsETL
    {
        private static WebScrapper scrapper;
        private readonly CurrentOptions m_optionsCurrent;
        private readonly HistoricalOptions m_optionsHistorical;

        public FlightsETL(CurrentOptions curr)
        {
            m_optionsCurrent = curr;
        }

        public FlightsETL(HistoricalOptions hist)
        {
            m_optionsHistorical = hist;
        }

        public void Run()
        {
            //  Extraction and Transform
            if (m_optionsCurrent != null)
            {
                scrapper = new WebScrapper(m_optionsCurrent.Flight, "pqrhot2016@gmail.com", "Cerbero666", "https://www.flightradar24.com/21.33,-94.49/6", false);
            }
            else if (m_optionsHistorical != null)
            {
                scrapper = new WebScrapper(m_optionsHistorical.Flight, "pqrhot2016@gmail.com", "Cerbero666", "https://www.flightradar24.com/21.33,-94.49/6", true);
            }

            if (scrapper.Run())
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
                var connectionString = Program.configuration.GetConnectionString("DataConnection");
                var options = new DbContextOptionsBuilder<FlightsWebScrapperDbContext>()
                           .UseSqlServer(connectionString)
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
