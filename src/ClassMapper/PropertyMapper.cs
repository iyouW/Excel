using Excel.Validator.Abstraction;
using src.ClassMapper.Abstraction;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace src.ClassMapper
{
    public class PropertyMapper : IPropertyMapper
    {
        public string Name => PropertyInfo.Name;

        public string MapName { get; protected set; }

        public PropertyInfo PropertyInfo { get; protected set; }

        public List<IValidator> Validators { get; protected set; }

        public PropertyMapper(PropertyInfo propertyInfo)
        {
            PropertyInfo = propertyInfo;
        }

        public PropertyMapper To(string mapName)
        {
            MapName = mapName;
            return this;
        }

        public PropertyMapper ClearValidator()
        {
            Validators.Clear();
            return this;
        }

        public PropertyMapper WithValiator(IValidator validator)
        {
            Validators.Add(validator);
            return this;
        }
    }
}
