using EncryptionWithVectors.TypesEncryption;
using System.Text;

namespace EncryptionWithVectors
{
    public class Program
    {
        private static string _keyPeth = "key.txt";
        private static string _textPth = "text.txt";
        private static string _cipherTextPth = "cipherText.txt";

        private static IEncryptor? encrypt;
        private static Encoding _encoding = Encoding.UTF8;

        static void Main(string[] args)
        {
            Wrapper.InitializeDirectory(_keyPeth, _textPth, _cipherTextPth);

            string key = Wrapper.GetStringInFile(_keyPeth, _encoding);
            string text = Wrapper.GetStringInFile(_textPth, _encoding);

            

            encrypt = new ViginereCipher();

            string cipherText = encrypt.Decrypt(text, key);
            
            Console.WriteLine($"key: {key}");
            Console.WriteLine($"text: {text}");
            Console.WriteLine($"cipherText: {cipherText}");

            Wrapper.WriteStringInFile(_cipherTextPth, cipherText);

            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}