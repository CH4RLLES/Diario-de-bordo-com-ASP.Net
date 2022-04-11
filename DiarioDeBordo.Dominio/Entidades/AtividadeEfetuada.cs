using DiarioDeBordo.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DiarioDeBordo.Dominio.Entidades
{
    public class AtividadeEfetuada : EntidadeBase
    {
        [Required]
        public Guid IdUsuario { get; set; }
        
        [ForeignKey("IdUsuario")]
        public Usuario UsuarioAtividade { get; set; }

        [Required]
        [Display(Name = "Tipo de Atendimento ao Público")]
        public EnumTipoAtendimento TipoAtendimento { get; set; }
        [Required]
        [Display(Name = "Data da Atividade")]
        [DataType(DataType.Date)]
        public DateTime DataAtividade { get; set; }
        [Required]
        [Display(Name = "Atividade")]
        public Guid IdAtividade { get; set; }
        [ForeignKey("IdAtividade")]
        public Atividade AtividadeFeita { get; set; }

       

        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Display(Name = "Nº do Processo")]
        public string ProcessoSEI { get; set; }

        public DateTime DataHoraCadastro { get; set; }
    }
}
