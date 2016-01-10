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
    public class NoopTests : CommandTestBase
    {
        [Fact]
        void Noop_SendsOK() {
            ExecuteFtpCommand<Noop>(null, null);
            Assert_ServerResponceCode(FtpResponceCode.CommandOK);
        }
    }
}
