using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DiarioDeBordo.Dominio.Enums
{
    public enum EnumMotivoAfastamento
    {
        [Description("Atestado Médico")]
        AtestadoMedico = 1,
        [Description("INSS")]
        INSS = 2,
        [Description("Licença Paternidade")]
        LicencaPaternidade = 3,
        [Description("Licença Maternidade")]
        LicencaMaternidade = 4,
        [Description("Óbito")]
        Obito = 5,
        [Description("Atestado de Comparecimento")]
        AtestadoComparecimento = 6,
        [Description("Licença de Casamento")]
        LicencaCasamento = 7
    }
}
