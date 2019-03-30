using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Descricao { get; set; }

        public ICollection<Estoque> Estoques { get; set; }
        public ICollection<ItemPedidoEstoque> ItemPedidoEstoques { get; set; }
    }
}
