using System.Text;

namespace CryptosystemBusinessLogic.Algorithms
{
    public interface ICryptoAlgorithm
    {
        byte[] Encrypt(string sourceFileName, byte[] bytesOfPlainText, Encoding encoding);
        string Decrypt(string sourceFileName, byte[] bytesOfCipherText, Encoding encoding);
    }
}
