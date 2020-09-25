using Schmidt.Softplan.TechnicalEvaluation.Common.Exception;
using System;
using System.Text.RegularExpressions;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.ValueObjects
{
    public struct EmailValueObject
    {
        public string Value { get; set; }
        public EmailValueObject(string email)
        {
            Value = email;
            if (!IsValid())
                throw new EmailInvalidException();
        }
        private bool IsValid()
        {
            try
            {
                return Regex.IsMatch(Value,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
