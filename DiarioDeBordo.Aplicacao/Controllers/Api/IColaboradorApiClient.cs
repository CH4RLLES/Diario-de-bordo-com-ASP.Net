using DiarioDeBordo.Aplicacao.Models.Api;
using DiarioDeBordo.Dominio.Models.Colaborador;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiarioDeBordo.Aplicacao.Controllers.Api
{
    public interface IColaboradorApiClient : IApiClient
    {
        Task<BaseApiResult<List<UnidadeDTO>>> ListarUnidades();
        Task<BaseApiResult<List<string>>> PesquisaNome(string nome);
        Task<BaseApiResult<ColaboradorDTO>> BuscaColaboradorNome(string nome);
    }
}
