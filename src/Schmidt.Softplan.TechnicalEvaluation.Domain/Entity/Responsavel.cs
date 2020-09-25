using Schmidt.Softplan.TechnicalEvaluation.Common.Exception;
using Schmidt.Softplan.TechnicalEvaluation.Common.ValueObjects;
using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.Entity
{
    public class Responsavel : Abstraction.Entity
    {
        public Guid ID { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string Foto { get; private set; }
        public IEnumerable<Processo> Processos { get; private set; }
        private Responsavel() { }
        private Responsavel(Guid id,
                            string nome,
                            string cpf,
                            string email,
                            string foto)
        {
            ID = id;
            Nome = ValidNome(nome);
            CPF = ValidCPF(cpf);
            Email = ValidEmail(email);
            Foto = foto;

            AddDomainEvent(new CreateResponsavelDomainEvent(this));
        }
        public static Responsavel Create(string nome,
                                         string cpf,
                                         string email,
                                         string foto)
        {
            return new Responsavel(Guid.NewGuid(),
                                   nome,
                                   cpf,
                                   email,
                                   foto);
        }
        public void Update(string nome,
                           string cpf,
                           string email,
                           string foto)
        {
            Nome = ValidNome(nome);
            CPF = ValidCPF(cpf);
            Email = ValidEmail(email);
            Foto = foto;

            AddDomainEvent(new ChangeResponsavelDomainEvent(this));
        }
        public void AddProcesso(Processo processo)
        {
            var processos = Processos?.ToList() ?? new List<Processo>();
            processos.Add(processo);
            Processos = processos;
        }
        private string ValidCPF(string cpf)
        {
            return new CPFValueObject(cpf).Value;
        }
        private string ValidNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ResponsavelNomeIsRequiredException();
            var maxLength = 150;
            if (nome.Length > maxLength)
                throw new ResponsavelNomeMaxLengthException(maxLength);
            return nome;
        }
        private string ValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ResponsavelEmailIsRequiredException();
            var maxLength = 400;
            if (email.Length > maxLength)
                throw new ResponsavelEmailMaxLengthException(maxLength);
            return new EmailValueObject(email).Value;

        }
    }
}
