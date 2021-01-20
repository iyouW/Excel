using Excel.Validator.Abstraction;
using src.ClassMapper.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace src.ClassMapper
{
    public class ClassMapper<T> : IClassMapper<T>
        where T : class
    {
        public string MapName { get; protected set; }

        public List<IPropertyMapper> PropertyMappers { get; protected set; }

        public List<IValidator> Validators { get; private set; }

        public ClassMapper()
        {
            PropertyMappers = new List<IPropertyMapper>();
            Validators = new List<IValidator>();
        }

        protected void To(string mapName)
        {
            MapName = mapName;
        }

        protected PropertyMapper Map(Expression<Func<T, object>> lambda)
        {
            var pi = GetMemberInfo(lambda) as PropertyInfo;
            return Map(pi);
        }

        protected PropertyMapper Map(PropertyInfo propertyInfo)
        {
            GuardForDuplicatePropertyMap(propertyInfo);
            var mapper = new PropertyMapper(propertyInfo);
            PropertyMappers.Add(mapper);
            return mapper;
        }

        protected ClassMapper<T> Validate(Expression<Func<T, object>> lambda, Func<List<IPropertyMapper>, IValidator> ValidatorFactory)
        {
            var members = GetMemberInfos(lambda);
            var propMappers = PropertyMappers.Where(o => members.Any(m => m.Name == o.Name));
            Validators.Add(ValidatorFactory(propMappers.ToList()));
            return this;
        }

        private void GuardForDuplicatePropertyMap(PropertyInfo propertyInfo)
        {
            if (PropertyMappers.Any(p => p.Name.Equals(propertyInfo.Name)))
            {
                throw new ArgumentException(string.Format("Duplicate mapping for property {0} detected.", propertyInfo.Name));
            }
        }

        private MemberInfo GetMemberInfo(LambdaExpression lambda)
        {
            Expression expr = lambda;
            for (; ; )
            {
                switch (expr.NodeType)
                {
                    case ExpressionType.Lambda:
                        expr = ((LambdaExpression)expr).Body;
                        break;
                    case ExpressionType.Convert:
                        expr = ((UnaryExpression)expr).Operand;
                        break;
                    case ExpressionType.MemberAccess:
                        MemberExpression memberExpression = (MemberExpression)expr;
                        MemberInfo mi = memberExpression.Member;
                        return mi;
                    default:
                        return null;
                }
            }
        }

        private List<MemberInfo> GetMemberInfos(LambdaExpression lambda)
        {
            var res = new List<MemberInfo>();
            var nodeType = lambda.Body.NodeType;
            if (nodeType == ExpressionType.New)
            {
                res.AddRange(((NewExpression)lambda.Body).Members);
            }
            else
            {
                res.Add(GetMemberInfo(lambda));
            }
            return res;
        }
    }
}
