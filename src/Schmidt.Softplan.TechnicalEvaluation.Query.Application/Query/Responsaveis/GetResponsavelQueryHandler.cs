using Microsoft.EntityFrameworkCore;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.Extension;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.ViewModel;
using Schmidt.Softplan.TechnicalEvaluation.Query.Data.Abstraction;
using System.Linq;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Application.Query.Responsaveis
{
    public class GetResponsavelQueryHandler : CommandHandlerAsync<GetResponsavelQuery, ResponsavelViewModel>
    {
        private readonly IQueryRepository _repository;
        public GetResponsavelQueryHandler(IQueryRepository repository)
        {
            _repository = repository;
        }
        public async override Task<ResponsavelViewModel> HandleAsync(GetResponsavelQuery request)
        {
            var responsavel = await _repository
                .Responsaveis
                .Where(a => a.ID == request.ID)
                .Select(a => a.ToViewModel())
                .FirstOrDefaultAsync();
            return responsavel;
        }
    }
}
