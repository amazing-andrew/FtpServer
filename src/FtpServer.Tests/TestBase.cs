using FtpServer.Core.Logging;
using FtpServer.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FtpServer.Tests
{
    public abstract class TestBase {
        protected LogManager TestLogManager { get; private set; }
        protected Log Log { get; private set; }

        public TestBase(ITestOutputHelper output) {
            this.TestLogManager = new LogManager(name => new TestLog(name, output));
            this.Log = TestLogManager.GetLogFor(GetType());
        }
        
    }
}
