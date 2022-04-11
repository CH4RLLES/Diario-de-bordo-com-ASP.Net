using System;
using System.Collections.Generic;
using System.Text;

namespace DiarioDeBordo.Dominio.Models.Colaborador
{
    public class TurnoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        //public List<HorarioDTO> Horarios { get; set; }
        public TimeSpan CargaHoraria { get; set; }
        public bool MenorAprendiz { get; set; }
    }
}
