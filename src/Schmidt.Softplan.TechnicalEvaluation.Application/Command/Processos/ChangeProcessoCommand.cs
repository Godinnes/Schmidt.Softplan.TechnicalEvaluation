﻿using Schmidt.Softplan.TechnicalEvaluation.Mediator.Interfaces;
using System;
using System.Collections.Generic;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.Command.Processos
{
    public class ChangeProcessoCommand : ICommand
    {
        public Guid ID { get; set; }
        public string NumeroProcessoUnificado { get; set; }
        public DateTime? Distribuicao { get; set; }
        public string PastaFisicaCliente { get; set; }
        public string Descricao { get; set; }
        public Guid SituacaoID { get; set; }
        public IEnumerable<Guid> Responsaveis { get; set; }
        public bool SegredoJustica { get; set; }
        public Guid? ProcessoPaiID { get; set; }
    }
}
