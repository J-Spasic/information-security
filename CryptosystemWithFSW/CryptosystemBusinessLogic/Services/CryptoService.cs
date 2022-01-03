using System;
using System.IO;
using System.Linq;
using System.Text;

using CryptosystemBusinessLogic.Algorithms;
using CryptosystemBusinessLogic.HashFunctions;

namespace CryptosystemBusinessLogic.Services
{
    public static class CryptoService
    {
        #region Field(s)
        private static ICryptoAlgorithm cryptoAlgorithm;
        private static ICryptoHashFunction cryptoHashFunction;

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

        public static void SetCryptoHashFunction(ICryptoHashFunction cryptoHashFunction) =>
            CryptoService.cryptoHashFunction = cryptoHashFunction;

        public static void SetEncoding(Encoding encoding) => CryptoService.encoding = encoding;

        public static void EncryptFile(string sourceFilePath, string destinationFolderPath)
        {
            string sourceFileName = Path.GetFileNameWithoutExtension(sourceFilePath);
            byte[] bytesOfPlainText = File.ReadAllBytes(sourceFilePath);

            byte[] bytesOfCipherText = CryptoService.cryptoAlgorithm.Encrypt(
                sourceFileName, bytesOfPlainText, CryptoService.encoding);

            using var binaryWriter = new BinaryWriter(File.Open(destinationFolderPath + "\\" +
                sourceFileName + " - Encrypted.dat", FileMode.Create));

            if (CryptoService.cryptoAlgorithm is not FourSquareCipher)
            {
                byte[] messageDigest = CryptoService.cryptoHashFunction.ComputeHash(bytesOfPlainText);

                binaryWriter.Write(messageDigest);
                binaryWriter.Write("\n");
            }

            binaryWriter.Write(bytesOfCipherText);
        }

        public static bool DecryptFile(string sourceFilePath, string destinationFolderPath)
        {
            string sourceFileName = Path.GetFileNameWithoutExtension(sourceFilePath)
                .Replace(" - Encrypted", string.Empty);
            byte[] bytesOfData = File.ReadAllBytes(sourceFilePath);

            byte[] bytesOfCipherText = bytesOfData;
            bool returnValue = true;

            if (CryptoService.cryptoAlgorithm is not FourSquareCipher)
            {
                int noBytesInMD = CryptoService.cryptoHashFunction.GetNoBytesInMessageDigest();

                bytesOfCipherText = new byte[bytesOfData.Length - noBytesInMD - 2];
                Array.Copy(bytesOfData, noBytesInMD + 2, bytesOfCipherText, 0,
                    bytesOfData.Length - noBytesInMD - 2);
            }

            string plainText = CryptoService.cryptoAlgorithm.Decrypt(
                sourceFileName, bytesOfCipherText, CryptoService.encoding).Trim(new char[] { '\0' });

            using var streamWriter = new StreamWriter(destinationFolderPath + "\\" +
                sourceFileName + " - Decrypted.txt");
            streamWriter.Write(plainText);

            if (CryptoService.cryptoAlgorithm is not FourSquareCipher)
            {
                int noBytesInMD = CryptoService.cryptoHashFunction.GetNoBytesInMessageDigest();

                var messageDigest = new byte[noBytesInMD];
                Array.Copy(bytesOfData, 0, messageDigest, 0, noBytesInMD);

                byte[] computedMessageDigest = CryptoService.cryptoHashFunction.ComputeHash(
                    CryptoService.encoding.GetBytes(plainText));

                returnValue = messageDigest.SequenceEqual(computedMessageDigest);
            }

            return returnValue;
        }
        #endregion Method(s)
    }
}
