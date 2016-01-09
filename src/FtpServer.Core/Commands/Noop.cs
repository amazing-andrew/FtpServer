using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core.Commands
{
    public class Noop : FtpCommand
    {
        public void Execute(FtpSession session) {
            session.Send("200 OK");
        }
    }
}
