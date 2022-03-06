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
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private AppDbContext appDbContext
        {
            get
            {
                return _dbContext as AppDbContext;
            }
        }
        public CartRepository(DbContext dbContext):base(dbContext)
        {

        }

        public Cart GetCart(Guid CartId)
        {
            return appDbContext.Cart.Include("Items")
                .Where(c => c.Id == CartId && c.IsActive == true)
                .FirstOrDefault();
        }
    }
}
