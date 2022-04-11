using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiarioDeBordo.Aplicacao.Models
{
    public class ViewModelRelatorios
    {
        [Display(Name = "Data início")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data fim")]
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }


        public List<Relatorio> RelatorioTeste { get; set; }
        public List<Relatorio1> Relatorio1Teste { get; set; }
        public List<Relatorio2> Relatorio2Teste { get; set; }
    }
}
