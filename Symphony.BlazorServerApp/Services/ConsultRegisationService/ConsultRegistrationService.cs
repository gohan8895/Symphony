using Symphony.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.BlazorServerApp.Services.ConsultRegisationService
{
    public class ConsultRegistrationService : IConsultRegistrationService
    {
        private readonly IHttpClientFactory clientFactory;

        private readonly JsonSerializerOptions options;

        public ConsultRegistrationService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task DeleteConsultRegistration(int id)
        {
            if (id != 0)
            {
                var client = clientFactory.CreateClient("symphony");
                using var httpResponse = await client.DeleteAsync("ConsultRegistrations/" + $"{id}");

                httpResponse.EnsureSuccessStatusCode();
            }
        }

        public async Task<ConsultVM> GetConsultRegistration(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"ConsultRegistrations/{id}");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var reponseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<ConsultVM>(reponseStream, options);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<ConsultVM>> GetConsultRegistrations()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "ConsultRegistrations/");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var reponseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<ConsultVM>>(reponseStream, options);
            }
            else
            {
                return null;
            }
        }

        public async Task<int> PostConsultRegistration(ConsultCreateRequest registration)
        {
            if (registration is not null)
            {
                var client = clientFactory.CreateClient("symphony");
                var consultRegisJson = new StringContent(
                                    JsonSerializer.Serialize(registration, options),
                                    encoding: Encoding.UTF8,
                                    "application/json"
                                    );

                using var httpResponse = await client.PostAsync("ConsultRegistrations/", consultRegisJson);

                httpResponse.EnsureSuccessStatusCode();
                return 1;
            }
            return 0;
        }

        public async Task<int> PutConsultRegistration(int id)
        {
            if (id != 0)
            {
                var request = new HttpRequestMessage(HttpMethod.Put, $"ConsultRegistrations/{id}");
                var client = clientFactory.CreateClient("symphony");
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}