using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceInterno.Models;

namespace ECommerceInterno.Repositories
{
    public interface ICompraRepository
    {
        Task<Compra?> GetByIdAsync(int id);
        Task<List<Compra>> GetAllAsync();
        Task<Compra> AddAsync(Compra c);
    }
}