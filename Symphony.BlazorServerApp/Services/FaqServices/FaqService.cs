using Microsoft.AspNetCore.Components;
using Symphony.BlazorServerApp.Services.FaqServices;
using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Symphony.BlazorServerApp.Services.FaqServices
{
    public class FaqService : IFaqService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly JsonSerializerOptions options;
        public FaqService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task CreateFaqAsync(CreateFAQVM faq)
        {
            if (faq is not null)
            {
                var client = clientFactory.CreateClient("symphony");
                var faqJson = new StringContent(
                    JsonSerializer.Serialize(faq, options),
                    encoding: Encoding.UTF8,
                    "application/json"
                    );

                using var httpResponse = await client.PostAsync("faqs/", faqJson);

                httpResponse.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteFaqAsync(int id)
        {
            if (id != 0)
            {
                var client = clientFactory.CreateClient("symphony");
                using var httpResponse = await client.DeleteAsync("faqs/" + $"{id}");

                httpResponse.EnsureSuccessStatusCode();
            }
        }

        public async Task<FAQVM> GetFaqAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"faqs/{id}");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var reponseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<FAQVM>(reponseStream, options);
            }
            else
            {
                return null;
            }

        }

        public async Task<IEnumerable<FAQVM>> GetFaqsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "faqs/");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var reponseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<FAQVM>>(reponseStream, options);
            }
            else
            {
                return null;
            }

        }

        public async Task UpdateFaqAsync(UpdateFAQVM faq)
        {
            if (faq is not null)
            {
                var client = clientFactory.CreateClient("symphony");
                var faqJson = new StringContent(
                    JsonSerializer.Serialize(faq, options),
                    encoding: Encoding.UTF8,
                    "application/json"
                    );

                using var httpResponse = await client.PutAsync("faqs/", faqJson);

                httpResponse.EnsureSuccessStatusCode();
            }
        }
    }
}