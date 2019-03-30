using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Estoque
    {
        public int Id { get; set; }
        public int FilialId { get; set; }
        public int ProdutoId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Quantidade { get; set; }

        public Filial Filial { get; set; }
        public Produto Produto { get; set; }
    }
}
