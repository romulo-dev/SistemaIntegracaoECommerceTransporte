using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceInterno.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceInterno.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalController : ControllerBase
    {
        private readonly IExternalApiService _ext;
        public ExternalController(IExternalApiService ext) => _ext = ext;

        [HttpGet("estado-entrega")] //GET http://localhost:5000/api/external/estado-entrega
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetEstado()
        {

            // Exemplo com publicapis.org: /categories
            // GET http://localhost:5001/api/entrega/estado-entrega
            var result = await _ext.GetAsync<List<string>>("api/entrega/estado-entrega");
            if (result == null || !result.Any())
                return NoContent(); // ou NotFound()
            return Ok(result);
        }
    }
}