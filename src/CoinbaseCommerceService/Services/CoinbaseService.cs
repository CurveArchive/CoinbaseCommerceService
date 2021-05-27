using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoinbaseCommerceService.Helpers;
using CoinbaseCommerceService.Models;
using CoinbaseCommerceService.Models.Charge;

namespace CoinbaseCommerceService.Services
{
    public class CoinbaseService
    {
        private readonly HttpClient _httpClient;

        public CoinbaseService(string apiKey, string apiVersion = "2018-03-22")
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentNullException(apiKey);

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(CoinbaseCommon.BaseApi),
                DefaultRequestHeaders =
                {
                    {"X-CC-Api-Key", apiKey},
                    {"X-CC-Version", apiVersion},
                }
            };
        }

        public async Task<CoinbaseResponse<Charge>> CreateChargeAsync(CreateCharge createCharge)
        {
            var httpResponseMessage = await _httpClient.PostAsync("/charges", new JsonContent(createCharge));

            return await httpResponseMessage.Content.ReadAsJsonAsync<CoinbaseResponse<Charge>>();
        }

        public async Task<CoinbaseResponse<List<Charge>>> ReadChargesAsync()
        {
            var httpResponseMessage = await _httpClient.GetAsync($"/charges/");

            return await httpResponseMessage.Content.ReadAsJsonAsync<CoinbaseResponse<List<Charge>>>();
        }

        public async Task<CoinbaseResponse<Charge>> ReadChargeAsync(string chargeIdOrCode)
        {
            var httpResponseMessage = await _httpClient.GetAsync($"/charges/{chargeIdOrCode}");

            return await httpResponseMessage.Content.ReadAsJsonAsync<CoinbaseResponse<Charge>>();
        }

        public async Task<CoinbaseResponse<Charge>> CancelChargeAsync(string chargeIdOrCode)
        {
            var httpResponseMessage = await _httpClient.PostAsync($"/charges/{chargeIdOrCode}/cancel", new JsonContent(new {}));

            return await httpResponseMessage.Content.ReadAsJsonAsync<CoinbaseResponse<Charge>>();
        }

        public async Task<CoinbaseResponse<Charge>> ResolveChargeAsync(string chargeIdOrCode)
        {
            var httpResponseMessage = await _httpClient.PostAsync($"/charges/{chargeIdOrCode}/resolve", new JsonContent(new {}));

            return await httpResponseMessage.Content.ReadAsJsonAsync<CoinbaseResponse<Charge>>();
        }
    }
}