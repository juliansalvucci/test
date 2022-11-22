using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContratoTestWebApi.Migrations
{
    public partial class contrato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolizaDigital = table.Column<int>(type: "int", nullable: false),
                    NumeroContrato = table.Column<int>(type: "int", nullable: false),
                    Cuit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trabajadores = table.Column<int>(type: "int", nullable: false),
                    Prima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deuda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Siniestros = table.Column<int>(type: "int", nullable: false),
                    InicioVigencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinVigencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUnidadComercial = table.Column<int>(type: "int", nullable: false),
                    AlicuotaFija = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AlicuotaVariable = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AlicuotasVigentes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CnoPedido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CIIU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NivelRiesgo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Regimen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contrato");
        }
    }
}
