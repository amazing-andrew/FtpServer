using FtpServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FtpServer.Tests
{
    public class FtpRequestTests
    {
        [Fact]
        public void Ctor_CommandOnly_SetsProperty() {
            FtpRequest req = new FtpRequest("NOOP", null);
            Assert.Equal("NOOP", req.Command);   
        }

        [Fact]
        public void Ctor_CommandAndArgument_SetsProperty() {
            FtpRequest req = new FtpRequest("CMD", "ARG");

            Assert.Equal("CMD", req.Command);
            Assert.Equal("ARG", req.Arguments);
        }
    }
}
