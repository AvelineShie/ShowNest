﻿using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class EcpayOrder
{
    public string MerchantTradeNo { get; set; }

    public string MemberId { get; set; }

    public int? RtnCode { get; set; }

    public string RtnMsg { get; set; }

    public string TradeNo { get; set; }

    public int? TradeAmt { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string PaymentType { get; set; }

    public string PaymentTypeChargeFee { get; set; }

    public string TradeDate { get; set; }

    public int SimulatePaid { get; set; }

    public int OrderId { get; set; }

    public virtual Order Order { get; set; }
}
