using src.ClassMapper;
using src.Validator;
using System;
using System.Collections.Generic;
using System.Text;

namespace client.Model.Mapper
{
    public class PersonMapper : ClassMapper<Person>
    {
        public PersonMapper()
        {
            To("person");

            Map(o => o.Name).To("姓名").Required();

            Map(o => o.Email).To("邮箱");

            Map(o => o.Age).To("年龄");

            Map(o => o.Gender).To("性别");

            Map(o => o.Birthday).To("生日");

            Map(o => o.Phone).To("手机").MaxLength(30);

            Validate(o => new { o.Name, o.Age }, mappers => new MaxLengthValidator(100));

            Validate(o => o.Age, mappers => new RequiredValidator());
        }
    }
}
