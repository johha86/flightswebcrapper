using OpenQA.Selenium.Chrome;
using System;

namespace WebScrapperLibrary
{
    /// <summary>
    /// Represent a state machine
    /// </summary>
    public class WebScrapper
    {
        private State m_currentState;

        public State LoginPage;
        public State SearchPage;
        public State ResultPage;

        internal ChromeDriver m_chromeDriver;
        internal readonly string m_flight;
        internal readonly string m_username;
        internal readonly string m_password;
        internal readonly string m_loginUrl;

        public WebScrapper(string flight,string username, string password,string loginUrl)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            m_chromeDriver = new ChromeDriver(chromeOptions);

            m_flight = flight;
            m_username = username;
            m_password = password;
            m_loginUrl = loginUrl;
        }

        public void TransitioTo(State next)
        {

        }

        public void Run()
        {
            var navigation = m_chromeDriver.Navigate();
            navigation.GoToUrl(m_loginUrl);
            System.Threading.Thread.Sleep(2000);

            var logInElement = m_chromeDriver.FindElementByXPath("//*[@id='premiumOverlay']/a");
            logInElement.Click();
            System.Threading.Thread.Sleep(500);

            var emailInput = m_chromeDriver.FindElementByXPath("//*[@id='fr24_SignInEmail']");
            emailInput.SendKeys(m_username);

            var passwordInput = m_chromeDriver.FindElementByXPath("//*[@id='fr24_SignInPassword']");
            passwordInput.SendKeys(m_password);

            var logInSubmitBtn = m_chromeDriver.FindElementByXPath("//*[@id='fr24_SignIn']");
            logInSubmitBtn.Click();
        }
    }
}
