using System;
using System.Collections.Generic;
using System.Text;

namespace DiarioDeBordo.Dominio.Models.Colaborador
{
    public class DepartamentoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid IdUnidade { get; set; }
        public UnidadeDTO UnidadeNegocio { get; set; }
        public string Descricao { get; set; }
    }
}
