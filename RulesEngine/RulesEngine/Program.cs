using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Text;

namespace RulesEngine
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Signal> signalData = null;
            //json file path
            string signalsFile = String.Format(" {0}{1}", GetApplicationPath(), Properties.Resources.InputJson);

            //deserialize the json file.
            using (var streamReader = new StreamReader(signalsFile))
            {
                string signalJson = streamReader.ReadToEnd();
                if (!string.IsNullOrEmpty(signalJson))
                {
                    signalData = deserializeJson<List<Signal>>(signalJson);
                }

            }

            if (signalData == null) return;

            Task.Factory.StartNew(() =>
            {
                foreach (Signal signal in signalData)
                {
                    BootStrap.Instance.rule.bc_Signal.TryAdd(signal);
                }
                BootStrap.Instance.rule.bc_Signal.CompleteAdding();
            });

            BootStrap.Instance.rule.Parse();

            DisopseAll();

            if (signalData != null)
            {
                signalData.Clear();
                signalData = null;
            }
        }
        public static T deserializeJson<T>(string result)
        {
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(result)))
            {
                ms.Position = 0;
                return (T)jsonSer.ReadObject(ms);
            }
        }

        private static void DisopseAll()
        {
            if(BootStrap.Instance.rule != null)
            {
                BootStrap.Instance.rule.Dispose(true);
                BootStrap.Instance.rule = null;
            }

            if(BootStrap.Instance.textFile != null)
            {
                BootStrap.Instance.textFile.Dispose(true);
                BootStrap.Instance.rule = null;
            }
        }

        public static string GetApplicationPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
