namespace ShowNest.Web.ViewModels.Events;

public class TicketTypeSelectionViewModel
{
    public EventDetailsViewModel EventDetails { get; set; }
    public List<PaymentMethodViewModel> PaymentMethods { get; set; }
    public string PaymentMethodsForDisplay
    {
        get { return string.Join('、', this.PaymentMethods.Select(i => i.PaymentMethodName)); }
    }
    public List<StepStatusViewModel> StepStatus { get; set; }
    public List<TicketPriceTableViewModel> TicketPriceTable { get; set; }
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
}