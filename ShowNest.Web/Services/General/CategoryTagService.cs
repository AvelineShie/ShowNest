namespace ShowNest.Web.Services.General
{
    public class CategoryTagService
    {
        public List<CategoryTagsVeiwModel> CategoryTags { get; }

        public CategoryTagService()
        {
            CategoryTags = new List<CategoryTagsVeiwModel>
            {
                new CategoryTagsVeiwModel
                {
                    Id = 1,
                    CategoryNameEng = "Music",
                    CategoryNameZh = "音樂"
                },
                new CategoryTagsVeiwModel
                {
					Id = 2,
					CategoryNameEng = "Drama",
					CategoryNameZh = "戲劇"
				},
                new CategoryTagsVeiwModel
                {
					Id = 3,
					CategoryNameEng = "Exhibition",
					CategoryNameZh = "展覽"
				},
                new CategoryTagsVeiwModel
                {
					Id = 4,
					CategoryNameEng = "Concert",
					CategoryNameZh = "演唱會"
				},
                new CategoryTagsVeiwModel
                {
					Id = 5,
					CategoryNameEng = "Seminar",
					CategoryNameZh = "講座"
				},
                new CategoryTagsVeiwModel
                {
					Id = 6,
					CategoryNameEng = "Movie",
					CategoryNameZh = "電影"
				},
                new CategoryTagsVeiwModel
                {
					Id = 7,
					CategoryNameEng = "Art",
					CategoryNameZh = "藝術"
				},
                new CategoryTagsVeiwModel
                {
                    Id = 8,
					CategoryNameEng = "Sport",
					CategoryNameZh = "運動"
				},
                new CategoryTagsVeiwModel
                {
					Id = 9,
					CategoryNameEng = "Technology",
					CategoryNameZh = "科技"
				},
                new CategoryTagsVeiwModel
                {
					Id = 10,
					CategoryNameEng = "Travel",
					CategoryNameZh = "旅遊"
				},
                new CategoryTagsVeiwModel
                {
					Id = 11,
					CategoryNameEng = "Online Event",
					CategoryNameZh = "線上活動"
				},
            };
        }

        public List<CategoryTagsVeiwModel> GetAllCategoryTags()
        {
            return CategoryTags.ToList();
        }
    }
}
