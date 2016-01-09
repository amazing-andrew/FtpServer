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
    public abstract class TcpServer2 : IDisposable
    {
        private const int listenerBackLog = 100; //back log of accepted socket connections.
        private EndPoint endpoint;
        private int port;
        private Socket serverSocket;
        private SocketAsyncEventArgs asyncAcceptArgs;
        private Log log;


        public TcpServer2(int port, LogManager log) {
            this.port = port;
            this.log = log.GetLogFor(GetType());
            this.endpoint = new IPEndPoint(IPAddress.Any, this.port);
        }
        

        private async void DispatchClientToHandler(Socket socket) {
            if (socket == null || socket.Connected == false)
                return;

            try {
                TcpClient tcp = new TcpClient();
                tcp.Client = socket;
                await HandleClient(tcp);

                tcp.Close();
                socket.Close();
                tcp = null;
                socket = null;
            }
            catch (Exception ex) {
                OnError("Handle Client", ex);
            }            
        }

        protected abstract Task HandleClient(TcpClient client);
        

        private bool IsAlreadyListening() {
            return serverSocket != null;
        }

        public void Listen() {
            lock(this) {
                if (!IsAlreadyListening()) {
                    CreateServerSocketAndListen();
                    StartAcceptSingleConnection();
                }
            }
        }


        private void StartAcceptSingleConnection() {
            CreateAsyncAcceptArgsIfNeeded();

            asyncAcceptArgs.AcceptSocket = null; //clear socket to reuse events

            bool willRaiseCompletedEvent = false;

            try {
                willRaiseCompletedEvent = serverSocket.AcceptAsync(asyncAcceptArgs);
            }
            catch (NullReferenceException) { return; }
            catch (ObjectDisposedException) { return; }
            
            if (!willRaiseCompletedEvent)
                ProcessAccept(asyncAcceptArgs);
        }
        

        private void ProcessAccept(SocketAsyncEventArgs args) {
            if (args.SocketError != SocketError.Success) {
                if (args.SocketError == SocketError.OperationAborted) {
                    //do nothing for these socket errors
                }
                else {
                    log.ErrorFormat("Socket Error: {0}", args.SocketError);
                    OnError("Socket Accept", new SocketException((int)args.SocketError));
                }
                return;
            }

            var socket = args.AcceptSocket;
            StartAcceptSingleConnection();
            
            DispatchClientToHandler(socket);
        }


        private void OnError(string msg, Exception ex) {
            log.Fatal(msg, ex);
        }
        
        #region Creating Socket Server

        private void CreateServerSocketAndListen() {
            serverSocket = new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(endpoint);
            serverSocket.Listen(listenerBackLog);
        }

        private void CreateAsyncAcceptArgsIfNeeded() {
            if (asyncAcceptArgs == null) {
                asyncAcceptArgs = new SocketAsyncEventArgs();
                asyncAcceptArgs.Completed += AsyncAcceptArgs_Completed;
            }
        }

        private void AsyncAcceptArgs_Completed(object sender, SocketAsyncEventArgs e) {
            ProcessAccept(e);
        }


        #endregion

        #region Closing and Disposal

        public void Close() {
            if (serverSocket == null)
                return;

            lock(this) {
                DestoryServerSocket();
                DestoryAsyncAcceptArgs();
            }
        }

        public void Dispose() {
            Close();
        }

        private void DestoryServerSocket() {
            if (serverSocket == null)
                return;

            try {
                serverSocket.Close();
            }
            catch (Exception ex) {
                OnError("Close", ex);
            }
            finally {
                serverSocket = null;
            }
        }
        
        private void DestoryAsyncAcceptArgs() {
            asyncAcceptArgs.Completed -= AsyncAcceptArgs_Completed;
            asyncAcceptArgs.Dispose();
            asyncAcceptArgs = null;
        }

        #endregion
    }
}
