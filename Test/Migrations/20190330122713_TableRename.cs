using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Migrations
{
    public partial class TableRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Filials_FilialId",
                table: "Estoques");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoEstoques_Filials_FilialId",
                table: "PedidoEstoques");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filials",
                table: "Filials");

            migrationBuilder.RenameTable(
                name: "Filials",
                newName: "Filiais");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filiais",
                table: "Filiais",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Filiais_FilialId",
                table: "Estoques",
                column: "FilialId",
                principalTable: "Filiais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoEstoques_Filiais_FilialId",
                table: "PedidoEstoques",
                column: "FilialId",
                principalTable: "Filiais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Filiais_FilialId",
                table: "Estoques");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoEstoques_Filiais_FilialId",
                table: "PedidoEstoques");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filiais",
                table: "Filiais");

            migrationBuilder.RenameTable(
                name: "Filiais",
                newName: "Filials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filials",
                table: "Filials",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Filials_FilialId",
                table: "Estoques",
                column: "FilialId",
                principalTable: "Filials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoEstoques_Filials_FilialId",
                table: "PedidoEstoques",
                column: "FilialId",
                principalTable: "Filials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
