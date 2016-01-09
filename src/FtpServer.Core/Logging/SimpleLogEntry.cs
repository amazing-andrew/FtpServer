using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core.Logging
{
    public struct SimpleLogEntry
    {
        public SimpleLogEntry(string logName, string level, string message, Exception ex) {
            this.LogName = logName;
            this.Level = level;
            this.Message = message;
            this.Exception = ex;
        }

        public string LogName;
        public string Level;
        public string Message;
        public Exception Exception;
    }
}
