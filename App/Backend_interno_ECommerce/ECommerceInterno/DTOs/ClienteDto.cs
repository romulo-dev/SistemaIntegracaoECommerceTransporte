using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceInterno.DTOs
{
    public record ClienteDto(int Id, string Nome, string CPF);
}