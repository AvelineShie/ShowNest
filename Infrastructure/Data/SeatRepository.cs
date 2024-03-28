using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class SeatRepository: EfRepository<Seat>, ISeatRepository
{
    public SeatRepository(DatabaseContext context) : base(context)
    {
    }

    public async Task<List<Seat>> GetSeatsBySeatAreaId(int seatAreaID)
    {
        var seats = await this.DbContext.Seats
            .Where(i => i.SeatAreaId == seatAreaID)
            .ToListAsync();

        return seats;
    }
}