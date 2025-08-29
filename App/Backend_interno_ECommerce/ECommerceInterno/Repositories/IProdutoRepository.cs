using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceInterno.Models;

namespace ECommerceInterno.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto?> GetByIdAsync(int id);
        Task<List<Produto>> GetAllAsync();
        Task<Produto> AddAsync(Produto c);
        Task UpdateAsync(Produto c);
        Task DeleteAsync(int id);
    }
}