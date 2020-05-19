using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataLayerLibrary;

namespace FlightsWebScrapper
{
    public class FlightsWebScrapperDbContext : DbContext
    {
        public FlightsWebScrapperDbContext()
        {
        }

        public FlightsWebScrapperDbContext(DbContextOptions<FlightsWebScrapperDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=FlightsHistorical;uid=sa;pwd=Cuba1234;Integrated Security=True");
        }

        public DbSet<Test> _Tests { get; set; }
        public DbSet<Flight> Flights { get; set; }
    }
}
