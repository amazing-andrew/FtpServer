using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core.Authentication
{
    public interface AuthenticationProvider
    {
        bool Authenticate(string userName, string password);
    }
}
