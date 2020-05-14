using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archivationClass
{
    public interface IArchivation
    {
        void CompressFile(string sourceFile, string compressedFile);
        void DecompressFile(string compressedFile, string targetFile);
    }
}
