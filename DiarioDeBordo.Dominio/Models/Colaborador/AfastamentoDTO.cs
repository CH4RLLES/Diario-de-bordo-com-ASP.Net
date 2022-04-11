using DiarioDeBordo.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiarioDeBordo.Dominio.Models.Colaborador
{
    public class AfastamentoDTO
    {
        public Guid Id { get; set; }
        public Guid IdColaboradorAfastamento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public EnumMotivoAfastamento MotivoAfastamento { get; set; }
        public DateTime DataCadastro { get; set; }
        public Guid IdColaboradorCadastro { get; set; }
        public string Observacao { get; set; }
        public Guid? IdDocumento { get; set; }
        public DocumentoDTO DocumentoAfastamento { get; set; }
        public EnumStatusSolicitacao Status { get; set; }
    }
}
