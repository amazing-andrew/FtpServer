using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core.Commands
{
    public class User : FtpCommand
    {
        public const string UserDataKey = "USER";

        public void Execute(FtpRequest request, FtpSession session) {

            if (request.Arguments == null || request.Arguments.Trim() == "") {
                session.Send("501 Missing User Name Argument");
                return;
            }

            //record user name input
            session.SetData(UserDataKey, request.Arguments);
            session.Send("331 Send Password Command");
        }
    }
}
