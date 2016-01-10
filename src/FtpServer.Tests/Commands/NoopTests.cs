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
    public class NoopTests
    {
        FtpSessionSpy session = new FtpSessionSpy();


        [Fact]
        void TestNoop() {
            Noop noop = new Noop();
            noop.Execute(null, session);

            Assert.StartsWith("200", session.MessageSent);
        }
    }
}
