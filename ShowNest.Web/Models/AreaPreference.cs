namespace ShowNest.Web.Models
{
    public class AreaPreference
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Key]
        [ForeignKey("Area")]
        public int AreaId { get; set; }

        public virtual User User { get; set; }
        public virtual Area Area { get; set; }
    }
}
