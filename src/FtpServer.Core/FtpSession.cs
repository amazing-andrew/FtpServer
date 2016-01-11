using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core
{
    public interface FtpSession
    {
        void SetData(string key, string value);
        string GetData(string key);


        void Send(string message);
        
        void Authenticate(string inputUser, string inputPass);
        void Quit();
    }
}
