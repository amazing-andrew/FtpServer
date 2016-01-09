using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core.Logging
{
    public class LogManager
    {
        private Func<string, Log> factory;

        public LogManager(Func<string, Log> factory) {
            if (factory == null) throw new ArgumentNullException("factory");
            this.factory = factory;
        }


        public Log GetLog(string name) {
            return factory(name);
        }

        public Log GetLogFor(Type type) {
            return GetLog(type.FullName);
        }

        public Log GetLogFor<T>() {
            return GetLogFor(typeof(T));
        }
        
    }
}
