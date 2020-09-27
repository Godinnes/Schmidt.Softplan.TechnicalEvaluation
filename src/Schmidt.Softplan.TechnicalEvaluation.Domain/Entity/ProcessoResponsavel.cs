using System;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.Entity
{
    public class ProcessoResponsavel : Abstraction.Entity
    {
        public Guid ProcessoID { get; private set; }
        public Guid ResponsavelID { get; private set; }
        public Processo Processo { get; private set; }
        public Responsavel Responsavel { get; private set; }
        private ProcessoResponsavel()
        {

        }
        private ProcessoResponsavel(Guid processoID,
                                    Guid responsavelID)
        {
            ProcessoID = processoID;
            ResponsavelID = responsavelID;
        }
        public static ProcessoResponsavel Create(Guid processoID,
                                                 Guid responsavelID)
        {
            return new ProcessoResponsavel(processoID, responsavelID);
        }
    }
}
