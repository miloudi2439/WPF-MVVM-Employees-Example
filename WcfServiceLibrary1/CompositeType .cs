using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WcfServiceLibrary1
{
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        String stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
