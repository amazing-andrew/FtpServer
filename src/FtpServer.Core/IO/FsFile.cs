using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core.IO
{
    public interface FsFile
    {
        bool Exists { get; }
        long Size { get; }
    }
}
