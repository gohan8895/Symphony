using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text;
using Symphony.ViewModels.VMs;

namespace Symphony.BlazorServerApp.Services.NewService
{
    public class NewService : INewService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly JsonSerializerOptions options;

        public NewService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task CreateAsync(CreateNewsVM news)
        {
            if (news is not null)
            {
                var client = clientFactory.CreateClient("symphony");
                var newJson = new StringContent(
                    JsonSerializer.Serialize(news, options),
                    encoding: Encoding.UTF8,
                    "application/json"
                    );

                using var httpResponse = await client.PostAsync("news/", newJson);

                httpResponse.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteAsync(int id)
        {
            if (id != 0)
            {
                var client = clientFactory.CreateClient("symphony");
                using var httpResponse = await client.DeleteAsync("news/" + $"{id}");

                httpResponse.EnsureSuccessStatusCode();
            }
        }

        public async Task<NewsVM> GetNewAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"news/{id}");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var reponseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<NewsVM>(reponseStream, options);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<NewsVM>> GetNewsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "news/");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var reponseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<NewsVM>>(reponseStream, options);
            }
            else
            {
                return null;
            }
        }

        public async Task UpdateAsync(UpdateNewsVM news)
        {
            if (news is not null)
            {
                var client = clientFactory.CreateClient("symphony");
                var newJson = new StringContent(
                    JsonSerializer.Serialize(news, options),
                    encoding: Encoding.UTF8,
                    "application/json"
                    );

                using var httpResponse = await client.PutAsync("news/", newJson);

                httpResponse.EnsureSuccessStatusCode();
            }
        }
    }
}
