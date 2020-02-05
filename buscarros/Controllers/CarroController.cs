using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly CarroService _bookService;

        public CarroController(CarroService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<Carro>> Get() =>
            _bookService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCarro")]
        public ActionResult<Carro> Get(string id)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }
    }
}