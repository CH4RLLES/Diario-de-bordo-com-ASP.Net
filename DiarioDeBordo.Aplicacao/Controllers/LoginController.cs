using DiarioDeBordo.Aplicacao.Controllers.Api;
using DiarioDeBordo.Aplicacao.Models;
using DiarioDeBordo.Dominio.Enums;
using DiarioDeBordo.Dominio.Models;
using DiarioDeBordo.Servicos.DiarioServicos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DiarioDeBordo.Aplicacao.Controllers
{
    public class LoginController : Controller
    {
        private readonly TokenApiClient _token = new TokenApiClient();
        private LoginApiClient _login;

        [HttpPost]
        public async Task<IActionResult> Login([Bind] LoginDTO usuario)
        {
            var appValido = await _token.BuscaToken();
            if (!appValido.Success)
            {
                TempData["LoginUsuarioFalhou"] = "O login Falhou. Esta aplicação não está autorizada a acessar o sistema.";
                return RedirectToAction("Index", "Home");
            }

            var Token = appValido.Data.Mensagem.ToString();

            _login = new LoginApiClient(Token);
            var usu = await _login.EfetuarLogin(usuario);
            if (usu.Data.Status == EnumStatusAcesso.Ativo)
            {
                var retCol = new UsuarioServico().Obter(a => a.IdColaborador == usu.Data.IdColaborador);
                if (retCol == null)
                {
                    TempData["LoginUsuarioFalhou"] = "O login Falhou. Usuário não autorizado a acessar este sistema.";
                    return RedirectToAction("Index", "Home");
                }

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, usu.Data.IdColaborador.ToString()),
                        new Claim(ClaimTypes.Name, retCol.Nome),
                        new Claim(ClaimTypes.Authentication, ((int)retCol.ControleAcesso).ToString()),
                        new Claim(ClaimTypes.AuthenticationMethod, Token),
                    };

                ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                HttpContext.Session.Put("Usuario", retCol);

                await HttpContext.SignInAsync(principal, new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(2000)
                });

                //if (retCol.ControleAcesso == EnumControleAcesso.Administrador)
                //    return RedirectToAction("Index", "Admin");

                return RedirectToAction("Index", "Diario");
            }
            else
            {
                TempData["LoginUsuarioFalhou"] = "O login Falhou. " + usu.Data.Status.GetEnumDescription();
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}