using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rappel_API.BLL.Interfaces;
using Rappel_API.BLL.Models;

namespace Rappel_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _PizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _PizzaService = pizzaService;
        }

        public IActionResult GetAll()
        {
            // TODO Add DTO + Mapper
            IEnumerable<PizzaModel> pizzas = _PizzaService.GetAll();

            return Ok(pizzas);
        }
    }
}
