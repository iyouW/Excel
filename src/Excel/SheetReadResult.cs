using src.Excel.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace src.Excel
{
    public class SheetReadResult<T> : Result.Result, ISheetReadResult<T>
        where T : class
    {
        public List<T> Data { get; set; } = new List<T>();
    }
}
