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

        public List<HomeCarouselViewModel> GetCarouselViewModel()
        {
            Random rnd = new Random();
            var result = new List<HomeCarouselViewModel>();

            for (int i = 0; i < 3; i++)
            {
                result.Add(new HomeCarouselViewModel
                {
                    CarouselImgUrl = $"https://picsum.photos/800/180/?random={rnd.Next(1, 100)}"
                });
            }

            return result;
        }
    }
}
