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
            }
        }
    }
}