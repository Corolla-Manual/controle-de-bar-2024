﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeBar.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class AddPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBGarçom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGarçom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Preco = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBProduto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroPedido = table.Column<int>(type: "int", nullable: false),
                    Produto_Id = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPedido_TBProduto",
                        column: x => x.Produto_Id,
                        principalTable: "TBProduto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBPedido_Produto_Id",
                table: "TBPedido",
                column: "Produto_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBGarçom");

            migrationBuilder.DropTable(
                name: "TBPedido");

            migrationBuilder.DropTable(
                name: "TBProduto");
        }
    }
}