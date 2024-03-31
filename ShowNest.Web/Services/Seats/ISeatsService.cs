namespace ShowNest.Web.Services.Seats;

public interface ISeatsService
{
    public Task<SeatsSelectionViewModel> GetSeatsSelectionViewModelBySeatAreaId(int seatAreaId);
}