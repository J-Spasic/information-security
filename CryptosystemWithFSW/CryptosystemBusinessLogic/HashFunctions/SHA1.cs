using System.Numerics;
using System.Text;

namespace CryptosystemBusinessLogic.HashFunctions
{
    public class SHA1 : ICryptoHashFunction
    {
        #region Field(s)
        private readonly uint[] intermediateHash;

        private readonly int noBytesInChunk;
        private readonly int noRounds;

        private readonly int noBytesInMD;
        #endregion Field(s)

        #region Constructor(s)
        public SHA1()
        {
            this.intermediateHash = new uint[5];

            this.noBytesInChunk = 64;
            this.noRounds = 80;

            this.noBytesInMD = 20;
        }
        #endregion Constructor(s)

        #region Method(s)
        public byte[] ComputeHash(byte[] message)
        {
            this.ResetIntermediateHash();

            int noBytesInExtendedMessage = this.GetNoBytesForExtendedMessage(message.Length);

            var extendedMessage = new byte[noBytesInExtendedMessage];
            SHA1.DoPreprocessing(message, extendedMessage);

            this.ProcessTheMessage(extendedMessage, noBytesInExtendedMessage);

            var messageDigest = new byte[this.noBytesInMD];

            int currentFirstByte = 0;
            foreach (var hash in this.intermediateHash)
            {
                for (int i = currentFirstByte, offset = 24; i < (currentFirstByte + 4); i++, offset -= 8)
                {
                    messageDigest[i] = SHA1.ShiftRight(hash, offset);
                }

                currentFirstByte += 4;
            }

            return messageDigest;
        }

        public string GetHexValueOfHash(byte[] messageDigest)
        {
            var hexString = new StringBuilder(messageDigest.Length * 2);

            foreach (var byteValue in messageDigest)
            {
                hexString.AppendFormat("{0:x2}", byteValue);
            }

            return hexString.ToString();
        }

        public int GetNoBytesInMessageDigest() => this.noBytesInMD;
        #endregion Method(s)

        #region Helper Method(s)
        private void ResetIntermediateHash()
        {
            this.intermediateHash[0] = 0x67452301; this.intermediateHash[1] = 0xEFCDAB89;
            this.intermediateHash[2] = 0x98BADCFE; this.intermediateHash[3] = 0x10325476;
            this.intermediateHash[4] = 0xC3D2E1F0;
        }

        private int GetNoBytesForExtendedMessage(int noBytesInMessage)
        {
            int noBytesInExtendedMessage = noBytesInMessage + 9;

            while (noBytesInExtendedMessage % this.noBytesInChunk != 0)
            {
                noBytesInExtendedMessage++;
            }

            return noBytesInExtendedMessage;
        }

        private static void DoPreprocessing(byte[] message, byte[] extendedMessage)
        {
            for (int i = 0; i < message.Length; i++)
            {
                extendedMessage[i] = message[i];
            }

            extendedMessage[message.Length] = 0x80;

            for (int i = message.Length + 1; i < extendedMessage.Length - 8; i++)
            {
                extendedMessage[i] = 0;
            }

            long noBitsInMessage = message.Length * 8;
            for (int i = extendedMessage.Length - 8, offset = 56; i < extendedMessage.Length;
                i++, offset -= 8)
            {
                extendedMessage[i] = SHA1.ShiftRight(noBitsInMessage, offset);
            }
        }

        private static byte ShiftRight(long value, int offset) => (byte)((value >> offset) & 0xFF);

        private static byte ShiftRight(uint value, int offset) => (byte)((value >> offset) & 0xFF);

        private void ProcessTheMessage(byte[] extendedMessage, int noBytesInExtendedMessage)
        {
            for (int i = 0; i < noBytesInExtendedMessage; i += 64)
            {
                var chunk = new byte[this.noBytesInChunk];
                for (int j = 0; j < this.noBytesInChunk; j++)
                {
                    chunk[j] = extendedMessage[j + i];
                }

                var words = new int[this.noRounds];

                for (int j = 0; j < 16; j++)
                {
                    words[j] = extendedMessage[j * 4] << 24;
                    words[j] |= extendedMessage[j * 4 + 1] << 16;
                    words[j] |= extendedMessage[j * 4 + 2] << 8;
                    words[j] |= extendedMessage[j * 4 + 3];
                }

                for (int j = 16; j < this.noRounds; j++)
                {
                    words[j] = (int)BitOperations.RotateLeft(
                        (uint)(words[j - 3] ^ words[j - 8] ^ words[j - 14] ^ words[j - 16]), 1);
                }

                uint a = this.intermediateHash[0], b = this.intermediateHash[1],
                    c = this.intermediateHash[2], d = this.intermediateHash[3],
                    e = this.intermediateHash[4];

                for (int j = 0; j < this.noRounds; j++)
                {
                    uint f, k;

                    if (j < 20)
                    {
                        f = (b & c) | ((~b) & d); k = 0x5A827999;
                    }
                    else if (j >= 20 && j < 40)
                    {
                        f = b ^ c ^ d; k = 0x6ED9EBA1;
                    }
                    else if (j >= 40 && j < 60)
                    {
                        f = (b & c) | (b & d) | (c & d); k = 0x8F1BBCDC;
                    }
                    else
                    {
                        f = b ^ c ^ d; k = 0xCA62C1D6;
                    }

                    uint tempValue = BitOperations.RotateLeft(a, 5) + f + e + k + (uint)words[j];

                    e = d; d = c;
                    c = BitOperations.RotateLeft(b, 30);
                    b = a; a = tempValue;
                }

                this.intermediateHash[0] += a; this.intermediateHash[1] += b;
                this.intermediateHash[2] += c; this.intermediateHash[3] += d;
                this.intermediateHash[4] += e;
            }
        }
        #endregion Helper Method(s)
    }
}
