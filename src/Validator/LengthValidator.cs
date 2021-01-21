using Excel.Validator.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace src.Validator
{
    public class LengthValidator : IValidator
    {
        public long Min { get; private set; }
        public long Max { get; private set; }
        public string ErrorMessage { get; private set; }

        public LengthValidator(long min, long max, string errorMessage)
        {
            Min = min;
            Max = max;

        }

        public IValidateResult Validate(object value)
        {
            throw new NotImplementedException();
        }
    }
}
