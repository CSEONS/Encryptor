namespace EncryptionWithVectors
{
    public interface IEncryptor
    {
        string Encrypt(string text, string keyWord);
        string Decrypt(string text, string keyWord);
    }
}