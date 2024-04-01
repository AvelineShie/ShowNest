using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Infrastructure.Data;

public class TicketTypeRepository : EfRepository<TicketType>, ITicketTypeRepository
{
    public TicketTypeRepository(DatabaseContext context) : base(context)
    {
        
    }
}