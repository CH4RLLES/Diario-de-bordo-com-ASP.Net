using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DiarioDeBordo.Dominio.Enums
{
    public enum EnumEstadoCivil
    {
        [Description("Solteiro")]
        Solteiro = 1,
        [Description("Casado")]
        Casado = 2,
        [Description("Divorciado")]
        Divorciado = 3,
        [Description("Separado")]
        Separado = 4,
        [Description("Viúvo")]
        Viuvo = 5
    }
}
