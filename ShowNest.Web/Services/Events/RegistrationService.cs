
namespace ShowNest.Web.Services.Events
{
    public class RegistrationService
    {
        public RegistrationViewModel GetRegistrationInfo()
        {
            return new RegistrationViewModel()
            {
                EventName = "【ALTA】theLOOP presents : PSY.P 臺灣個人巡演預熱戰",
                StartTime = DateTime.Now,
                EventLocation = "ALTA NIGHTCLUB",
                EventAddress = "台中市西屯區青海南街59號",
                EventHost = "歐達休閒娛樂有限公司",
                TicketCollectionChannel = "台灣全家 FamiPort 取票",
                PaymentMethodName = "ATM 虛擬帳號、信用卡",
                TicketSeats = new List<Tickets>
                {
                    new Tickets {
                        SeatArea ="B2 區",
                        SeatRow ="17 排",
                        SeatNumber="8 號",
                        TicketTypeName="全票 ",
                        TicketPrice=3680,
                        PurchaseAmount=1,
                    },
                     new Tickets {
                        SeatArea ="B3 區",
                        SeatRow ="15 排",
                        SeatNumber="88 號",
                        TicketTypeName="半票 ",
                        TicketPrice=3680,
                        PurchaseAmount=1,
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
