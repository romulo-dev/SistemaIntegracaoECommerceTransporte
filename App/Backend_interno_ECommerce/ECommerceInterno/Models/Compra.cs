using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceInterno.DTOs;

namespace ECommerceInterno.Models
{
    public class Compra
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; } = null!;

        public int QuantidadeComprada { get; set; }

        public decimal ValorTotal { get; set; }

        public DateTime DataCompra { get; set; }

        public Compra(ClienteDto cliente, Produto produto, int quantidade, decimal valor, DateTime data)
        {
            // ClienteDto = cliente;
            Produto = produto;
            QuantidadeComprada = quantidade;
            ValorTotal = valor;
            DataCompra = data;
        }
    }
}