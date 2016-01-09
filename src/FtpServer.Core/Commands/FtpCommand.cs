using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core.Commands
{
    public interface FtpCommand
    {
        void Execute(FtpRequest request, FtpSession session);
    }
}
