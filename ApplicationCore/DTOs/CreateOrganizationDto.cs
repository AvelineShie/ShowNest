namespace ApplicationCore.DTOs
{
    public class CreateOrganizationDto
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string OrganizationUrl { get; set; }
        public string OuterUrl { get; set; }
        public string Description { get; set; }
        public string FBLink { get; set; }
        public string IGAccount { get; set; }
        public string Email { get; set; }
        public string ImgUrl { get; set; }
        public string ContactName { get; set; }
        public string ContactMobile { get; set; }
        public string ContactTelephone { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EditedAt { get; set; }
    }
}
