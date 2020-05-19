using archivationClass;
using myEncryption;
using System.IO;

namespace lab3
{
    class EncryptionAdapter : IAdditionalProcess
    {
        IEncryption Encoder;

        public EncryptionAdapter(IEncryption encoder)
        {
            Encoder = encoder;
        }

        public void OnSave(string sourceFileName, string encryptedFileName)
        {
            FileStream sourceStream = new FileStream(sourceFileName, FileMode.OpenOrCreate);
            key = Encoder.OnSaving(sourceStream, encryptedFileName);
        }

        byte key = 3;
        public void OnLoad(string encryptedFileName, string targetFileName)
        {
            using (FileStream sourceStream = new FileStream(encryptedFileName, FileMode.OpenOrCreate))
            {
                var data = Encoder.OnLoading(sourceStream, key);
                using (FileStream targetStream = File.Create(targetFileName))
                {
                    targetStream.Write(data, 0, data.Length);
                }
            }
        }
    }
}