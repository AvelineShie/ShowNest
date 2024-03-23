
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace ShowNest.Web.Services.Events
{
    public interface ITicketOrderService
    {
        RegistrationViewModel RegistrationTicketOrders();
    }
    public class OrderTicketService : ITicketOrderService
    {
        private readonly DatabaseContext _context;
        public OrderTicketService(DatabaseContext context)
        {
            _context = context;
        }
        public RegistrationViewModel RegistrationTicketOrders()//int eventId, int orderId
        {
            //var eventId = _context.Events.Any(e=>e.Id== orderId); // Assume this is the ID provided by the user
            var eventInfo = _context.Events.FirstOrDefault();//e => e.Id == eventId
            var order = _context.Order.FirstOrDefault();
            var seats=_context.Seats.FirstOrDefault();
            var seatArea=_context.SeatAreas.FirstOrDefault();
            var archiveOrder = _context.ArchiveOrders.FirstOrDefault();
            var userPreFillInfo = _context.PreFills.FirstOrDefault();
            var logInInfo =_context.LogInInfos.FirstOrDefault();


            if (eventInfo == null || order == null || seats == null || seatArea == null)
            {
                // 如果找不到事件資訊，則返回 null 或者拋出異常
                return null;
            }
            // 將資料填充到 RegistrationViewModel 中
            return new RegistrationViewModel
            {
                EventName = eventInfo.Name,
                StartTime = eventInfo.StartTime,
                EventId = eventInfo.Id.ToString(),
                EventLocation = eventInfo.LocationAddress,
                EventAddress = eventInfo.LocationAddress,
                EventHost = eventInfo.MainOrganizer,
                TicketCollectionChannel = "線上QRcode",
                PaymentMethodName = order.PaymentType.ToString(),
                TicketSeats = new List<Tickets>
                {
                    new Tickets
                    {
                        SeatArea=seatArea.Name,
                        SeatNumber=seats.Number,
                        TicketTypeName=archiveOrder.TicketTypeName,
                        TicketPrice=archiveOrder.TicketPrice,
                        PurchaseAmount=archiveOrder.PurchaseAmount
                    }
                   
                },
                TotalPrice = archiveOrder.TicketPrice * archiveOrder.PurchaseAmount,
                Name= userPreFillInfo.Name,
                PhoneNumber = userPreFillInfo.Mobile,
                Email = logInInfo.Email,
                ShownParticipatedCampaign=order.IsDisplayed
            }; 
        }
    }
}
    //public class OrderTicketService
    //{
    //    //private readonly OrderTicketService _registrationService;
    //    //public OrderTicketService(OrderTicketService registrationService)
    //    //{
    //    //    _registrationService = registrationService;
    //    //}

    //    //public RegistrationViewModel GetRegistrationInfo()
    //    //{
    //    //    return new RegistrationViewModel()
    //    //    {
    //    //        EventName = "【ALTA】theLOOP presents : PSY.P 臺灣個人巡演預熱戰",
    //    //        StartTime = DateTime.Now,
    //    //        EventLocation = "ALTA NIGHTCLUB",
    //    //        EventAddress = "台中市西屯區青海南街59號",
    //    //        EventHost = "歐達休閒娛樂有限公司",
    //    //        TicketCollectionChannel = "電子票卷取票",
    //    //        PaymentMethodName = "ATM 虛擬帳號、信用卡",
    //    //        TicketSeats = new List<Tickets>
    //    //        {
    //    //            new Tickets {
    //    //                SeatArea ="B2 區",
    //    //                SeatRow ="17 排",
    //    //                SeatNumber="8 號",
    //    //                TicketTypeName="全票 ",
    //    //                TicketPrice=3680,
    //    //                PurchaseAmount=1,
    //    //            },
    //    //             new Tickets {
    //    //                SeatArea ="B3 區",
    //    //                SeatRow ="15 排",
    //    //                SeatNumber="88 號",
    //    //                TicketTypeName="半票 ",
    //    //                TicketPrice=3680,
    //    //                PurchaseAmount=1,
    //    //            }
    //    //        },
    //    //        TotalPrice = 3680,
    //    //        Name = "志明與春嬌",
    //    //        PhoneNumber = "+88697812345",
    //    //        Email = "1234@gmail.com"

    //    //    };

    //    //}
           

       



    //    //    public RegistrationViewModel GetRegistrationInfo(DatabaseContext context)
    //    //    {
    //    //        var ticketSeats = new List<Tickets>
    //    //{
    //    //    new Tickets {
    //    //        SeatArea ="B2 區",
    //    //        SeatRow ="17 排",
    //    //        SeatNumber="8 號",
    //    //        TicketTypeName="全票 ",
    //    //        TicketPrice=3680,
    //    //        PurchaseAmount=1,
    //    //    },
    //    //    new Tickets {
    //    //        SeatArea ="B3 區",
    //    //        SeatRow ="15 排",
    //    //        SeatNumber="88 號",
    //    //        TicketTypeName="半票 ",
    //    //        TicketPrice=3680,
    //    //        PurchaseAmount=1,
    //    //    }
    //    //};

    //    //        var totalPrice = ticketSeats.Sum(t => t.TicketPrice * t.PurchaseAmount);

    //    //        return new RegistrationViewModel()
    //    //        {
    //    //            EventName = "【ALTA】theLOOP presents : PSY.P 臺灣個人巡演預熱戰",
    //    //            StartTime = DateTime.Now,
    //    //            EventLocation = "ALTA NIGHTCLUB",
    //    //            EventAddress = "台中市西屯區青海南街59號",
    //    //            EventHost = "歐達休閒娛樂有限公司",
    //    //            TicketCollectionChannel = "電子票卷取票",
    //    //            PaymentMethodName = "ATM 虛擬帳號、信用卡",
    //    //            TicketSeats = ticketSeats,
    //    //            TotalPrice = totalPrice,
    //    //            Name = "塗翡",
    //    //            PhoneNumber = "+88697812345",
    //    //            Email = "1234@gmail.com"
    //    //        };
    //    //    }
    //}}

