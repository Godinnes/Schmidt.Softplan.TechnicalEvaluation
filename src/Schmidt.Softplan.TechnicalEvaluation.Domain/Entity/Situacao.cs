using System;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.Entity
{
    public class Situacao : Abstraction.Entity
    {
        public string Nome { get; private set; }
        public bool Finalizado { get; private set; }
        private Situacao() { }
        private Situacao(Guid id,
                         string nome,
                         bool finalizado)
        {
            ID = id;
            Nome = nome;
            Finalizado = finalizado;
        }
        public static Situacao Create(string nome,
                                      bool finalizado)
        {
            return new Situacao(Guid.NewGuid(),
                                nome,
                                finalizado);
        }
    }
}
