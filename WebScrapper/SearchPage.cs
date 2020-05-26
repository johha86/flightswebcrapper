using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebScrapperLibrary
{
    public class SearchState : State
    {
        public SearchState(WebScrapper context) : base(context)
        {

        }

        public override void End()
        {

        }

        public override void Process()
        {
            var navigation = m_context.Driver.Navigate();
            navigation.GoToUrl($"https://www.flightradar24.com/data/flights/{m_context.Flight}");
            System.Threading.Thread.Sleep(2000);

            if (m_context.RetrieveAll)
            {
                m_context.TransitioTo(m_context.RetrieveAllPage);
            }
            else
            {
                m_context.TransitioTo(m_context.RetrieveTodayPage);
            }
        }

        public override void Start()
        {

        }
    }
}
