using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceInterno.Data;
using ECommerceInterno.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceInterno.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _ctx;
        public ClienteRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<Cliente?> GetByIdAsync(int id) => await _ctx.Clientes.FindAsync(id);

        public async Task<List<Cliente>> GetAllAsync() =>
            await _ctx.Clientes.AsNoTracking().ToListAsync();

        public async Task<Cliente> AddAsync(Cliente c)
        {
            _ctx.Clientes.Add(c);
            await _ctx.SaveChangesAsync();
            return c;
        }

        public async Task UpdateAsync(Cliente c)
        {
            _ctx.Clientes.Update(c);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var c = await _ctx.Clientes.FindAsync(id);
            if (c is null) return;
            _ctx.Clientes.Remove(c);
            await _ctx.SaveChangesAsync();
        }
    }
}