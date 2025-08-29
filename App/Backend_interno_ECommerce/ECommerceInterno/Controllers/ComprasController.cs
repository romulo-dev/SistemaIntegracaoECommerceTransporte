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
    public class ComprasController : ControllerBase
    {
        private readonly CompraService _service;
        public ComprasController(CompraService service) => _service = service;

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Compra>> Get(int id)
        {
            var compra = await _service.ObterCompra(id);
            return compra is null ? NotFound() : Ok(compra);
        }


        [HttpPost]
        public async Task<ActionResult<Compra>> Create(NovaCompraDTO req)
        {
            var compra = await _service.CreateCompra(req.ClienteId, req.ProdutoId, req.QuantidadeComprada);
            return CreatedAtAction(nameof(Get), new { id = compra.Id }, compra);
        }
    }
}