using System.Net.Http;
using System.Threading.Tasks;

namespace CoinbaseCommerceService.Helpers
{
    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content,
            JsonNamingStrategy namingStrategy = JsonNamingStrategy.Default)
        {
            var stringContent = await content.ReadAsStringAsync();
            return NewtonsoftJsonSerializer.Create(namingStrategy).Deserialize<T>(stringContent);
        }
    }
}