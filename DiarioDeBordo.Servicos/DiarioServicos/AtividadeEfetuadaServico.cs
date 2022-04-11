using DiarioDeBordo.Dominio.Entidades;
using DiarioDeBordo.Dominio.Utils;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DiarioDeBordo.Servicos.DiarioServicos
{
    public class AtividadeEfetuadaServico : ServicoBase<AtividadeEfetuada>
    {
        public List<AtividadeEfetuada> ListarMinhasAtividades(DateTime dataInicio, DateTime dataFim, Guid? idColaborador = null, Guid? idAtividade = null, string superintendencia = "")
        {
            try
            {
                var dados = ListarInclude(a => a.DataAtividade >= dataInicio && a.DataAtividade <= dataFim && 
                (idColaborador != null ? a.UsuarioAtividade.IdColaborador == idColaborador : a.IdUsuario != null)
                , "AtividadeFeita,UsuarioAtividade").OrderByDescending(a => a.DataAtividade).ThenByDescending(a => a.DataHoraCadastro).ToList();

                if (!string.IsNullOrWhiteSpace(superintendencia))
                {
                    var usuarios = new UsuarioServico().Listar(a => a.Superintendencia == superintendencia).Select(a => a.Id).ToList();
                    dados = dados.Where(a => usuarios.Contains(a.IdUsuario)).ToList();
                }

                if (idAtividade != null)
                {
                    var atividades = TodasAtividades((Guid)idAtividade);

                    dados = dados.Where(a => atividades.Contains(a.IdAtividade)).ToList();
                }

                return dados;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<Guid> TodasAtividades(Guid idPai)
        {
            var atividades = new List<Guid>();
            atividades.Add(idPai);

            var filhos = new AtividadeServico().Listar(a => a.IdPai == idPai);
            foreach (var item in filhos)
            {
                atividades.Add(item.Id);
                if (new AtividadeServico().VerExiste(a => a.IdPai == item.Id))
                    atividades.AddRange(TodasAtividades(item.Id));
            }

            return atividades;
        }


        



    }
}
