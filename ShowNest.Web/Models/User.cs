using System.ComponentModel;
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
        [StringLength(100)]
        public string UserAccount { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Column(TypeName = "char(255)")]
        public string Password { get; set; }

        [StringLength(50)]
        public string UserNickName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Mobile { get; set; }

        public DateTime? Birthday { get; set; }

        public int? Gender { get; set; }

        public int? AreaPreffered { get; set; }

        [Url]
        public string PersonalUrl { get; set; }

        [StringLength(300)]
        public string PersonalDescription { get; set; }

        [Required]
        [DefaultValue(1)]
        public bool DMSubscription { get; set; }

        public string ProfileImage { get; set; }

        [Required]
        [DefaultValue(1)]
        public int AccountStatus { get; set; }

        [Required]
        public DateTime AccountCreateTime { get; set; }

        [Required]
        public DateTime AccountLastLoginTime { get; set; }
    }
}
