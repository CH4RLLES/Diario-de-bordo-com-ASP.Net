using DiarioDeBordo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiarioDeBordo.Aplicacao.Models.Diario
{
    public class AtividadesModel
    {
        public Atividade DadosAtividade { get; set; }
        public List<Atividade> ListaAtividades { get; set; }
    }
}
