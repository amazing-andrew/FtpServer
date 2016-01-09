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
            
            //record user name input
            session.SetData(UserDataKey, request.Arguments);
        }
    }
}
