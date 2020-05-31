using System;

namespace Codenation.Challenge
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        public string Crypt(string message)
        {

            ValidateContainsInvalidCaractersorNull(message);

            String encryptMessage = EncryptAndDecryptMessage(message, 3);

            return encryptMessage;
        }

        public string Decrypt(string cryptedMessage)
        {
            ValidateContainsInvalidCaractersorNull(cryptedMessage);

            String decryptMessage = EncryptAndDecryptMessage(cryptedMessage, -3);

            return decryptMessage;
        }


        public string ValidateContainsInvalidCaractersorNull(string message)
        {

            if (message == null)
            {
                throw new ArgumentNullException();

            }
            else
            {
                foreach (var c in message)
                {
                    if (((int)c >= 33 && (int)c <= 47) || ((int)c >= 58 && (int)c <= 64) || ((int)c >= 91 && (int)c <= 96) || ((int)c >= 123 && (int)c <= 254))
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
            }

           

            return message;
        }

        public string EncryptAndDecryptMessage(string message, int key)
        {
            String msg = message.ToLower();
            String outputMessage = "";

            foreach(var c in msg)
            {
                if((int)c >= 97 && (int)c <= 122)
                {
                    if(key == 3)
                    {
                        int asc = (int)c + 3;

                        if(asc > 122)
                        {
                            int cod = asc % 123;
                            int position = cod + 97;
                            outputMessage += (char)position;
                        }
                        else
                        {
                            outputMessage += (char)asc;
                        }
                    }
                    else if(key == -3)
                    {
                         int asc = (int)c - 3;

                         if (asc < 97)
                         {
                             int cod = 97 % asc;
                             int position = 123 - cod;
                             outputMessage += (char)position;
                         }
                         else
                         {
                             outputMessage += (char)asc;
                         }
                    }
                }
                else
                {
                    outputMessage += c;
                }  
            }
            return outputMessage;
        }
    }
}
