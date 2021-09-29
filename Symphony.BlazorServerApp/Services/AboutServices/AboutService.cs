using Symphony.ViewModels.AboutViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Symphony.BlazorServerApp.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly JsonSerializerOptions options;

        public AboutService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<AboutVM> GetAboutAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"abouts/{id}");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var reponseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<AboutVM>(reponseStream, options);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<AboutVM>> GetAboutsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "abouts/");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var reponseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<AboutVM>>(reponseStream, options);
            }
            else
            {
                return null;
            }
        }

        public async Task CreateAsync(CreateAboutVM about)
        {
            if (about is not null)
            {
                var client = clientFactory.CreateClient("bookApi");
                var aboutJson = new StringContent(
                    JsonSerializer.Serialize(about, options),
                    encoding: Encoding.UTF8,
                    "application/json"
                    );

                using var httpResponse = await client.PostAsync("abouts/", aboutJson);

                httpResponse.EnsureSuccessStatusCode();
            }
        }

        public async Task UpdateAsync(UpdateAboutVM about)
        {
            if (about is not null)
            {
                var client = clientFactory.CreateClient("bookApi");
                var aboutJson = new StringContent(
                    JsonSerializer.Serialize(about, options),
                    encoding: Encoding.UTF8,
                    "application/json"
                    );

                using var httpResponse = await client.PutAsync("abouts/", aboutJson);

                httpResponse.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteAsync(int id)
        {
            if (id != 0)
            {
                var client = clientFactory.CreateClient("bookApi");
                using var httpResponse = await client.DeleteAsync("abouts/" + $"{id}");

                httpResponse.EnsureSuccessStatusCode();
            }
        }
    }
}
