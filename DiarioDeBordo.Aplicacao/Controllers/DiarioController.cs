using DiarioDeBordo.Aplicacao.Controllers.Api;
using DiarioDeBordo.Aplicacao.Models;
using DiarioDeBordo.Aplicacao.Models.Diario;
using DiarioDeBordo.Dominio;
using DiarioDeBordo.Dominio.Entidades;
using DiarioDeBordo.Dominio.Enums;
using DiarioDeBordo.Infra.Dados.Contexto;
using DiarioDeBordo.Servicos.DiarioServicos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeView = DiarioDeBordo.Aplicacao.Models.TreeView;

namespace DiarioDeBordo.Aplicacao.Controllers
{
    [Authorize(AuthenticationSchemes = AuthSchemes)]
    public class DiarioController : Controller
    {
        private readonly UsuarioLogado _usuario;
        private const string AuthSchemes = CookieAuthenticationDefaults.AuthenticationScheme;
        private readonly ColaboradorApiClient _colaborador;

        public DiarioController(UsuarioLogado usuario)
        {
            _usuario = usuario;
            _colaborador = new ColaboradorApiClient(usuario.Token);
        }

        public IActionResult Index()
        {
            var dados = new AtividadeEfetuadaModel
            {
                ListaAtividades = new AtividadeEfetuadaServico().ListarInclude(a => a.DataAtividade.Date == DateTime.Now.Date && a.IdUsuario == HttpContext.Session.Get<Usuario>("Usuario").Id,
                        "AtividadeFeita").OrderByDescending(a => a.DataHoraCadastro).ToList()              
            };

            MontarCombosAtendimento(false);

            
            List<TreeView> nodes = new List<TreeView>();
            var atividades = new AtividadeServico().ListarTodos();
            foreach (Atividade subType in atividades)
            {
                nodes.Add(new TreeView
                {
                    id = subType.Id.ToString(),
                    parent = subType.IdPai.ToString() == "00000000-0000-0000-0000-000000000000" ? "#" : subType.IdPai.ToString(),
                    text = subType.Descricao
                });
            }
            ViewBag.Json = JsonConvert.SerializeObject(nodes);
            return View(dados);
        }

        public IActionResult EditIndex()
        {
            var dados = new AtividadeEfetuadaModel
            {
                ListaAtividades = new AtividadeEfetuadaServico().ListarInclude(a => a.DataAtividade.Date == DateTime.Now.Date && a.IdUsuario == HttpContext.Session.Get<Usuario>("Usuario").Id,
                        "AtividadeFeita").OrderByDescending(a => a.DataHoraCadastro).ToList()
            };

            MontarCombosAtendimento(false);


            List<TreeView> nodes = new List<TreeView>();
            var atividades = new AtividadeServico().ListarTodos();
            foreach (Atividade subType in atividades)
            {
                nodes.Add(new TreeView
                {
                    id = subType.Id.ToString(),
                    parent = subType.IdPai.ToString() == "00000000-0000-0000-0000-000000000000" ? "#" : subType.IdPai.ToString(),
                    text = subType.Descricao
                });
            }
            ViewBag.Json = JsonConvert.SerializeObject(nodes);
            return View(dados);
        }



        [HttpPost]
        public IActionResult CadIndex([FromForm] AtividadeEfetuadaModel atividade)
        {
            try
            {
                atividade.DadosAtividade.AtividadeFeita = null;
                atividade.DadosAtividade.IdUsuario = HttpContext.Session.Get<Usuario>("Usuario").Id;
                atividade.DadosAtividade.DataHoraCadastro = DateTime.Now;

                if (atividade.DadosAtividade.Id.ToString() == "00000000-0000-0000-0000-000000000000")
                    new AtividadeEfetuadaServico().Inserir(atividade.DadosAtividade);
                    
                else
                    new AtividadeEfetuadaServico().Editar(atividade.DadosAtividade);

                TempData["Messagem"] = "Atividade salva com sucesso!";

                var dados = new AtividadeEfetuadaModel
                {
                    ListaAtividades = new AtividadeEfetuadaServico().ListarInclude(a => a.DataAtividade.Date == DateTime.Now.Date && a.IdUsuario == HttpContext.Session.Get<Usuario>("Usuario").Id,
                        "AtividadeFeita").OrderByDescending(a => a.DataHoraCadastro).ToList(),
                    DadosAtividade = new AtividadeEfetuada()
                };

                List<TreeView> nodes = new List<TreeView>();
                var atividades = new AtividadeServico().ListarTodos();

                foreach (Atividade subType in atividades)
                {
                    nodes.Add(new TreeView
                    {
                        id = subType.Id.ToString(),
                        parent = subType.IdPai.ToString() == "00000000-0000-0000-0000-000000000000" ? "#" : subType.IdPai.ToString(),
                        text = subType.Descricao
                    });
                }

                ViewBag.Json = JsonConvert.SerializeObject(nodes);

                MontarCombosAtendimento(false);
                dados.DadosAtividade.Quantidade = 0;
                return View("Index",  dados);
            }
            catch (Exception ex)
            {
                TempData["Messagem"] = "Erro ao salvar a atividade!"/* + ex.Message*/;

                var dados = new AtividadeEfetuadaModel
                {
                    ListaAtividades = new AtividadeEfetuadaServico().ListarInclude(a => a.DataAtividade.Date == DateTime.Now.Date && a.IdUsuario == HttpContext.Session.Get<Usuario>("Usuario").Id, 
                        "AtividadeFeita").OrderByDescending(a => a.DataHoraCadastro).ToList()
                };

                List<TreeView> nodes = new List<TreeView>();
                var atividades = new AtividadeServico().ListarTodos();

                foreach (Atividade subType in atividades)
                {
                    nodes.Add(new TreeView
                    {
                        id = subType.Id.ToString(),
                        parent = subType.IdPai.ToString() == "00000000-0000-0000-0000-000000000000" ? "#" : subType.IdPai.ToString(),
                        text = subType.Descricao
                    });
                }

                ViewBag.Json = JsonConvert.SerializeObject(nodes);

                MontarCombosAtendimento(false);
                return View(dados);
            }
            
        }

        [HttpGet]
        public IActionResult BuscarAtividadeEfetuada(Guid id)
        {
            var ret = new AtividadeEfetuadaServico().Obter(id);

            MontarCombosAtendimento(false);

            var dados = new AtividadeEfetuadaModel
            {
                ListaAtividades = new AtividadeEfetuadaServico().ListarInclude(a => a.IdUsuario == HttpContext.Session.Get<Usuario>("Usuario").Id && a.Id == ret.Id, "AtividadeFeita")
                    .OrderByDescending(a => a.DataHoraCadastro).ToList(),
                DadosAtividade = ret
            };
            
            
            List<TreeView> nodes = new List<TreeView>();
            var atividades = new AtividadeServico().ListarTodos();
            foreach (Atividade subType in atividades)
            {
                nodes.Add(new TreeView
                {
                    id = subType.Id.ToString(),
                    parent = subType.IdPai.ToString() == "00000000-0000-0000-0000-000000000000" ? "#" : subType.IdPai.ToString(),
                    text = subType.Descricao
                });
            }

            var teste = JsonConvert.SerializeObject(nodes);

            ViewBag.Json = JsonConvert.SerializeObject(nodes);

            return View("EditIndex", dados);
        }

        [HttpGet]
        public IActionResult MinhasAtividades(int? pagina)
        {
            var dados = new AtividadeEfetuadaModel
            {
                ListaAtividades = new AtividadeEfetuadaServico().ListarInclude(a => a.IdUsuario == HttpContext.Session.Get<Usuario>("Usuario").Id, "AtividadeFeita")
                    .OrderByDescending(a => a.DataAtividade).ThenByDescending(a => a.DataHoraCadastro).ToList()
            };
            MontarCombosAtendimento(true);
            
            List<TreeView> nodes = new List<TreeView>();
            var atividades = new AtividadeServico().ListarTodos();
            foreach (Atividade subType in atividades)
            {
                nodes.Add(new TreeView
                {
                    id = subType.Id.ToString(),
                    parent = subType.IdPai.ToString() == "00000000-0000-0000-0000-000000000000" ? "#" : subType.IdPai.ToString(),
                    text = subType.Descricao
                });
            }

            ViewBag.Json = JsonConvert.SerializeObject(nodes);

           
            return View(Paginacao<AtividadeEfetuada>.Paginar(dados.ListaAtividades, pagina ?? 1, 10));
        }

        //[HttpGet]
        //public IActionResult MinhasAtividadesEditar(int? pagina)
        //{
        //    var dados = new AtividadeEfetuadaModel
        //    {
        //        ListaAtividades = new AtividadeEfetuadaServico().ListarInclude(a => a.IdUsuario == HttpContext.Session.Get<Usuario>("Usuario").Id, "AtividadeFeita")
        //            .OrderByDescending(a => a.DataAtividade).ThenByDescending(a => a.DataHoraCadastro).ToList()
        //    };
        //    MontarCombosAtendimento(true);

        //    List<TreeView> nodes = new List<TreeView>();
        //    var atividades = new AtividadeServico().ListarTodos();
        //    foreach (Atividade subType in atividades)
        //    {
        //        nodes.Add(new TreeView
        //        {
        //            id = subType.Id.ToString(),
        //            parent = subType.IdPai.ToString() == "00000000-0000-0000-0000-000000000000" ? "#" : subType.IdPai.ToString(),
        //            text = subType.Descricao
        //        });
        //    }

        //    ViewBag.Json = JsonConvert.SerializeObject(nodes);


        //    return View(Paginacao<AtividadeEfetuada>.Paginar(dados.ListaAtividades, pagina ?? 1, 10));
        //}


        //[HttpGet]
        //public IActionResult BuscarMinhasAtividadesEditar(Guid id)
        //{
        //    var ret = new AtividadeEfetuadaServico().Obter(id);

        //    MontarCombosAtendimento(false);

        //    var dados = new AtividadeEfetuadaModel
        //    {
        //        ListaAtividades = new AtividadeEfetuadaServico().ListarInclude(a => a.DataAtividade.Date == DateTime.Now.Date && a.IdUsuario == HttpContext.Session.Get<Usuario>("Usuario").Id, "AtividadeFeita")
        //            .OrderByDescending(a => a.DataHoraCadastro).ToList(),
        //        DadosAtividade = ret
        //    };


        //    List<TreeView> nodes = new List<TreeView>();
        //    var atividades = new AtividadeServico().ListarTodos();
        //    foreach (Atividade subType in atividades)
        //    {
        //        nodes.Add(new TreeView
        //        {
        //            id = subType.Id.ToString(),
        //            parent = subType.IdPai.ToString() == "00000000-0000-0000-0000-000000000000" ? "#" : subType.IdPai.ToString(),
        //            text = subType.Descricao
        //        });
        //    }

        //    var teste = JsonConvert.SerializeObject(nodes);

        //    ViewBag.Json = JsonConvert.SerializeObject(nodes);

        //    return View("MinhasAtividadesEditar", dados);
        //}


        [HttpPost]
        public async Task<IActionResult> BuscarMinhasAtividades([FromForm] FiltroMinhasAtividades filtro)
        {
            Guid? idColaborador = null;
            if (filtro.Colaborador != null)
            {
                var usuPonto = await _colaborador.BuscaColaboradorNome(filtro.Colaborador);
                idColaborador = usuPonto.Data.Id;
            }
            //usuario.DadosUsuario.IdColaborador = usuPonto.Data.Id;

            var dados = new AtividadeEfetuadaModel
            {
                ListaAtividades = new AtividadeEfetuadaServico().ListarMinhasAtividades(filtro.DataInicio, filtro.DataFim, idColaborador, filtro.IdAtividade, filtro.Superintendencia)
            };

            MontarCombosAtendimento(true);
            
            List<TreeView> nodes = new List<TreeView>();
            var atividades = new AtividadeServico().ListarTodos();
            foreach (Atividade subType in atividades)
            {
                nodes.Add(new TreeView
                {
                    id = subType.Id.ToString(),
                    parent = subType.IdPai.ToString() == "00000000-0000-0000-0000-000000000000" ? "#" : subType.IdPai.ToString(),
                    text = subType.Descricao
                });
            }

            ViewBag.Json = JsonConvert.SerializeObject(nodes);
            return View("MinhasAtividades", Paginacao<AtividadeEfetuada>.Paginar(dados.ListaAtividades, 1, 10));
        }

        private void MontarCombosAtendimento(bool selecione)
        {
            TempData["Usuario"] = _usuario;
            TempData["Admin"] = Admin();
        }

        private bool Admin()
        {
            return _usuario.Acesso == EnumControleAcesso.Administrador;
        }
    }
}