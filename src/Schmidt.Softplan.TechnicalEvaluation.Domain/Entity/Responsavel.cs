using System;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.Entity
{
    public class Responsavel : Abstraction.Entity
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string Foto { get; private set; }
        private Responsavel() { }
        private Responsavel(Guid id,
                            string nome,
                            string cpf,
                            string email,
                            string foto)
        {
            ID = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Foto = foto;
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
    }
}
