using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexEstoque.Migrations
{
    /// <inheritdoc />
    public partial class FlexEstoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeProduto = table.Column<string>(type: "TEXT", nullable: false),
                    CodigoProduto = table.Column<string>(type: "TEXT", nullable: false),
                    DescricaoProduto = table.Column<string>(type: "TEXT", nullable: false),
                    ValorProduto = table.Column<string>(type: "TEXT", nullable: false),
                    ValidadeProduto = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstoqueMinimo = table.Column<int>(type: "INTEGER", nullable: false),
                    EstoqueMaximo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
