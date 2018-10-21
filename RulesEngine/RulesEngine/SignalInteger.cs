using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine
{
    class SignalInteger : ISignal
    {
        public string signal { get; set; }

        private Signal _signal;
        public SignalInteger(Signal signal)
        {
            this._signal = signal;
        }
        public void Validate()
        {
            double max = 0;
            double value = 0;
            if (double.TryParse(Properties.Resources.Integer_Max, out max) && 
                double.TryParse(_signal.value.ToString(), out value))
            {
                if (_signal != null && value > max)
                {
                    BootStrap.Instance.textFile.WriteLine(_signal.signal);
                }
            }
        }
    }
}
