namespace ShowNest.Web.Models
{
    public class AreaPreference
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Area")]
        public int AreaId { get; set; }

        public virtual User User { get; set; }
        public virtual Area Area { get; set; }
    }
}
