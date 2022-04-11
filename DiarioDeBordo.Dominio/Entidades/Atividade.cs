using DiarioDeBordo.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DiarioDeBordo.Dominio.Entidades
{
    public class Atividade : EntidadeBase
    {
        [Required]
        [Display(Name = "Nome da Atividade")]
        public string Descricao { get; set; }
        public EnumTipoAtendimento Sistema { get; set; }
        public bool Quantidade { get; set; }
        [Display(Name = "N° do Processo")]
        public bool NumProcesso { get; set; }
        [Display(Name = "Vínculo")]
        public Guid IdPai { get; set; }
        [ForeignKey("IdPai")]
        
        public Atividade AtividadePai { get; set; }

        public virtual List<Atividade> AtividadesFilhos { get; set; }
    }
}
