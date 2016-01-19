using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer.Core.IO
{
    public class SystemFsFile : FsFile
    {
        string path;
        System.IO.FileInfo fileInfo;

        public SystemFsFile(string filePath) {
            this.path = filePath;
            this.fileInfo = new System.IO.FileInfo(this.path);
        }
        public bool Exists {
            get {
                return fileInfo.Exists;
            }
        }

        public long Size {
            get {
                return fileInfo.Length;
            }
        }
    }
}
