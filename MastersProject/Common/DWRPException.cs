using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MastersProject.Core.Common
{
    [DataContract]
    public class DWRPException:System.Exception
    {
        public DWRPException(string message)
            : base(message:message)
        {

        }
        public DWRPException(string message,Exception innerException)
            :base(message:message,innerException:innerException)
        {

        }
        public DWRPException(SerializationInfo info, StreamingContext context)
            :base( info:info,context:context)
        {

        }
    }

    [DataContract]
    public class WCFException
    {   
        [DataMember]
        public string Message { get; set; }

    }
}
