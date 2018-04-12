using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBet.Validators.Users
{
    public class Major : ValidationAttribute
    {
        private int _years;
        public Major(int years)
        {
            _years = years;
        }

        public override bool IsValid(object value)
        {
            if (value is DateTime)
            {
                DateTime dt = (DateTime)value;
                return dt.AddYears(_years) <= DateTime.Now;
            }
            return base.IsValid(value);
        }
    }
}
