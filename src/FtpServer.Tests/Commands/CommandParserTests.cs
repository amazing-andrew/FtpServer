using FtpServer.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FtpServer.Tests.Commands
{
    public class CommandParserTests
    {
        CommandParser parser = new CommandParser();

        [Fact] 
        void Parse_Noop() {
            string cmdString = "NOOP";
            FtpCommand cmd = parser.Parse(cmdString);
            Assert.IsType<Noop>(cmd);
        }

    }
}
