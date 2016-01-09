using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core.Commands
{
    public class CommandParser
    {
        static readonly Dictionary<string, Type> commands = new Dictionary<string, Type>();

        static CommandParser() {
            AddCommand("NOOP", typeof(Noop));
        }

        private static void AddCommand(string commandName, Type type) {
            commands.Add(commandName, type);
        }

        public FtpCommand Parse(string cmd) {
            string commandName = cmd;

            if (commands.ContainsKey(commandName))
                return (FtpCommand)Activator.CreateInstance(commands[commandName]);

            return null;
        }
    }
}
