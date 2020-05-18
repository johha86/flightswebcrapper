using System;
using System.Collections.Generic;
using System.Text;

namespace WebScrapperLibrary
{
    public class LoginState : State
    {   
        public LoginState(WebScrapper context):base(context)
        {
            
        }

        public override void End()
        {
            
        }

        public override void Process()
        {
            var navigation = m_context.Driver.Navigate();
            navigation.GoToUrl(m_context.LoginUrl);
            System.Threading.Thread.Sleep(2000);

            var logInElement = m_context.Driver.FindElementByXPath("//*[@id='premiumOverlay']/a");
            logInElement.Click();
            System.Threading.Thread.Sleep(500);

            var emailInput = m_context.Driver.FindElementByXPath("//*[@id='fr24_SignInEmail']");
            emailInput.SendKeys(m_context.Email);

            var passwordInput = m_context.Driver.FindElementByXPath("//*[@id='fr24_SignInPassword']");
            passwordInput.SendKeys(m_context.Password);

            var logInSubmitBtn = m_context.Driver.FindElementByXPath("//*[@id='fr24_SignIn']");
            logInSubmitBtn.Click();
            System.Threading.Thread.Sleep(2000);

            m_context.TransitioTo(m_context.SearchPage);
        }

        public override void Start()
        {
            
        }
    }
}
