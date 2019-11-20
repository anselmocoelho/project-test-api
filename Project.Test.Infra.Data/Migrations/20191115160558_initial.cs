using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Test.Infra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carro",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Marca = table.Column<string>(maxLength: 255, nullable: true),
                    Modelo = table.Column<string>(maxLength: 255, nullable: true),
                    Placa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manobrista",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(maxLength: 255, nullable: true),
                    CPF = table.Column<string>(maxLength: 11, nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manobrista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manobra",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CarroId = table.Column<Guid>(nullable: false),
                    ManobristaId = table.Column<Guid>(nullable: false),
                    Realizada = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manobra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manobra_Carro_CarroId",
                        column: x => x.CarroId,
                        principalTable: "Carro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Manobra_Manobrista_ManobristaId",
                        column: x => x.ManobristaId,
                        principalTable: "Manobrista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manobra_CarroId",
                table: "Manobra",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_Manobra_ManobristaId",
                table: "Manobra",
                column: "ManobristaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manobra");

            migrationBuilder.DropTable(
                name: "Carro");

            migrationBuilder.DropTable(
                name: "Manobrista");
        }
    }
}
