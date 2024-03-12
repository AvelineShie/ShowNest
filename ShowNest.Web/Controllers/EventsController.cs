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
                EventDescription = "<p>&lt;活動描述&gt;</p>\r\n\r\n<p>&nbsp;</p>\r\n\r\n<blockquote>\r\n<p><strong>DEVCORE 深信，最佳的防禦策略是了解敵人的攻擊思路，並在駭客之前掌握新型攻擊手法。因此，我們持續研究適用於紅隊演練的戰術及攻擊手法，來協助企業應對不斷變化的網路攻擊威脅。</strong></p>\r\n</blockquote>\r\n\r\n<p><strong>延續 2023 年的 DEVCORE CONFERENCE，我們再次舉辦這場專注於攻擊導向的技術研討會。本次活動將分享最新的漏洞研究和真實紅隊演練案例，包括 WAF 的繞過、AD 網域安全、新的攻擊向量、Pwn2Own 經驗、以藍隊從業人員的視角分享紅隊攻擊思路，以及紅隊演練工具開發指南等獨特議題。</strong></p>\r\n\r\n<p>&nbsp;</p>\r\n\r\n<p>&nbsp;</p>\r\n\r\n<p><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">活動資訊</b></strong></p>\r\n\r\n<p dir=\"ltr\"><strong><b id=\"docs-internal-guid-6662469e-7fff-a3cd-b58a-135306891b62\">時間：</b></strong></p>\r\n\r\n<ul>\r\n\t<li>\r\n\t<p dir=\"ltr\"><strong><b id=\"docs-internal-guid-6662469e-7fff-a3cd-b58a-135306891b62\">2024/03/16（六）08:40 - 16:20</b></strong></p>\r\n\t</li>\r\n</ul>\r\n\r\n<p dir=\"ltr\"><strong><b id=\"docs-internal-guid-6662469e-7fff-a3cd-b58a-135306891b62\">地點：</b></strong></p>\r\n\r\n<ul>\r\n\t<li>\r\n\t<p dir=\"ltr\"><strong><b id=\"docs-internal-guid-6662469e-7fff-a3cd-b58a-135306891b62\">TICC 台北國際會議中心 201 會議室（台北市信義區信義路五段 1 號）</b>&nbsp;</strong></p>\r\n\t</li>\r\n</ul>\r\n\r\n<p dir=\"ltr\"><strong><b id=\"docs-internal-guid-470c2b18-7fff-fbb6-e811-f87cedf623da\">費用：</b></strong></p>\r\n\r\n<ul dir=\"ltr\">\r\n\t<li><strong>早鳥票 $5,000</strong></li>\r\n\t<li><strong>一般票 $7,500</strong></li>\r\n\t<li><strong>晚鳥票 $10,000</strong></li>\r\n\t<li><strong>學生票 $1,500（限額 50 名）</strong></li>\r\n</ul>\r\n\r\n<p><strong>DEVCORE CONFERENCE 2024 x OffSec 獨家優惠</strong></p>\r\n\r\n<ul>\r\n\t<li><strong>優惠一：凡於活動期間付費購票者，可於報名 OffSec 系列課程折抵 5,000 元（需先至&nbsp;<a href=\"#\" rel=\"noopener noreferrer\" target=\"_blank\"></a>&nbsp;完成表單填寫），每門課程限量 10 名，額滿為止。各課程剩餘名額如下：</strong>\r\n\r\n\t<ul>\r\n\t\t<li><strong>PEN-200 (OSCP)：剩餘 0&nbsp;名</strong></li>\r\n\t\t<li><strong>SOC-200 (OSDA)：剩餘 6&nbsp;名</strong></li>\r\n\t\t<li><strong>EXP-401 (OSEE)：剩餘 4&nbsp;名</strong></li>\r\n\t</ul>\r\n\t</li>\r\n\t<li><strong>優惠二：於研討會結束後，將從本次付費購票者中隨機抽出一名會眾，贈送 OSCP Live Training 課程。（價值 219,000 元）<img alt=\"🤘\" height=\"16\" referrerpolicy=\"origin-when-cross-origin\" src=\"https://picsum.photos/1300/600/?random=10\" width=\"16\" /></strong></li>\r\n</ul>\r\n\r\n<p dir=\"ltr\"><strong><b id=\"docs-internal-guid-470c2b18-7fff-fbb6-e811-f87cedf623da\">報名方式：</b></strong></p>\r\n\r\n<ul dir=\"ltr\">\r\n\t<li><strong>煩請於此網頁報名購票，因本研討會委託 KKTIX 代開發票，故購票前須完成 KKTIX 會員註冊並通過手機驗證，造成不便，敬請見諒。</strong></li>\r\n</ul>\r\n\r\n<p dir=\"ltr\"><strong><b id=\"docs-internal-guid-28c395a4-7fff-87ef-ef0b-9bd40760b644\">報到流程：</b></strong></p>\r\n\r\n<ul dir=\"ltr\">\r\n\t<li><strong>請於一樓報到處出示 KKTIX 電子票券辦理報到手續，我們將於報到時依照身份別提供對應的識別證與贈品，報到完成後可直接搭乘手扶梯或電梯至二樓會場。</strong></li>\r\n\t<li><strong>為順利完成報到程序，煩請以下身份者報到時出示證明文件，以利身份確認：</strong>\r\n\t<ul>\r\n\t\t<li><strong>購買學生票的來賓，請出示有效學生證。</strong></li>\r\n\t\t<li><strong>受 DEVCORE 邀請的客戶代表，請提供名片一張。</strong></li>\r\n\t</ul>\r\n\t</li>\r\n\t<li><strong>為確保能獲得合適尺寸的紀念 T-shirt，建議活動當日儘早報到，如有不便敬請見諒（購買晚鳥票的來賓，恕不提供紀念 T-shirt 及午餐）。</strong></li>\r\n</ul>\r\n\r\n<p dir=\"ltr\"><strong>更多活動消息：</strong></p>\r\n\r\n<ul dir=\"ltr\">\r\n\t<li><strong>請密切鎖定 DEVCORE FB 粉絲專頁：https://fb.com/、DEVCORE 研討會網站：https://</strong></li>\r\n</ul>\r\n\r\n<p dir=\"ltr\"><strong>注意事項：</strong></p>\r\n\r\n<ul>\r\n\t<li dir=\"ltr\">\r\n\t<p dir=\"ltr\"><strong><b id=\"docs-internal-guid-8c2776cc-7fff-f338-1418-5f1056e477bb\">主辦單位保有修改、終止、變更活動內容細節之權利。</b></strong></p>\r\n\t</li>\r\n\t<li dir=\"ltr\">\r\n\t<p><strong>本活動委由 KKTIX 代為處理退票退款事宜，退票時將酌收 10% 手續費、且活動前十天內（不含活動日）不予退票。</strong></p>\r\n\t</li>\r\n\t<li dir=\"ltr\">\r\n\t<p dir=\"ltr\"><strong>有任何發票開立作廢、退票作業相關問題，請於平日 09:30 - 12:30、13:30 - 18:30 致電 KKTIX 客服中心 02-2752-2836，謝謝！</strong></p>\r\n\t</li>\r\n</ul>\r\n\r\n<p dir=\"ltr\"><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">議程介紹</b></strong></p>\r\n\r\n<p dir=\"ltr\"><strong>本次研討會將分享最新的漏洞研究和真實紅隊演練案例，其中包括 WAF 的繞過、AD 網域安全、新的攻擊向量、Pwn2Own 經驗、以藍隊從業人員的視角分享紅隊攻擊思路，以及紅隊演練工具開發指南等獨特議題。</strong></p>\r\n\r\n<p><strong>分分鐘拿下整個網域－關於 AD，你還疏忽了什麼？</strong></p>\r\n\r\n<p dir=\"ltr\">Vtim | DEVCORE 紅隊隊長<br />\r\n根據戴夫寇爾近一年半紅隊演練的結果，高達 5 成企業內網存在 Active Directory 憑證服務（AD CS）相關的設定疏失，導致攻擊者能在僅擁有低權限的網域帳號情況下，迅速在數分鐘內獲得網域的最高控制權。本次演講將去識別化展示各企業在設定上的常見疏失及攻擊者如何利用這些弱點，以強調 AD CS 服務為近年來企業內網中最需要定期檢核的關鍵基礎設施之一，並提供防止錯誤設定的方法，以及特殊情況下的緩解策略。</p>\r\n\r\n<p dir=\"ltr\"><br />\r\n<strong>牆の調查：致 WAF 前的你</strong></p>\r\n\r\n<p dir=\"ltr\">Mico | DEVCORE 資深紅隊演練專家<br />\r\n&quot;WAF&quot; 作為一種已臻於成熟的技術產品，不僅是抵禦網路威脅的高壘深塹，其發展速度也猶如是向紅隊發出了挑戰。本議程將回顧早期的繞過技巧，以及介紹至今紅隊專家如何鑿壁偷光？議程中將簡單解析 WAF 的基本原理，探討紅隊如何在實際情況中，成功讓關鍵請求繞過這些安全措施。亦會分享一些從實戰中提煉出的經驗，包括那些起初看似不可能繞過，卻屢屢成功實現的真實案例。最後將從戴夫寇爾視角總結 WAF 在當今網路安全生態中的地位和效力。</p>\r\n\r\n<p dir=\"ltr\">&nbsp;</p>\r\n\r\n<p><strong>The Art of Cyber Craftsman：紅隊該如何打造自己的利器</strong></p>\r\n\r\n<p dir=\"ltr\">Inndy | DEVCORE 資深開發工程師<br />\r\n執行滲透測試與紅隊演練時，往往需要各式各樣的網路代理與後門工具，市面上的工具可能無法完美滿足需求，常見的工具又經常被防毒軟體與 EDR 阻擋，自己打造紅隊工具能滿足客製化的需求並大幅降低被偵測的機率。這場議程講者會基於過去分析惡意程式的經驗，分享開發紅隊工具的心得、技巧，幫助大家降低自行研發紅隊工具的門檻。</p>\r\n\r\n<p dir=\"ltr\">&nbsp;</p>\r\n\r\n<p><strong>《轉生赤隊：異世界網際穿越之旅》</strong></p>\r\n\r\n<p dir=\"ltr\">Linwz | DEVCORE 紅隊演練專家<br />\r\n紅隊演練致力於強化企業防禦能力，從而提升客戶的整體安全。然而，客戶變得更加的安全的同時，也意味著我們越難找到突破口。因此，我們持續地思考與探索，尋求新的攻擊策略和突破點。本次演講會從紅隊演練遇到的真實案例，帶到演講主軸紅隊的 Side Channel Attack，深入探討紅隊的多個視野維度，揭露那些鮮為人知的攻擊技巧與潛在風險，內容涵蓋了資訊搜集技巧、服務偽造與劫持手段及個資情蒐方法，最終將展示我們如何透過 One-Click 攻破網路限制執行任意指令，達到從外網突破到內部的新途徑。</p>\r\n\r\n<p dir=\"ltr\">&nbsp;</p>\r\n\r\n<p><strong>當資深藍隊成員，換上紅隊的外衣</strong></p>\r\n\r\n<p dir=\"ltr\">Henry | 奧義智慧 資深軟體架構師 &amp; 資安研究員<br />\r\n講者 Henry 任職於奧義智慧，負責開發 Unix EDR 核心元件。他日夜觀察各路紅隊手法，撰寫偵測邏輯，做著藍隊工作的同時，Henry 的心裡其實也流著紅隊的熱血。本次 Henry 將分享他見過的紅隊案例中，有趣的手法和背後的偵測邏輯，同時也從藍隊的身份、紅隊的視角，探討可能的攻擊思路。</p>\r\n\r\n<p dir=\"ltr\">&nbsp;</p>\r\n\r\n<p><strong>LeakLess? Another Leak Way in Windows Kernel DFSC.&nbsp;</strong></p>\r\n\r\n<p dir=\"ltr\">Angelboy | DEVCORE 資深資安研究員<br />\r\n在日常使用的 Windows 系統中，net use 命令扮演著不可或缺的角色。這個命令簡單卻功能強大，讓使用者能夠輕鬆連接到各種網路資源，例如共享文件夾。DFSC（Distributed File System Client）便是 net use 命令背後的核心機制之一。本議程將深入探討一個在 Windows Kernel 的 DFSC 中被發現的漏洞。這個漏洞原本被認為幾乎無法被利用，但經過一系列的操作和分析後，將這種看似不可能的情況變成了可能：講者成功利用該漏洞實現了 Information Leakage，特別是在 Windows Kernel 保護越來越多的情況下，更突顯了這個漏洞的潛在風險和影響。</p>\r\n\r\n<p dir=\"ltr\">&nbsp;</p>\r\n\r\n<p><strong>第一次打 Pwn2Own 就 SOHO Smashup 是不是搞錯了什麼？</strong></p>\r\n\r\n<p dir=\"ltr\">LJP &amp; YingMuo | DEVCORE 實習生（Pwn2Own Toronto 2023 第三名）<br />\r\nDEVCORE 實習生導師 Angelboy 曾經說過一句話：「Pwn2Own IoT 那場還蠻適合第一次挖掘 Real World 漏洞的人打」，於是本議程講者（DEVCORE 實習生）就以 Pwn2Own 作為實習階段目標，並且一舉拿下世界第三。此議程中將講述這次參賽是如何成功串起從 WAN 端 TP-Link ER605 Router 到 LAN 端 QNAP TS-464 NAS 的攻擊，並分享從目標挑選、研究、發現漏洞然後最後幾天被官方 patch 的過程，以及講者如何在報名截止前兩天加班趕工找到新漏洞並成功利用。本議程提及的漏洞較少被關注，相信無論是開發者或研究員都能有所收穫，敬請期待。</p>\r\n\r\n<p dir=\"ltr\">&nbsp;</p>\r\n\r\n<p dir=\"ltr\"><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">議程表</b></strong></p>\r\n\r\n<table border=\"2\" cellpadding=\"2\" cellspacing=\"2\" dir=\"ltr\">\r\n\t<thead>\r\n\t\t<tr>\r\n\t\t\t<th>\r\n\t\t\t<p><strong>時間</strong></p>\r\n\t\t\t</th>\r\n\t\t\t<th><strong>議程</strong></th>\r\n\t\t\t<th><strong>講師</strong></th>\r\n\t\t</tr>\r\n\t</thead>\r\n\t<tbody>\r\n\t\t<tr>\r\n\t\t\t<td>\r\n\t\t\t<p><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">08:40 - 09:20</b></strong></p>\r\n\t\t\t</td>\r\n\t\t\t<td><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">來賓報到</b></strong></td>\r\n\t\t\t<td><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">／</b></strong></td>\r\n\t\t</tr>\r\n\t\t<tr>\r\n\t\t\t<td>\r\n\t\t\t<p><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">09:20&nbsp;- 09:30</b></strong></p>\r\n\t\t\t</td>\r\n\t\t\t<td><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">開幕</b></strong></td>\r\n\t\t\t<td><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">／</b></strong></td>\r\n\t\t</tr>\r\n\t\t<tr>\r\n\t\t\t<td>\r\n\t\t\t<p><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">09:30 - 10:00</b></strong></p>\r\n\t\t\t</td>\r\n\t\t\t<td><strong>分分鐘拿下整個網域－關於 AD，你還疏忽了什麼？</strong></td>\r\n\t\t\t<td><strong>DEVCORE 紅隊隊長&nbsp;Vtim</strong></td>\r\n\t\t</tr>\r\n\t\t<tr>\r\n\t\t\t<td>\r\n\t\t\t<p><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">10:00&nbsp;- 10:10</b></strong></p>\r\n\t\t\t</td>\r\n\t\t\t<td><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">中場休息</b></strong></td>\r\n\t\t\t<td><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">／</b></strong></td>\r\n\t\t</tr>\r\n\t\t<tr>\r\n\t\t\t<td>\r\n\t\t\t<p><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">10:10 - 10:40</b></strong></p>\r\n\t\t\t</td>\r\n\t\t\t<td><strong>牆の調查：致 WAF 前的你</strong></td>\r\n\t\t\t<td><strong>DEVCORE 資深紅隊演練專家&nbsp;Mico</strong></td>\r\n\t\t</tr>\r\n\t\t<tr>\r\n\t\t\t<td>\r\n\t\t\t<p><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">10:40 - 10:50</b></strong></p>\r\n\t\t\t</td>\r\n\t\t\t<td><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">中場休息</b></strong></td>\r\n\t\t\t<td><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">／</b></strong></td>\r\n\t\t</tr>\r\n\t\t<tr>\r\n\t\t\t<td>\r\n\t\t\t<p><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">10:50 - 11:20</b></strong></p>\r\n\t\t\t</td>\r\n\t\t\t<td><strong>The Art of Cyber Craftsman：紅隊該如何打造自己的利器</strong></td>\r\n\t\t\t<td><strong>DEVCORE 資深開發工程師&nbsp;Inndy</strong></td>\r\n\t\t</tr>\r\n\t\t<tr>\r\n\t\t\t<td>\r\n\t\t\t<p><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">11:20&nbsp;- 11:30</b></strong></p>\r\n\t\t\t</td>\r\n\t\t\t<td><strong>中場休息</strong></td>\r\n\t\t\t<td><strong>／</strong></td>\r\n\t\t</tr>\r\n\t\t<tr>\r\n\t\t\t<td>\r\n\t\t\t<p><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">11:30&nbsp;- 12:00</b></strong></p>\r\n\t\t\t</td>\r\n\t\t\t<td><strong>《轉生赤隊：異世界網際穿越之旅》</strong></td>\r\n\t\t\t<td><strong>DEVCORE 紅隊演練專家 Linwz</strong></td>\r\n\t\t</tr>\r\n\t\t<tr>\r\n\t\t\t<td>\r\n\t\t\t<p><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">12:00&nbsp;- 13:20</b></strong></p>\r\n\t\t\t</td>\r\n\t\t\t<td><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">午餐休息</b></strong></td>\r\n\t\t\t<td><strong>／</strong></td>\r\n\t\t</tr>\r\n\t\t<tr>\r\n\t\t\t<td>\r\n\t\t\t<p><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">13:20&nbsp;- 13:50</b></strong></p>\r\n\t\t\t</td>\r\n\t\t\t<td><strong>當資深藍隊成員，換上紅隊的外衣</strong></td>\r\n\t\t\t<td><strong>CyCraft Technology<br />\r\n\t\t\t資深軟體架構師 &amp; 資安研究員&nbsp;Henry</strong></td>\r\n\t\t</tr>\r\n\t\t<tr>\r\n\t\t\t<td>\r\n\t\t\t<p><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">13:50&nbsp;- 14:00</b></strong></p>\r\n\t\t\t</td>\r\n\t\t\t<td><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">中場休息</b></strong></td>\r\n\t\t\t<td><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">／</b></strong></td>\r\n\t\t</tr>\r\n\t\t<tr>\r\n\t\t\t<td>\r\n\t\t\t<p><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">14:00&nbsp;- 14:30</b></strong></p>\r\n\t\t\t</td>\r\n\t\t\t<td><strong>LeakLess? Another Leak Way in Windows Kernel DFSC.</strong></td>\r\n\t\t\t<td><strong>DEVCORE 資深資安研究員&nbsp;Angelboy</strong></td>\r\n\t\t</tr>\r\n\t\t<tr>\r\n\t\t\t<td>\r\n\t\t\t<p><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">14:30&nbsp;- 15:00</b></strong></p>\r\n\t\t\t</td>\r\n\t\t\t<td><strong>Coffee Break - 現場來賓交流</strong></td>\r\n\t\t\t<td><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">／</b></strong></td>\r\n\t\t</tr>\r\n\t\t<tr>\r\n\t\t\t<td>\r\n\t\t\t<p><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">15:00 - 16:00</b></strong></p>\r\n\t\t\t</td>\r\n\t\t\t<td><strong>第一次打 Pwn2Own 就 SOHO Smashup 是不是搞錯了什麼？</strong></td>\r\n\t\t\t<td>\r\n\t\t\t<p><strong>DEVCORE 實習生 LJP &amp; YingMuo<br />\r\n\t\t\t（Pwn2Own Toronto 2023 第三名）</strong></p>\r\n\t\t\t</td>\r\n\t\t</tr>\r\n\t\t<tr>\r\n\t\t\t<td>\r\n\t\t\t<p><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">16:00 - 16:20</b></strong></p>\r\n\t\t\t</td>\r\n\t\t\t<td><strong>閉幕</strong></td>\r\n\t\t\t<td><strong><b id=\"docs-internal-guid-987ce9cd-7fff-3c36-37ab-221517493a77\">／</b></strong></td>\r\n\t\t</tr>\r\n\t</tbody>\r\n</table>\r\n\r\n<p>&nbsp;</p>\r\n",
                EventLocationAddress = "106台北市大安區忠孝東路三段96號11號樓之1",
                EventAttendance = "500",


                AllTickets = new List<EventTicket> {
                    new EventTicket {
                        TicketTypeName = "早鳥票",
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