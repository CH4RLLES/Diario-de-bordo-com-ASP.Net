using DiarioDeBordo.Aplicacao.Models;
using DiarioDeBordo.Aplicacao.Models.Api;
using DiarioDeBordo.Dominio;
using DiarioDeBordo.Dominio.Models;
using System.Threading.Tasks;

namespace DiarioDeBordo.Aplicacao.Controllers.Api
{
    public sealed class TokenApiClient : ApiClient, ITokenApiClient
    {
        public TokenApiClient()
            : base(Globais.CaminhoWebApi + "Token", "")
        {

        }

        public async Task<BaseApiResult<RetornaToken>> BuscaToken()
        {
            return await GetAsync<RetornaToken>("BuscaToken?nome=DiarioBordo&token=9EE8BE1D3E3A46BA934C96B0DCFE2F4B0CDA13A4ABD046BC829B6A19E31E5261");
        }
    }
}
