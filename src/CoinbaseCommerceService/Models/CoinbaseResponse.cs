using Newtonsoft.Json;

namespace CoinbaseCommerceService.Models
{
    public class CoinbaseResponse<TResponse>
    {
        [JsonProperty(PropertyName = "data")]
        public TResponse Data { get; set; }
        
        [JsonProperty(PropertyName = "warnings")]
        public string[] Warnings { get; set; }

        public bool HasWarnings => Warnings is {Length: > 0};
    }
}