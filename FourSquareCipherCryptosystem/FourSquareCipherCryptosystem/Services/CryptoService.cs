using System.IO;

using CryptosystemExtensionMethods;

namespace FourSquareCipherCryptosystem.Services
{
    public static class CryptoService
    {
        #region Method(s)
        public static void EncryptFile(string sourceFilePath, string destinationFolderPath)
        {
            string sourceFileName = Path.GetFileNameWithoutExtension(sourceFilePath);
            string plainText = File.ReadAllText(sourceFilePath).GetLettersOnly();

            string cipherText = new FourSquareCipher().Encrypt(sourceFileName, plainText);

            using var streamWriter = new StreamWriter(destinationFolderPath + "\\" + sourceFileName +
                " - Encrypted.txt");
            streamWriter.Write(cipherText);
        }

        public static void DecryptFile(string sourceFilePath, string destinationFolderPath)
        {
            string sourceFileName = Path.GetFileNameWithoutExtension(sourceFilePath)
                .Replace(" - Encrypted", string.Empty);
            string cipherText = File.ReadAllText(sourceFilePath);

            string plainText = new FourSquareCipher().Decrypt(sourceFileName, cipherText);

            using var streamWriter = new StreamWriter(destinationFolderPath + "\\" + sourceFileName +
                " - Decrypted.txt");
            streamWriter.Write(plainText);
        }
        #endregion Method(s)
    }
}
