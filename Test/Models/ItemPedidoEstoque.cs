using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class ItemPedidoEstoque
    {
        public int Id { get; set; }
        public int PedidoEstoqueId { get; set; }
        public int ProdutoId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Quantidade { get; set; }

        public PedidoEstoque PedidoEstoque { get; set; }
        public Produto Produto { get; set; }
    }
}
