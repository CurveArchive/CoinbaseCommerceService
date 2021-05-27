using Newtonsoft.Json;

namespace CoinbaseCommerceService.Models.Charge
{
    public class LocalPrice
    {
        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
    }
}