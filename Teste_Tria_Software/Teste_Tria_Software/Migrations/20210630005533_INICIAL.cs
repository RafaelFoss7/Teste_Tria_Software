using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste_Tria_Software.Migrations
{
    public partial class INICIAL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    DATA_CRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    EmpresaID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    RAZAO_SOCIAL = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresaID);
                });

            migrationBuilder.CreateTable(
                name: "ClienteEmpresas",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteID = table.Column<long>(type: "bigint", nullable: false),
                    EmpresaID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteEmpresas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClienteEmpresas_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteEmpresas_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteEmpresas_ClienteID",
                table: "ClienteEmpresas",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteEmpresas_EmpresaID",
                table: "ClienteEmpresas",
                column: "EmpresaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteEmpresas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
