using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceInterno.Models
{
    public class Produto
    {
        public Produto(int id, string descricao, decimal precoUnitario, int quantidade)
        {
            Id = id;
            Descricao = descricao;
            PrecoUnitario = precoUnitario;
            Quantidade = quantidade;
        }

        public int Id { get; set; }
        public string Descricao { get; set; } = null!;
        public decimal PrecoUnitario { get; set; } = 0M;

        [Range(1, 500)]
        public int Quantidade { get; set; } = 1;
        public ICollection<Compra> Compras { get; set; } = new List<Compra>();

        
    }
}