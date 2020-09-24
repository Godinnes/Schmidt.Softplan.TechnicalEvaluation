using System;
using System.Collections.Generic;
using System.Linq;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.Entity
{
    public class Responsavel : Abstraction.Entity
    {
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
            Nome = nome;
            CPF = cpf;
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
        public void Update(string nome,
                           string cpf,
                           string email,
                           string foto)
        {
            Nome = nome;
            CPF = cpf;
            Email = email;
            Foto = foto;
        }
        public void AddProcesso(Processo processo)
        {
            var processos = Processos?.ToList() ?? new List<Processo>();
            processos.Add(processo);
            Processos = processos;
        }
    }
}
