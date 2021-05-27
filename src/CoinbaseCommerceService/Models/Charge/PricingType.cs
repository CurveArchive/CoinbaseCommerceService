using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinbaseCommerceService.Models.Charge
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PricingType
    {
        [EnumMember(Value = "no_price")]
        NoPrice,
        [EnumMember(Value = "fixed_price")]
        FixedPrice
    }
}