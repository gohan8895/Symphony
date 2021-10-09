using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Symphony.BlazorServerApp.Services.EventServices
{
    public class EventService : IEventService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly JsonSerializerOptions options;
        public EventService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task CreateEventAsync(CreateEventVM item)
        {

            if (item is not null)
            {
                var client = clientFactory.CreateClient("symphony");
                var newJson = new StringContent(
                    JsonSerializer.Serialize(item, options),
                    encoding: Encoding.UTF8,
                    "application/json"
                    );

                using var httpResponse = await client.PostAsync("events/", newJson);

                httpResponse.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteEventAsync(int id)
        {

            if (id != 0)
            {
                var client = clientFactory.CreateClient("symphony");
                using var httpResponse = await client.DeleteAsync("events/" + $"{id}");

                httpResponse.EnsureSuccessStatusCode();
            }
        }

        public async Task<EventVM> GetEventAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"events/{id}");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var reponseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<EventVM>(reponseStream, options);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<EventVM>> GetEventsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "events/");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var reponseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<EventVM>>(reponseStream, options);
            }
            else
            {
                return null;
            }
        }

        public async Task UpdateEventAsync(UpdateEventVM item)
        {
            if (item is not null)
            {
                var client = clientFactory.CreateClient("symphony");
                var newJson = new StringContent(
                    JsonSerializer.Serialize(item, options),
                    encoding: Encoding.UTF8,
                    "application/json"
                    );

                using var httpResponse = await client.PutAsync("events/", newJson);

                httpResponse.EnsureSuccessStatusCode();
            }
        }
    }
}
