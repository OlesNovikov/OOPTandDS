using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace archivationClass
{
    public interface IAdditionalProcess
    {
        void OnSave(string sourceFile, string compressedFile);
        void OnLoad(string compressedFile, string targetFile);
    }
}
