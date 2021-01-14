using Excel.Validator.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace src.Validator
{
    public class MaxLengthValidator : IValidator
    {
        public long Max { get; private set; }

        public MaxLengthValidator(long max)
        {
            Max = max;
        }

        public IValidateResult Validate(object value)
        {
            throw new NotImplementedException();
        }
    }
}
