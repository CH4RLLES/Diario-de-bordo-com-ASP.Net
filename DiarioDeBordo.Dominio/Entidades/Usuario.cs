using DiarioDeBordo.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DiarioDeBordo.Dominio.Entidades
{
    public class Usuario : EntidadeBase
    {
        [Required]
        public Guid IdColaborador { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        [Display(Name = "Nome do Colaborador")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Superintendência")]
        public string Superintendencia { get; set; }
        [Required]
        public EnumStatusAcesso Status { get; set; }
        [Required]
        [Display(Name = "Perfil de Acesso")]
        public EnumControleAcesso ControleAcesso { get; set; }
    }
}
