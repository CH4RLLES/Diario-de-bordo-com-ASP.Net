using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DiarioDeBordo.Dominio.Entidades
{
    public class EntidadeBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
