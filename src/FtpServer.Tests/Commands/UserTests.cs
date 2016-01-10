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
    public class UserTests
    {
        FtpSessionSpy session = new FtpSessionSpy();

        [Fact]
        public void User_RecordsUserName() {
            var req = make_UserRequest("Steve");

            User cmd = new User();
            cmd.Execute(req, session);

            string recorded_username = session.GetData(User.UserDataKey);
            Assert.Equal("Steve", recorded_username);
        }

        private FtpRequest make_UserRequest(string userName) {
            return new FtpRequest("USER", userName);
        }
    }
}
