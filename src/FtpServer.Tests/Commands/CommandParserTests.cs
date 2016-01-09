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
            string input = "NOOP";
            FtpCommand cmd = parser.Parse(input);

            Assert.IsType<Noop>(cmd);
        }

        [Fact]
        void Parse_User() {
            string input = "USER";
            FtpCommand cmd = parser.Parse(input);

            Assert.IsType<User>(cmd);
        }

    }
}
