using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceInterno.Data;
using ECommerceInterno.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceInterno.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        private readonly AppDbContext _ctx;
        public CompraRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<Compra?> GetByIdAsync(int id) =>
            await _ctx.Compras
                .Include(c => c.Cliente)
                .Include(c => c.Produto)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<Compra>> GetAllAsync() =>
            await _ctx.Compras.AsNoTracking().ToListAsync();

        public async Task<Compra> AddAsync(Compra c)
        {
            _ctx.Compras.Add(c);
            await _ctx.SaveChangesAsync();
            return c;
        }

    }
}