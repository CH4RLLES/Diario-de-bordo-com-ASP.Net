using DiarioDeBordo.Aplicacao.Models.Api;
using DiarioDeBordo.Dominio;
using System.Threading.Tasks;

namespace DiarioDeBordo.Aplicacao.Controllers.Api
{
    public interface ITokenApiClient : IApiClient
    {
        Task<BaseApiResult<RetornaToken>> BuscaToken();
    }
}
