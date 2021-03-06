﻿using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction
{
    public interface IResponsavelRepository
    {
        Task<Responsavel> FindAsync(Guid id);
        Task<IEnumerable<Responsavel>> GetResponsaveisByIDsAsync(IEnumerable<Guid> ids);
        void Add(Responsavel responsavel);
        void Remove(Responsavel responsavel);
        Task SaveChangesAsync();
        bool ExistsCPF(Guid id, string cpf);
        Task<bool> HasProcessoAsync(Guid id);
    }
}
