using FtpServer.Core;
using FtpServer.Core.TestTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FtpServer.Tests
{
    public class FtpSessionTests
    {
        FtpSessionSpy session = new FtpSessionSpy();
            

        [Fact]
        public void Send_SendsMessage() {
            session.Send("Hello");
            Assert.Equal("Hello", session.MessageSent);
        }
    }
}
