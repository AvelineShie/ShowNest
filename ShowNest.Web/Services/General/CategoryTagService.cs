namespace ShowNest.Web.Services.General
{
    public class CategoryTagService
    {
        public IEnumerable<CategoryTagsVeiwModel> CategoryTags { get; }

        public CategoryTagService()
        {
            CategoryTags = new List<CategoryTagsVeiwModel>
            {
                new CategoryTagsVeiwModel
                {
                    Category = "Music"
                },
                new CategoryTagsVeiwModel
                {
                    Category = "Drama"
                },
                new CategoryTagsVeiwModel
                {
                    Category = "Exhibition"
                },
                new CategoryTagsVeiwModel
                {
                    Category = "Concert"
                },
                new CategoryTagsVeiwModel
                {
                    Category = "Drama"
                },
                new CategoryTagsVeiwModel
                {
                    Category = "Movie"
                },
                new CategoryTagsVeiwModel
                {
                    Category = "Art"
                },
                new CategoryTagsVeiwModel
                {
                    Category = "Sport"
                },
                new CategoryTagsVeiwModel
                {
                    Category = "Technology"
                },
                new CategoryTagsVeiwModel
                {
                    Category = "Travel"
                },
                new CategoryTagsVeiwModel
                {
                    Category = "Online Event"
                },
            };
        }
    }
}
