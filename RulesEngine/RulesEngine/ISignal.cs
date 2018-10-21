using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine
{
    //Dependency Inject (Factory Pattern)
    interface ISignal
    {
        string signal { get; set; }
        void Validate();
    }
}
