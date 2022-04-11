using System;
using System.Collections.Generic;
using System.Text;

namespace DiarioDeBordo.Dominio.Models.Colaborador
{
    public class RetornoFeriasDTO
    {
        public string AnoBase { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public string StatusGestor { get; set; }
        public string StatusRH { get; set; }
    }
}
