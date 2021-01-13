using src.ClassMapper.Abstraction;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace src.ClassMapper
{
    public static class ClassMapperDict
    {
        private static readonly ConcurrentDictionary<Type, IClassMapper> _mapperDict = new ConcurrentDictionary<Type, IClassMapper>();

        public static IClassMapper GetMapper<T>()
            where T : class
        {
            return GetMapper(typeof(T));
        }

        public static IClassMapper GetMapper(Type entityType)
        {
            if (!_mapperDict.TryGetValue(entityType, out var mapper))
            {
                var mapperType = GetMapperType(entityType);
                if (mapperType == null)
                {
                    return mapper;
                }
                mapper = Activator.CreateInstance(mapperType) as IClassMapper;
                _mapperDict[entityType] = mapper;
            }
            return mapper;
        }

        public static Type GetMapperType(Type entityType)
        {
            Func<Assembly, Type, Type> FindType = (asm, entType) =>
            {
                return (from type in asm.GetTypes()
                        let interfaceType = type.GetInterface(typeof(IClassMapper<>).FullName)
                        where interfaceType != null && interfaceType.GenericTypeArguments[0] == entType
                        select type).SingleOrDefault();
            };
            return FindType(entityType.Assembly, entityType);
        }
    }
}
