using Car_Hub.Server.Model;
using Car_Hub.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Car_Hub.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly ICarService _carModelService;

        public CarController(ICarService carModelService)
        {
            _carModelService = carModelService;
        }


        [HttpPost]
        public IActionResult CreateCarModel([FromBody] CarDTO carModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _carModelService.CreateCarModel(carModel);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetCarModels()
        {
            var models = _carModelService.GetAllCarModels();
            return Ok(models);
        }
    }
}
