using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayerLibrary;
using Microsoft.EntityFrameworkCore;
using FlightsWebScrapper;
using System;

namespace TestProject
{
    [TestClass]
    public class DataLayerTest
    {
        private string _connectionString = @"Server=localhost;Database=FlightsHistorical;uid=sa;pwd=Cuba1234;Integrated Security=True";
        [TestMethod]
        public void CreateConnectinToDB()
        {
            var options = new DbContextOptionsBuilder<FlightsWebScrapperDbContext>()
                   .UseSqlServer(_connectionString)
                   .Options;
            //using (var ctx = new FlightsWebScrapperDbContext(options))
            //{
            //}

            Assert.IsNotNull(options);
        }

        [TestMethod]
        public void CreateElementInTestTableToDB()
        {
            var options = new DbContextOptionsBuilder<FlightsWebScrapperDbContext>()
                   .UseSqlServer(_connectionString)
                   .Options;
            using (var ctx = new FlightsWebScrapperDbContext(options))
            {
                Test t1 = new Test();
                t1.Name = "Foo"+DateTime.Now.ToString();
                ctx.Add(t1);
                ctx.SaveChangesAsync();
            }

            Assert.IsNotNull(options);
        }
    }
}
