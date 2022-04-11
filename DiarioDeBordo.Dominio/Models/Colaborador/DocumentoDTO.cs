using DiarioDeBordo.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiarioDeBordo.Dominio.Models.Colaborador
{
    public class DocumentoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public EnumMotivoAfastamento Tipo { get; set; }
        public string Formato { get; set; }
        public byte[] Arquivo { get; set; }
    }
}
