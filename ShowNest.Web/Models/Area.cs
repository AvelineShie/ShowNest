namespace ShowNest.Web.Models
{
    public class Area
    {
        [Key]
        public int AreaId { get; set; }

        [Required]
        public string AreaName { get; set; }
    }
}
