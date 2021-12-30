using System;
using System.Collections;
using System.Linq;
using System.Text;

using CryptosystemExtensionMethods;

namespace CryptosystemBusinessLogic.Algorithms.DES
{
    public class DES : ICryptoAlgorithm
    {
        #region Field(s)
        #region Initial and Final Permutation Table Field(s)
        private readonly int[] initialP =
        {
            58, 50, 42, 34, 26, 18, 10, 2, 60, 52, 44, 36, 28, 20, 12, 4,
            62, 54, 46, 38, 30, 22, 14, 6, 64, 56, 48, 40, 32, 24, 16, 8,
            57, 49, 41, 33, 25, 17, 9, 1, 59, 51, 43, 35, 27, 19, 11, 3,
            61, 53, 45, 37, 29, 21, 13, 5, 63, 55, 47, 39, 31, 23, 15, 7
        };

        private readonly int[] finalP =
        {
            40, 8, 48, 16, 56, 24, 64, 32, 39, 7, 47, 15, 55, 23, 63, 31,
            38, 6, 46, 14, 54, 22, 62, 30, 37, 5, 45, 13, 53, 21, 61, 29,
            36, 4, 44, 12, 52, 20, 60, 28, 35, 3, 43, 11, 51, 19, 59, 27,
            34, 2, 42, 10, 50, 18, 58, 26, 33, 1, 41, 9, 49, 17, 57, 25
        };
        #endregion Initial and Final Permutation Table Field(s)

        #region Expansion and Permutation Table Field(s)
        private readonly int[] expansion =
        {
            32, 1, 2, 3, 4, 5, 4, 5, 6, 7, 8, 9,
            8, 9, 10, 11, 12, 13, 12, 13, 14, 15, 16, 17,
            16, 17, 18, 19, 20, 21, 20, 21, 22, 23, 24, 25,
            24, 25, 26, 27, 28, 29, 28, 29, 30, 31, 32, 1
        };

        private readonly int[] permutation =
        {
            16, 7, 20, 21, 29, 12, 28, 17,
            1, 15, 23, 26, 5, 18, 31, 10,
            2, 8, 24, 14, 32, 27, 3, 9,
            19, 13, 30, 6, 22, 11, 4, 25
        };
        #endregion Expansion and Permutation Table Field(s)

        #region S-box Matrices Field(s)
        private readonly int[,,] sBox =
        {
            {
                { 14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7 },
                { 0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8 },
                { 4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0 },
                { 15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 }
            },
            {
                { 15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10 },
                { 3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5 },
                { 0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15 },
                { 13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 }
            },
            {
                { 10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8 },
                { 13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1 },
                { 13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7 },
                { 1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 }
            },
            {
                { 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15 },
                { 13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9 },
                { 10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4 },
                { 3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 }
            },
            {
                { 2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9 },
                { 14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6 },
                { 4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14 },
                { 11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3 }
            },
            {
                { 12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11 },
                { 10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8 },
                { 9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6 },
                { 4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 }
            },
            {
                { 4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1 },
                { 13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6 },
                { 1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2 },
                { 6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12 }
            },
            {
                { 13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7 },
                { 1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2 },
                { 7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8 },
                { 2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11 }
            }
        };
        #endregion S-box Matrices Field(s)

        #region Permuted Choice Table Field(s)
        private readonly int[] pc1 =
        {
            57, 49, 41, 33, 25, 17, 9, 1, 58, 50, 42, 34, 26, 18,
            10, 2, 59, 51, 43, 35, 27, 19, 11, 3, 60, 52, 44, 36,
            63, 55, 47, 39, 31, 23, 15, 7, 62, 54, 46, 38, 30, 22,
            14, 6, 61, 53, 45, 37, 29, 21, 13, 5, 28, 20, 12, 4
        };

        private readonly int[] pc2 =
        {
            14, 17, 11, 24, 1, 5, 3, 28, 15, 6, 21, 10,
            23, 19, 12, 4, 26, 8, 16, 7, 27, 20, 13, 2,
            41, 52, 31, 37, 47, 55, 30, 40, 51, 45, 33, 48,
            44, 49, 39, 56, 34, 53, 46, 42, 50, 36, 29, 32
        };
        #endregion Permuted Choice Table Field(s)

        private readonly int[] noShifts = { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };

        private readonly int keyLength;
        private readonly int subkeyLength;
        private readonly int noRounds;

        protected readonly int blockSizeInBits;
        #endregion Field(s)

        #region Constructor(s)
        public DES()
        {
            this.keyLength = 56;
            this.subkeyLength = 48;

            this.noRounds = 16;
            this.blockSizeInBits = 64;
        }
        #endregion Constructor(s)

        #region Method(s)
        public virtual byte[] Encrypt(string sourceFileName, byte[] bytesOfPlainText, Encoding encoding)
        {
            BitArray key = DES.GetExtractedKey(DES.Generate64BitKey(sourceFileName.GetLettersOnly(), encoding),
                this.keyLength, this.pc1);

            BitArray[] subkeys = this.GenerateSubkeys(key);

            BitArray bitsOfPlainText = this.GetBitsOfData(bytesOfPlainText);

            var bytesOfCipherText = new byte[bitsOfPlainText.Count / 8];
            for (int i = 0; i < bitsOfPlainText.Count; i += this.blockSizeInBits)
            {
                BitArray blockOfData = bitsOfPlainText.Extract(i, this.blockSizeInBits);

                DES.PermuteBlockOfData(ref blockOfData, this.initialP);
                this.GetThroughRounds(ref blockOfData, subkeys);
                DES.PermuteBlockOfData(ref blockOfData, this.finalP);

                Array.Copy(blockOfData.ConvertToByteArray(), 0, bytesOfCipherText, i / 8, 8);
            }

            return bytesOfCipherText;
        }

        public virtual string Decrypt(string sourceFileName, byte[] bytesOfCipherText, Encoding encoding)
        {
            BitArray key = DES.GetExtractedKey(DES.Generate64BitKey(sourceFileName.GetLettersOnly(), encoding),
                this.keyLength, this.pc1);

            BitArray[] subkeys = this.GenerateSubkeys(key).Reverse().ToArray();

            BitArray bitsOfCipherText = this.GetBitsOfData(bytesOfCipherText);

            var bytesOfPlainText = new byte[bitsOfCipherText.Count / 8];
            for (int i = 0; i < bitsOfCipherText.Count; i += this.blockSizeInBits)
            {
                BitArray blockOfData = bitsOfCipherText.Extract(i, this.blockSizeInBits);

                DES.PermuteBlockOfData(ref blockOfData, this.initialP);
                this.GetThroughRounds(ref blockOfData, subkeys);
                DES.PermuteBlockOfData(ref blockOfData, this.finalP);

                Array.Copy(blockOfData.ConvertToByteArray(), 0, bytesOfPlainText, i / 8, 8);
            }

            return encoding.GetString(bytesOfPlainText);
        }
        #endregion Method(s)

        #region Helper Method(s)
        private static BitArray Generate64BitKey(string inputString, Encoding encoding)
        {
            int keySize = 64;
            var key = new BitArray(encoding.GetBytes(inputString));

            if (key.Count < keySize)
            {
                key = key.Expand(keySize, false);
            }
            else if (key.Count > keySize)
            {
                key = key.Reduce(keySize);
            }

            return key;
        }

        private static BitArray GetExtractedKey(BitArray key, int extractedKeyLength, int[] pc)
        {
            var extractedKey = new BitArray(extractedKeyLength);

            for (int i = 0; i < extractedKeyLength; i++)
            {
                extractedKey[i] = key[pc[i] - 1];
            }

            return extractedKey;
        }

        private BitArray[] GenerateSubkeys(BitArray key)
        {
            var subkeys = new BitArray[this.noRounds];

            for (int i = 0; i < this.noRounds; i++)
            {
                key.DivideInHalf(out BitArray leftHalfOfKey, out BitArray rightHalfOfKey);

                key = leftHalfOfKey.LeftRotation(this.noShifts[i])
                    .MergeHalves(rightHalfOfKey.LeftRotation(this.noShifts[i]));

                subkeys[i] = DES.GetExtractedKey(key, this.subkeyLength, this.pc2);
            }

            return subkeys;
        }

        protected BitArray GetBitsOfData(byte[] data)
        {
            var bitsOfData = new BitArray(data);

            int remainder = bitsOfData.Count % this.blockSizeInBits;
            if (remainder != 0)
            {
                bitsOfData = bitsOfData.Expand(bitsOfData.Count + this.blockSizeInBits - remainder, false);
            }

            return bitsOfData;
        }

        private static void PermuteBlockOfData(ref BitArray blockOfData, int[] permutation)
        {
            var permutedBlockOfData = new BitArray(blockOfData.Count);

            for (int i = 0; i < blockOfData.Count; i++)
            {
                permutedBlockOfData[i] = blockOfData[permutation[i] - 1];
            }

            blockOfData = permutedBlockOfData;
        }

        private void GetThroughRounds(ref BitArray blockOfData, BitArray[] subkeys)
        {
            blockOfData.DivideInHalf(out BitArray leftHalfOfData, out BitArray rightHalfOfData);

            for (int i = 0; i < this.noRounds; i++)
            {
                BitArray transformedRightHalf = this.ExpandRightHalfOfData(rightHalfOfData)
                    .Xor(subkeys[i]);

                this.ApplySBoxTransformation(ref transformedRightHalf);
                DES.PermuteBlockOfData(ref transformedRightHalf, this.permutation);

                transformedRightHalf = transformedRightHalf.Xor(leftHalfOfData);

                leftHalfOfData = rightHalfOfData;
                rightHalfOfData = transformedRightHalf;
            }

            blockOfData = rightHalfOfData.MergeHalves(leftHalfOfData);
        }

        private BitArray ExpandRightHalfOfData(BitArray rightHalf)
        {
            var expandedRightHalf = new BitArray(this.subkeyLength);

            for (int i = 0; i < this.subkeyLength; i++)
            {
                expandedRightHalf[i] = rightHalf[this.expansion[i] - 1];
            }

            return expandedRightHalf;
        }

        private void ApplySBoxTransformation(ref BitArray transformedRightHalf)
        {
            var modifiedRightHalf = new BitArray(32);

            for (int i = 0; i < this.sBox.GetLength(0); i++)
            {
                var blockOf6Bits = new BitArray(6);
                for (int j = 0; j < blockOf6Bits.Length; j++)
                {
                    blockOf6Bits[j] = transformedRightHalf[j + i * blockOf6Bits.Length];
                }

                int rowIndex = 2 * Convert.ToInt32(blockOf6Bits[0]) + Convert.ToInt32(blockOf6Bits[5]);
                int columnIndex = 8 * Convert.ToInt32(blockOf6Bits[1]) + 4 * Convert.ToInt32(blockOf6Bits[2])
                    + 2 * Convert.ToInt32(blockOf6Bits[3]) + Convert.ToInt32(blockOf6Bits[4]);

                var newData = new BitArray(new byte[] { Convert.ToByte(this.sBox[i, rowIndex, columnIndex]) });
                for (int j = 0; j < 4; j++)
                {
                    modifiedRightHalf[j + i * 4] = newData[3 - j];
                }
            }

            transformedRightHalf = modifiedRightHalf;
        }
        #endregion Helper Method(s)
    }
}
