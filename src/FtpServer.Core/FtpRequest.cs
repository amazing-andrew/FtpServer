using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core
{
    public class FtpRequest
    {
        public string Command { get; private set; }
        public string Arguments { get; private set; }

        public FtpRequest(string command, string arguments) {
            this.Command = command;
            this.Arguments = arguments;
        }

        
    }
}
