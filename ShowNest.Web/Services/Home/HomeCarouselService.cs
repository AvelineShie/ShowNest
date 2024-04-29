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
                    //CarouselImgUrl = e.EventImage
                })
                .ToListAsync();

            result[0].CarouselImgUrl = "https://res.cloudinary.com/dwn2iafcc/image/upload/c_fill,h_360,w_1200/v1714316703/LDAV-bn_KKTIX-1140360_lkc7zn.jpg";
            result[1].CarouselImgUrl = "https://res.cloudinary.com/dwn2iafcc/image/upload/c_fill,h_360,w_1200/v1713854127/Snipaste_2024-04-22_14-41-27_fly5hx.jpg";
            result[2].CarouselImgUrl = "https://res.cloudinary.com/dwn2iafcc/image/upload/c_fill,h_360,w_1200/v1714316335/kktix____1140x360_pncumw.png";

            return result;
        }
    }
}
