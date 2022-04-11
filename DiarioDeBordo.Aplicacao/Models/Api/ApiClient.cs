using DiarioDeBordo.Dominio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDeBordo.Aplicacao.Models.Api
{
    public class ApiClient : Controller, IApiClient
    {
        private HttpClient _restClient;
        private string _apiUrlBase;
        private readonly string _token;

        public ApiClient(string apiUrlBase, string token)
        {
            if (string.IsNullOrEmpty(apiUrlBase))
            {
                throw new ArgumentNullException("apiUrlBase", "Uma url base de API deve ser informada");
            }

            _token = token;
            _apiUrlBase = apiUrlBase;
        }

        public async Task<BaseApiResult<TModel>> GetAsync<TModel>(string apiRoute, Action<BaseApiResult<TModel>> callback = null)
        {
            try
            {
                var json = await GetAsync(apiRoute);
                var data = JsonConvert.DeserializeObject<TModel>(json, GetConverter());
                var result = new OkApiResult<TModel>(data);

                callback?.Invoke(result);

                return result;
            }
            catch (Exception ex)
            {
                return new InvalidApiResult<TModel>(ex);
            }
        }

        private async Task<string> GetAsync(string apiRoute)
        {
            var url = _apiUrlBase + "/" + apiRoute;

            _restClient = _restClient ?? new HttpClient();

            ClearReponseHeaders();
            AddReponseHeaders();

            var response = await _restClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var data = response.Content.ReadAsStringAsync().Result;

            return data;
        }

        
        public async Task<BaseApiResult<TModel>> PostAsync<TModel>(string apiRoute, object body = null, Action<BaseApiResult<TModel>> callback = null)
        {
            try
            {
                var json = await PostAsync(apiRoute, body);
                var data = JsonConvert.DeserializeObject<TModel>(json, GetConverter());
                var result = new OkApiResult<TModel>(data);

                callback?.Invoke(result);

                return result;
            }
            catch (Exception ex)
            {
                return new InvalidApiResult<TModel>(ex);
            }
        }

        public async Task<BaseApiResult<TModel>> PostResultAsync<TModel>(string apiRoute, object body = null, Action<BaseApiResult<TModel>> callback = null)
        {
            try
            {
                var data = await PostAsync(apiRoute, body);
                var result = JsonConvert.DeserializeObject<OkApiResult<TModel>>(data, GetConverter());

                callback?.Invoke(result);

                return result;
            }
            catch (Exception ex)
            {
                return new InvalidApiResult<TModel>(ex);
            }
        }

        private async Task<string> PostAsync(string apiRoute, object body)
        {
            var url = _apiUrlBase + "/" + apiRoute;

            _restClient = _restClient ?? new HttpClient();
            _restClient.BaseAddress = new Uri(url);

            ClearReponseHeaders();
            AddReponseHeaders();

            var bodySerialize = JsonConvert.SerializeObject(body);
            StringContent content = new StringContent(bodySerialize, Encoding.UTF8, "application/json");

            var response = await _restClient.PostAsync(_restClient.BaseAddress, content);
            response.EnsureSuccessStatusCode();
            var data = response.Content.ReadAsStringAsync().Result;

            return data;
        }


        private IsoDateTimeConverter GetConverter()
        {
            return new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" };
        }

        private void AddReponseHeaders()
        {
            if (_token != "")
                _restClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        }

        private void ClearReponseHeaders()
        {
            _restClient.DefaultRequestHeaders.Clear();
        }
    }
}
