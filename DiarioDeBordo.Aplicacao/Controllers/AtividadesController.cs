using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiarioDeBordo.Aplicacao.Models;
using DiarioDeBordo.Aplicacao.Models.Diario;
using DiarioDeBordo.Dominio;
using DiarioDeBordo.Dominio.Entidades;
using DiarioDeBordo.Dominio.Enums;
using DiarioDeBordo.Servicos.DiarioServicos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DiarioDeBordo.Aplicacao.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = AuthSchemes)]
    public class AtividadesController : Controller
    {
        private const string AuthSchemes = CookieAuthenticationDefaults.AuthenticationScheme; // + "," + JwtBearerDefaults.AuthenticationScheme;

        [HttpGet]
        [Route("VerificarTemPai")]
        public bool VerificarTemPai(string idAtividade)
        {
            try
            {
                var ret = new AtividadeServico().VerExiste(a => a.IdPai == Guid.Parse(idAtividade));
                return ret;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("VerificarTemQuantidade")]
        public bool VerificarTemQuantidade(string idAtividade)
        {
            try
            {
                var ret = new AtividadeServico().VerExiste(a => a.Id == Guid.Parse(idAtividade) && a.Quantidade);
                return ret;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("VerificarTemProcesso")]
        public bool VerificarTemProcesso(string idAtividade)
        {
            try
            {
                var ret = new AtividadeServico().VerExiste(a => a.Id == Guid.Parse(idAtividade) && a.NumProcesso);
                return ret;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("BuscarControleAtividades")]
        public IActionResult BuscarControleAtividades([FromQuery] FiltroMinhasAtividades filtro)
        {
            try
            {
                var dados = new AtividadeEfetuadaModel
                {
                    ListaAtividades = new AtividadeEfetuadaServico().ListarInclude(a => a.DataAtividade >= filtro.DataInicio && a.DataAtividade <= filtro.DataFim,
                        "AtividadeFeita,TipoAtividadeFeita,UsuarioAtividade")
                        .OrderByDescending(a => a.DataAtividade).ThenByDescending(a => a.DataHoraCadastro).ToList()
                };

                if (filtro.IdAtividade.ToString() != "00000000-0000-0000-0000-000000000000")
                    dados.ListaAtividades = dados.ListaAtividades.Where(a => a.IdAtividade == filtro.IdAtividade).ToList();
                
                if (!string.IsNullOrWhiteSpace(filtro.Colaborador))
                    dados.ListaAtividades = dados.ListaAtividades.Where(a => a.UsuarioAtividade.Nome == filtro.Colaborador).ToList();

                if (filtro.Superintendencia != "00000000-0000-0000-0000-000000000000")
                    dados.ListaAtividades = dados.ListaAtividades.Where(a => a.UsuarioAtividade.Superintendencia == filtro.Superintendencia).ToList();

                MontarCombosAtendimento(true);

                //if (filtro.TipoRelatorio == EnumTipoRelatorio.AtividadesRealizadas)
                //    return PartialView("../Admin/Relatorios/_AtividadesRealizadas", Paginacao<AtividadeEfetuada>.Paginar(dados.ListaAtividades, 1, 10));
                //else if(filtro.TipoRelatorio == EnumTipoRelatorio.AtividadesSuperintendencia)
                //    return PartialView("../Admin/Relatorios/_AtividadesColaborador", Paginacao<AtividadeEfetuada>.Paginar(dados.ListaAtividades, 1, 10));
                //else
                    return PartialView("../Admin/Relatorios/_AtividadesRealizadas", Paginacao<AtividadeEfetuada>.Paginar(dados.ListaAtividades, 1, 10));
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void MontarCombosAtendimento(bool selecione)
        {
            var itemSelecione = new SelectListItem("Selecione", "00000000-0000-0000-0000-000000000000");

            var itens = new Dictionary<int, string>
            {
                { (int)EnumTipoAtendimento.Portal, EnumTipoAtendimento.Portal.GetEnumDescription() },
                { (int)EnumTipoAtendimento.Sior, EnumTipoAtendimento.Sior.GetEnumDescription() },
                { (int)EnumTipoAtendimento.Sei, EnumTipoAtendimento.Sei.GetEnumDescription() }
            };

            ViewBag.TipoAtendimento = itens;

            ViewBag.TipoRelatorio = Metodos.GetEnumToSelectList<EnumTipoRelatorio>();

            List<SelectListItem> lista = new SelectList(new AtividadeServico().ListarTodos().OrderBy(a => a.Descricao), "Id", "Descricao").ToList();
            if (selecione)
                lista.Insert(0, itemSelecione);
            ViewBag.Atividades = lista;
            
            lista = new SelectList(new UsuarioServico().ListarTodos().OrderBy(a => a.Superintendencia).Select(a => a.Superintendencia).Distinct()).ToList();
            if (selecione)
                lista.Insert(0, itemSelecione);
            ViewBag.Superintendencias = lista;
        }
    }
}