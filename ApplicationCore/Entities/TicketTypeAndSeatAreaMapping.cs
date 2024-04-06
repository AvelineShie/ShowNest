using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities;

public partial class TicketTypeAndSeatAreaMapping
{
    public int Id { get; set; }

    public int TicketTypeId { get; set; }

    public int SeatAreaId { get; set; }

    public virtual TicketType TicketType { get; set; }

    public virtual SeatArea SeatArea { get; set; }
}
