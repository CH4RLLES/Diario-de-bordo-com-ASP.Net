using DiarioDeBordo.Aplicacao.Models.Api;
using DiarioDeBordo.Dominio.Models;
using DiarioDeBordo.Dominio.Models.Colaborador;
using System.Threading.Tasks;

namespace DiarioDeBordo.Aplicacao.Controllers.Api
{
    public interface ILoginApiClient : IApiClient
    {
        Task<BaseApiResult<LoginDTO>> EfetuarLogin(LoginDTO dados);
        Task<BaseApiResult<ColaboradorDTO>> BuscaColaborador(string id);
    }
}
