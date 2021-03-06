using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

namespace Symphony.BlazorServerApp.Services.SubjectServices
{
    public class SubjectService : ISubjectService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly JsonSerializerOptions options;
        private readonly ILogger logger;

        public SubjectService(IHttpClientFactory clientFactory, ILogger<SubjectService> logger)
        {
            this.clientFactory = clientFactory;
            this.logger = logger;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<SubjectVM>> GetSubjectVMsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "subjects/get-all-subjects");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var reponseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<SubjectVM>>(reponseStream, options);
            }
            else
            {
                logger.LogInformation(response.ReasonPhrase);
                return null;
            }
        }

        public async Task<SubjectVM> GetSubjectVMAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"subjects/{id}");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var reponseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<SubjectVM>(reponseStream, options);
            }
            else
            {
                logger.LogInformation(response.ReasonPhrase);
                return null;
            }
        }

        public async Task CreateSubjectVMAsync(SubjectCreateRequest createRequest)
        {
            if (createRequest is not null)
            {
                try
                {
                    var client = clientFactory.CreateClient("symphony");
                    var createRequestJson = new StringContent(
                        JsonSerializer.Serialize(createRequest, options),
                        encoding: Encoding.UTF8,
                        "application/json"
                        );

                    using var httpResponse = await client.PostAsync("subjects/", createRequestJson);

                    httpResponse.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    logger.LogInformation(ex.Message);
                }
            }
            else
            {
                logger.LogInformation("Create request is null");
            }
        }

        public async Task UpdateSubjectVMAsync(SubjectUpdateRequest updateRequest)
        {
            if (updateRequest is not null)
            {
                try
                {
                    var client = clientFactory.CreateClient("symphony");
                    var updateRequestJson = new StringContent(
                        JsonSerializer.Serialize(updateRequest, options),
                        encoding: Encoding.UTF8,
                        "application/json"
                        );

                    using var httpResponse = await client.PutAsync("subjects/update-subject-details", updateRequestJson);

                    httpResponse.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    logger.LogInformation(ex.Message);
                }
            }
            else
            {
                logger.LogInformation("Create request is null");
            }
        }

        public async Task<int> UpdateSubjectImagesVMAsync(int id, MultipartFormDataContent content)
        {
            if (content is not null)
            {
                try
                {
                    var client = clientFactory.CreateClient("symphony");

                    using var httpResponse = await client.PutAsync($"subjects/update-subject-images/{id}", content);

                    httpResponse.EnsureSuccessStatusCode();

                    return 1;
                }
                catch (Exception ex)
                {
                    logger.LogInformation(ex.Message);
                    return 0;
                }
            }

            logger.LogInformation("Create request is null");
            return 0;
        }

        public async Task<int> UpdateSubjectFilesVMAsync(int id, MultipartFormDataContent content)
        {
            if (content is not null)
            {
                var client = clientFactory.CreateClient("symphony");

                using var httpResponse = await client.PutAsync($"subjects/update-subject-files/{id}", content);

                httpResponse.EnsureSuccessStatusCode();

                return 1;

            }

            logger.LogInformation("Create request is null");
            return 0;
        }

        public async Task ChangeSubjectState(int id)
        {
            if (id != 0)
            {
                try
                {
                    var client = clientFactory.CreateClient("symphony");
                    var updateRequestJson = new StringContent(
                        JsonSerializer.Serialize(id, options),
                        encoding: Encoding.UTF8,
                        "application/json"
                        );

                    using var httpResponse = await client.PutAsync($"subjects/update-subject-state/{id}", updateRequestJson);

                    httpResponse.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    logger.LogInformation(ex.Message);
                }
            }
            else
            {
                logger.LogInformation("The id is invalid!");
            }
        }
    }
}
