using DiarioDeBordo.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiarioDeBordo.Dominio.Models.Colaborador
{
    public class ColaboradorDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string PIS { get; set; }
        public string Matricula { get; set; }
        public DateTime DataAdmissao { get; set; }
        public Guid IdCargo { get; set; }
        public CargoDTO CargoColaborador { get; set; }
        public Guid IdTurno { get; set; }
        public TurnoDTO TurnoColaborador { get; set; }
        public bool Ativo { get; set; }
        public Guid IdEquipe { get; set; }
        public EquipeDTO EquipeColaborador { get; set; }
        public DadosPessoaisDTO DadosPessoaisColaborador { get; set; }
        public ContatoDTO ContatoColaborador { get; set; }
        public EnderecoDTO EnderecoColaborador { get; set; }
        public string SaldoBanco { get; set; }
        public EnumControleAcesso ControleAcesso { get; set; }
        public bool HabilitaPonto { get; set; }
        public DateTime? DataDemissao { get; set; }
    }
}
