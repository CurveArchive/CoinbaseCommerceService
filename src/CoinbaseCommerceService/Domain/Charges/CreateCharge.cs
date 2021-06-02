using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace CoinbaseCommerceService.Domain.Charges
{
    public class CreateCharge
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        
        [JsonProperty(PropertyName = "metadata")]
        public JObject Metadata { get; set; }
        
        [JsonProperty(PropertyName = "local_price")]
        public LocalPrice LocalPrice { get; set; }
        
        [JsonProperty(PropertyName = "pricing_type")]
        public PricingType PricingType { get; set; }
        
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; set; }
        
        [JsonProperty(PropertyName = "cancel_url")]
        public string CancelUrl { get; set; }
    }
    
    public class LocalPrice
    {
        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum PricingType
    {
        [EnumMember(Value = "no_price")]
        NoPrice,
        [EnumMember(Value = "fixed_price")]
        FixedPrice
    }
}