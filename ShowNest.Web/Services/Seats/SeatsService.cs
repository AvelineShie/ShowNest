namespace ShowNest.Web.Services.Seats;

public class SeatsService : ISeatsService
{
    private readonly ISeatRepository _seatRepository;
    private readonly ISeatAreaRepository _seatAreaRepository;
    private readonly ITicketTypeRepository _ticketTypeRepository;

    public SeatsService(ISeatRepository seatRepository, ISeatAreaRepository seatAreaRepository, ITicketTypeRepository ticketTypeRepository)
    {
        this._seatRepository = seatRepository;
        this._seatAreaRepository = seatAreaRepository;
        this._ticketTypeRepository = ticketTypeRepository;
    }

    public async Task<SeatsSelectionViewModel> GetSeatsSelectionViewModelBySeatAreaId(int seatAreaId)
    {
        var seatArea = this._seatAreaRepository.GetById(seatAreaId);
        
        var seats = await this._seatRepository.GetSeatsBySeatAreaId(seatAreaId);
        var seatViewModel = seats.Select(i => new SeatViewModel
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
        viewModel.SeatAreaName = seatArea.Name;
        viewModel.ExpireTime = DateTime.UtcNow;
        viewModel.Seats = seatViewModel;

        return viewModel;
    }
}