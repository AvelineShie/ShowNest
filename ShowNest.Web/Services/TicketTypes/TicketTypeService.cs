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

        return new TicketTypeSelectionViewModel()
        {
            EventDetail = new EventDetailViewModel()
            {
                MainImage = eventDetails.EventImage,
                EventName = eventDetails.Name,
                StartTime = eventDetails.StartTime,
                EventLocation = $"{eventDetails.LocationName} / {eventDetails.LocationAddress}",
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
            TicketPriceRow = new List<TicketPriceViewModel>
            {
                new TicketPriceViewModel()
                {
                    Id = 1,
                    SeatArea = "B1特一, B1特二",
                    SeatSelectionMethod = "自行選位",
                    Tickets = new TicketsViewModel()
                    {
                        TicketTypeName = "全票",
                        TicketPrice = 3000
                    }
                },
                new TicketPriceViewModel()
                {
                    Id = 2,
                    SeatArea = "紫1D, 紫1B, 黃2C, 紫1A, 紫1C, 紅1A, 紅1B, 紅1C, 紅1D",
                    SeatSelectionMethod = "自行選位",
                    Tickets = new TicketsViewModel()
                    {
                        TicketTypeName = "全票",
                        TicketPrice = 2600
                    }
                },
                new TicketPriceViewModel()
                {
                    Id = 3,
                    SeatArea = "紫2C, 紅2B, 紫1E, 紅2D, 紅2C, 紫2B, 紫2D, 黃2B, 紅1E, 黃2D",
                    SeatSelectionMethod = "自行選位",
                    Tickets = new TicketsViewModel()
                    {
                        TicketTypeName = "全票",
                        TicketPrice = 2400
                    }
                },
                new TicketPriceViewModel()
                {
                    Id = 4,
                    SeatArea = "紫2C, 紅2B, 紅2D, 紅2C, 紫2B, 紫2D, 紫2E, 紅2E, 黃2A, 黃2E",
                    SeatSelectionMethod = "自行選位",
                    Tickets = new TicketsViewModel()
                    {
                        TicketTypeName = "全票",
                        TicketPrice = 2200
                    }
                }
            }
        };
    }
}