using DataLayerLibrary;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebScrapperLibrary
{
    public class ListState : State
    {   
        public ListState(WebScrapper context):base(context)
        {
            
        }

        public override void End()
        {
            
        }

        public override void Process()
        {            
            var logInElement = m_context.Driver.FindElementByXPath("//*[@id='tbl-datatable']/tbody");
            Flight model;

            var trCollection = logInElement.FindElements(By.XPath(".//tr"));
            foreach (var row in trCollection)
            {
                //  date //*[@id="tbl-datatable"]/tbody/tr[1]/td[3]
                var dateWebElement = row.FindElement(By.XPath(".//td[3]"));
                var date = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                date = date.AddSeconds(double.Parse(dateWebElement.GetAttribute("data-timestamp"))).ToLocalTime();

                var fromAirportFullname = row.FindElement(By.XPath(".//td[4]")).GetAttribute("title");

                var fromAirportIATA = row.FindElement(By.XPath(".//td[4]/a")).Text.Trim('(', ')');

                var toAirportFullname = row.FindElement(By.XPath(".//td[5]")).GetAttribute("title");

                var toAirportIATA = row.FindElement(By.XPath(".//td[5]/a")).Text.Trim('(', ')');

                var aircraftModel = row.FindElement(By.XPath(".//td[6]")).Text;

                var flightTime = row.FindElement(By.XPath(".//td[7]")).Text;

                var scheduledTimeDeparture = row.FindElement(By.XPath(".//td[8]")).GetAttribute("data-timestamp");
                var actualTimeDeparture = row.FindElement(By.XPath(".//td[9]")).GetAttribute("data-timestamp");
                var scheduledTimeArrival = row.FindElement(By.XPath(".//td[10]")).GetAttribute("data-timestamp");
                var actualTimeArrival = row.FindElement(By.XPath(".//td[12]")).GetAttribute("data-timestamp");
                var status = row.FindElement(By.XPath(".//td[12]")).GetAttribute("data-prefix");

                model = new Flight();
                model.FlightCode = m_context.Flight;
                model.RecordDate = DateTime.Now;
                model.FlightDate = date;
                model.FromAirportFullname = fromAirportFullname;
                model.FromAirportIATA = fromAirportIATA;
                model.ToAirportFullname = toAirportFullname;
                model.ToAirportIATA = toAirportIATA;
                model.AircraftModel = aircraftModel;
                model.Status = status;
                model.ScheduledTimeDeparture = !string.IsNullOrEmpty(scheduledTimeDeparture) ? double.Parse(scheduledTimeDeparture):0;
                model.ActualTimeDeparture = !string.IsNullOrEmpty(actualTimeDeparture) ? double.Parse(actualTimeDeparture):0;
                model.ScheduledTimeArrival = !string.IsNullOrEmpty(scheduledTimeArrival) ? double.Parse(scheduledTimeArrival):0;
                model.ActualTimeArrival = !string.IsNullOrEmpty(actualTimeArrival) ? double.Parse(actualTimeArrival):0;

                m_context.Models.Add(model);

                var d1 = !string.IsNullOrEmpty(scheduledTimeDeparture) ? new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(double.Parse(scheduledTimeDeparture)).ToLocalTime().ToShortTimeString() : "";
                var d2 = !string.IsNullOrEmpty(actualTimeDeparture) ? new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(double.Parse(actualTimeDeparture)).ToLocalTime().ToShortTimeString() : "";
                var d3 = !string.IsNullOrEmpty(scheduledTimeArrival) ? new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(double.Parse(scheduledTimeArrival)).ToLocalTime().ToShortTimeString() : "";

                Console.WriteLine($"{date.ToShortDateString()} " +
                    $"{fromAirportIATA} " +
                    $"{toAirportIATA} " +
                    $"{aircraftModel} " +
                    $"{flightTime} " +
                    $"{d1} " +
                    $"{d2} " +
                    $"{d3} " +
                    $"{status}");
            }

            m_context.TransitioTo(m_context.EndPage);
        }

        public override void Start()
        {
            
        }
    }
}
