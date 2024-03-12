namespace ShowNest.Web.ViewModels.Dashboard
{
    public class SetTicketPageViewModel
    {
        public string OrganizationName { get; set; }

        public List<SetTicketViewModel> SetTickets {  get; set; }

    }

    public class SetTicketViewModel
    {
        public string TicketName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Price { get; set; }
        public string Quantity { get; set; }

    }
}

