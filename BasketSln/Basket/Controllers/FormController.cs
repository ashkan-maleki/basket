using Basket.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Controllers
{
    public class FormController : Controller
    {
        private readonly IBasketRepository _repository;

        public FormController(IBasketRepository repository)
        {
            _repository = repository;
        }

        // GET
        public IActionResult Index()  => View(_repository.Forms);
        
    }
}