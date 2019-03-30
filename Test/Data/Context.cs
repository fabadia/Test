using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Test.Data
{
    using Models;

    public class Context : DbContext
    {
        public virtual DbSet<Filial> Filiais { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Estoque> Estoques { get; set; }
        public virtual DbSet<PedidoEstoque> PedidoEstoques { get; set; }
        public virtual DbSet<ItemPedidoEstoque> ItemPedidoEstoques { get; set; }

        public Context(DbContextOptions<Context> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var stringProperties = modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetProperties())
                .Where(x => x.ClrType == typeof(string));
            foreach(var stringProperty in stringProperties)
                stringProperty.IsUnicode(false);
        }
    }
}
