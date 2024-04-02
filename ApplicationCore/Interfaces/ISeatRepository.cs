using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface ISeatRepository : IRepository<Seat>
    {
        Task<List<Seat>> GetSeatsBySeatAreaId(int seatAreaID);
    }
}