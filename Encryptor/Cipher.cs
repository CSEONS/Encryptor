namespace EncryptionWithVectors
{
    public class Cipher : IEncryptor
    {
        public virtual string Decrypt(string text, string keyWord)
        {
            throw new NotImplementedException();
        }

        public virtual string Encrypt(string text, string keyWord)
        {
            throw new NotImplementedException();
        }
    }
}
