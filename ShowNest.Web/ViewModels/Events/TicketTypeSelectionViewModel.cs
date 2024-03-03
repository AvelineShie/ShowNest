namespace ShowNest.Web.ViewModels.Events;

public class TicketTypeSelectionViewModel
{
    public TicketTypeSelectionViewModel()
    {
        this.StepStatus = new List<StepStatusViewModel>
        {
            new StepStatusViewModel() { InProgress = false, IsDisabled = false },
            new StepStatusViewModel() { InProgress = false, IsDisabled = false },
            new StepStatusViewModel() { InProgress = false, IsDisabled = false },
            new StepStatusViewModel() { InProgress = false, IsDisabled = false }
        };
    }
    
    public EventDetailsViewModel EventDetails { get; set; }
    
    public List<StepStatusViewModel> StepStatus { get; set; }
}