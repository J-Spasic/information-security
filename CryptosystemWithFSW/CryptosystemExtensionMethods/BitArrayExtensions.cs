using System.Collections;

namespace CryptosystemExtensionMethods
{
    public static class BitArrayExtensions
    {
        #region Method(s)
        /// <summary>
        /// Gets expanded bit array with given expansion value.
        /// </summary>
        /// <param name="bitArray">Bit array used to create expanded bit array.</param>
        /// <param name="noBits">Number of bits in expanded bit array.</param>
        /// <param name="expansionValue">Value used to expand bit array.</param>
        /// <returns>Expanded bit array.</returns>
        public static BitArray Expand(this BitArray bitArray, int noBits, bool expansionValue)
        {
            var expandedBitArray = new BitArray(noBits);

            for (int i = 0; i < bitArray.Count; i++)
            {
                expandedBitArray[i] = bitArray[i];
            }

            for (int i = bitArray.Count; i < noBits; i++)
            {
                expandedBitArray[i] = expansionValue;
            }

            return expandedBitArray;
        }

        /// <summary>
        /// Gets reduced bit array.
        /// </summary>
        /// <param name="bitArray">Bit array used to create reduced bit array.</param>
        /// <param name="noBits">Number of bits in reduced bit array.</param>
        /// <returns>Reduced bit array.</returns>
        public static BitArray Reduce(this BitArray bitArray, int noBits)
        {
            var reducedBitArray = new BitArray(noBits);

            for (int i = 0; i < noBits; i++)
            {
                reducedBitArray[i] = bitArray[i];
            }

            return reducedBitArray;
        }

        /// <summary>
        /// Gets halves of a given bit array.
        /// </summary>
        /// <param name="bitArray">Bit array used to create halves.</param>
        /// <param name="leftHalf">Left half of a given bit array.</param>
        /// <param name="rightHalf">Right half of a given bit array.</param>
        public static void DivideInHalf(this BitArray bitArray, out BitArray leftHalf, out BitArray rightHalf)
        {
            int halfOfNoBits = bitArray.Count / 2;

            leftHalf = new BitArray(halfOfNoBits);
            rightHalf = new BitArray(halfOfNoBits);

            for (int i = 0; i < halfOfNoBits; i++)
            {
                leftHalf[i] = bitArray[i];
                rightHalf[i] = bitArray[i + halfOfNoBits];
            }
        }

        /// <summary>
        /// Gets rotated bit array for a given number of moves.
        /// </summary>
        /// <param name="bitArray">Bit array used for rotation.</param>
        /// <param name="noRotations">Number of rotations.</param>
        /// <returns>Bit array rotated to the left.</returns>
        public static BitArray LeftRotation(this BitArray bitArray, int noRotations)
        {
            for (int i = 0; i < noRotations; i++)
            {
                bool firstBit = bitArray[0];

                for (int j = 0; j < bitArray.Count - 1; j++)
                {
                    bitArray[j] = bitArray[j + 1];
                }

                bitArray[^1] = firstBit;
            }

            return bitArray;
        }

        /// <summary>
        /// Gets rotated bit array for a given number of moves.
        /// </summary>
        /// <param name="bitArray">Bit array used for rotation.</param>
        /// <param name="noRotations">Number of rotations.</param>
        /// <returns>Bit array rotated to the right.</returns>
        public static BitArray RightRotation(this BitArray bitArray, int noRotations)
        {
            for (int i = 0; i < noRotations; i++)
            {
                bool lastBit = bitArray[^1];

                for (int j = bitArray.Count - 1; j > 0; j--)
                {
                    bitArray[j] = bitArray[j - 1];
                }

                bitArray[0] = lastBit;
            }

            return bitArray;
        }

        /// <summary>
        /// Gets new bit array which contains both halves.
        /// </summary>
        /// <param name="leftHalf">Left half of a new bit array.</param>
        /// <param name="rightHalf">Right half of a new bit array.</param>
        /// <returns>New bit array with merged values.</returns>
        public static BitArray MergeHalves(this BitArray leftHalf, BitArray rightHalf)
        {
            var bytesOfData = new byte[leftHalf.Count / 4];

            leftHalf.CopyTo(bytesOfData, 0);
            rightHalf.CopyTo(bytesOfData, leftHalf.Count / 8);

            return new BitArray(bytesOfData);
        }

        /// <summary>
        /// Gets part of a given bit array starting from a given index.
        /// </summary>
        /// <param name="bitArray">Bit array used in the extraction process.</param>
        /// <param name="index">Index from which extraction begins.</param>
        /// <param name="noBits">Number of bits to be extracted.</param>
        /// <returns>Part of a given bit array.</returns>
        public static BitArray Extract(this BitArray bitArray, int index, int noBits)
        {
            var extractedBitArray = new BitArray(noBits);

            for (int i = 0; i < noBits; i++)
            {
                extractedBitArray[i] = bitArray[i + index];
            }

            return extractedBitArray;
        }

        /// <summary>
        /// Gets equivalent value as a byte array from a given bit array.
        /// </summary>
        /// <param name="bitArray">Bit array which needs to be converted to the byte array.</param>
        /// <returns>Bit array data represented as a byte array.</returns>
        public static byte[] ConvertToByteArray(this BitArray bitArray)
        {
            int noBitsInByte = 8;
            var bytesOfData = new byte[(bitArray.Count / noBitsInByte) +
                ((bitArray.Count % noBitsInByte == 0) ? 0 : 1)];

            for (int i = 0; i < bitArray.Count; i++)
            {
                int mask = ((bitArray[i]) ? 1 : 0) << (i % noBitsInByte);

                bytesOfData[i / noBitsInByte] |= (byte)mask;
            }

            return bytesOfData;
        }
        #endregion Method(s)
    }
}
