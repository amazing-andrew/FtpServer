using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core.Authentication
{
    public class AnonymousOnlyAuthenticationProvider : AuthenticationProvider
    {
        public bool Authenticate(string userName, string password) {
            return IsAnonymous(userName);
        }


        private bool IsAnonymous(string userName) {
            if (userName == null)
                return false;

            userName = userName.Trim();
            return userName.Equals("anonymous", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
