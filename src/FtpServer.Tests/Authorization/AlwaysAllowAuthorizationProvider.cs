using FtpServer.Core.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FtpServer.Tests.Authorization
{
    public class AlwaysAllowAuthorizationProviderTests
    {
        AuthorizationProvider auth = new AlwaysAllowAuthorizationProvider();

        [Fact]
        public void Authorize_AlwaysReturnsTrue() {
            bool results = auth.Authorize(null);
            Assert.True(results);
        }
    }
}
