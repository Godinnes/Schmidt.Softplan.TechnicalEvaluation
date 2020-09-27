using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using System;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime CurrentDateTime => DateTime.UtcNow;
    }
}
