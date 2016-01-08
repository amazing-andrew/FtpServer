﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using FtpServer.Core.Logging;

namespace FtpServer.Core.TestTypes
{
    public class EchoTcpServer : TcpServer
    {
        public EchoTcpServer(int port, Log log) : base(port, log) {
        }

        protected override async Task HandleClient(TcpClient client) {
            var stream = client.GetStream();
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);

            string line = await reader.ReadLineAsync().ConfigureAwait(false);
            
            while(line != null) {
                writer.WriteLine(line);
                writer.Flush();

                line = await reader.ReadLineAsync().ConfigureAwait(false);
            }
        }
    }
}