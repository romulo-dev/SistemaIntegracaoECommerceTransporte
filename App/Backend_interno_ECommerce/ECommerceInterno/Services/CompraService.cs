using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ECommerceInterno.Data;
using ECommerceInterno.DTOs;
using ECommerceInterno.Models;
using ECommerceInterno.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceInterno.Services
{
    public class CompraService
    {
        private readonly AppDbContext _ctx;
        private readonly ClienteService _cliente;
        private readonly ProdutoService _produto;
        private readonly CompraRepository _repository;

        public CompraService(AppDbContext ctx, ClienteService cliente, ProdutoService produto,
         CompraRepository repository)
        {
            _ctx = ctx;
            _cliente = cliente;
            _produto = produto;
            _repository = repository;
        }

        public async Task<Compra?> ObterCompra(int id)
        {
            var compra = await _repository.GetByIdAsync(id);
            return compra is null ? null : compra;
        }

        public async Task<Compra> CreateCompra(int clienteId, int produtoId, int quantidadeComprada)
        {

            if (quantidadeComprada <= 0)
                throw new ArgumentException("Quantidade comprada deve ser maior que zero.");


            // Verifica se o cliente existe
            var cliente = await _cliente.ObterClienteDto(clienteId);
            if (cliente is null)
                throw new ArgumentException("Cliente não encontrado.");

            // Verifica se o produto existe
            var produto = await _produto.ObterProdutoDto(produtoId);
            if (produto is null)
                throw new ArgumentException("Produto não encontrado.");

            // Verifica se há estoque suficiente
            if (quantidadeComprada > produto.Quantidade)
                throw new InvalidOperationException("Estoque insuficiente para a quantidade solicitada.");

            // Calcula valores
            int quantidadeRestante = produto.Quantidade - quantidadeComprada;
            decimal valorTotal = produto.PrecoUnitario * quantidadeComprada;

            // Atualiza o produto com nova quantidade
            var produtoAtualizado = new Produto(produto.Id, produto.Descricao, produto.PrecoUnitario, quantidadeRestante);
            await _produto.CreateProduto(produtoAtualizado);

            // var clienteAtualizado = 

            // Cria a compra
            var compra = new Compra(
                cliente,
                produtoAtualizado,
                quantidadeComprada,
                valorTotal,
                DateTime.Now
            );

            _ctx.Compras.Add(compra);
            await _ctx.SaveChangesAsync();

            return compra;
        }
        
    }
}