using FtpServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Tests.TestDoubles
{
    public class FtpSessionSpy : FtpSession
    {
        Dictionary<string, string> data = new Dictionary<string, string>();

        // spy properties
        public string ServerResponce { get; private set; }
        public bool AuthenticateWasCalled { get; private set; }
        public string AuthenticateUserName { get; private set; }
        public string AuthenticatePassword { get; private set; }


        
        public void Send(string message) {
            this.ServerResponce = message;
        }

        public string GetData(string key) {
            if (data.ContainsKey(key))
                return data[key];
            return null;
        }

        public void SetData(string key, string value) {
            if (data.ContainsKey(key) && value == null)
                data.Remove(key);
            else
                data[key] = value;
        }

        public void Authenticate(string inputUser, string inputPass) {
            this.AuthenticateWasCalled = true;
            this.AuthenticateUserName = inputUser;
            this.AuthenticatePassword = inputPass;
        }
    }
}
