using System;
using System.Collections;
using System.Linq;
using System.Text;

using CryptosystemExtensionMethods;

namespace CryptosystemBusinessLogic.Algorithms.DES
{
    public class DESWithCFBMode : DES
    {
        #region Field(s)
        private readonly int ivLength;
        #endregion Field(s)

        #region Constructor(s)
        public DESWithCFBMode() : base()
        {
            this.ivLength = 64;
        }
        #endregion Constructor(s)

        #region Method(s)
        public override byte[] Encrypt(string sourceFileName, byte[] bytesOfPlainText, Encoding encoding)
        {
            BitArray bitsOfPlainText = this.GetBitsOfData(bytesOfPlainText);

            byte[] initializationVector = this.GenerateInitializationVector(sourceFileName.GetLettersOnly(),
                encoding);
            byte[] encryptionResult = base.Encrypt(sourceFileName, initializationVector, encoding);

            BitArray blockOfPlainText = bitsOfPlainText.Extract(0, this.blockSizeInBits);
            BitArray bitsOfCipherText = this.GetBitsOfData(encryptionResult).Xor(blockOfPlainText);

            var bytesOfCipherText = new byte[bitsOfPlainText.Count / 8];
            Array.Copy(bitsOfCipherText.ConvertToByteArray(), 0, bytesOfCipherText, 0, 8);

            for (int i = this.blockSizeInBits; i < bitsOfPlainText.Count; i += this.blockSizeInBits)
            {
                encryptionResult = base.Encrypt(sourceFileName, bitsOfCipherText.ConvertToByteArray(),
                    encoding);

                blockOfPlainText = bitsOfPlainText.Extract(i, this.blockSizeInBits);
                bitsOfCipherText = this.GetBitsOfData(encryptionResult).Xor(blockOfPlainText);

                Array.Copy(bitsOfCipherText.ConvertToByteArray(), 0, bytesOfCipherText, i / 8, 8);
            }

            return bytesOfCipherText;
        }

        public override string Decrypt(string sourceFileName, byte[] bytesOfCipherText, Encoding encoding)
        {
            BitArray bitsOfCipherText = this.GetBitsOfData(bytesOfCipherText);

            byte[] initializationVector = this.GenerateInitializationVector(sourceFileName.GetLettersOnly(),
                encoding);
            byte[] encryptionResult = base.Encrypt(sourceFileName, initializationVector, encoding);

            BitArray blockOfCipherText = bitsOfCipherText.Extract(0, this.blockSizeInBits);
            BitArray bitsOfPlainText = this.GetBitsOfData(encryptionResult).Xor(blockOfCipherText);

            var bytesOfPlainText = new byte[bitsOfCipherText.Count / 8];
            Array.Copy(bitsOfPlainText.ConvertToByteArray(), 0, bytesOfPlainText, 0, 8);

            for (int i = this.blockSizeInBits; i < bitsOfCipherText.Count; i += this.blockSizeInBits)
            {
                encryptionResult = base.Encrypt(sourceFileName, blockOfCipherText.ConvertToByteArray(),
                    encoding);

                blockOfCipherText = bitsOfCipherText.Extract(i, this.blockSizeInBits);
                bitsOfPlainText = this.GetBitsOfData(encryptionResult).Xor(blockOfCipherText);

                Array.Copy(bitsOfPlainText.ConvertToByteArray(), 0, bytesOfPlainText, i / 8, 8);
            }

            return encoding.GetString(bytesOfPlainText);
        }
        #endregion Method(s)

        #region Helper Method(s)
        private byte[] GenerateInitializationVector(string inputString, Encoding encoding)
        {
            var initializationVector = new BitArray(encoding.GetBytes(inputString).Reverse().ToArray());

            if (initializationVector.Count < this.ivLength)
            {
                initializationVector = initializationVector.Expand(this.ivLength, false);
            }
            else if (initializationVector.Count > this.ivLength)
            {
                initializationVector = initializationVector.Reduce(this.ivLength);
            }

            return initializationVector.ConvertToByteArray();
        }
        #endregion Helper Method(s)
    }
}
