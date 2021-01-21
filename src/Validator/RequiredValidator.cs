using Excel.Validator.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace src.Validator
{
    public class RequiredValidator : IValidator
    {
        public string ErrorMessage { get; private set; }

        public RequiredValidator(string errorMessage)
        {
            ErrorMessage = errorMessage ?? "必填项,不允许为空";
        }

        public IValidateResult Validate(object value)
        {
            var res = new ValidateResult();
            if (value == null)
            {
                res.AddError(ErrorMessage);
            }
            if (value is string b && string.IsNullOrWhiteSpace(b))
            {
                res.AddError(ErrorMessage);
            }
            return res;
        }
    }
}
