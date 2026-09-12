using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEncryptionService
    {
        byte[] ComputeHash(string plainText);     // deterministic HMAC — for EmailHash/MobileHash
        byte[] Encrypt(string plainText);         // AES — for EmailCipher/MobileCipher
        string Decrypt(byte[] cipherBytes);
    }
}
