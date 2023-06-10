using HttpExternalServices.Exceptions;
using HttpExternalServices.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace HttpExternalServices.Services
{
    public class HttpServices : IHttpServices
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public async Task<T> GetRequest<T>(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new HttpServicesException();

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(json);
                if (result == null)
                    throw new HttpServicesException("The deserialized result is null.");
                return result;
            }
            catch (Exception ex)
            {
                throw new HttpServicesException(ex.Message);
            }
        }
        public async Task<TOut> PostRequest<TIn, TOut>(TIn content, string url, string token = "")
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var jsonRequest = JsonConvert.SerializeObject(content);
                var body = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, body);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new HttpServicesException();

                var jsonresponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TOut>(jsonresponse);
                if (result == null)
                    throw new HttpServicesException("The deserialized result is null.");
                return result;
            }
            catch (Exception ex)
            {
                throw new HttpServicesException(ex.Message);
            }
        }
    }
}
