using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DiarioDeBordo.Dominio.Entidades
{
    public class TipoAtividade : EntidadeBase
    {
        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}
