using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CoinbaseCommerceService.Models.Charge
{
    public class CreateCharge
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        
        [JsonProperty(PropertyName = "metadata")]
        public JObject Metadata { get; set; }
        
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; set; }
        
        [JsonProperty(PropertyName = "local_price")]
        public LocalPrice LocalPrice { get; set; }
        
        [JsonProperty(PropertyName = "pricing_type")]
        public PricingType PricingType { get; set; }
    }
}