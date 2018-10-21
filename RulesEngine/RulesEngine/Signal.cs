using System.Runtime.Serialization;

namespace RulesEngine
{
    [DataContract]
    public class Signal
    {
        [DataMember]
        public string signal { get; set; }

        [DataMember]
        public object value { get; set; }

        [DataMember]
        public object value_type { get; set; }
    }
}
