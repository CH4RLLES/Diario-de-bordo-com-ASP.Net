using System;
using System.Collections.Generic;
using System.Text;

namespace DiarioDeBordo.Dominio.Models.Colaborador
{
    public class ContatoDTO
    {
        public Guid Id { get; set; }
        public string TelefoneCelular { get; set; }
        public string TelefoneFixo { get; set; }
        public string EmailPessoal { get; set; }
        public string EmailProfissional { get; set; }
    }
}
