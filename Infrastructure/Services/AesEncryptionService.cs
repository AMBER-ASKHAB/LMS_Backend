using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    internal class AesEncryptionService : IEncryptionService
    {
        private readonly byte[] _aesKey;
        private readonly byte[] _hmacKey;

        public AesEncryptionService(IConfiguration config)
        {
            _aesKey = Convert.FromBase64String(config["Security:AesKey"]!);
            _hmacKey = Convert.FromBase64String(config["Security:HmacKey"]!);
        }

        public byte[] ComputeHash(string plainText)
        {
            using var hmac = new HMACSHA256(_hmacKey);
            return hmac.ComputeHash(Encoding.UTF8.GetBytes(plainText.Trim().ToLowerInvariant()));
        }
        public byte[] Encrypt(string plainText)
        {
            using var aes = Aes.Create();
            aes.Key = _aesKey;
            aes.GenerateIV();
            using var encryptor = aes.CreateEncryptor();
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            var cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            return aes.IV.Concat(cipherBytes).ToArray(); // prepend IV so Decrypt can read it back
        }
        public string Decrypt(byte[] cipherBytes)
        {
            using var aes = Aes.Create();
            aes.Key = _aesKey;
            var iv = cipherBytes.Take(16).ToArray();
            var actualCipher = cipherBytes.Skip(16).ToArray();
            aes.IV = iv;
            using var decryptor = aes.CreateDecryptor();
            var plainBytes = decryptor.TransformFinalBlock(actualCipher, 0, actualCipher.Length);
            return Encoding.UTF8.GetString(plainBytes);
        }

    }
}
