using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Symphony.BlazorServerApp.Services.EnrollmentServices
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly JsonSerializerOptions options;

        public EnrollmentService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<EnrollmentVM> GetEnrollmentVMAsync(Guid studentId, int courseId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"courseregistrations/student/{studentId}/course/{courseId}");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<EnrollmentVM>(responseStream, options);
            }
            else
            {
                return null;
            }
        }

        public async Task<int> ChangeEnrollmentStatus(Guid studentId, int courseId)
        {
            if (studentId == Guid.Empty || courseId == 0)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"update-enrollment-state/student/{studentId}/course/{courseId}");
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

        public async Task<IEnumerable<EnrollmentWithData>> GetEnrollmentWithDataVM()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "enrollments/get-enrollments-with-user-and-course");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<EnrollmentWithData>>(responseStream, options);
            }
            else
            {
                return null;
            }
        }


        public async Task<int> UpdateEnrollment(UpdateEnrollmentVM enrollmentVM)
        {
            if (enrollmentVM is not null)
            {
                var client = clientFactory.CreateClient("symphony");
                var enrollmentJson = new StringContent(
                    JsonSerializer.Serialize(enrollmentVM, options),
                    encoding: Encoding.UTF8,
                    "application/json"
                    );

                using var httpResponse = await client.PutAsync("courseregistrations/", enrollmentJson);

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
