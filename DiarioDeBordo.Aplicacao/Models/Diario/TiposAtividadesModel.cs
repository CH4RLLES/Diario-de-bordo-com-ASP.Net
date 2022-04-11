using DiarioDeBordo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiarioDeBordo.Aplicacao.Models.Diario
{
    public class TiposAtividadesModel
    {
        public TipoAtividade DadosTipoAtividade { get; set; }
        public List<TipoAtividade> ListaTiposAtividades { get; set; }
    }
}
