using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceInterno.DTOs;
using ECommerceInterno.Models;
using ECommerceInterno.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceInterno.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _service;
        public ClientesController(ClienteService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<ClienteDto>>> GetAll() =>
        await _service.GetAllAsync();

        [HttpGet("dto/{id:int}")]
        public async Task<ActionResult<ClienteDto>> GetClienteDTO(int id)
        {
            var dto = await _service.ObterClienteDto(id);
            return dto is null ? NotFound() : Ok(dto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClienteDto>> Get(int id)
        {
            var dto = await _service.ObterCliente(id);
            return dto is null ? NotFound() : Ok(dto);
        }


        [HttpPost]
        public async Task<ActionResult<ClienteDto>> CreateCliente(Cliente cliente)
        {
            var dto = await _service.CreateAsyncDTO(cliente);
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ClienteDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}