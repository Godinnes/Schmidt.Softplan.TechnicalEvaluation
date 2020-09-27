using System;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction
{
    public interface IDateTimeService
    {
        DateTime CurrentDateTime { get; }
    }
}
