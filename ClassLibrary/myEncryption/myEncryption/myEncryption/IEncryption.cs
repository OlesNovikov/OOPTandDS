using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myEncryption
{
    public interface IEncryption
    {
        byte[] OnLoading(Stream sourceStream, byte key);
        byte OnSaving(Stream sourceStream, string savePath);
    }
}
