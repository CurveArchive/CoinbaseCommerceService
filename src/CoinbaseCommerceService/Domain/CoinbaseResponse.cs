using Newtonsoft.Json;

namespace CoinbaseCommerceService.Domain
{
    public class CoinbaseResponse<TResponse>
    {
        [JsonProperty(PropertyName = "data")]
        public TResponse Data { get; set; }
        
        [JsonProperty(PropertyName = "warnings")]
        public string[] Warnings { get; set; }
        
        [JsonProperty(PropertyName = "error")]
        public Error Error { get; set; }

        public bool HasError => Error != null;
        public bool HasAnyWarnings => Warnings is {Length: > 0};
    }

    public class Error
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}