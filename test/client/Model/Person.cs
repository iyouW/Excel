using System;
using System.Collections.Generic;
using System.Text;

namespace client.Model
{
    public enum Gender
    {
        Unknow = 0,
        Male = 1,
        Female = 2
    }

    public class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
    }
}
