﻿using System;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Model.Model
{
    public class ProcessoResponsavel
    {
        public Guid ProcessoID { get; set; }
        public Guid ResponsavelID { get; set; }
        public Processo Processo { get; set; }
        public Responsavel Responsavel { get; set; }
    }
}
