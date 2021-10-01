using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Symphony.BlazorServerApp.Services.CourseRegistrationService
{
    public class CourseRegistrationService : ICourseRegistrationService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly JsonSerializerOptions options;

        public CourseRegistrationService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<CourseRegistrationVM>> GetAllCourseRegistrationVMsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "courseregistrations/");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<CourseRegistrationVM>>(responseStream, options);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<CourseRegistrationWithDataVM>> GetCourseRegistrationWithDataVMsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "courseregistrations/get-course-registration-with-data");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<CourseRegistrationWithDataVM>>(responseStream, options);
            }
            else
            {
                return null;
            }
        }

        public async Task<CourseRegistrationVM> GetCourseRegistrationVMAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"courseregistrations/{id}");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<CourseRegistrationVM>(responseStream, options);
            }
            else
            {
                return null;
            }
        }

        public async Task CreateCourseRegistrationAsync(CreateCourseRegistrationVM courseRegistration)
        {
            if (courseRegistration is not null)
            {
                var client = clientFactory.CreateClient("symphony");
                var courseJson = new StringContent(
                    JsonSerializer.Serialize(courseRegistration, options),
                    encoding: Encoding.UTF8,
                    "application/json"
                    );

                using var httpResponse = await client.PostAsync("courseregistrations", courseJson);

                httpResponse.EnsureSuccessStatusCode();
            }
        }

        public async Task UpdateCourseRegistrationAsync(UpdateCourseRegistrationVM courseRegistration)
        {
            if (courseRegistration is not null)
            {
                var client = clientFactory.CreateClient("symphony");
                var courseRegistrationJson = new StringContent(
                    JsonSerializer.Serialize(courseRegistration, options),
                    encoding: Encoding.UTF8,
                    "application/json"
                    );

                using var httpResponse = await client.PutAsync("courseregistrations/", courseRegistrationJson);

                httpResponse.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteCourseRegistrationAsync(int id)
        {
            if (id != 0)
            {
                var client = clientFactory.CreateClient("symphony");
                using var httpResponse = await client.DeleteAsync("courseregistrations/" + $"{id}");

                httpResponse.EnsureSuccessStatusCode();
            }
        }
    }
}
