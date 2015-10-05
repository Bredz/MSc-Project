using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MastersProject.Core.Common.Infrastructure
{
    public class Alert
    {
      
        public string Message { get; set; }
        public string AlertClass { get; set; }
        public bool IsTimedOut { get; set; }
        public Alert(string alertClass,string message,bool isTimedOut)
        {
            Message = message;
            AlertClass = alertClass;
            IsTimedOut = isTimedOut;
        }

        public Alert()
        {
            // TODO: Complete member initialization
        }
    }
}