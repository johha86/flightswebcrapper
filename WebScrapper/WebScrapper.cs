using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using DataLayerLibrary;

namespace WebScrapperLibrary
{
    /// <summary>
    /// Represent a state machine
    /// </summary>
    public class WebScrapper
    {
        private State m_currentState;
        private ChromeDriver m_chromeDriver;
        private readonly string m_flight;
        private readonly string m_email;
        private readonly string m_password;
        private readonly string m_loginUrl;
        private readonly bool m_retrieveAll;

        public State LoginPage;
        public State SearchPage;
        public State RetrieveAllPage;
        public State RetrieveTodayPage;
        public State EndPage;

        public List<Flight> Models;

        public WebScrapper(string flight, string username, string password, string loginUrl,bool all = false)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            m_chromeDriver = new ChromeDriver(chromeOptions);

            m_flight = flight;
            m_email = username;
            m_password = password;
            m_loginUrl = loginUrl;

            //  State initializing
            LoginPage = new LoginState(this);
            SearchPage = new SearchState(this);
            RetrieveAllPage = new ListState(this);
            RetrieveTodayPage = new RetrieveTodayState(this);
            EndPage = new EndState(this);
            m_currentState = LoginPage;

            Models = new List<Flight>();
        }

        public void TransitioTo(State next)
        {
            if (m_currentState != null)
                m_currentState.End();

            m_currentState = next;

            m_currentState.Start();
            m_currentState.Process();
        }

        public void Run()
        {
            m_currentState.Start();
            m_currentState.Process();
        }

        public ChromeDriver Driver => m_chromeDriver;
        public string Flight => m_flight;
        public string Email => m_email;
        public string Password => m_password;
        public string LoginUrl => m_loginUrl;
        public bool RetrieveAll => m_retrieveAll;
    }
}
