using Excel.Result.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace src.Excel.Abstraction
{
    public interface ISheetReadResult<T> : IResult
        where T : class
    {
        List<T> Data { get; }
    }
}
