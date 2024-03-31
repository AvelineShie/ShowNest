using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class SeatAreaRepository : EfRepository<SeatArea>, ISeatAreaRepository
{
    public SeatAreaRepository(DatabaseContext context) : base(context)
    {
    }
}