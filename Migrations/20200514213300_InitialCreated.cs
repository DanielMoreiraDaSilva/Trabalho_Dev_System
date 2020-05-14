using Microsoft.EntityFrameworkCore.Migrations;

namespace Novo_Dev.Migrations
{
    public partial class InitialCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Franquias",
                columns: table => new
                {
                    FranquiaId = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    HorarioDeAbertura = table.Column<string>(nullable: true),
                    HorarioDeFechamento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franquias", x => x.FranquiaId);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Preço = table.Column<int>(nullable: false),
                    Acompanhamento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Regra = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Nome", "Regra", "Senha" },
                values: new object[] { "1", "Admin", "admin", "QL0AFWMIX8NRZTKeof9cXsvbvu8=" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Nome", "Regra", "Senha" },
                values: new object[] { "2", "Daniel", "user", "QL0AFWMIX8NRZTKeof9cXsvbvu8=" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Nome",
                table: "Users",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Franquias");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
