using FtpServer.Core.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core
{
    public abstract class TcpServer : IDisposable
    {
        private int port;
        private TcpListener listener;
        private Log log;

        public TcpServer(int port, Log log) {
            this.port = port;
            this.log = log;

            listener = new TcpListener(
                IPAddress.Any,
                this.port);
        }

        public void Listen() {
            if (!listener.Server.IsBound) {
                listener.Start();
                AcceptClientsAsync(listener);
            }
        }

        private async void AcceptClientsAsync(TcpListener listener) {
            TcpClient client = null;

            while(true) {
                try {
                    client = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
                    StartHandleTask(client);
                }
                catch (Exception ex) { //listener closed
                    log.Fatal("Accept Clients Async Exception", ex);
                    break;
                }
            }
        }

        private async void StartHandleTask(TcpClient client) {
            if (client == null || client.Connected == false)
                return;

            try {
                log.Info("Handling Client");
                await HandleClient(client);
            }
            catch (Exception ex) {
                log.Fatal("Start Handle Task Exception", ex);
            }            
        }

        protected abstract Task HandleClient(TcpClient client);
        

        public void Close() {
            try {
                if (listener.Server.IsBound) {
                    listener.Stop();
                }
            }
            catch(Exception ex) {
                log.Fatal("Close Exception", ex);
            }
            
        }

        public void Dispose() {
            Close();
        }
    }
}
