using FtpServer.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace FtpServer.Tests.Helpers
{
    public class TestLog : SimpleLog
    {
        private ITestOutputHelper output;

        public TestLog(ITestOutputHelper output) {
            this.output = output;
        }

        private string GetExceptionString(Exception ex) {
            return string.Format("{0} - {1}",
                ex.GetType().Name, ex.Message);
        }

        private void Write(string msg, params object[] args) {
            try {
                string f = string.Format(msg, args);
                output.WriteLine(f);
                System.Diagnostics.Trace.WriteLine(f);
            }
            catch(InvalidOperationException) { }
        }

        protected override void Log(string level, string msg) {
            Write("{0} : {1}", 
                level, 
                msg);
        }

        protected override void Log(string level, string msg, params object[] args) {
            Write("{0} : {1}", 
                level,
                string.Format(msg, args));
        }

        protected override void Log(string level, string msg, Exception ex) {
            Write("{0} : {1} \r\n {2}",
                level,
                msg,
                GetExceptionString(ex));
        }
    }
}
