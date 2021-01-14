using Excel.Validator.Abstraction;
using src.ClassMapper.Abstraction;
using src.Validator;
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

        public List<IValidator> Validators { get; private set; }

        public PropertyMapper(PropertyInfo propertyInfo)
        {
            PropertyInfo = propertyInfo;
            Validators = new List<IValidator>();
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

        public PropertyMapper Required()
        {
            var validator = new RequiredValidator();
            Validators.Add(validator);
            return this;
        }

        public PropertyMapper MaxLength(long max)
        {
            var validator = new MaxLengthValidator(max);
            Validators.Add(validator);
            return this;
        }
    }
}
