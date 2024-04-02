using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Infrastructure.Data
{
    public class OrderRepository : EfRepository<Order>, IOrderRepository
    {
        public OrderRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Order> GetAll()
        {
            var allOrders = base.List(o => true);

            return allOrders.OrderByDescending(o => o.ArchiveOrder.Order.CreatedAt);
        }
        public override void Delete(Order entity)
        {
           
            var source = base.FirstOrDefault(o => o.ArchiveOrder.Order.Id== entity.ArchiveOrder.Order.Id);
            if (source == null)
            {
                return ;
            }


            base.Update(source);


        }
    }
}
