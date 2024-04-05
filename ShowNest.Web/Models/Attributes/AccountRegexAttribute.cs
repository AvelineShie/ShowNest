using System.Text.RegularExpressions;

namespace ShowNest.Web.Models.Attributes
{
    public class AccountRegexAttribute : ValidationAttribute
    {   
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var account = value as string;
            if (account == null)
            {
                return new ValidationResult("帳號必須為字串");
            }

            // 正則表達式，大小寫英文字母和數字
            var regex = new Regex(@"^[a-zA-Z0-9]+$");
            if (!regex.IsMatch(account))
            {
                return new ValidationResult("帳號只能使用包含大小寫英文字母與數字");
            }

            return ValidationResult.Success;
        }

    }
}
