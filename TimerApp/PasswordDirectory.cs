using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TimerApp
{
    class PasswordDirectory
    {
        private byte[] plainText;
        byte[] entropy = new byte[20];
        public PasswordDirectory(string password)
        {
            plainText = Encoding.UTF8.GetBytes(password);
        }

        public byte[] EncyrptPassword()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(entropy);
            }
            return ProtectedData.Protect(plainText, entropy, DataProtectionScope.CurrentUser);
        }
        public byte[] GetPlainText
        {
            get { return plainText; }
            set { plainText = value; }
        }
    }
}
