using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DiarioDeBordo.Dominio.Enums
{
    public enum EnumStatusSolicitacao
    {
        [Description("Aguardando")]
        Aguardando = 1,
        [Description("Aprovada")]
        Aprovada = 2,
        [Description("Rejeitada")]
        Rejeitada = 3
    }
}
