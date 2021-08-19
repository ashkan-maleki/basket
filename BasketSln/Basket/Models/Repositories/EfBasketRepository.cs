using System.Linq;
using Basket.Models.Entities;
using Basket.Models.Persistence;

namespace Basket.Models.Repositories
{
    public class EfBasketRepository : IBasketRepository
    {
        private readonly BasketDbContext _context;

        public EfBasketRepository(BasketDbContext context)
        {
            _context = context;
        }

        public IQueryable<Form> Forms => _context.Forms;
    }
}