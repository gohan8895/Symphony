using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Symphony.ViewModels.VMs;

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
            var request = new HttpRequestMessage(HttpMethod.Get, "paymentstatus/get-all-paymentstatus");
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

        public async Task<PaymentStatusWithData> GetPaymentStatusAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"paymentstatus/{id}");
            var client = clientFactory.CreateClient("symphony");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var reponseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<PaymentStatusWithData>(reponseStream, options);
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
                using var httpResponse = await client.DeleteAsync("paymentstatus/" + $"{id}");

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