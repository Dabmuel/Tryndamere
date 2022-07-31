using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Tryndamere.Back.Crypt
{
    class Crypter
    {
        private RSACryptoServiceProvider rsa;

        public Crypter(String profile)
        {
            rsa = new RSACryptoServiceProvider();
        }
    }
}
