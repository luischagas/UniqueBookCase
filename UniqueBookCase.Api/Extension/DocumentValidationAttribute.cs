using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UniqueBookCase.Api.Extension
{
    public class DocumentValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var regex = new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$");

            if (regex.IsMatch(value.ToString()))
            {
                return true;
            }

            return false;
        }
    }
}
