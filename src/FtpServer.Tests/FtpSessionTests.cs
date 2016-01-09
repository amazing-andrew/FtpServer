using FtpServer.Core;
using FtpServer.Core.TestTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FtpServer.Tests
{
    public class FtpSessionTests
    {
        FtpSessionSpy session = new FtpSessionSpy();
            
        [Fact]
        public void Send_SendsMessage() {
            session.Send("Hello");
            Assert.Equal("Hello", session.MessageSent);
        }

        [Fact]
        public void SetData_CanBeRetrieved() {

            session.SetData("test", "something");
            string results = session.GetData("test");

            Assert.Equal("something", results);
        }

        [Fact]
        public void SetData_Null_ReturnsNull() {
            session.SetData("T1", null);
            string results = session.GetData("T1");

            Assert.Null(results);
        }

        [Fact]
        public void SetData_OverwriteWithNull_ReturnsNull() {
            session.SetData("A", "previous value");
            session.SetData("A", null);

            string results = session.GetData("A");
            Assert.Null(results);
        }
    }
}
