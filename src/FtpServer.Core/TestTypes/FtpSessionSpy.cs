using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core.TestTypes
{
    public class FtpSessionSpy : FtpSession
    {
        public string MessageSent { get; private set; }

        public void Send(string message) {
            this.MessageSent = message;
        }
    }
}
