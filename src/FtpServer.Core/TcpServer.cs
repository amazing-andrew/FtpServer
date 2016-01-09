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


        public TcpServer(int port, LogManager log) {
            this.port = port;
            this.log = log.GetLogFor(GetType());

            listener = new TcpListener(
                IPAddress.Any,
                this.port);
        }
        
        private async void AcceptClientsAsync(TcpListener listener) {
            TcpClient client = null;

            while(true) {
                try {
                    client = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
                }
                catch (ObjectDisposedException)   { /*the listener has stopped */ break; }
                catch (NullReferenceException)    { /*the listener has stopped */ break; }
                catch (InvalidOperationException) { /*the listener has stopped */ break; }

                DispatchClientToHandler(client);
            }
        }

        private async void DispatchClientToHandler(TcpClient client) {
            if (client == null || client.Connected == false)
                return;

            try {
                await HandleClient(client);
                client.Close();
                client = null;
            }
            catch (Exception ex) {
                log.Fatal("Start Handle Task Exception", ex);
            }            
        }

        protected abstract Task HandleClient(TcpClient client);
        

        private bool IsAlreadyListening() {
            var x1 = listener;
            var x2 = listener.Server;

            if (x1 == null || x2 == null)
                return false;

            else return x2.IsBound;
        }


        public void Listen() {
            lock(this) {
                if (!IsAlreadyListening()) {
                    listener.Start(100);
                    AcceptClientsAsync(listener);
                }
            }
        }

        public void Close() {
            lock(this) {
                try {
                    if (IsAlreadyListening()) {
                        listener.Stop();
                    }
                }
                catch (Exception ex) {
                    log.Fatal("Close Exception", ex);
                }
            }
        }

        public void Dispose() {
            Close();
        }
    }
}
