using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core.TestTypes
{
    public class FtpSessionSpy : FtpSession
    {
        Dictionary<string, string> data = new Dictionary<string, string>();

        public string MessageSent { get; private set; }


        public void Send(string message) {
            this.MessageSent = message;
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
    }
}
