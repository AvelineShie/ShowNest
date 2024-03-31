
using ApplicationCore.Entities;
using System.Linq;
using Ticket = ApplicationCore.Entities.Ticket;

namespace ShowNest.Web.Services.Events
{
    public interface IOrderCenterService
    {
        OrderDetailViewModel GetMemberOrders(int userId);
    }
    public interface IRregistrationFakedata
    {
        RegistrationViewModel GetRegistrationInfo();
    }
    public class OrderTicketService : IOrderCenterService
    {
        private readonly IOrderQueryService _orderQueryService;
        private readonly int _userId;
        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<ArchiveOrder> _archiveOrderRepo;
        private readonly IRepository<Ticket> _ticket;
        public OrderTicketService(IOrderQueryService orderQueryService,
            IRepository<Order> orderRepo,
            IRepository<ArchiveOrder> archiveOrderRepo,
            IRepository<Ticket> ticket)
        {
            _orderQueryService = orderQueryService;

            //_userId = httpContextAccessor.HttpContext?.User?.Identity?.Name ?? string.Empty;
            _userId = 1;
            _orderRepo = orderRepo;
            _archiveOrderRepo = archiveOrderRepo;
            _ticket = ticket;
        }

        public OrderDetailViewModel GetMemberOrders(int userId)
        {
            var totalPrice = _orderQueryService.GetCustomerOrderTotalAmount(userId);
            var orders = _orderQueryService.GetOrdersByUserId(userId);
            var result = new OrderDetailViewModel
            {
                MemberCenterOrders = new List<MemberCenterOrders>()
            };
            foreach (var order in orders)
            {
                var orderDetailQueryDto = order.orderDetailQueryDtos?.SingleOrDefault();
                if (orderDetailQueryDto != null)
                {
                    var tempResult = new MemberCenterOrders
                    {
                        OrderId = order.OrderId,
                        UserId = order.UserId,
                        OrderStatus = order.OrderStatus,
                        EventName = order.EventName,
                        EventHost = order.EventHost ?? string.Empty,
                        StartTime = order.OrderDate,
                        EventLocation = order.LocationName,
                        EventAddress = order.LocationAddress,
                        PaymentMethod = order.PaymentType,
                        UserName = order.UserName,
                        Email = order.UserEmail,
                        PhoneNumber = order.UserPhoneNumber,
                        AllTickets = new List<AllTickets>
                        {
                            new AllTickets
                            {
                                TicketId = orderDetailQueryDto.TicketId,
                                TicketTypeId = orderDetailQueryDto.TicketTypeId,
                                TicketTypeName = orderDetailQueryDto.TicketTypeName,
                                TicketNumber = orderDetailQueryDto.TicketNumber,
                                SeatAreaId = orderDetailQueryDto.SeatAreaId,
                                SeatArea = orderDetailQueryDto.SeatArea,
                                SeatsId = orderDetailQueryDto.SeatsId,
                                SeatNumber = orderDetailQueryDto.SeatNumber,
                                TicketPrice = orderDetailQueryDto.TicketPrice,
                                PurchaseAmount = orderDetailQueryDto.PurchaseAmount
                            }
                        }
                    };  
                    result.MemberCenterOrders.Add(tempResult);
                }
            }
            return result;
        }

        public RegistrationViewModel GetRegistrationsFakeData()
        {
            return new RegistrationViewModel()
            {
                EventName = "【ALTA】theLOOP presents : PSY.P 臺灣個人巡演預熱戰",
                StartTime = DateTime.Now,
                EventLocation = "ALTA NIGHTCLUB",
                EventAddress = "台中市西屯區青海南街59號",
                EventHost = "歐達休閒娛樂有限公司",
                PaymentMethodName = "ATM 虛擬帳號、信用卡",
                TicketSeats = new List<Tickets>
                {
                    new Tickets {
                        SeatArea = "B2 區 17 排",
                        SeatNumber = "8 號",
                        TicketTypeName = "全票 ",
                        TicketPrice = 3680,
                        PurchaseAmount = 1,
                    },
                    new Tickets {
                        SeatArea = "B3 區 15 排",
                        SeatNumber = "88 號",
                        TicketTypeName = "半票 ",
                        TicketPrice = 3680,
                        PurchaseAmount = 1,
                    }
                },
                TotalPrice = 3680,
                Name = "志明與春嬌",
                PhoneNumber = "+88697812345",
                Email = "1234@gmail.com"

            };

        }

    }
}





