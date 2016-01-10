using FtpServer.Core;
using FtpServer.Core.Commands;
using FtpServer.Tests.TestDoubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Tests.Commands
{
    public class CommandTestBase
    {
        protected FtpSessionSpy session;

        public CommandTestBase() {
            session = new FtpSessionSpy();
        }

        
        protected void ExecuteFtpCommand<TCmd>(string ftpCommand, string argument) where TCmd : FtpCommand {
            var ftpCmd = make_Command<TCmd>();
            var req = make_Request(ftpCommand, argument);
            ftpCmd.Execute(req, session);
        }


        //factories
        protected FtpCommand make_Command<TCmd>() where TCmd : FtpCommand {
            return Activator.CreateInstance<TCmd>();
        }

        protected FtpRequest make_Request(string cmd, string arg) {
            return new FtpRequest(cmd, arg);
        }



        protected void Assert_ServerResponceCode(FtpResponceCode responce) {
            Assert_ServerResponceCode((int)responce);
        }
        protected void Assert_ServerResponceCode(int expectedResponceCode) {
            string code = expectedResponceCode.ToString(System.Globalization.CultureInfo.InvariantCulture);
            Assert_ServerResponceCode(code);
        }
        protected void Assert_ServerResponceCode(string expectedResponceCode) {
            Assert.True(session.ServerResponce != null, "Server did not send a responce");
            
            string serverResponceCode = session.ServerResponce;

            int spaceIdx = session.ServerResponce.IndexOf(' ');
            if (spaceIdx != -1)
                serverResponceCode = serverResponceCode.Substring(0, spaceIdx);

            Assert.Equal(expectedResponceCode, serverResponceCode);
        }
    }
}
