using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace MastersProject.Core.Common.Utils
{
    public class LogManager : LoggerBase
    {
        protected override Type LogPrefix
        {
            get { return this.GetType(); }
        }

        public void LogError(Type type, Exception e)
        {
            this.LogError(type.FullName, e);
        }

        public void LogInfo(Type type, Exception e)
        {
            this.LogInfo(type.FullName, e);
        }

        //public void LogInfo(string message)
        //{
        //    this.LogInfo(message);
        //}
    }
}
