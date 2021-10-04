using Symphony.ViewModels.CourseViewModel;
using System;
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

        public async Task<IEnumerable<CourseWithSubjects>> GetCourseVMsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "courses/get-all-courses-with-subjects/");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var reponseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<CourseWithSubjects>>(reponseStream, options);
            }
            else
            {
                return null;
            }
        }

        public async Task<int> UpdateCourseStatusAsync(int id)
        {
            if (id != 0)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"courses/update-course-status/{id}");
                var client = clientFactory.CreateClient("symphony");
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
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

        public async Task<int> CreateAsync(CourseCreateRequest course)
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

                if (httpResponse.IsSuccessStatusCode)
                    return 1;
                else
                    return 0;
            }
            return 0;
        }

        public async Task<int> UpdateAsync(CourseUpdateRequest course)
        {
            if (course is not null)
            {
                try
                {
                    var client = clientFactory.CreateClient("symphony");
                    var courseJson = new StringContent(
                        JsonSerializer.Serialize(course, options),
                        encoding: Encoding.UTF8,
                        "application/json"
                        );

                    using var httpResponse = await client.PutAsync("courses/update-course-details", courseJson);

                    httpResponse.EnsureSuccessStatusCode();

                    if (httpResponse.IsSuccessStatusCode)
                        return 1;
                    else
                        return 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return 0;
        }

        public async Task<int> UpdateImageAsync(int id, MultipartFormDataContent content)
        {
            if (id != 0 && content is not null)
            {
                try
                {
                    var client = clientFactory.CreateClient("symphony");

                    using var httpResponse = await client.PutAsync($"courses/update-course-image/{id}", content);

                    httpResponse.EnsureSuccessStatusCode();

                    if (httpResponse.IsSuccessStatusCode)
                        return 1;
                    else
                        return 0;
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return 0;
        }

        public async Task<int> UpdateSubjectInCourseAsync(int id, List<int> request)
        {
            if (id != 0 && request is not null)
            {
                try
                {
                    var client = clientFactory.CreateClient("symphony");
                    var requestJson = new StringContent(
                        JsonSerializer.Serialize(request, options),
                        encoding: Encoding.UTF8,
                        "application/json"
                        );

                    using var httpResponse = await client.PutAsync($"courses/update-subjects-in-course/{id}", requestJson);

                    httpResponse.EnsureSuccessStatusCode();

                    if (httpResponse.IsSuccessStatusCode)
                        return 1;
                    else
                        return 0;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return 0;
        }
    }
}
