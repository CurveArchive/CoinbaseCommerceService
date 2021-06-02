using System;
using System.Security.Cryptography;
using System.Text;
using CoinbaseCommerceService.Domain.Exceptions;

namespace CoinbaseCommerceService.Helpers
{
    public class CoinbaseHelpers
    {
        private static readonly ASCIIEncoding AsciiEncoding = new();

        public static void EnsureSignatureIsValid(string payload, string signature, string secretKey)
        {
            if (string.IsNullOrWhiteSpace(payload))
                throw new ArgumentNullException(payload);

            if (string.IsNullOrWhiteSpace(signature))
                throw new ArgumentNullException(signature);

            if (string.IsNullOrWhiteSpace(secretKey))
                throw new ArgumentNullException(secretKey);
            
            var computedSignature = HmacSha256Digest(payload, secretKey);

            if (computedSignature != signature)
                throw new CoinbaseSignatureMismatchException();
        }

        private static string HmacSha256Digest(string message, string secret)
        {
            using var hmacSha256 = new HMACSHA256(AsciiEncoding.GetBytes(secret));

            var bytes = hmacSha256.ComputeHash(AsciiEncoding.GetBytes(message));
            return BitConverter.ToString(bytes).Replace("-", string.Empty);
        }
    }
}