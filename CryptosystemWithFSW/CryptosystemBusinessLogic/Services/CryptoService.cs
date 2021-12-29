using System.IO;
using System.Text;

using CryptosystemBusinessLogic.Algorithms;

namespace CryptosystemBusinessLogic.Services
{
    public static class CryptoService
    {
        #region Field(s)
        private static ICryptoAlgorithm cryptoAlgorithm;

        private static Encoding encoding;
        #endregion Field(s)

        #region Constructor(s)
        static CryptoService()
        {
            CryptoService.encoding = new UTF8Encoding();
        }
        #endregion Constructor(s)

        #region Method(s)
        public static void SetCryptoAlgorithm(ICryptoAlgorithm cryptoAlgorithm) =>
            CryptoService.cryptoAlgorithm = cryptoAlgorithm;

        public static void SetEncoding(Encoding encoding) => CryptoService.encoding = encoding;

        public static void EncryptFile(string sourceFilePath, string destinationFolderPath)
        {
            string sourceFileName = Path.GetFileNameWithoutExtension(sourceFilePath);
            byte[] bytesOfPlainText = File.ReadAllBytes(sourceFilePath);

            byte[] bytesOfCipherText = CryptoService.cryptoAlgorithm.Encrypt(
                sourceFileName, bytesOfPlainText, CryptoService.encoding);

            using var binaryWriter = new BinaryWriter(File.Open(destinationFolderPath + "\\" +
                sourceFileName + " - Encrypted.dat", FileMode.Create));
            binaryWriter.Write(bytesOfCipherText);
        }

        public static void DecryptFile(string sourceFilePath, string destinationFolderPath)
        {
            string sourceFileName = Path.GetFileNameWithoutExtension(sourceFilePath)
                .Replace(" - Encrypted", string.Empty);
            byte[] bytesOfCipherText = File.ReadAllBytes(sourceFilePath);

            string plainText = CryptoService.cryptoAlgorithm.Decrypt(
                sourceFileName, bytesOfCipherText, CryptoService.encoding);

            using var streamWriter = new StreamWriter(destinationFolderPath + "\\" +
                sourceFileName + " - Decrypted.txt");
            streamWriter.Write(plainText);
        }
        #endregion Method(s)
    }
}
