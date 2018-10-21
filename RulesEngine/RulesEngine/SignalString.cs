using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine
{
    class SignalString : ISignal
    {
        public string signal { get; set; }

        private Signal _signal;
        public SignalString(Signal signal)
        {
            this._signal = signal;
        }
        public void Validate()
        {
            if(_signal != null && _signal.value.Equals(Properties.Resources.String_MIN))
            {
                BootStrap.Instance.textFile.WriteLine(_signal.signal);
            }
        }
    }
}
