using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
using TreeView = DiarioDeBordo.Aplicacao.Models.TreeView;

namespace DiarioDeBordo.Aplicacao.Controllers
{
    [Authorize(AuthenticationSchemes = AuthSchemes)]
    public class AdminController : Controller
    {
        private readonly UsuarioLogado _usuario;
        private const string AuthSchemes = CookieAuthenticationDefaults.AuthenticationScheme;
        private readonly ColaboradorApiClient _colaborador;

        public AdminController(UsuarioLogado usuario)
        {
            _usuario = usuario;
            _colaborador = new ColaboradorApiClient(_usuario.Token);
        }

        public IActionResult Index()
        {
            TempData["Usuario"] = _usuario;
            TempData["Admin"] = Admin();
            if (AcessoNegado())
                return View("AcessoNegado");

            return View();
        }

        public IActionResult Usuarios()
        {
            TempData["Usuario"] = _usuario;
            TempData["Admin"] = Admin();
            if (AcessoNegado())
                return View("AcessoNegado");

            MontarCombosUsuario();

            var dados = new UsuariosModel
            {
                ListaUsuarios = new UsuarioServico().ListarTodos().ToList()
            };
            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Usuarios([FromForm] UsuariosModel usuario)
        {
            try
            {
                TempData["Usuario"] = _usuario;
                TempData["Admin"] = Admin();
                if (AcessoNegado())
                    return View("AcessoNegado");

                Usuario ret;
                MontarCombosUsuario();

                var usuPonto = await _colaborador.BuscaColaboradorNome(usuario.DadosUsuario.Nome);
                if (usuPonto.Data == null)
                {
                    var model = new UsuariosModel
                    {
                        ListaUsuarios = new UsuarioServico().ListarTodos().ToList()
                    };

                    TempData["Messagem"] = "Nome de usuário inválido!";
                    return View(model);
                }

                usuario.DadosUsuario.IdColaborador = usuPonto.Data.Id;
                usuario.DadosUsuario.CPF = usuPonto.Data.CPF;
                usuario.DadosUsuario.Superintendencia = usuPonto.Data.EquipeColaborador.Nome;

                if (usuario.DadosUsuario.Id.ToString() == "00000000-0000-0000-0000-000000000000")
                    ret = new UsuarioServico().Inserir(usuario.DadosUsuario);
                else
                    ret = new UsuarioServico().Editar(usuario.DadosUsuario);

                var dados = new UsuariosModel
                {
                    ListaUsuarios = new UsuarioServico().ListarTodos().ToList()
                };

                TempData["Messagem"] = ret != null ? "Usuário salvo com sucesso!" : "Erro ao salvar o usuário!";

                return View(dados);
            }
            catch (Exception ex)
            {
                TempData["Messagem"] = "Erro ao salvar o usuário! Err: " + ex.Message;

                var dados = new UsuariosModel
                {
                    ListaUsuarios = new UsuarioServico().ListarTodos().ToList()
                };

                MontarCombosUsuario();
                return View(dados);
            }

        }

        [HttpGet]
        public IActionResult BuscarUsuario(Guid id)
        {
            TempData["Usuario"] = _usuario;
            TempData["Admin"] = Admin();
            if (AcessoNegado())
                return View("AcessoNegado");

            var ret = new UsuarioServico().Obter(id);

            MontarCombosUsuario();

            var dados = new UsuariosModel
            {
                ListaUsuarios = new UsuarioServico().ListarTodos().ToList(),
                DadosUsuario = ret
            };

            return View("Usuarios", dados);
        }

        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> PesquisaNome()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var names = await _colaborador.PesquisaNome(term);
                return Ok(names.Data);
            }
            catch
            {
                return BadRequest();
            }
        }

        private void MontarCombosUsuario()
        {
            ViewBag.ControleAcesso = Metodos.GetEnumToSelectList<EnumControleAcesso>();
            var itens = Metodos.GetEnumToSelectList<EnumStatusAcesso>();

            ViewBag.Status = itens.Where(a => a.Value == "1" || a.Value == "3").OrderBy(a => a.Text);
        }



        public IActionResult Atividades()
        {
            TempData["Usuario"] = _usuario;
            TempData["Admin"] = Admin();
            if (AcessoNegado())
                return View("AcessoNegado");

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

            var dados = new AtividadesModel
            {
                ListaAtividades = new AtividadeServico().ListarTodos().OrderBy(a => a.Descricao).ToList()
            };
            return View(dados);
        }

        [HttpPost]
        public IActionResult Atividades([FromForm] AtividadesModel atividade)
        {
            try
            {
                TempData["Usuario"] = _usuario;
                TempData["Admin"] = Admin();

                if (AcessoNegado())
                    return View("AcessoNegado");

                if (atividade.DadosAtividade.Id.ToString() == "00000000-0000-0000-0000-000000000000")
                    new AtividadeServico().Inserir(atividade.DadosAtividade);
                else
                    new AtividadeServico().Editar(atividade.DadosAtividade);

                var dados = new AtividadesModel
                {
                    ListaAtividades = new AtividadeServico().ListarTodos().OrderBy(a => a.Descricao).ToList(),
                    DadosAtividade = new Atividade()
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

                MontarCombosAtendimento(true);

                TempData["Messagem"] = "Atividade salva com sucesso!";

                return View(dados);
            }
            catch (Exception ex)
            {
                TempData["Messagem"] = "Erro ao salvar a atividade!" /*+ ex.Message*/;

                var dados = new AtividadesModel
                {
                    ListaAtividades = new AtividadeServico().ListarTodos().OrderBy(a => a.Descricao).ToList()
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

                return View(dados);
            }
        }

        [HttpGet]
        public IActionResult BuscarAtividade(Guid id)
        {
            TempData["Usuario"] = _usuario;
            TempData["Admin"] = Admin();
            if (AcessoNegado())
                return View("AcessoNegado");

            MontarCombosAtendimento(true);

            var ret = new AtividadeServico().Obter(id);



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



            var dados = new AtividadesModel
            {
                DadosAtividade = ret,
                ListaAtividades = new AtividadeServico().ListarTodos().OrderBy(a => a.Descricao).ToList(),
            };

            return View("Atividades", dados);
        }



        public IActionResult ControleAtividades()
        {
            TempData["Usuario"] = _usuario;
            TempData["Admin"] = Admin();
            var dados = new FiltroMinhasAtividades();

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

        
     
        

        public async Task<IActionResult> BuscarControleAtividades([FromForm]FiltroMinhasAtividades filtro)
        {
            TempData["Usuario"] = _usuario;
            TempData["Admin"] = Admin();

            Guid? idColaborador = null;
            if (filtro.Colaborador != null)
            {
                var usuPonto = await _colaborador.BuscaColaboradorNome(filtro.Colaborador);
                idColaborador = usuPonto.Data.Id;
            }

            filtro.ListaAtividades = new AtividadeEfetuadaServico().ListarMinhasAtividades(filtro.DataInicio, filtro.DataFim, idColaborador, filtro.IdAtividade, filtro.Superintendencia);

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
            return View("ControleAtividades", filtro);
        }





        public IActionResult Relatorio(DateTime dataInicio, DateTime dataFim)
        {
            TempData["Usuario"] = _usuario;
            TempData["Admin"] = Admin();

            var db = new DiarioContext();
            ViewModelRelatorios modelRelatorios = new ViewModelRelatorios();

            var query = from a in db.Atividades
                         join ae in db.AtividadesEfetuadas
                         on a.Id equals ae.IdAtividade
                         select new
                         {
                             ae.DataHoraCadastro,
                             legenda = a.Descricao
                         };
            var obj = new List<Relatorio>();
            foreach (var ret in query.Where(a=> a.DataHoraCadastro >= dataInicio && a.DataHoraCadastro <= dataFim ).GroupBy(a => a.legenda))
            {
                obj.Add(new Relatorio
                {
                    Legenda = ret.Key,
                    Valor = ret.Count()
                });
            }





            var query2 = from u in db.Usuarios
                        join ae in db.AtividadesEfetuadas
                        on u.Id equals ae.IdUsuario
                        select new
                        {
                            ae.DataHoraCadastro,
                            legenda = u.Superintendencia
                        };
            var obj3 = new List<Relatorio2>();
            foreach (var ret in query2.Where(a => a.DataHoraCadastro >= dataInicio && a.DataHoraCadastro <= dataFim).GroupBy(a => a.legenda))
            {
                obj3.Add(new Relatorio2
                {
                    Legenda = ret.Key,
                    Valor = ret.Count()
                });
            }





            var result2 = from a in db.Usuarios
                          select new
                          {
                              legenda = a.Superintendencia
                          };
            var obj2 = new List<Relatorio1>();
            foreach (var ret in result2.GroupBy(a => a.legenda))
            {
                obj2.Add(new Relatorio1
                {
                    Legenda = ret.Key,
                    Valor = ret.Count()
                });
            }

            modelRelatorios.RelatorioTeste = obj;
            modelRelatorios.Relatorio1Teste = obj2;
            modelRelatorios.Relatorio2Teste = obj3;

            return View(modelRelatorios);
        }


        private bool AcessoNegado()
        {
            return _usuario.Acesso != EnumControleAcesso.Administrador;
        }

        private void MontarCombosAtendimento(bool selecione)
        {
            var itemSelecione = new SelectListItem("Selecione", "00000000-0000-0000-0000-000000000000");



            ViewBag.TipoRelatorio = Metodos.GetEnumToSelectList<EnumTipoRelatorio>();

            List<SelectListItem> lista = new SelectList(new AtividadeServico().ListarTodos().OrderBy(a => a.Descricao), "Id", "Descricao").ToList();
            if (selecione)
                lista.Insert(0, itemSelecione);
            ViewBag.Atividades = lista;

            lista = Metodos.GetEnumToSelectList<EnumTipoAtendimento>().ToList();
            if (selecione)
                lista.Insert(0, itemSelecione);
            ViewBag.TipoAtendimento = lista;

            //lista = new SelectList(new UsuarioServico().ListarTodos().OrderBy(a => a.Superintendencia).Select(a => a.Superintendencia).Distinct()).ToList();
            //if (selecione)
            //    lista.Insert(0, itemSelecione);
            //ViewBag.Superintendencias = lista;

            lista = new SelectList(new UsuarioServico().ListarTodos().OrderBy(a => a.Superintendencia).Select(a => a.Superintendencia).Distinct()).ToList();
            if (selecione)
                lista.Insert(0, itemSelecione);
            ViewBag.Superintendencias = lista;
        }

        private bool Admin()
        {
            return _usuario.Acesso == EnumControleAcesso.Administrador;
        }
    }
}