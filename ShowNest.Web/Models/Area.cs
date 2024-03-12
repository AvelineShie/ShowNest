namespace ShowNest.Web.Models
{
    public class Area
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AreaName { get; set; }
    }
}
