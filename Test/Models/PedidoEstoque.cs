using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class PedidoEstoque
    {
        public int Id { get; set; }
        public int FilialId { get; set; }
        public DateTime Data { get; set; }
        public TipoPedido Tipo { get; set; }

        public Filial Filial { get; set; }
        public ICollection<ItemPedidoEstoque> ItemPedidoEstoques { get; set; }
    }

    public enum TipoPedido { Entrada, Saida }
}
