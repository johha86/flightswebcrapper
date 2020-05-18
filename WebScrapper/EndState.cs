using System;
using System.Collections.Generic;
using System.Text;

namespace WebScrapperLibrary
{
    public class EndState : State
    {   
        public EndState(WebScrapper context):base(context)
        {
            
        }

        public override void End()
        {
            
        }

        public override void Process()
        {
            m_context.Driver.Close();
            m_context.Driver.Quit();

        }

        public override void Start()
        {
            
        }
    }
}
