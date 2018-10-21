using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine
{
    public sealed class BootStrap
    {
        public TextFile textFile = new TextFile();
        public ParseRule rule = new ParseRule();

        BootStrap()
        { 
        }
        private static readonly object padlock = new object();
        private static BootStrap instance = null;
        public static BootStrap Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new BootStrap();
                    }
                    return instance;
                }
            }
        }
    }
}
