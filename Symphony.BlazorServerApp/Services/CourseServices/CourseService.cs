using Symphony.ViewModels.CourseViewModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Symphony.BlazorServerApp.Services.CourseServices
{
    public class CourseService : ICourseService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly JsonSerializerOptions options;
        
        public CourseService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<CourseWithSubjects> GetCourseVMAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"courses/get-course-by-id/{id}");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var reponseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<CourseWithSubjects>(reponseStream, options);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<CourseVM>> GetCourseVMsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "courses/get-all-courses-with-subjects/");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var reponseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<CourseVM>>(reponseStream, options);
            }
            else
            {
                return null;
            }
        }

        public async Task CreateAsync(CourseCreateRequest course)
        {
            if (course is not null)
            {
                var client = clientFactory.CreateClient("symphony");
                var courseJson = new StringContent(
                    JsonSerializer.Serialize(course, options),
                    encoding: Encoding.UTF8,
                    "application/json"
                    );

                using var httpResponse = await client.PostAsync("courses/create-course-with-subjects", courseJson);

                httpResponse.EnsureSuccessStatusCode();
            }
        }

        public async Task UpdateAsync(CourseUpdateRequest course)
        {
            if (course is not null)
            {
                var client = clientFactory.CreateClient("symphony");
                var courseJson = new StringContent(
                    JsonSerializer.Serialize(course, options),
                    encoding: Encoding.UTF8,
                    "application/json"
                    );

                using var httpResponse = await client.PutAsync("courses/", courseJson);

                httpResponse.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteAsync(int id)
        {
            if (id != 0)
            {
                var client = clientFactory.CreateClient("symphony");
                using var httpResponse = await client.DeleteAsync("courses/" + $"{id}");

                httpResponse.EnsureSuccessStatusCode();
            }
        }
    }
}
