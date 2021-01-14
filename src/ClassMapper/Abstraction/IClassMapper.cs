using Excel.Validator.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace src.ClassMapper.Abstraction
{
    public interface IClassMapper
    {
        string MapName { get; }
        List<IPropertyMapper> PropertyMappers { get; }
        List<IValidator> Validators { get; }
    }

    public interface IClassMapper<T> : IClassMapper
        where T : class
    { 
    }
}
