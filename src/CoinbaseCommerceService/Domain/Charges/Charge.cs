using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinbaseCommerceService.Domain.Charges
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
        
        [JsonProperty("confirmed_at")]
        public DateTimeOffset ConfirmedAt { get; set; }
        
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
    
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TimelineStatus
    {
        [EnumMember(Value = "NEW")]
        New,
        [EnumMember(Value = "PENDING")]
        Pending,
        [EnumMember(Value = "COMPLETED")]
        Completed,
        [EnumMember(Value = "EXPIRED")]
        Expired,
        [EnumMember(Value = "UNRESOLVED")]
        Unresolved,
        [EnumMember(Value = "RESOLVED")]
        Resolved,
        [EnumMember(Value = "CANCELED")]
        Canceled,
        [EnumMember(Value = "REFUND PENDING")]
        PendingRefund,
        [EnumMember(Value = "REFUNDED")]
        Refunded,
    }

    public class Timeline
    {
        [JsonProperty(PropertyName = "time")]
        public DateTimeOffset Time { get; set; }
        
        [JsonProperty(PropertyName = "status")]
        public TimelineStatus Status { get; set; }
        
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
        public Block Block { get; set; }
    }

    public class Block
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