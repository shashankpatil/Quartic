using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine
{
    public class ParseRule : IDisposable
    {
        public BlockingCollection<Signal> bc_Signal = new BlockingCollection<Signal>();

        internal ISignal ValSignal { get; set; }

        public void Dispose()
        {
            if(bc_Signal != null)
            {
                bc_Signal.Dispose();
                bc_Signal = null;
            }

            if(ValSignal != null)
            {
                ValSignal = null;
            }
        }

        public void Dispose(bool result)
        {
            if(result)
                Dispose();
        }
        public void Parse()
        {
            Signal signal;
            while (!bc_Signal.IsCompleted)
            {
                if (bc_Signal.TryTake(out signal))
                {
                    if (!string.IsNullOrEmpty(signal.signal))
                    {
                        switch (signal.value_type.ToString())
                        {
                            case "Integer":
                                ValSignal = new SignalInteger(signal);
                                break;
                            case "String":
                                ValSignal = new SignalString(signal);
                                break;
                            case "Datetime":
                                ValSignal = new SignalDatetime(signal);
                                break;
                            default: break;
                        }
                    }

                    if (ValSignal != null)
                    {
                        ValSignal.Validate();
                    }
                }
            }
        }
    }
}
