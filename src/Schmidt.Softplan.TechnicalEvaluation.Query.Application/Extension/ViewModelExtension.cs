using Schmidt.Softplan.TechnicalEvaluation.Query.Application.ViewModel;
using Schmidt.Softplan.TechnicalEvaluation.Query.Model.Model;
using System.Collections.Generic;
using System.Linq;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Application.Extension
{
    public static class ViewModelExtension
    {
        public static ProcessoQueryViewModel ToViewModel(this Processo processo) => processo;
        public static SituacaoQueryViewModel ToViewModel(this Situacao situacao) => situacao;
        public static ResponsavelQueryViewModel ToViewModel(this Responsavel responsavel) => responsavel;
        public static IEnumerable<ResponsavelQueryViewModel> ToViewModel(this IEnumerable<Responsavel> responsaveis) => responsaveis.Select(r => r.ToViewModel()).ToList();
    }
}