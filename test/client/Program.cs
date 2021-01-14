using client.Model;
using src.Excel;
using System;
using System.IO;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var fs = new FileStream(@"Excel/Person.xlsx", FileMode.Open, FileAccess.Read))
            {
                var excel = new NpoiExcel();
                excel.Load(fs);
                var res = excel.Read<Person>();
                Console.WriteLine(res);

                var excel1 = new NpoiExcel();
                excel1.Load(null);
                excel1.Write(res.Data);

                using (var fs1 = new FileStream("Excel/Person_Copy.xlsx", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    excel1.Save(fs1,false);
                }
            }
        }
    }
}