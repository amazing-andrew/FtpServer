using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core.Logging
{
    public abstract class SimpleLog : Log
    {
        protected abstract void Log(string level, string msg);
        protected abstract void Log(string level, string msg, Exception ex);
        protected abstract void Log(string level, string msg, params object[] args);

        public void Debug(string msg) {
            Log("DEBUG", msg);
        }
        public void Debug(string msg, Exception ex) {
            Log("DEBUG", msg, ex);
        }
        public void DebugFormat(string msg, params object[] args) {
            Log("DEBUG", msg, args);
        }

        public void Info(string msg) {
            Log("INFO", msg);
        }
        public void Info(string msg, Exception ex) {
            Log("INFO", msg, ex);
        }
        public void InfoFormat(string msg, params object[] args) {
            Log("INFO", msg, args);
        }

        public void Warn(string msg) {
            Log("WARN", msg);
        }
        public void Warn(string msg, Exception ex) {
            Log("WARN", msg, ex);
        }
        public void WarnFormat(string msg, params object[] args) {
            Log("WARN", msg, args);
        }

        public void Error(string msg) {
            Log("ERROR", msg);
        }
        public void Error(string msg, Exception ex) {
            Log("ERROR", msg, ex);
        }
        public void ErrorFormat(string msg, params object[] args) {
            Log("ERROR", msg, args);
        }

        public void Fatal(string msg) {
            Log("FATAL", msg);
        }
        public void Fatal(string msg, Exception ex) {
            Log("FATAL", msg, ex);
        }
        public void FatalFormat(string msg, params object[] args) {
            Log("FATAL", msg, args);
        }
    }
}
