using System.Text;

namespace EncryptionWithVectors.TypesEncryption
{
    public class ViginereCipher : Cipher
    {
        public override string Decrypt(string text, string keyWord)
        {
            string messageKey = TextToKeyForm(text, keyWord);
            string messageDecrypt = DecryptMessage(text, messageKey);

            return messageDecrypt;
        }

        public override string Encrypt(string text, string keyWord)
        {
            string messageKey = TextToKeyForm(text, keyWord);
            string messageEncrypt = EncryptMessage(text, messageKey);

            return messageEncrypt;
        }

        private string EncryptMessage(string text, string messageKey)
        {
            StringBuilder outputMessage = new StringBuilder(text.Length);

            for (int i = 0; i < text.Length; i++)
            {
                var messageSymbol = char.ToLower(text[i]);
                var messageKeySymbol = char.ToLower(messageKey[i]);

                if (Wrapper.Cyrillic.Contains(messageSymbol) is false)
                {
                    outputMessage.Append(text[i]);
                    continue;
                }

                int symbolSum = ((Wrapper.Cyrillic.IndexOf(messageSymbol) + Wrapper.Cyrillic.IndexOf(messageKeySymbol)) % Wrapper.Cyrillic.Length); 
                char symbol = Wrapper.Cyrillic[symbolSum];
                outputMessage.Append(symbol);
            }

            return outputMessage.ToString();
        }

        private string DecryptMessage(string text, string messageKey)
        {
            StringBuilder outputMessage = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                var messageSymbol = char.ToLower(text[i]);
                var messageKeySymbol = char.ToLower(messageKey[i]);

                if (Wrapper.Cyrillic.Contains(messageSymbol) is false)
                {
                    outputMessage.Append(text[i]);
                    continue;
                }

                int symbolSum = ((Wrapper.Cyrillic.IndexOf(messageSymbol) + Wrapper.Cyrillic.Length - Wrapper.Cyrillic.IndexOf(messageKeySymbol)) % Wrapper.Cyrillic.Length);
                char symbol = Wrapper.Cyrillic[symbolSum];
                outputMessage.Append(symbol);
            }

            return outputMessage.ToString();
        }

        private string TextToKeyForm(string text, string key)
        {
            StringBuilder outputText = new StringBuilder(text.Length);

            int keyCharCouner = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];

                if (Wrapper.Cyrillic.Contains(char.ToLower(symbol)))
                {
                    outputText.Append(key[keyCharCouner % key.Length]);
                    keyCharCouner++;
                }
                else
                {
                    outputText.Append(symbol);
                }
            }

            return outputText.ToString();
        }
    }
}
