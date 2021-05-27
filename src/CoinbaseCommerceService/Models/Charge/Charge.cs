using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinbaseCommerceService.Models.Charge
{
    public class Charge
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "addresses")]
        public Dictionary<string, string> Addresses { get; set; }
        
        [JsonProperty(PropertyName = "payments")]
        public List<Payment> Payments { get; set; }
        
        [JsonProperty(PropertyName = "timeline")]
        public List<Timeline> Timeline { get; set; }
        
        [JsonProperty(PropertyName = "support_email")]
        public string SupportEmailAddress { get; set; }
        
        [JsonProperty(PropertyName = "created_at")]
        public DateTimeOffset CreatedOn { get; set; }
        
        [JsonProperty(PropertyName = "expires_at")]
        public DateTimeOffset ExpiresOn { get; set; }
        
        [JsonProperty(PropertyName = "exchange_rates")]
        public Dictionary<string, string> ExchangeRates { get; set; }
        
        [JsonProperty(PropertyName = "hosted_url")]
        public string HostedUri { get; set; }

        public bool IsExpired => ExpiresOn < DateTimeOffset.UtcNow;

        public override string ToString()
        {
            return Name;
        }
    }

    public class Timeline
    {
        [JsonProperty(PropertyName = "time")]
        public DateTimeOffset Time { get; set; }
        
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        
        [JsonProperty(PropertyName = "context")]
        public string Context { get; set; }
    }

    public class Payment
    {
        [JsonProperty(PropertyName = "network")]
        public string Network { get; set; }
        
        [JsonProperty(PropertyName = "transaction_id")]
        public string TransactionId { get; set; }
        
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        
        [JsonProperty(PropertyName = "block")]
        public PaymentBlock Block { get; set; }
    }

    public class PaymentBlock
    {
        [JsonProperty(PropertyName = "height")]
        public ulong Height { get; set; }
        
        [JsonProperty(PropertyName = "hash")]
        public string Hash { get; set; }
        
        [JsonProperty(PropertyName = "confirmations_accumulated")]
        public int ConfirmationsAccumulated { get; set; }
        
        [JsonProperty(PropertyName = "confirmations_required")]
        public int ConfirmationsRequired { get; set; }
    }
}