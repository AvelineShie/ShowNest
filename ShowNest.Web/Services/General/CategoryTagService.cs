namespace ShowNest.Web.Services.General
{
    public class CategoryTagService
    {
        private readonly CategoryTagsRepository _categoryTagsRepository;

        public CategoryTagService(CategoryTagsRepository categoryTagsRepository)
        {
            _categoryTagsRepository = categoryTagsRepository;
        }

        public async Task<List<CategoryTagsViewModel>> GetAllCategoryTags()
        {
            var query = _categoryTagsRepository.All();
            var result = new List<CategoryTagsViewModel>();
            foreach (var categoryTag in query)
            {
                result.Add(new CategoryTagsViewModel
                {
                    Id = categoryTag.Id,
                    CategoryName = categoryTag.Name,
                });
            }
            return result;
        }

		public List<CategoryTagsViewModel> GetCategoryTagsById(List<int> inputList)
		{

            //var query = _categoryTagsRepository.All();

            var result = new List<CategoryTagsViewModel>();
            //var result = inputList.SelectMany(id => query.Where(tag => tag.Id == id)).ToList();
            //foreach (var categoryTag in query)
            //{
            //    result.Add(new CategoryTagsViewModel
            //    {
            //        Id = categoryTag.Id,
            //        CategoryName = categoryTag.Name,
            //    });
            //}
            return result;
        }
	}
}
