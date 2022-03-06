using ePizzaHub.Entities;
using ePizzaHub.Repositories.Interfaces;
using ePizzaHub.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Repositories.Implementations
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private AppDbContext appDbContext
        {
            get
            {
                return _dbContext as AppDbContext;
            }
        }
        public OrderRepository(DbContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<Order> GetUserOrders(int UserId)
        {
            //return appDbContext.Order.Include("OrderItems")
            //    .Where(c => c.UserId == UserId)
            //    .ToList();

            return appDbContext.Order.Include(o => o.OrderItems)
                .Where(c => c.UserId == UserId).ToList();
                
        }
    }
}
