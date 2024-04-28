namespace ShowNest.Web.Services.Home
{
    public class HomeCarouselService
    {
        private readonly DatabaseContext DbContext;

        public HomeCarouselService(DatabaseContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<HomeCarouselViewModel>> GetCarouselViewModel(int eventId1, int eventId2, int eventId3)
        {
            var result = await DbContext.Events
                .Where(e => e.Id == eventId1 || e.Id == eventId2 || e.Id == eventId3)
                .Select(e => new HomeCarouselViewModel
                {
                    EventId = e.Id,
                    CarouselImgUrl = e.EventImage
                })
                .ToListAsync();

            return result;
        }
    }
}
