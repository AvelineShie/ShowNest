namespace ShowNest.Web.Services.Seats;

public class SeatsService : ISeatsService
{
    private readonly ISeatRepository _seatRepository;

    public SeatsService(ISeatRepository seatRepository)
    {
        this._seatRepository = seatRepository;
    }
    
    public async Task<SeatsSelectionViewModel> GetSeatsSelectionViewModelBySeatAreaId(int seatAreaId)
    {
        var seats = await this._seatRepository.GetSeatsBySeatAreaId(seatAreaId);
        var seatViewModel = seats.Select(i => new Seat
            {
                SeatId = i.Id,
                SeatAreaId = i.SeatAreaId,
                SeatNumber = i.Number,
                SeatStatus = i.Status
            })
            .GroupBy(i => i.SeatNumber.Split("排").First())
            .Select(i=>i.ToList())
            .ToList();
            
        var viewModel = new SeatsSelectionViewModel();
        viewModel.Seats = seatViewModel;

        return viewModel;
    }
}