using FtpServer.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FtpServer.Tests.Commands
{
    public class QuitTests : CommandTestBase {
        [Fact]
        public void Quit_SendsCloseToSession() {
            ExecuteFtpCommand<Quit>("QUIT", null);
            Assert.True(session.QuitWasCalled);
        }

        [Fact]
        public void Quit_InformsControlIsClosing() {
            ExecuteFtpCommand<Quit>("QUIT", null);
            Assert_ServerResponceCode(Core.FtpResponceCode.ClosingControl);
        }

    }
}
