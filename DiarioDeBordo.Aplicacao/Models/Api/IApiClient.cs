using DiarioDeBordo.Aplicacao.Models.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDeBordo.Aplicacao.Models.Api
{
    public interface IApiClient
    {
        Task<BaseApiResult<TModel>> GetAsync<TModel>(string apiRoute, Action<BaseApiResult<TModel>> callback = null);
        Task<BaseApiResult<TModel>> PostAsync<TModel>(string apiRoute, object body = null, Action<BaseApiResult<TModel>> callback = null);
    }
}
