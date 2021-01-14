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

        public LengthValidator(long min, long max)
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
