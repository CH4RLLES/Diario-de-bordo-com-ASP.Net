using DiarioDeBordo.Dominio.Enums;
using System;

namespace DiarioDeBordo.Dominio.Models
{
    public class LoginDTO 
    {
        public Guid Id { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public EnumStatusAcesso Status { get; set; }
        public Guid IdColaborador { get; set; }
    }
}
