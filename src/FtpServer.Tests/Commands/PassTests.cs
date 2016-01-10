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
    public class PassTests : CommandTestBase
    {
        [Fact]
        public void Pass_WithoutUser_RequiresUserFirst() {
            ExecuteFtpCommand<Pass>("PASS", "12345");
            Assert_ServerResponceCode(FtpResponceCode.BadCommandSequence);
        }
        
        [Fact]
        public void Pass_WithUser_AttemptsAuthentication() {
            ExecuteFtpCommand<User>("USER", "bob");
            ExecuteFtpCommand<Pass>("PASS", "12345");
            
            Assert.True(session.AuthenticateWasCalled);
            Assert.Equal("bob", session.AuthenticateUserName);
            Assert.Equal("12345", session.AuthenticatePassword);
        }
    }
}
