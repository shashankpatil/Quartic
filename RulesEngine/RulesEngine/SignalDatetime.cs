using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine
{
    class SignalDatetime : ISignal
    {
        public string signal { get; set; }

        private Signal _signal;
        public SignalDatetime(Signal signal)
        {
            this._signal = signal;
        }
        public void Validate()
        {
            DateTime time;
            if (DateTime.TryParse(_signal.value.ToString(), out time))
            {
                if (_signal != null && time > DateTime.Now )
                {
                    BootStrap.Instance.textFile.WriteLine(_signal.signal);
                }
            }
        }
    }
}
