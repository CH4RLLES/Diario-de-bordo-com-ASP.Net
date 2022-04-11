using DiarioDeBordo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiarioDeBordo.Aplicacao.Models.Diario
{
    public class UsuariosModel
    {
        public Usuario DadosUsuario { get; set; }
        public List<Usuario> ListaUsuarios { get; set; }
    }
}
