using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceInterno.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string CPF { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public string Email { get; set; } = null!;
        public ICollection<Compra> Compras { get; set; } = new List<Compra>();
    }

}