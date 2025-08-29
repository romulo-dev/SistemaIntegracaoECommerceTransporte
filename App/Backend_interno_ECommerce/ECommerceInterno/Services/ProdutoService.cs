using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceInterno.DTOs;
using ECommerceInterno.Models;
using ECommerceInterno.Repositories;

namespace ECommerceInterno.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _repository;
        public ProdutoService(IProdutoRepository repository) => _repository = repository;

        public async Task<ProdutoDto?> ObterProdutoDto(int id)
        {
            var produto = await _repository.GetByIdAsync(id);
            return produto is null ? null : new ProdutoDto(produto.Id, produto.Descricao,
             produto.PrecoUnitario, produto.Quantidade);
        }

        public async Task<Produto?> ObterProduto(int id)
        {
            var produto = await _repository.GetByIdAsync(id);
            return produto is null ? null : produto;
        }






        
        public async Task<List<ProdutoDto>> GetAllAsync()
        {
            
            var list = await _repository.GetAllAsync();
            return list.Select(produto => new ProdutoDto(produto.Id, produto.Descricao,
             produto.PrecoUnitario, produto.Quantidade)).ToList();
        }

        public async Task<List<Produto>> ListaProdutos()
        {
            
            var list = await _repository.GetAllAsync();
            return list;
        }
        
        public async Task<Produto> CreateProduto(Produto produto)
        {
            
            var p = await _repository.AddAsync(produto);
            return p;
        }

        public async Task UpdateAsync(int id, Produto produto)
        {
            var p = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Produto não encontrado");
            p.Descricao = produto.Descricao;
            p.PrecoUnitario = produto.PrecoUnitario;
            p.Quantidade = produto.Quantidade;
            await _repository.UpdateAsync(produto);
        }

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}