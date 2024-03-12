using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using ShowNest.Web.Services;
using ShowNest.Web.Services.Events;
using ShowNest.Web.Services.Event;
using ShowNest.Web.ViewModels.Events;
using ShowNest.Web.ViewModels.Organization;

namespace ShowNest.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventIndexService _eventIndexService;

        public EventsController(EventIndexService eventIndexService)
        {
            _eventIndexService = eventIndexService;
        }
        /// <summary>
        /// 測試於網址列輸入的參數並查詢資料庫內容
        /// </summary>
        /// <param name="OrganizationId"></param>
        /// <param name="EventId"></param>
        /// <returns></returns>
        //private readonly ShowNestContext _context;
        //public EventsController(ShowNestContext context)
        //{
        //    _context = context;
        //}
        //public IActionResult Index(string OrganizationId, string EventId)
        //{
        //    var organization = _context.Organizations.FirstOrDefault(x => x.OrganizationId == OrganizationId);
        //    if (organization == null)
        //    {
        //        // 組織不存在，返回相應的頁面或錯誤訊息
        //        return NotFound(); // 或者其他適當的處理
        //    }

        //    // 組織存在，繼續執行其他操作
        //    return View();
        //}
        //以上測試中--------------------------------------------------------------

        private readonly RegistrationService _registrationService;
        public EventsController (RegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        public IActionResult Index()
        {
            var eventIndexViewModel = _eventIndexService.GetEventIndexViewModel();

			return View(eventIndexViewModel);
        }

        public IActionResult EventPage()
        {
            var model = new EventPageViewModel()
            {

                MainImage = "https://picsum.photos/1300/600/?random=10",
                EventName = "Build School Demo Test Activity",
                EventTime = DateTime.Now,
                EventLocationName = "Build School",
                OrganizationName= "Build School",
                EventDescription = "<h2>活動資訊</h2>\r\n\r\n                <p>活動日期：2024年2月24日（六）～ 2024年2月25日（日）</p>\r\n\r\n                <p>活動地點：BS教室</p>\r\n\r\n                <p>主辦單位：Give me fives team</p>\r\n\r\n                <p>承辦單位：BS</p>\r\n\r\n                <p>執行單位：ShowNest LIVE</p>\r\n\r\n                <h2>實名認證須知</h2>\r\n\r\n                <ol>\r\n                    <li>每位ShowNest會員僅限購買4張，VIP區無法與其他區域同筆訂單訂購，若欲購買VIP區請分開購票。</li>\r\n                    <li>\r\n                        VIP區採「實名制認證」，請在購票過程中於票券的「姓名」、「手機」、「身分證字號（海外觀眾寫護照號碼）」欄位中正確填寫每一張票券入場人的資料，一旦確認表單資料送出後，即「無法事後修改或補填」，請務必於送出前再次確認票券入場人資料正確無誤。\r\n                    </li>\r\n                    <li>\r\n                        演出當天入場將會核對每張票券上印製姓名與入場人法定證件是否相符（有效且附有照片之個人證件正本，例如身分證/健保卡/駕照/護照擇一；外籍人士憑護照），確認無誤後方可入場，如不符或無法提供姓名證明者將無法入場。\r\n                    </li>\r\n                    <li>\r\n                        姓名僅限「繁體中文」與「英文」，外籍人士請填寫「護照姓名」，請勿使用特殊符號與字元。（如以下圖示）\r\n                        <img src=\"~/img/events/實名圖檔.jpg\">\r\n                    </li>\r\n                </ol>\r\n                <h2>購票方式說明</h2>\r\n\r\n                <p>\r\n                    您的ShowNest會員需完成\"電子郵件地址及手機號碼驗證\"才能進行購票流程，請至\r\n                    <a asp-controller=\"Account\" asp-action=\"UserEdit\" target=\"_blank\">\r\n                        ShowNest帳號設定\r\n                    </a>確認是否您的電子郵件及手機號碼已經認證完畢。提醒您請勿使用Yahoo、Hotmail信箱註冊及驗證，以避免驗證信未能寄達。\r\n                </p>\r\n\r\n                <ol>\r\n                    <li>\r\n                        本節目網站購票僅接受已完成手機號碼及電子郵件地址驗證之會員購買，購票前請先\"<a href=\"#\" target=\"_blank\">加入會員</a>\r\n                        \"並盡早完成\"\r\n                        <a asp-controller=\"Account\" asp-action=\"UserEdit\" target=\"_blank\">手機號碼及電子郵件地址</a>\r\n                        \"驗證，以便進行購票流程，建議可於會員\"設定\"中的\"\r\n                        <a asp-controller=\"Account\" asp-action=\"Prefills\" target=\"_blank\">報名預填資料</a>\"先行存檔「姓名」和「手機」，可減少購票時間快速進行下一步。\r\n                    </li>\r\n                    <li>為了確保您的權益，強烈建議您，在註冊會員或是結帳時填寫的聯絡人電子郵件，盡量不要使用Yahoo或Hotmail郵件信箱，以免因為擋信、漏信，甚至被視為垃圾郵件而無法收到『訂單成立通知信』。</li>\r\n                    <li>\r\n                        訂單成立通知信可能因其他因素未能寄達，僅提供交易通知之用，未收到訂單成立通知信不代表交易沒有成功，又或是刷卡付款失敗，請於付款期限之內再次嘗試刷卡（即便收到銀行的授權成功的簡訊或電子郵件），若訂單逾期取消，則表示訂單真的沒有成立，請再重新訂購。一旦無法確認於網站上的訂單是否交易成功，請至會員帳戶的\"<a href=\"Orders\" target=\"_blank\">訂單</a>\"查詢您的消費資料，只要是成功的訂單，皆會顯示您所消費的票券明細，若查不到您所訂購的票券，表示交易並未成功，請重新訂票。\r\n                    </li>\r\n                    <li>本節目在全家FamiPort購票為「自動配位」，若需自行選擇座位請於網站上購票。</li>\r\n                    <li>ShowNest系統沒有固定的清票時間，只要消費者沒有於期限內完成付款，未付款的座位就會陸陸續續釋放出來，消費者可隨時留意網頁或是機台是否有釋出可售票券張數。</li>\r\n                    <li>\r\n                        ShowNest網站購票：\r\n                        <ul>\r\n                            <li>\r\n                                需<a href=\"#\" target=\"_blank\">加入會員</a>並通過\"<a href=\"UserEdit\" target=\"_blank\">手機號碼及電子郵件地址</a>\"驗證，每位ShowNest會員限購4張，請務必在活動啟售前24小時完成驗證，售票當天無法保證能驗證成功，24小時之內才驗證手機成功的帳號恕無法確保能順利購票。\r\n                            </li>\r\n                            <li>\r\n                                進行手機號碼驗證，但收不到簡訊怎麼辦？<a href=\"#\" target=\"_blank\">請點我</a>\r\n                            </li>\r\n                            <li>系統會先配好最適座位，可以在規定時間內更改座位</li>\r\n                            <li>付款方式：信用卡(VISA/MASTER/JCB)</li>\r\n                            <li>\r\n                                為強化信用卡網路付款安全，ShowNest售票系統網站導入了更安全的信用卡 3D 驗證服務，會員購票時，將取得簡訊驗證碼，確保卡號確實為持卡人所有，以提供持卡人更安全的網路交易環境。<a href=\"#\" target=\"_blank\">信用卡3D驗證流程為何？</a>\r\n                            </li>\r\n                            <li>取票方式：全家取票(手續費每筆$30/4張為限，請於全家便利商店繳納給櫃檯)</li>\r\n                            <li>\r\n                                ShowNest購票流程圖示說明 <a href=\"#\" target=\"_blank\">請點我</a>\r\n                            </li>\r\n                            <li>\r\n                                全家便利商店FamiPort取票說明 <a href=\"#\" target=\"_blank\">請點我</a>\r\n                            </li>\r\n                            <li>\r\n                                選擇全家便利商店FamiPort取票請留意：請勿在啟售當天於網站訂購完成後馬上至全家便利商店取票，極有可能因系統繁忙無法馬上取票，只要訂購成功票券在演出前皆可取票，請擇日再至全家便利商店取票。\r\n                            </li>\r\n                        </ul>\r\n                    </li>\r\n                    <li>\r\n                        全家便利商店FamiPort購票：(VIP區不適用)\r\n                        <ul>\r\n                            <li>無需加入會員，每筆訂單限購4張</li>\r\n                            <li>為系統自動配位，選擇區域後系統將自動配至購買票價的最適區域及座位，且可能與選擇的區域不同，無法自行選區域及座位</li>\r\n                            <li>付款方式：僅接受現金</li>\r\n                            <li>取票方式：付款完畢直接於全家便利商店櫃檯現場取票，免手續費</li>\r\n                            <li>\r\n                                全家便利商店店鋪查詢 <a href=\"#\" target=\"_blank\">請點我</a>\r\n                            </li>\r\n                            <li>\r\n                                全家便利商店FamiPort購票流程圖示說明 <a href=\"#\" target=\"_blank\">請點我</a>\r\n                            </li>\r\n                            <li>於全家便利商店FamiPort列印繳費單後，需在10分鐘內在該店櫃檯完成結帳，若無法在時間內完成結帳取票，訂單將會被取消，原本購買的座位將釋回到系統中重新銷售。</li>\r\n                            <li>於全家便利商店之購票動作皆於結帳取票後方能保證座位，請注意單憑列印繳費單無法保證其座位。</li>\r\n                        </ul>\r\n                    </li>\r\n                    <li>\r\n                        身心障礙票券說明：\r\n                        <ul>\r\n                            <li>\r\n                                僅限 ShowNest 網站購票，需<a href=\"#\" target=\"_blank\">加入會員</a>並通過\"<a href=\"UserEdit\"\r\n                                                                                             target=\"_blank\">手機號碼及電子郵件地址</a>\"驗證，請務必在活動啟售前24小時完成「<a href=\"#\"\r\n                                                                                                                                                   target=\"_blank\">身心障礙者身份認證</a>」，售票當天無法保證能認證成功，24小時之內才認證的帳號恕無法確保能順利購票。\r\n                            </li>\r\n                            <li>\r\n                                進行手機號碼驗證，但收不到簡訊怎麼辦？<a href=\"#\" target=\"_blank\">請點我</a>\r\n                            </li>\r\n                            <li>\r\n                                如何進行身心障礙者身份認證？<a href=\"#\" target=\"_blank\">請點我</a>\r\n                            </li>\r\n                            <li>通過身份認證之帳號，僅可購買身心障礙證明「有效期限」晚於「活動日」之票券。</li>\r\n                            <li>每位身心障礙人士含必要陪同者限購最多2張票券，「必要陪伴者優惠措施」須通過主管機關身分認證始能購買陪同席票。</li>\r\n                            <li>身心障礙優先席以主辦單位／場館規劃區域、座位、優惠票價配位銷售，售完為止，票價每席 2,640 元。</li>\r\n                            <li>系統會先配好最適座位，恕無法跨區選位或換位，敬請見諒。</li>\r\n                            <li>進場時須出示有效身心障礙證明正本，若有必要陪伴者，須一同入場（恕無法單獨持票進場），以利查驗。入場時如有不合規定或非身心障礙證明持有者，可拒絕入場並拒絕任何退換票要求。</li>\r\n                        </ul>\r\n                    </li>\r\n                </ol>\r\n\r\n                <h2>注意事項</h2>\r\n\r\n                <ol>\r\n                    <li>\r\n                        退票方式：消費者請求退換票之時限為演出日前10日(不含演出日)，但消費者於退換票時限屆至前購買,迄於時限屆至後始收受票券或於開演前仍未收受票券者，亦得退換票，全家取票因購買當日便可取票則不適用此規範；請求退換票日期以實體票券寄達日為準，退票需酌收票面金額10%手續費，限2024/2/7(含)前寄達至ShowNest郵政信箱，請詳閱\r\n                        <a href=\"#\" target=\"_blank\">ShowNest退換票規定</a>。\r\n                    </li>\r\n                    <li>\r\n                        請勿於拍賣網站或是其他非ShowNest正式授權售票之通路、網站購票、也不要透過陌生代購進行購票，主辦單位與ShowNest均無法保證票券真實性。除可能衍生詐騙案件或交易糾紛外，以免影響自身權益，若發生演出現場無法入場或是其他問題，主辦單位及ShowNest概不負責。\r\n                    </li>\r\n                    <li>\r\n                        若有任何形式非供自用而加價轉售（無論加價名目為代購費、交通費、補貼等均包含在內）之情事者，已違反社會秩序維護法第64條第2款；且依文化創意產業發展法第十條之一第二項規定，將票券超過票面金額或定價販售者，按票券張數，由直轄市政府、縣（市）政府處每張票面金額之十倍至五十倍罰鍰，請勿以身試法！\r\n                    </li>\r\n                    <li>購票前請詳閱注意事項，一旦購票成功視為同意上述所有活動注意事項。</li>\r\n                </ol>",
                EventLocationAddress = "106台北市大安區忠孝東路三段96號11號樓之1",
                EventAttendance = "500",


                AllTickets = new List<EventTicket> {
                    new EventTicket {
                        TicketTypeName = "搖滾票",
                        TicketSalseBegin = DateTime.Now,
                        TicketSalseEnd = DateTime.Now,
                        TicketPrice = 3600
                    }, new EventTicket {
                        TicketTypeName = "一般票",
                        TicketSalseBegin = DateTime.Now,
                        TicketSalseEnd = DateTime.Now,
                        TicketPrice = 2800
                    }, new EventTicket {
                        TicketTypeName = "優待票",
                        TicketSalseBegin = DateTime.Now,
                        TicketSalseEnd = DateTime.Now,
                        TicketPrice = 1200
                    }, new EventTicket {
                        TicketTypeName = "站票",
                        TicketSalseBegin = DateTime.Now,
                        TicketSalseEnd = DateTime.Now,
                        TicketPrice = 800
                    },
                    
    }
            };
            return View(model);
        }


        

        public IActionResult TicketTypeSelection()
        {
            var model = new TicketTypeSelectionViewModel()
            {
                EventDetail = new EventDetailViewModel()
                {
                    MainImage = "https://picsum.photos/1300/600/?random=10",
                    EventName = "NOT SUPER JUNIOR-L.S.S. THE SHOW : TH3EE GUYS",
                    StartTime = DateTime.Now,
                    EventLocation = "亞洲國際博覽館 10號展館 / 國際機場亞洲國際博覽館",
                    EventHost = "ShowNest",
                    TicketCollectionChannel = "電子票券",
                    SeatAreaImage = "https://picsum.photos/1200/1200/?random=10"
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
                TicketPriceRow = new List<TicketPriceViewModel>{
                    new TicketPriceViewModel()
                    {
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
            return View(model);
        }

        public IActionResult SelectArea()
        {
            return View();
        }

        public IActionResult SelectSeats()
        {
            return View();
        }

        public IActionResult Registrations()
        {
            var registration = _registrationService.GetRegistrationInfo();
            return View(registration);
        }

        public IActionResult PaymentInfo()
        {
            return View();
        }

        public IActionResult OrderDetail()
        {
            return View();
        }
    }
}