using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DiarioDeBordo.Dominio.Enums
{
    public enum EnumTipoAtendimento
    {
        [Description("Portal")]
        Portal = 1,
        [Description("SIOR")]
        Sior = 2,
        [Description("SEI")]
        Sei = 3
    }
}
