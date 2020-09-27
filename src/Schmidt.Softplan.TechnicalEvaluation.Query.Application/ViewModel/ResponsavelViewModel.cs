using Schmidt.Softplan.TechnicalEvaluation.Query.Model.Model;
using System;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Application.ViewModel
{
    public class ResponsavelViewModel
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Foto { get; set; }
        public static implicit operator ResponsavelViewModel(Responsavel responsavel)
        {
            return new ResponsavelViewModel()
            {
                ID = responsavel.ID,
                Nome = responsavel.Nome,
                CPF = responsavel.CPF,
                Foto = responsavel.Foto
            };
        }
    }
}
