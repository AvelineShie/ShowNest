namespace ShowNest.Web.Services.Home
{
    public class HomeCarouselService
    {
        public List<HomeCarouselViewModel> Carousels { get; }
        public HomeCarouselService()
        {
            Carousels = new List<HomeCarouselViewModel>
            {
                new HomeCarouselViewModel
                {
                    CarouselImgUrl = "https://picsum.photos/800/180/?random=1"
                },
                new HomeCarouselViewModel
                {
                    CarouselImgUrl = "https://picsum.photos/800/180/?random=2"
                },
                new HomeCarouselViewModel
                {
                    CarouselImgUrl = "https://picsum.photos/800/180/?random=3"
                }
            };
        }
    }
}
