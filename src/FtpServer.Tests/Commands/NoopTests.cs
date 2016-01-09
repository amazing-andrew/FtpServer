using FtpServer.Core.Commands;
using FtpServer.Core.TestTypes;
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
        FtpSessionSpy session = make_Session();

        private static FtpSessionSpy make_Session() {
            FtpSessionSpy spy = new FtpSessionSpy();
            return spy;
        }

        [Fact]
        void TestNoop() {
            Noop noop = new Noop();
            noop.Execute(session);

            Assert.StartsWith("200", session.MessageSent);
        }
    }
}
