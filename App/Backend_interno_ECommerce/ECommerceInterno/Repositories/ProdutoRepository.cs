using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceInterno.Data;
using ECommerceInterno.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceInterno.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _ctx;
        public ProdutoRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task<Produto?> GetByIdAsync(int id) => await _ctx.Produtos.FindAsync(id);

        public async Task<List<Produto>> GetAllAsync() =>
            await _ctx.Produtos.AsNoTracking().ToListAsync();

        public async Task<Produto> AddAsync(Produto p)
        {
            _ctx.Produtos.Add(p);
            await _ctx.SaveChangesAsync();
            return p;
        }

        public async Task UpdateAsync(Produto p)
        {
            _ctx.Produtos.Update(p);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var p = await _ctx.Produtos.FindAsync(id);
            if (p is null) return;
            _ctx.Produtos.Remove(p);
            await _ctx.SaveChangesAsync();
        }
    }
}