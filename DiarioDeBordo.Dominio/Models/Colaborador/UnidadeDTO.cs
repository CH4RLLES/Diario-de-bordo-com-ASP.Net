using DiarioDeBordo.Dominio.Enums;
using System;

namespace DiarioDeBordo.Dominio.Models.Colaborador
{
    public class UnidadeDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Observacoes { get; set; }
        public string Telefone { get; set; }
        public EnderecoDTO Endereco { get; set; }
        public EnumFusoHorario FusoHorario { get; set; }
        public UfDTO Estado { get; set; }
        public Geometry Localizacao { get; set; }
        public int DistanciaMetros { get; set; }
    }

    public class Geometry
    {
        public WellKnownText geometry { get; set; }
    }

    public class WellKnownText
    {
        public string wellKnownText { get; set; }
    }
}
