using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace UniqueBookCase.Api.Extensions
{
    public class UniqueIdentificatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var regex = new Regex(@"^[A-Z0-9]{3}\-[A-Z0-9]{2}\-[A-Z0-9]{3}\-[A-Z0-9]{4}\-[A-Z0-9]{1}$");

            if (regex.IsMatch(value.ToString()))
            {
                return true;
            }

            return false;
        }
    }
}

