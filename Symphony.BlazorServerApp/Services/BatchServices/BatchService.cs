using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.BlazorServerApp.Services.BatchServices
{
    public class BatchService : IBatchService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly JsonSerializerOptions options;
        public BatchService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<BatchVM>> GetBatchesVMsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "batches/get-all-batches/");
            var client = httpClientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<BatchVM>>(responseStream, options);
            }
            else
            {
                return null;
            }
        }

        public async Task<BatchVM> GetBatchVMAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"batches/get-batch-by-id/{id}");
            var client = httpClientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var reponseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<BatchVM>(reponseStream, options);
            }
            else
            {
                return null;
            }
        }

        public async Task<int> CreateAsync(BatchCreateRequest request)
        {
            if (request is not null)
            {
                var client = httpClientFactory.CreateClient("symphony");
                var requestJson = new StringContent(
                    JsonSerializer.Serialize(request, options),
                    encoding: Encoding.UTF8,
                    "application/json"
                    );

                using var httpResponse = await client.PostAsync("batches/create-batch/", requestJson);

                httpResponse.EnsureSuccessStatusCode();

                if (httpResponse.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                    return 0;
            }
            return 0;
        }

        public async Task<int> UpdateAsync(BatchUpdateRequest request)
        {
            if (request is not null)
            {
                var client = httpClientFactory.CreateClient("symphony");
                var requestJson = new StringContent(
                    JsonSerializer.Serialize(request, options),
                    encoding: Encoding.UTF8,
                    "application/json"
                    );

                using var httpResponse = await client.PutAsync("batches/update-batch-details/", requestJson);

                httpResponse.EnsureSuccessStatusCode();

                if (httpResponse.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                    return 0;
            }
            return 0;
        }
    }
}
