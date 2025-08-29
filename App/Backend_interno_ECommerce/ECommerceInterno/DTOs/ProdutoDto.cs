using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceInterno.DTOs
{
    public record ProdutoDto(int Id, string Descricao, decimal PrecoUnitario, int Quantidade);
}