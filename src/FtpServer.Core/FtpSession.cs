using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core
{
    public interface FtpSession
    {
        void Send(string message);
    }
}
