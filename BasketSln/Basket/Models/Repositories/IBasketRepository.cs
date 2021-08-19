using System.Linq;
using Basket.Models.Entities;

namespace Basket.Models.Repositories
{
    public interface IBasketRepository
    {
        IQueryable<Form> Forms { get; }
    }
}