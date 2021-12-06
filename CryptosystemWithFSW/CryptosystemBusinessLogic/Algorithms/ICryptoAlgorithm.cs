namespace CryptosystemBusinessLogic.Algorithms
{
    public interface ICryptoAlgorithm
    {
        string Encrypt(string sourceFileName, string plainText);
        string Decrypt(string sourceFileName, string cipherText);
    }
}
