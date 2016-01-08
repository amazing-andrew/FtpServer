using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core.Logging
{
    public class ColoredConsoleLog : SimpleLog
    {
        Dictionary<string, ConsoleColor> colorLevels = new Dictionary<string, ConsoleColor>() {
            { "DEBUG", ConsoleColor.Gray },
            { "INFO",  ConsoleColor.White },
            { "WARN",  ConsoleColor.Yellow },
            { "ERROR",  ConsoleColor.Red },
            { "FATAL",  ConsoleColor.Red }
        };

        ConsoleColor getColor(string level) {
            if (colorLevels.ContainsKey(level))
                return colorLevels[level];
            else
                return colorLevels["INFO"];
        }

        public void WriteInColor(string level, string msg) {
            var newColor = getColor(level);
            var b4 = Console.ForegroundColor;

            Console.ForegroundColor = newColor;
            Console.WriteLine(msg);
            Console.ForegroundColor = b4;
        }

        protected override void Log(string level, string msg) {
            WriteInColor(level, msg);
        }

        protected override void Log(string level, string msg, params object[] args) {
            WriteInColor(level, string.Format(msg, args));
        }

        protected override void Log(string level, string msg, Exception ex) {
            string fullMessage = msg + "\r\n\r\n" + ex.ToString();
            WriteInColor(level, fullMessage);
        }
    }
}
