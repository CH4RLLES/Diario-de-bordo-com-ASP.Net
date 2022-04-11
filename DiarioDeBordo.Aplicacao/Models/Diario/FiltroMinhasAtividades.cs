using DiarioDeBordo.Dominio.Entidades;
using DiarioDeBordo.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiarioDeBordo.Aplicacao.Models.Diario
{
    public class FiltroMinhasAtividades
    {
        [Display(Name = "Data início")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data fim")]
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }

        [Display(Name = "Atividade")]
        public Guid? IdAtividade { get; set; }
        
        [Display(Name = "Colaborador")]
        public string Colaborador { get; set; }

        [Display(Name = "Superintendência")]
        public string Superintendencia { get; set; }

        public AtividadeEfetuada DadosAtividade { get; set; }

        public List<AtividadeEfetuada> ListaAtividades { get; set; }

        public Usuario DadosUsuario { get; set; }

        public List<Usuario> ListaUsuarios { get; set; }
    }
}
