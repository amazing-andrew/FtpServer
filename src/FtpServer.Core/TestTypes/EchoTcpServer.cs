using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using FtpServer.Core.Logging;

namespace FtpServer.Core.TestTypes
{
    public class EchoTcpServer : TcpServer2
    {
        public EchoTcpServer(int port, LogManager logManager) : base(port, logManager) {
        }

        protected override async Task HandleClient(TcpClient client) {
            using (var stream = client.GetStream())
            using (var reader = new StreamReader(stream))
            using (var writer = new StreamWriter(stream)) {

                string line = await reader.ReadLineAsync().ConfigureAwait(false);

                while (line != null) {
                    writer.WriteLine(line);
                    writer.Flush();
                    line = await reader.ReadLineAsync().ConfigureAwait(false);
                }
            }
        }
    }
}
