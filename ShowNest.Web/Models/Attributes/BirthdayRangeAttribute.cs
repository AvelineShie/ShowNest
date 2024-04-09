namespace ShowNest.Web.Models.Attributes
{
    public class BirthdayRangeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime birthday)
            {
                var today = DateTime.Today;
                var age = today.Year - birthday.Year;
                if (birthday.Date > today.AddYears(-age)) age--;

                if (age < 18)
                {
                    return new ValidationResult("您必須滿18歲才能註冊。");
                }
                else if (age > 130)
                {
                    return new ValidationResult("您的年齡超出我們的註冊範圍。");
                }
            }

            return ValidationResult.Success;
        }
    }
}
