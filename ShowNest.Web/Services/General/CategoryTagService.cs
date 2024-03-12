namespace ShowNest.Web.Services.General
{
    public class CategoryTagService
    {
        public List<CategoryTagsViewModel> CategoryTags { get; }

        public CategoryTagService()
        {
            CategoryTags = new List<CategoryTagsViewModel>
            {
                new CategoryTagsViewModel
                {
                    Id = 1,
                    CategoryNameEng = "Music",
                    CategoryNameZh = "音樂"
                },
                new CategoryTagsViewModel
                {
					Id = 2,
					CategoryNameEng = "Drama",
					CategoryNameZh = "戲劇"
				},
                new CategoryTagsViewModel
                {
					Id = 3,
					CategoryNameEng = "Exhibition",
					CategoryNameZh = "展覽"
				},
                new CategoryTagsViewModel
                {
					Id = 4,
					CategoryNameEng = "Concert",
					CategoryNameZh = "演唱會"
				},
                new CategoryTagsViewModel
                {
					Id = 5,
					CategoryNameEng = "Seminar",
					CategoryNameZh = "講座"
				},
                new CategoryTagsViewModel
                {
					Id = 6,
					CategoryNameEng = "Movie",
					CategoryNameZh = "電影"
				},
                new CategoryTagsViewModel
                {
					Id = 7,
					CategoryNameEng = "Art",
					CategoryNameZh = "藝術"
				},
                new CategoryTagsViewModel
                {
                    Id = 8,
					CategoryNameEng = "Sport",
					CategoryNameZh = "運動"
				},
                new CategoryTagsViewModel
                {
					Id = 9,
					CategoryNameEng = "Technology",
					CategoryNameZh = "科技"
				},
                new CategoryTagsViewModel
                {
					Id = 10,
					CategoryNameEng = "Travel",
					CategoryNameZh = "旅遊"
				},
                new CategoryTagsViewModel
                {
					Id = 11,
					CategoryNameEng = "Online Event",
					CategoryNameZh = "線上活動"
				},
            };
        }

        public List<CategoryTagsViewModel> GetAllCategoryTags()
        {
            return CategoryTags.ToList();
        }

		public List<CategoryTagsViewModel> GetCategoryTagsById(List<int> inputList)
		{
			//foreach (var id in inputList)
			//{
			//	result.AddRange(CategoryTags.Where(item => item.Id == id));
			//}

			var result = inputList.SelectMany(id => CategoryTags.Where(tag => tag.Id == id)).ToList();

			return result;
		}
	}
}
