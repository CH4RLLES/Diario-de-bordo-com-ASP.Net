using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DiarioDeBordo.Dominio.Enums
{
    public enum EnumStatusAcesso
    {
        [Description("Usuário não cadastrado")]
        NaoCadastrado = 0,
        [Description("Cancelada")]
        Cancelado = 1,
        [Description("Senha incorreta")]
        SenhaIncorreta = 2,
        [Description("Ativo")]
        Ativo = 3,
        [Description("Ip de acesso não está liberado. Foi enviada uma solicitação para o seu gestor liberar o acesso.")]
        IpNaoLiberado = 4
    }
}
