using System;

namespace CoinbaseCommerceService.Domain.Exceptions
{
    public class CoinbaseSignatureMismatchException : InvalidOperationException
    {
        public CoinbaseSignatureMismatchException() : base("Payload does not match with the webhook signature.") { }
    }
}