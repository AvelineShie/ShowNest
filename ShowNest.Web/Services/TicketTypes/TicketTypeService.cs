using ShowNest.Web.ViewModels.Tickets;

namespace ShowNest.Web.Services.TicketTypes;

public class TicketTypeService : ITicketTypeService
{
    private readonly DatabaseContext _dbContext;

    public TicketTypeService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TicketTypeSelectionViewModel> GetTicketTypesByEventId(int eventId)
    {
        var eventDetails = await _dbContext.Events
            .Include(i => i.Organization)
            .Where(i => i.Id == eventId)
            .FirstOrDefaultAsync();

        var ticketTypes = await _dbContext.TicketTypes
            .Include(i => i.TicketTypeAndSeatAreaMappings)
            .Where(i => i.EventId == eventId)
            .Select(i => new TicketPriceViewModel()
            {
                Id = i.Id,
                SeatArea = string.Join(",", i.TicketTypeAndSeatAreaMappings
                    .Select(j => j.SeatArea.Name).ToList()),
                SeatSelectionMethod = "自行選位",
                Tickets = new TicketsViewModel()
                {
                    TicketTypeName = i.Name,
                    TicketPrice = i.Price,
                }
            })
            .ToListAsync();

        return new TicketTypeSelectionViewModel()
        {
            EventDetail = new EventDetailViewModel()
            {
                EventId = eventDetails.Id,
                MainImage = eventDetails.EventImage,
                EventName = eventDetails.Name,
                StartTime = eventDetails.StartTime,
                EventLocation = $"{eventDetails.LocationName} / {eventDetails.LocationAddress}",
                LocationLongitude = eventDetails.Longitude,
                LocationLatitude = eventDetails.Latitude,
                EventHost = eventDetails.Organization.Name,
                TicketCollectionChannel = "電子票券",
                SeatAreaImage = "https://danichen12.github.io/00Project/booking/image/map.png"
            },
            PaymentMethods = new List<PaymentMethodViewModel>
            {
                new PaymentMethodViewModel()
                {
                    PaymentMethodName = "信用卡"
                },
                new PaymentMethodViewModel()
                {
                    PaymentMethodName = "ATM"
                }
            },
            TicketPriceRow = ticketTypes
        };
    }

    public async Task<AutoSeatSelectionResponseViewModel> GetAutoSelectedSeats(
        AutoSeatSelectionRequestViewModel request)
    {
        var tickets = new List<AutoSelectedSeatViewModel>();

        foreach (var criteria in request.Criteria)
        {
            var query = from ticketType in _dbContext.TicketTypes
                join ticket in _dbContext.Tickets on ticketType.Id equals ticket.TicketTypeId
                join seat in _dbContext.Seats on ticket.SeatId.Value equals seat.Id
                where seat.Status == 0 && ticketType.Id == criteria.TicketTypeId
                orderby seat.Id
                select new AutoSelectedSeatViewModel
                {
                    Price = ticketType.Price,
                    SeatAreaId = seat.SeatArea.Id,
                    SeatAreaName = seat.SeatArea.Name,
                    SeatId = seat.Id,
                    SeatNumber = seat.Number,
                    TicketTypeName = ticketType.Name,
                    TicketId = ticket.Id
                };
            var result = await query.Take(criteria.TicketCount).ToListAsync();

            tickets.AddRange(result);
        }

        return new AutoSeatSelectionResponseViewModel
        {
            Tickets = tickets
        };
    }
}