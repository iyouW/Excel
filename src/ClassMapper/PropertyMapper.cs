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

        public string MapName { get; private set; }

        public PropertyInfo PropertyInfo { get; private set; }

        public PropertyMapper(PropertyInfo propertyInfo)
        {
            PropertyInfo = propertyInfo;
        }

        public PropertyMapper To(string mapName)
        {
            MapName = mapName;
            return this;
        }
    }
}
