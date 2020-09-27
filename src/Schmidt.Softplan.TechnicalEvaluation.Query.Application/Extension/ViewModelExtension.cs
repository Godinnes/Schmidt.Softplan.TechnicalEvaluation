using Schmidt.Softplan.TechnicalEvaluation.Query.Application.ViewModel;
using Schmidt.Softplan.TechnicalEvaluation.Query.Model.Model;
using System.Collections.Generic;
using System.Linq;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Application.Extension
{
    public static class ViewModelExtension
    {
        public static ProcessoQueryViewModel ToQueryViewModel(this Processo processo) => processo;
        public static ProcessoViewModel ToViewModel(this Processo processo) => processo;
        public static SituacaoQueryViewModel ToQueryViewModel(this Situacao situacao) => situacao;
        public static ResponsavelQueryViewModel ToQueryViewModel(this Responsavel responsavel) => responsavel;
        public static ResponsavelViewModel ToViewModel(this Responsavel responsavel) => responsavel;
        public static IEnumerable<ResponsavelQueryViewModel> ToQueryViewModel(this IEnumerable<Responsavel> responsaveis) => responsaveis.Select(r => r.ToQueryViewModel()).ToList();
    }
}