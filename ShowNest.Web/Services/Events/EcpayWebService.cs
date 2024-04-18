using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Security.Cryptography;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ShowNest.Web.Services
{
    public class EcpayWebService 
    {
        private readonly IEcpayOrderService _ecpayOrderService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EcpayWebService(
          IRepository<Order> orderRepo,
          IRepository<ArchiveOrder> archiveOrderRepo,
          IRepository<Ticket> ticket,
          IHttpContextAccessor httpContextAccessor, IEcpayOrderService ecpayOrderService
            )
        {
            _ecpayOrderService = ecpayOrderService;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
