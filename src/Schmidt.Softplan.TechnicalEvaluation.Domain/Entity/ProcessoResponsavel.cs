using System;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.Entity
{
    public class ProcessoResponsavel : Abstraction.Entity
    {
        public Guid ProcessoID { get; private set; }
        public Guid ResponsavelID { get; private set; }
    }
}
