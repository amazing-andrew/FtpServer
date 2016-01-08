using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FtpServer.Tests
{
    public class Assert : global::Xunit.Assert
    {
        public static void PortIsOpen(int port) {
            bool isPortOpen = check_IsPortOpen(port);
            Assert.True(isPortOpen,
                string.Format(
                    "Port '{0}' is not listening but was expected to be.",
                    port));
        }

        public static void PortIsNotOpen(int port) {
            bool isPortOpen = check_IsPortOpen(port);
            Assert.False(isPortOpen,
                string.Format(
                    "Port '{0}' is listening but was expect to not be.",
                    port));
        }

        private static bool check_IsPortOpen(int port) {
            try {
                using (TcpClient checker = new TcpClient()) {
                    checker.Connect("localhost", port);
                    checker.Close();
                    return true;
                }
            }
            catch {
                return false;
            }
        }
    }
}
