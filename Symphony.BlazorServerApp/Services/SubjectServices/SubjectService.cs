using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Symphony.BlazorServerApp.Services.SubjectServices
{
    public class SubjectService : ISubjectService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly JsonSerializerOptions options;

        public SubjectService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public Task<IEnumerable<SubjectVM>> GetSubjectVMsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SubjectVM> GetSubjectVMAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreateSubjectVMAsync(SubjectCreateRequest createRequest)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSubjectVMAsync(SubjectUpdateRequest subjectVM)
        {
            throw new NotImplementedException();
        }

        public Task ChangeSubjectState(int id)
        {
            throw new NotImplementedException();
        }
    }
}
