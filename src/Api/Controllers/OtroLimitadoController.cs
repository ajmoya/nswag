using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OtroLimitadoController : ControllerBase
    {
        private static readonly string[] _summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<OtroLimitadoController> _logger;
        public OtroLimitadoController(ILogger<OtroLimitadoController> logger) => _logger = logger;

        [HttpGet]
        public IEnumerable<ModeloOtroLimitado> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new ModeloOtroLimitado
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = _summaries[rng.Next(_summaries.Length)]
            })
            .ToArray();
        }
    }
}
