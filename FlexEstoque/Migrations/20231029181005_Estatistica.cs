using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlexEstoque.Migrations
{
    /// <inheritdoc />
    public partial class Estatistica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "CategoriaProutoId",
            //    table: "Produto");

            //migrationBuilder.AddColumn<int>(
            //    name: "CategoriaProdutoId",
            //    table: "Produto",
            //    type: "INTEGER",
            //    nullable: true);

            migrationBuilder.CreateTable(
                name: "Estatistica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estatistica", x => x.Id);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Produto_CategoriaProdutoId",
            //    table: "Produto",
            //    column: "CategoriaProdutoId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Produto_CategoriaProduto_CategoriaProdutoId",
            //    table: "Produto",
            //    column: "CategoriaProdutoId",
            //    principalTable: "CategoriaProduto",
            //    principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Produto_CategoriaProduto_CategoriaProdutoId",
            //    table: "Produto");

            //migrationBuilder.DropTable(
            //    name: "Estatistica");

            //migrationBuilder.DropIndex(
            //    name: "IX_Produto_CategoriaProdutoId",
            //    table: "Produto");

            //migrationBuilder.DropColumn(
            //    name: "CategoriaProdutoId",
            //    table: "Produto");

            //migrationBuilder.AddColumn<int>(
            //    name: "CategoriaProutoId",
            //    table: "Produto",
            //    type: "INTEGER",
            //    nullable: false,
            //    defaultValue: 0);
        }
    }
}
