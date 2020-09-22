using Schmidt.Softplan.TechnicalEvaluation.Query.Model.Model;
using System;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Application.ViewModel
{
    public class ResponsavelQueryViewModel
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public static implicit operator ResponsavelQueryViewModel(Responsavel responsavel)
        {
            return new ResponsavelQueryViewModel()
            {
                ID = responsavel.ID,
                Nome = responsavel.Nome
            };
        }
    }
}