namespace CryptosystemBusinessLogic.HashFunctions
{
    public interface ICryptoHashFunction
    {
        byte[] ComputeHash(byte[] message);
        string GetHexValueOfHash(byte[] messageDigest);
        int GetNoBytesInMessageDigest();
    }
}
