using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceInterno.DTOs;
using ECommerceInterno.Models;
using ECommerceInterno.Repositories;

namespace ECommerceInterno.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository) => _repository = repository;

        public async Task<ClienteDto?> ObterClienteDto(int id)
        {
            var c = await _repository.GetByIdAsync(id);
            return c is null ? null : new ClienteDto(c.Id, c.Nome, c.CPF);
        }

        public async Task<Cliente?> ObterCliente(int id)
        {
            var cliente = await _repository.GetByIdAsync(id);
            return cliente is null ? null : cliente;
        }






        // O tipo Task<T> representa uma operação assíncrona que vai retornar um valor do tipo T no futuro
        public async Task<List<ClienteDto>> GetAllAsync()
        {
            // var list é equivalente List<Cliente>
            var list = await _repository.GetAllAsync();
            return list.Select(c => new ClienteDto(c.Id, c.Nome, c.CPF)).ToList();
        }


        // public async Task<ClienteDto> CreateAsync(ClienteDto dto, string email, string senha)
        public async Task<ClienteDto> CreateAsyncDTO(Cliente cliente)
        {
            // var c = new Cliente { Nome = dto.Nome, CPF = dto.CPF, Email = email, Senha = senha };
            var c = await _repository.AddAsync(cliente);
            return new ClienteDto(c.Id, c.Nome, c.CPF);
        }
        
        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            // var c = new Cliente { Nome = dto.Nome, CPF = dto.CPF, Email = email, Senha = senha };
            var c = await _repository.AddAsync(cliente);
            return c;
        }

        public async Task UpdateAsync(int id, ClienteDto dto)
        {
            var c = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Cliente não encontrado");
            c.Nome = dto.Nome;
            c.CPF = dto.CPF;
            await _repository.UpdateAsync(c);
        }

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}