using FtpServer.Core;
using FtpServer.Core.Commands;
using FtpServer.Tests.TestDoubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FtpServer.Tests.Commands
{
    public class PassTests
    {
        FtpSessionSpy session = new FtpSessionSpy();

        [Fact]
        public void Pass_WithoutUser_RequiresUserFirst() {
            var req = make_PassRequest("12345");

            Pass cmd = new Pass();
            cmd.Execute(req, session);

            string result = session.MessageSent;
            Assert.StartsWith("503", result);
        }


        [Fact]
        public void Pass_WithUser_AttemptsAuthentication() {
            init_SendUserToSession("bob");
            var req = make_PassRequest("12345");
            Pass cmd = new Pass();
            cmd.Execute(req, session);

            Assert.True(session.AuthenticateWasCalled);
            Assert.Equal("bob", session.AuthenticateUserName);
            Assert.Equal("12345", session.AuthenticatePassword);
        }



        private FtpRequest make_PassRequest(string pass) {
            return new FtpRequest("PASS", pass);
        }

        private void init_SendUserToSession(string user) {
            FtpRequest userReq = new FtpRequest("USER", user);
            User userCmd = new User();
            userCmd.Execute(userReq, session);
        }
    }
}
