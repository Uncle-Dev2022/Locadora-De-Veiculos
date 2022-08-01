using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class Correcao_PlanoDeCobranca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBPlanoDeCobranca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    grupoDeVeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    planoControlado_limiteKm = table.Column<decimal>(type: "DECIMAL(11,4)", nullable: true),
                    planoControlado_valorDiario = table.Column<decimal>(type: "DECIMAL(11,4)", nullable: true),
                    planoControlado_valorKm = table.Column<decimal>(type: "DECIMAL(11,4)", nullable: true),
                    planoDiario_valorDiario = table.Column<decimal>(type: "DECIMAL(11,4)", nullable: true),
                    planoDiario_valorKm = table.Column<decimal>(type: "DECIMAL(11,4)", nullable: true),
                    planoLivre_valorDiario = table.Column<decimal>(type: "DECIMAL(11,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPlanoDeCobranca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPlanoDeCobranca_TBGrupoDeVeiculos_grupoDeVeiculoId",
                        column: x => x.grupoDeVeiculoId,
                        principalTable: "TBGrupoDeVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoDeCobranca_grupoDeVeiculoId",
                table: "TBPlanoDeCobranca",
                column: "grupoDeVeiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBPlanoDeCobranca");
        }
    }
}
