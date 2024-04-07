namespace ShowNest.Web.ViewModels.UserAccount
{
    public class ChangePasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "密碼必須要 8 個字元長", MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "新密碼必須要 8 個字元長", MinimumLength = 8)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("NewPassword", ErrorMessage = "密碼重複輸入不正確，請確認是否正確輸入")]
        public string ConfirmPassword { get; set; }
    }
}
