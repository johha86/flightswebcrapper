using System;
using System.Collections.Generic;
using System.Text;

namespace WebScrapperLibrary
{
    public abstract class State
    {
        protected WebScrapper m_context;
        public State(WebScrapper context)
        {
            m_context = context;
        }

        public abstract void Start();

        public abstract void Process();

        public abstract void End();
    }
}
