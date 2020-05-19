using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace myEncryption
{
    public class Encryption : IEncryption
    {
        public byte OnSaving(Stream sourceStream, string savePath)
        {
            byte key = 3;
            using (var targetStream = new FileStream(savePath, FileMode.OpenOrCreate))
            {
                byte[] data = new byte[sourceStream.Length];
                sourceStream.Read(data, 0, data.Length);
                data = data.Select(x => (byte)(x - key)).ToArray();
                targetStream.Write(data, 0, data.Length);
            }

            return key;
        }

        public byte[] OnLoading(Stream sourceStream, byte key)
        {
            var data = new byte[sourceStream.Length];
            sourceStream.Read(data, 0, data.Length);
            var decryptedData = data.Select(x => (byte)(x + key)).ToArray();
            
            return decryptedData;
        }
    }
}
