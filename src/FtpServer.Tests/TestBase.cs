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
    public abstract class TestBase
    {
        protected Log Log { get; private set; }

        public TestBase(ITestOutputHelper output) {
            
            this.Log = new TestLog(output);
        }
        
    }
}
