using System.Collections.Generic;
using System.Linq;
using System.Text;

using CryptosystemExtensionMethods;

namespace CryptosystemBusinessLogic.Algorithms
{
    public class FourSquareCipher : ICryptoAlgorithm
    {
        #region Field(s)
        private readonly int keyLength;
        private readonly string plainAlphabet;
        #endregion Field(s)

        #region Constructor(s)
        public FourSquareCipher()
        {
            this.keyLength = 25;
            this.plainAlphabet = "abcdefghiklmnopqrstuvwxyz";
        }
        #endregion Constructor(s)

        #region Method(s)
        public byte[] Encrypt(string sourceFileName, byte[] bytesOfPlainText, Encoding encoding)
        {
            List<char> firstKey = this.GenerateFirstKey(sourceFileName.GetLettersOnly());
            List<char> secondKey = this.GenerateSecondKey(firstKey);

            string plainText = FourSquareCipher.GetModifiedPlainText(
                encoding.GetString(bytesOfPlainText).GetLettersOnly());

            string cipherText = string.Empty;
            for (int i = 0; i < plainText.Length; i += 2)
            {
                int firstCharRowIndex = this.plainAlphabet.IndexOf(plainText[i]) % 5;
                int firstCharColumnIndex = this.plainAlphabet.IndexOf(plainText[i]) / 5;

                int secondCharRowIndex = this.plainAlphabet.IndexOf(plainText[i + 1]) % 5;
                int secondCharColumnIndex = this.plainAlphabet.IndexOf(plainText[i + 1]) / 5;

                cipherText += firstKey[5 * firstCharColumnIndex + secondCharRowIndex];
                cipherText += secondKey[5 * secondCharColumnIndex + firstCharRowIndex];
            }

            return encoding.GetBytes(cipherText);
        }

        public string Decrypt(string sourceFileName, byte[] bytesOfCipherText, Encoding encoding)
        {
            List<char> firstKey = this.GenerateFirstKey(sourceFileName.GetLettersOnly());
            List<char> secondKey = this.GenerateSecondKey(firstKey);

            string cipherText = encoding.GetString(bytesOfCipherText);

            string plainText = string.Empty;
            for (int i = 0; i < cipherText.Length; i += 2)
            {
                int firstCharRowIndex = firstKey.IndexOf(cipherText[i]) % 5;
                int firstCharColumnIndex = firstKey.IndexOf(cipherText[i]) / 5;

                int secondCharRowIndex = secondKey.IndexOf(cipherText[i + 1]) % 5;
                int secondCharColumnIndex = secondKey.IndexOf(cipherText[i + 1]) / 5;

                plainText += this.plainAlphabet[5 * firstCharColumnIndex + secondCharRowIndex];
                plainText += this.plainAlphabet[5 * secondCharColumnIndex + firstCharRowIndex];
            }

            return plainText;
        }
        #endregion Method(s)

        #region Helper Method(s)
        private List<char> GenerateFirstKey(string inputString)
        {
            var firstKey = new List<char>(this.keyLength);

            List<char> availableLetters = this.plainAlphabet.ToUpper().ToList();

            for (int i = 0; firstKey.Count < this.keyLength && i < inputString.Length; i++)
            {
                if (availableLetters.Contains(inputString[i]))
                {
                    firstKey.Add(char.ToUpper(inputString[i]));

                    availableLetters.Remove(inputString[i]);
                }
            }

            while (firstKey.Count != this.keyLength)
            {
                firstKey.Add(availableLetters[firstKey.Count % availableLetters.Count]);

                availableLetters.RemoveAt((firstKey.Count - 1) % availableLetters.Count);
            }

            return firstKey;
        }

        private List<char> GenerateSecondKey(List<char> firstKey)
        {
            var secondKey = new List<char>(this.keyLength);

            List<char> availableLetters = this.plainAlphabet.ToUpper().ToList();

            for (int i = this.keyLength - 1; i >= 0; i--)
            {
                secondKey.Add(availableLetters[(firstKey[i] - 'A') % availableLetters.Count]);

                availableLetters.RemoveAt((firstKey[i] - 'A') % availableLetters.Count);
            }

            return secondKey;
        }

        private static string GetModifiedPlainText(string plainText)
        {
            if (plainText.Length % 2 != 0)
            {
                plainText += "q";
            }

            return plainText.ToLower().Replace('j', 'i');
        }
        #endregion Helper Method(s)
    }
}
