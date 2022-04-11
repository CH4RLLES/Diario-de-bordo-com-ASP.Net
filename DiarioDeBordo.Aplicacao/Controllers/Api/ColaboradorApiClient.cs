using DiarioDeBordo.Aplicacao.Models;
using DiarioDeBordo.Aplicacao.Models.Api;
using DiarioDeBordo.Dominio.Models;
using DiarioDeBordo.Dominio.Models.Colaborador;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiarioDeBordo.Aplicacao.Controllers.Api
{
    public sealed class ColaboradorApiClient : ApiClient, IColaboradorApiClient
    {
        public ColaboradorApiClient(string token)
            : base(Globais.CaminhoWebApi + "Colaborador", token)
        {

        }

        public async Task<BaseApiResult<List<UnidadeDTO>>> ListarUnidades()
        {
            return await GetAsync<List<UnidadeDTO>>("ListarUnidades");
        }

        public async Task<BaseApiResult<List<string>>> PesquisaNome(string nome)
        {
            return await GetAsync<List<string>>("PesquisaNome?nome=" + nome);
        }

        public async Task<BaseApiResult<ColaboradorDTO>> BuscaColaboradorNome(string nome)
        {
            return await GetAsync<ColaboradorDTO>("BuscaColaboradorNome?nome=" + nome);
        }
    }
}
