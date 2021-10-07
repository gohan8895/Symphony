using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Symphony.BlazorServerApp.Services.PaymentStatusServices
{
    public class PaymentStatusService : IPaymentStatusService
    {
        private readonly IHttpClientFactory clientFactory;

        private readonly JsonSerializerOptions options;

        public PaymentStatusService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
            options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<PaymentStatusVM>> GetAllPaymentStatusAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "PaymentStatuss/get-all-paymentstatus");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<PaymentStatusVM>>(responseStream, options);
            }
            else
            {
                return null;
            }
        }

        public async Task<PaymentStatusVM> GetPaymentStatusAsync(int courseRegistrationId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"PaymentStatuss/{courseRegistrationId}");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var reponseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<PaymentStatusVM>(reponseStream, options);
            }
            else
            {
                return null;
            }
        }

        public async Task<int> DeletePaymentStatusAsync(int id)
        {
            if (id != 0)
            {
                var client = clientFactory.CreateClient("symphony");
                using var httpResponse = await client.DeleteAsync("PaymentStatuss/" + $"{id}");

                httpResponse.EnsureSuccessStatusCode();
                return 1;
            }
            return 0;
        }
    }
}