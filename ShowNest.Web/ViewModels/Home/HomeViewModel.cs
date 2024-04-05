namespace ShowNest.Web.ViewModels.Home
{
    public class HomeViewModel
    {
        public List<HomeCarouselViewModel> HomeCarousels { get; set; }
        public List<EventCardViewModel> MainSectionTag1Cards { get; set; }
        public List<EventCardViewModel> MainSectionTag2Cards { get; set; }
        public List<EventCardViewModel> MainSectionTag3Cards { get; set; }
        public List<EventCardViewModel> SubSectionCards { get; set; }
    }
}
