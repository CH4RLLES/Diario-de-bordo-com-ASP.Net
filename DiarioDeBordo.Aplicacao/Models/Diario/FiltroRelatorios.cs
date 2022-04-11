using DiarioDeBordo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiarioDeBordo.Aplicacao.Models.Diario
{
    public class FiltroRelatorios
    {
        public AtividadeEfetuada DadosAtividade { get; set; }
        public List<AtividadeEfetuada> ListaAtividades { get; set; }
    }
}
