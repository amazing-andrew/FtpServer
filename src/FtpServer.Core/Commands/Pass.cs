using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core.Commands
{
    public class Pass : FtpCommand
    {
        private const string SendUserFirst = "503 Send USER command first";
        
        public void Execute(FtpRequest request, FtpSession session) {
            var inputUser = session.GetData(User.UserDataKey);
            var inputPass = request.Arguments;

            if (inputUser == null) {
                session.Send(SendUserFirst);
                return;    
            }


            session.Authenticate(inputUser, inputPass);
        }
    }
}
