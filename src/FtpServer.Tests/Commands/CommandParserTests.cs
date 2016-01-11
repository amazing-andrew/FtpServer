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

        void Parse_Unknown_ReturnsNull() {
            CommandParser parser = new CommandParser();
            FtpCommand result = parser.Parse("ASDF");
            Assert.Null(result);
        }

        [Fact] 
        void Parse_Noop() {
            Assert_CommandMatchesType<Noop>("NOOP");
        }

        [Fact]
        void Parse_User() {
            Assert_CommandMatchesType<User>("USER");
        }

        [Fact]
        void Parse_Pass() {
            Assert_CommandMatchesType<Pass>("PASS");
        }

        [Fact]
        void Parse_Quit() {
            Assert_CommandMatchesType<Quit>("QUIT");
        }


        private void Assert_CommandMatchesType<T>(string inputCommandName) {
            FtpCommand cmd = parser.Parse(inputCommandName);
            Assert.IsType<T>(cmd);
        }
    }
}
