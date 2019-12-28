using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace UniqueBookCase.Api.Extensions
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
