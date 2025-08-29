using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceInterno.DTOs
{
    public class NovaCompraDTO
    {
        public int ClienteId { get; set; }
        public int ProdutoId { get; set; }
        public int QuantidadeComprada { get; set; }
    }
}