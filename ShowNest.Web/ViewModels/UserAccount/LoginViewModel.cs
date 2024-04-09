namespace ShowNest.Web.ViewModels.UserAccount
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "請輸入使用者名稱或email")]
        public string Account { get; set; }

        [Required(ErrorMessage = "請輸入密碼")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
