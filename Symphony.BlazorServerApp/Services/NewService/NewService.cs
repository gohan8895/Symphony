using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

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

        public Task CreateAsync(CreateNewsVM news)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
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

        public Task UpdateAsync(UpdateNewsVM news)
        {
            throw new NotImplementedException();
        }
    }
}
