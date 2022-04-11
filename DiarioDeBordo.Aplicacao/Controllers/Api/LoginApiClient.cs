using DiarioDeBordo.Aplicacao.Models;
using DiarioDeBordo.Aplicacao.Models.Api;
using DiarioDeBordo.Dominio.Models;
using DiarioDeBordo.Dominio.Models.Colaborador;
using System.Threading.Tasks;

namespace DiarioDeBordo.Aplicacao.Controllers.Api
{
    public sealed class LoginApiClient : ApiClient, ILoginApiClient
    {
        public LoginApiClient(string token)
            : base(Globais.CaminhoWebApi + "Login", token)
        {

        }

        public async Task<BaseApiResult<LoginDTO>> EfetuarLogin(LoginDTO dados)
        {
            return await PostAsync<LoginDTO>("EfetuarLogin", dados);
        }

        public async Task<BaseApiResult<ColaboradorDTO>> BuscaColaborador(string id)
        {
            return await GetAsync<ColaboradorDTO>("BuscaColaborador?id=" + id);
        }
    }
}
