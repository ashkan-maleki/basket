using System.Linq;
using Basket.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Controllers
{
    public class FormController : Controller
    {
        private readonly IBasketRepository _repository;
        public int PageSize { get; set; } = 4;

        public FormController(IBasketRepository repository)
        {
            _repository = repository;
        }

        // GET
        public ViewResult Index(int pageNumber = 1)  => View(_repository.Forms
            .OrderBy(f => f.FormID)
            .Skip((pageNumber - 1) * PageSize)
            .Take(PageSize));
        
    }
}