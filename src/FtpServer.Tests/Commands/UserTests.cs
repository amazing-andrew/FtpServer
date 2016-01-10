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
    public class UserTests : CommandTestBase
    {
        [Fact]
        public void User_RecordsUserName() {
            ExecuteFtpCommand<User>("USER", "Steve");
            
            string recorded_username = session.GetData(User.UserDataKey);
            Assert.Equal("Steve", recorded_username);
        }

    }
}
