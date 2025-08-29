using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceInterno.Models;

namespace ECommerceInterno.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente?> GetByIdAsync(int id);
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente> AddAsync(Cliente c);
        Task UpdateAsync(Cliente c);
        Task DeleteAsync(int id);
    }
}