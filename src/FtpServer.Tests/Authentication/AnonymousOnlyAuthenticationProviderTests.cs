using FtpServer.Core.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FtpServer.Tests.Authentication
{
    public class AnonymousOnlyAuthenticationProviderTests
    {
        AuthenticationProvider auth = new AnonymousOnlyAuthenticationProvider();

        [Fact]
        public void Authenticate_Anonymous_ReturnsTrue() {
            bool results = auth.Authenticate("anonymous", null);
            Assert.True(results);
        }

        [Fact]
        public void Authenticate_NonAnonymous_ReturnsFalse() {
            bool results = auth.Authenticate("bob", null);
            Assert.False(results);
        }
    }
}
