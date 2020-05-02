using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BTCPayServer.Client.Utils;
using Newtonsoft.Json;

namespace BTCPayServer.Client.Legacy
{
    /// <summary>
    /// Legacy client for BTCPay Server
    /// </summary>
    public class BTCPayServerClientLegacy
    {
        private readonly Uri _serverUrl;
        private readonly string _apiKey;
        private readonly HttpClient _httpClient = new HttpClient();


        /// <summary>
        /// Legacy client for BTCPay Server
        /// </summary>
        /// <param name="serverUrl">Your BTCPay Server url</param>
        /// <param name="apiKey">Generated legacy API key under 'Stores --> Settings --> Access Tokens'</param>
        public BTCPayServerClientLegacy(Uri serverUrl, string apiKey)
        {
            Validations.ValidateInput(serverUrl, nameof(serverUrl));

            _serverUrl = serverUrl;
            _apiKey = apiKey ?? string.Empty;

            _httpClient.BaseAddress = serverUrl;

            PrepareHttpClient();
        }

        /// <summary>
        /// Create a new invoice for specified price and currency.
        /// Get invoice id in return. 
        /// </summary>
        /// <param name="invoiceRequest">A new invoice data</param>
        /// <returns>The newly created invoice</returns>
        public async Task<InvoiceResponseLegacy> CreateInvoice(InvoiceRequestLegacy invoiceRequest)
        {
            Validations.ValidateInput(invoiceRequest, nameof(invoiceRequest));

            var url = $"/invoices";
            var invoiceSerialized = JsonConvert.SerializeObject(invoiceRequest, JsonUtils.Settings);


            var requestContent = new StringContent(invoiceSerialized, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await _httpClient.PostAsync(url, requestContent))
            using (HttpContent content = response.Content)
            {
                var result = await content.ReadAsStringAsync();
                var parsed = JsonConvert.DeserializeObject<ResponseLegacy<InvoiceResponseLegacy>>(result);
                return parsed.Data;
            }
        }

        /// <summary>
        /// Get an invoice by specified id
        /// </summary>
        /// <param name="invoiceId">Existing invoice id</param>
        /// <param name="token">Existing invoice token</param>
        /// <returns>Existing invoice data</returns>
        public async Task<InvoiceResponseLegacy> GetInvoice(string invoiceId, string token)
        {
            Validations.ValidateInput(invoiceId, nameof(invoiceId));

            var url = $"/invoices/{invoiceId}?token={token}";

            using (HttpResponseMessage response = await _httpClient.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                var result = await content.ReadAsStringAsync();
                var parsed = JsonConvert.DeserializeObject<ResponseLegacy<InvoiceResponseLegacy>>(result);
                return parsed.Data;
            }
        }



        private void PrepareHttpClient()
        {
            if (!string.IsNullOrWhiteSpace(_apiKey))
            {
                var apiKeyBase64 = Base64Encode(_apiKey);
                var authHeader = $"Basic {apiKeyBase64}";
                _httpClient.DefaultRequestHeaders.Add("Authorization", authHeader);
            }
        }

        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
