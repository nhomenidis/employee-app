using System;
using System.ComponentModel.DataAnnotations;

namespace Employee.Business.Validators
{
    public class AgeAttribute : ValidationAttribute
    {
        private int _age;

        public AgeAttribute(int age)
        {
            _age = age;
        }
        public override bool IsValid(object value)
        {
            var dateTime = (DateTime)value;
            var lowerDateTime = DateTime.Now.AddYears(-_age);

            if (lowerDateTime < dateTime)
            {
                return false;
            }

            return true;
        }
    }
}
