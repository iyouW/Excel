using src.Excel.Abstraction;
using System.Collections.Generic;
using System.IO;

namespace Excel.Excel.Abstraction
{
    public interface IExcel
    {
        void Load(Stream file);

        ISheetValidateResult Validate<T>() where T : class, new();
        ISheetReadResult<T> Read<T>() where T :class, new();
        ISheetWriteResult Write<T>(IEnumerable<T> data) where T : class, new();

        void Save(Stream file, bool leaveOpen);
    }
}