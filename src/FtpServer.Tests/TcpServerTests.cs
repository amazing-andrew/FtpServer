using FtpServer.Core;
using FtpServer.Core.TestTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;
using Xunit.Abstractions;
using System.Threading;
using FtpServer.Tests.Helpers;

namespace FtpServer.Tests
{
    public class TcpServerTests : TestBase, IDisposable
    {
        const int TestPort = 9999;
        TcpServer server;
        
        public TcpServerTests(ITestOutputHelper output) : base(output) {
            server = new EchoTcpServer(TestPort, new TestLog(output));
            server.Listen();
        }

        [Fact]
        public void Listen_OpensThePort() {
            //listen is called in this ctor
            Assert.PortIsOpen(TestPort);
        }

        [Fact]
        public void Close_ClosesPort() {
            server.Close();
            Assert.PortIsNotOpen(TestPort); ;
        }

        [Fact]
        public void Dispose_ClosesPort() {
            server.Dispose();
            Assert.PortIsNotOpen(TestPort);
        }

        [Fact]
        public void WriteAndRead_DataToAndFromServer() {
            var client = make_ClientAndConnect();
            TestServerReadAndWrite(client);
        }


        [Fact]
        public void WriteAndRead_Multiple_DataToAndFromServer() {
            int numOfClients = 100;
            Parallel.For(0, numOfClients, i => {
            //for (int i = 0; i < 100; i++) { 
                Log.InfoFormat("Testing Client #{0}", i);
                var client = make_ClientAndConnect();
                TestServerReadAndWrite(client);
            }
            );
        }
        
        private static void TestServerReadAndWrite(TcpClient client) {
            using (var s = client.GetStream())
            using (var sw = new System.IO.StreamWriter(s))
            using (var sr = new System.IO.StreamReader(s)) {
                sw.AutoFlush = true;
                sw.WriteLine("Hello World!");

                string messageFromServer = sr.ReadLine();
                Assert.Equal("Hello World!", messageFromServer);
            }
        }

        public TcpClient make_ClientAndConnect() {
            TcpClient c = new TcpClient();
            c.Connect(IPAddress.Loopback, TestPort);
            return c;
        }

        public void Dispose() {
            try {
                server.Dispose();
                Thread.Sleep(100);
            }
            catch(Exception ex) {
                Log.Fatal("Dispose Exception", ex);
            }
            
        }
    }
}
