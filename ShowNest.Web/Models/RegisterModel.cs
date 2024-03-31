public class RegisterModel
{
    [Required]
    public string Account { get; set; } // 添加使用者名稱屬性

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "這個{0}必須要{2} 個字元長", MinimumLength = 8)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "密碼輸入不正確，請確認是否正確輸入")]
    public string ConfirmPassword { get; set; }

    [DataType(DataType.Date)]
    [BirthdayRange] // 應用自訂驗證屬性
    public DateTime Birthday { get; set; }


}
