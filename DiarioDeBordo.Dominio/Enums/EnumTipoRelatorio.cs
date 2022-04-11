using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DiarioDeBordo.Dominio.Enums
{
    public enum EnumTipoRelatorio
    {
        [Description("Atividades Realizadas")]
        AtividadesRealizadas = 1,
        [Description("Atividades da Superintendência")]
        AtividadesSuperintendencia = 2,
        [Description("Atividades da Superintendencia por Tipo")]
        AtividadesSuperintendenciaTipo = 3
    }
}
