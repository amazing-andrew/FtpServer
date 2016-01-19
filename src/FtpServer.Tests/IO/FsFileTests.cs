using FtpServer.Core.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace FtpServer.Tests.IO
{
    public class FsFileTests : TestBase
    {
        public FsFileTests(ITestOutputHelper output) : base(output) {
        }

        [Fact]
        public void Exists_ExistingFile_ReturnsTrue() {
            FsFile file = GetFile("exists.txt");
            Assert.True(file.Exists);
        }

        [Fact]
        public void Exists_MissingFile_ReturnsFalse() {
            FsFile file = GetFile("not-exists.txt");
            Assert.False(file.Exists);
        }

        [Fact]
        public void Size_ExistingFile_ReturnsSize() {
            FsFile file = GetFile("exists.txt");
            var size = file.Size;
           
            Assert.NotEqual(0, size);
            Assert.Equal(39, size);
        }

        [Fact]
        public void Size_MissingFile_ThrowsException() {
            Assert.Throws<FileNotFoundException>(() => {
                FsFile file = GetFile("missing.txt");
                long size = file.Size;
            });
        }

        [Fact]
        private FsFile GetFile(string filePath) {
            string fullPath = Path.Combine(".\\IO\\TestDir", filePath);
            return new SystemFsFile(fullPath);
        }
    }
}
