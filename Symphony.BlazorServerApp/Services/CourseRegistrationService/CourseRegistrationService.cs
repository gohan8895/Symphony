using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

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
            var request = new HttpRequestMessage(HttpMethod.Get, "courseregistrations/get-all-course-registration");
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
            var request = new HttpRequestMessage(HttpMethod.Get, "courseregistrations/get-all-course-registrations-with-data");
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

        public async Task<CourseRegistrationWithDataVM> GetCourseRegistrationVMAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"courseregistrations/get-course-registration-by-id/{id}");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<CourseRegistrationWithDataVM>(responseStream, options);
            }
            else
            {
                return null;
            }
        }

        public async Task<int> CreateAsync(CreateCourseRegistrationVM courseRegistration)
        {
            if (courseRegistration is not null)
            {
                var client = clientFactory.CreateClient("symphony");
                var courseJson = new StringContent(
                    JsonSerializer.Serialize(courseRegistration, options),
                    encoding: Encoding.UTF8,
                    "application/json"
                    );

                using var httpResponse = await client.PostAsync("courseregistrations/create-course-registration", courseJson);

                httpResponse.EnsureSuccessStatusCode();

                if (httpResponse.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }

        public async Task<int> UpdateAsync(int id)
        {
            if (id != 0)
            {
                var client = clientFactory.CreateClient("symphony");
                var courseRegistrationJson = new StringContent(
                    JsonSerializer.Serialize(id, options),
                    encoding: Encoding.UTF8,
                    "application/json"
                    );

                using var httpResponse = await client.PutAsync($"courseregistrations/approve-course-registration/{id}", courseRegistrationJson);

                httpResponse.EnsureSuccessStatusCode();

                if (httpResponse.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }

        public async Task<int> DeleteAsync(int id)
        {
            if (id != 0)
            {
                var client = clientFactory.CreateClient("symphony");
                using var httpResponse = await client.DeleteAsync($"courseregistrations/delete-course-registration/{id}");

                httpResponse.EnsureSuccessStatusCode();

                if (httpResponse.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
    }
}
