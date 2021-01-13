using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace src.Excel.Internal
{
    public static class NpoiCellExtension
    {
        public static object GetValue(this ICell cell)
        {
            object res;
            switch (cell.CellType)
            {
                case CellType.Boolean:
                    res = cell.BooleanCellValue;
                    break;
                case CellType.Numeric:
                    if (DateUtil.IsCellDateFormatted(cell))
                    {
                        res = cell.DateCellValue;
                    }
                    else
                    {
                        res = cell.NumericCellValue.ToString();
                    }
                    break;
                case CellType.String:
                    res = cell.StringCellValue;
                    break;
                default:
                    res = null;
                    break;
            }
            return res;
        }
    }
}
