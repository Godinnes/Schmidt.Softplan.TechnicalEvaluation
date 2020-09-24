using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.Command.Responsaveis
{
    public class CreateResponsavelCommandHandler : CommandHandlerAsync<CreateResponsavelCommand, Guid>
    {
        private readonly IResponsavelRepository _repository;
        public CreateResponsavelCommandHandler(IResponsavelRepository repository)
        {
            _repository = repository;
        }
        public async override Task<Guid> HandleAsync(CreateResponsavelCommand request)
        {
            var newReponsavel = Responsavel.Create(request.Nome, request.CPF, request.Email, request.Foto);
            _repository.Add(newReponsavel);
            await _repository.SaveChangesAsync();
            return newReponsavel.ID;
        }
    }
}
