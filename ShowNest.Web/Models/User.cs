using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ShowNest.Web.Models
{
    public class User
    {
        // [Key]
        [Required]
        public int UserId { get; set; }

        [Required]
        public string UserAccount { get; set; }

        [Required]
        public string Password { get; set; }

        public string? UserNickName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Mobile { get; set; }

        public DateTime? Birthday { get; set; }

        public int? Gender { get; set; }

        public int? AreaPreffered { get; set; }

        public string? PersonalUrl { get; set; }

        public string? PersonalDescription { get; set; }

        [Required]
        public bool DMSubscription { get; set; }

        public string? ProfileImage { get; set; }

        [Required]
        public int AccountStatus { get; set; }

        [Required]
        public DateTime AccountCreateTime { get; set; }

        [Required]
        public DateTime AccountLastLoginTime { get; set; }
    }
}
