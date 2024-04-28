using ApplicationCore.Entities;
using ShowNest.Web.ViewModels.Orders;
using Ticket = ApplicationCore.Entities.Ticket;

namespace ShowNest.Web.Services.Events
{
    public interface IRregistrationFakedata
    {
        RegistrationViewModel GetRegistrationInfo();
    }

    public class OrderTicketService
    {
        private readonly IOrderQueryService _orderQueryService;
        private readonly IEcpayOrderService _ecpayOrderServcie;
        private readonly int _userId;
        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<ArchiveOrder> _archiveOrderRepo;
        private readonly IRepository<Ticket> _ticket;
        private readonly DatabaseContext _dbContext;

        public OrderTicketService(IOrderQueryService orderQueryService,
            IEcpayOrderService ecpayOrderService,
            IRepository<Order> orderRepo,
            IRepository<ArchiveOrder> archiveOrderRepo,
            IRepository<Ticket> ticket,
            DatabaseContext dbContext)
        {
            _orderQueryService = orderQueryService;
            _ecpayOrderServcie = ecpayOrderService;

            //_userId = httpContextAccessor.HttpContext?.User?.Identity?.Name ?? string.Empty;
            //_userId = 1;
            _orderRepo = orderRepo;
            _archiveOrderRepo = archiveOrderRepo;
            _ticket = ticket;
            _dbContext = dbContext;
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
                    new Tickets
                    {
                        SeatArea = "B2 區 17 排",
                        SeatNumber = "8 號",
                        TicketTypeName = "全票 ",
                        TicketPrice = 3680,
                        PurchaseAmount = 1,
                    },
                    new Tickets
                    {
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

        //更新訂單明細聯絡人資訊 UpdateOrder details contact information
        //根據orderID
        //傳入姓名email 手機 參數
        //不回傳值 void
        /*public async Task<Order> UpdateOrderDetailContactInfoByOrderId(string name,string email,string phone,int orderid)
        {
            //根據orderID找到那筆order
            var targetOrder = await _orderRepo.GetByIdAsync(orderid);
            if (targetOrder is null )
            {
                return null;
            }
            //更新聯絡人資訊
            var contactInfo = new ContactInfo
            {
                Name = name,
                Email = email,
                PhoneNumber = phone
            };

            string contactJsonString = JsonConvert.SerializeObject(contactInfo);
            targetOrder.ContactPerson = contactJsonString;
            return await _orderRepo.UpdateAsync(targetOrder);





        }*/
        public async Task<Order> UpdateOrderDetailContactInfoByOrderId(string contactJsonString, int orderid)
        {
            //根據orderID找到那筆order
            var targetOrder = await _orderRepo.GetByIdAsync(orderid);

            targetOrder.ContactPerson = contactJsonString;
            return await _orderRepo.UpdateAsync(targetOrder);
        }


        public async Task<CreateOrderResponse> CreateOrder(int userId, CreateOrderRequest request)
        {
            _dbContext.Database.BeginTransaction();

            // Create Order
            var order = new Order
            {
                UserId = userId,
                EventId = request.EventId,
                PaymentType = 1,
                Status = 0,
                IsDeleted = false,
                ContactPerson = JsonConvert.SerializeObject(request.ContactInformation),
                IsDisplayed = false,
                CreatedAt = DateTime.UtcNow,
                EcpayTradeNo = _ecpayOrderServcie.GenerateOrderIdAsync()
            };
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            foreach (var ticketViewModel in request.Tickets)
            {
                var ticket = _dbContext.Tickets
                    .FirstOrDefault(i => i.Id == ticketViewModel.TicketId);
                ticket.OrderId = order.Id;

                if (ticketViewModel.HasSeat)
                {
                    var seat = _dbContext.Seats
                        .FirstOrDefault(i => i.Id == ticketViewModel.SeatId);
                    seat.Status = 2;
                }
            }

            _dbContext.SaveChanges();
            _dbContext.Database.CommitTransaction();

            return new CreateOrderResponse
            {
                OrderId = order.Id
            };
        }
    }
}