using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebScrapperLibrary
{
    public class SearchState : State
    {   
        public SearchState(WebScrapper context):base(context)
        {
            
        }

        public override void End()
        {
            
        }

        public override void Process()
        {
            var navigation = m_context.Driver.Navigate();
            navigation.GoToUrl("https://www.flightradar24.com/data/flights/dl363");
            System.Threading.Thread.Sleep(2000);

            //var emailInput = m_context.Driver.FindElementByXPath("//*[@id='searchFlight']");
            //emailInput.SendKeys(m_context.Flight.ToUpper());
            //emailInput.SendKeys(Keys.Enter);
        }

        public override void Start()
        {
            
        }
    }
}
