using ShowNest.Web.ViewModels.UserAccount;

namespace ShowNest.Web.ViewModels.Events
{
    public class RegistrationViewModel
    {
        public EventDetailsViewModel EventDetails { get; set; }
        public TicketTypeViewModel Ticket { get; set; }
        public SelectSeatsViewModel Seat { get; set; }
        public PrefillsInfoViewModel Prefills { get; set; }

        public bool ShownParticipatedCampaign { get; set; }

    }
}
