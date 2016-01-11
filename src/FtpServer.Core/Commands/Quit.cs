using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core.Commands
{
    public class Quit : FtpCommand
    {
        private const string Responce_ClosingControl = "221 Closing Control";

        public void Execute(FtpRequest request, FtpSession session) {
            session.Send(Responce_ClosingControl);
            session.Quit();
        }
    }
}
