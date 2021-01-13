using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace src.ClassMapper.Abstraction
{
    public interface IPropertyMapper
    {
        string Name { get; }
        string MapName { get; }
        PropertyInfo PropertyInfo { get; }
    }
}
