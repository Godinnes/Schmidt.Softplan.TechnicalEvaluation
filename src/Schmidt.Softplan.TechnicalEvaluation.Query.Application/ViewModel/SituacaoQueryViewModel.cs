using Schmidt.Softplan.TechnicalEvaluation.Query.Model.Model;
using System;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Application.ViewModel
{
    public class SituacaoQueryViewModel
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public static implicit operator SituacaoQueryViewModel(Situacao situacao)
        {
            return new SituacaoQueryViewModel()
            {
                ID = situacao.ID,
                Nome = situacao.Nome
            };
        }
    }
}
