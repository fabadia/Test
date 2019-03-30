using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Migrations
{
    public partial class TipoPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "PedidoEstoques",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "PedidoEstoques");
        }
    }
}
