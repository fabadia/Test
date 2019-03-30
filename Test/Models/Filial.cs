using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Filial
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nome { get; set; }

        public ICollection<PedidoEstoque> PedidoEstoques { get; set; }
        public ICollection<Estoque> Estoques { get; set; }
    }
}
