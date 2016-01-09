using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core.Authorization
{
    public class AlwaysAllowAuthorizationProvider : AuthorizationProvider
    {
        public bool Authorize(string userName) {
            return true;
        }
    }
}
