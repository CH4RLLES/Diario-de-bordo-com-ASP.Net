using System;
using System.Collections.Generic;
using System.Text;

namespace DiarioDeBordo.Dominio.Models.Colaborador
{
    public class EquipeDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DepartamentoDTO DepartamentoEquipe { get; set; }
        public Guid IdDepartamento { get; set; }
        public Guid IdGestorEquipe { get; set; }
        public string Descricao { get; set; }
        public Guid? EquipePai { get; set; }
        public string NomeGestor { get; set; }
    }
}
