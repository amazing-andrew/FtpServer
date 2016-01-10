using FtpServer.Core;
using FtpServer.Tests.TestDoubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FtpServer.Tests
{
    public class FtpSessionSpyTests
    {
        FtpSessionSpy session = new FtpSessionSpy();
            
        [Fact]
        public void Send_SetsServerResponce() {
            session.Send("Hello");
            Assert.Equal("Hello", session.ServerResponce);
        }

        public void Send_TwiceOverwritesResponce() {
            session.Send("1");
            session.Send("2");
            Assert.Equal("2", session.ServerResponce);
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
