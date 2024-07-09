using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeBar.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class addMesa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBMesa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocupada = table.Column<string>(type: "varchar(5)", nullable: false),
                    NumeroMesa = table.Column<string>(type: "varchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBMesa", x => x.Id);
                });
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBGarcom");

            migrationBuilder.DropTable(
                name: "TBMesa");

            migrationBuilder.DropTable(
                name: "TBProduto");
        }
    }
}
