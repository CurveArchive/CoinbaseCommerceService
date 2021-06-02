using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoinbaseCommerceService.Domain
{
    public class CoinbasePagedResponse
    {
        [JsonProperty(PropertyName = "pagination")]
        public Pagination Pagination { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortBy
    {
        Desc,
        Asc
    }

    public class Pagination
    {
        [JsonProperty(PropertyName = "order")]
        public SortBy SortBy { get; set; }
        
        [JsonProperty(PropertyName = "starting_after")]
        public Guid? StartAfter { get; set; }
        
        [JsonProperty(PropertyName = "ending_before")]
        public Guid? EndBefore { get; set; }
        
        [JsonProperty(PropertyName = "total")]
        public uint Total { get; set; }
        
        [JsonProperty(PropertyName = "limit")]
        public uint Limit { get; set; }
        
        [JsonProperty(PropertyName = "yielded")]
        public uint Yielded { get; set; }
        
        [JsonProperty(PropertyName = "cursor_range")]
        public List<string> CursorRange { get; set; }
        
        [JsonProperty(PropertyName = "previous_uri")]
        public Uri PreviousUri { get; set; }
        
        [JsonProperty(PropertyName = "next_uri")]
        public Uri NextUri { get; set; }
    }
}