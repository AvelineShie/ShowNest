using ShowNest.Web.Models.Attributes;

public class RegisterViewModel
{
    [Required]
    [AccountRegex]
    public string Account { get; set; } 

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "密碼必須要 8 個字元長", MinimumLength = 8)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "密碼重複輸入不正確，請確認是否正確輸入")]
    public string ConfirmPassword { get; set; }

    [DataType(DataType.Date)]
    [BirthdayRange] // 應用自訂驗證屬性
    public DateTime Birthday { get; set; }


}
