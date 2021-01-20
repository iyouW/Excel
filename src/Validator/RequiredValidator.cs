using Excel.Validator.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace src.Validator
{
    public class RequiredValidator : IValidator
    {
        
        public IValidateResult Validate(object value)
        {
            var res = new ValidateResult();
            throw new NotImplementedException();
        }
    }
}
