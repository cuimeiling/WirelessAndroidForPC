using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WireLessPC
{
    class IntegerParseException : Exception
    {
        public override void GetObjectData(SerializationInfo info,StreamingContext context)
        {
            base.GetObjectData(info,context);
        }

        public override string Message
        {
            get
            {
                return "端口无效!";
            }
        }
    }
}
