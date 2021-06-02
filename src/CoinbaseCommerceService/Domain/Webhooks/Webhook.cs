using System;
using System.Runtime.Serialization;
using CoinbaseCommerceService.Domain.Charges;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinbaseCommerceService.Domain.Webhooks
{
    public class Webhook
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        
        [JsonProperty(PropertyName = "scheduled_for")]
        public DateTimeOffset ScheduledFor { get; set; }
        
        [JsonProperty(PropertyName = "attempt_number")]
        public int Attempts { get; set; }
        
        [JsonProperty(PropertyName = "event")]
        public Event<Charge> Event { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum EventType
    {
        [EnumMember(Value = "charge:created")]
        Created,
        [EnumMember(Value = "charge:confirmed")]
        Confirmed,
        [EnumMember(Value = "charge:failed")]
        Failed,
        [EnumMember(Value = "charge:delayed")]
        Delayed,
        [EnumMember(Value = "charge:pending")]
        Pending
    }
    
    public class Event<TData>
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        
        [JsonProperty(PropertyName = "resource")]
        public string Resource { get; set; }
        
        [JsonProperty(PropertyName = "type")]
        public EventType Type { get; set; }
        
        [JsonProperty(PropertyName = "data")]
        public TData Charge { get; set; }
    }
}