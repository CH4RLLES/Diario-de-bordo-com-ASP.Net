using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DiarioDeBordo.Dominio.Enums
{
    public enum EnumFusoHorario
    {
        [Description("Amazônia (GMT -4)")]
        Amazonia = -1,
        [Description("Brasília (GMT -3)")]
        Brasilia = 0,
        [Description("Fernando de Noronha (GMT -2)")]
        Noronha = 1,
        [Description("Acre (GMT -5)")]
        Acre = -2
    }
}
