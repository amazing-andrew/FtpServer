using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core.Logging
{
    public interface Log
    {
        void Debug(string msg);
        void Debug(string msg, Exception ex);
        void DebugFormat(string msg, params object[] args);

        void Info(string msg);
        void Info(string msg, Exception ex);
        void InfoFormat(string msg, params object[] args);

        void Warn(string msg);
        void Warn(string msg, Exception ex);
        void WarnFormat(string msg, params object[] args);

        void Error(string msg);
        void Error(string msg, Exception ex);
        void ErrorFormat(string msg, params object[] args);

        void Fatal(string msg);
        void Fatal(string msg, Exception ex);
        void FatalFormat(string msg, params object[] args);

    }
}
