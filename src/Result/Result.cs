using Excel.Error.Abstraction;
using Excel.Result.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace src.Result
{
    public class Result : IResult
    {
        public bool IsSuccess => Errors.Count == 0;

        public List<IError> Errors { get; set; } = new List<IError>();

        public void AddError(IError error)
        {
            Errors.Add(error);
        }

        public void AddError(IList<IError> errors)
        {
            Errors.AddRange(errors);
        }

        public void AddError(IEnumerable<IError> errors)
        {
            Errors.AddRange(errors);
        }

        public IEnumerable<string> WriteErrors()
        {
            return Errors.Select(o => o.Write());
        }
    }
}
