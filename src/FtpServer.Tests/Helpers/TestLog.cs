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

        public TestLog(string name, ITestOutputHelper output) : base(name) {
            this.output = output;
        }

        private string GetExceptionString(Exception ex) {
            return string.Format(
                "  {0} - {1}",
                ex.GetType().Name, 
                ex.Message);
        }
        
        protected override void LogCore(SimpleLogEntry entry) {
            StringBuilder sb = new StringBuilder();
            sb.Append(entry.LogName);
            sb.Append(" : ");
            sb.Append(entry.Level);
            sb.Append(" : ");
            sb.Append(entry.Message);

            if (entry.Exception != null) {
                sb.AppendLine();
                sb.Append(GetExceptionString(entry.Exception));
            }

            //send to trace
            System.Diagnostics.Trace.Write(sb.ToString());

            //send to test output
            try { output.WriteLine(sb.ToString()); }
            catch (InvalidOperationException) { }
        }
    }
}
