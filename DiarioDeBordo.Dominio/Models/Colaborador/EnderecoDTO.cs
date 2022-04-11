using System;
using System.Collections.Generic;
using System.Text;

namespace DiarioDeBordo.Dominio.Models.Colaborador
{
    public class EnderecoDTO
    {
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
    }
}
