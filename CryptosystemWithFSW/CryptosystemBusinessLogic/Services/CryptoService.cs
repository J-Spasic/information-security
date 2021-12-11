using System.IO;

using CryptosystemBusinessLogic.Algorithms;

using CryptosystemExtensionMethods;

namespace CryptosystemBusinessLogic.Services
{
    public static class CryptoService
    {
        #region Field(s)
        private static ICryptoAlgorithm cryptoAlgorithm;
        #endregion Field(s)

        #region Method(s)
        public static void SetCryptoAlgorithm(ICryptoAlgorithm cryptoAlgorithm) =>
            CryptoService.cryptoAlgorithm = cryptoAlgorithm;

        public static void EncryptFile(string sourceFilePath, string destinationFolderPath)
        {
            string sourceFileName = Path.GetFileNameWithoutExtension(sourceFilePath);
            string plainText = File.ReadAllText(sourceFilePath).GetLettersOnly();

            string cipherText = CryptoService.cryptoAlgorithm.Encrypt(sourceFileName, plainText);

            using var streamWriter = new StreamWriter(destinationFolderPath + "\\" + sourceFileName +
                " - Encrypted.txt");
            streamWriter.Write(cipherText);
        }

        public static void DecryptFile(string sourceFilePath, string destinationFolderPath)
        {
            string sourceFileName = Path.GetFileNameWithoutExtension(sourceFilePath)
                .Replace(" - Encrypted", string.Empty);
            string cipherText = File.ReadAllText(sourceFilePath);

            string plainText = CryptoService.cryptoAlgorithm.Decrypt(sourceFileName, cipherText);

            using var streamWriter = new StreamWriter(destinationFolderPath + "\\" + sourceFileName +
                " - Decrypted.txt");
            streamWriter.Write(plainText);
        }
        #endregion Method(s)
    }
}
