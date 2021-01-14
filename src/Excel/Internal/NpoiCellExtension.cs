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

        public static void WriteValue(this ICell cell, object value)
        {
            if (value == null)
            {
                cell.SetCellValue(string.Empty);
            }
            switch (value)
            {
                case bool b:
                    cell.SetCellValue(b);
                    break;
                case int i:
                    cell.SetCellValue(i);
                    break;
                case long l:
                    cell.SetCellValue(l);
                    break;
                case double d:
                    cell.SetCellValue(d);
                    break;
                case string s:
                    cell.SetCellValue(s);
                    break;
                case DateTime dt:
                    cell.SetCellValue(dt.ToString());
                    break;
                default:
                    cell.SetCellValue(value.ToString());
                    break;
            }
        }
    }
}
