using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using buscarros.core.DTO;
using buscarros.core.Service;
using buscarros.infra.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace buscarros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly CarroService _carService;

        public CarroController(CarroService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public ActionResult<List<CarroDTO>> Get(string brand = null, string adress = null) =>
            _carService.Get(brand, adress);

        [HttpGet("{id:length(24)}", Name = "GetCar")]
        public ActionResult<CarroDTO> Get(string id)
        {
            var book = _carService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }
    }
}