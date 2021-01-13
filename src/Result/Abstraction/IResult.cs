using System.Collections.Generic;
using Excel.Error.Abstraction;

namespace Excel.Result.Abstraction
{
    public interface IResult
    {
        bool IsSuccess {get;}
        List<IError> Errors {get;}

        void AddError(IError error);
        void AddError(IList<IError> errors);
        void AddError(IEnumerable<IError> errors);

        IEnumerable<string> WriteErrors();
    }
}