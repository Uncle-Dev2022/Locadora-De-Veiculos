using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class AdicaoLocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocacaoId",
                table: "TBTaxa",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "TBLocacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CondutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoDeVeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    veiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    planoDeCobrancaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dataDeLocacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataDeDevolucaoPrevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KmAtualVeiculo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    funcionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBLocacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBCondutor_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "TBCondutor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBFuncionario_funcionarioId",
                        column: x => x.funcionarioId,
                        principalTable: "TBFuncionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBGrupoDeVeiculos_GrupoDeVeiculoId",
                        column: x => x.GrupoDeVeiculoId,
                        principalTable: "TBGrupoDeVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBPlanoDeCobranca_planoDeCobrancaId",
                        column: x => x.planoDeCobrancaId,
                        principalTable: "TBPlanoDeCobranca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBLocacao_TBVeiculo_veiculoId",
                        column: x => x.veiculoId,
                        principalTable: "TBVeiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBTaxa_LocacaoId",
                table: "TBTaxa",
                column: "LocacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_ClienteId",
                table: "TBLocacao",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_CondutorId",
                table: "TBLocacao",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_funcionarioId",
                table: "TBLocacao",
                column: "funcionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_GrupoDeVeiculoId",
                table: "TBLocacao",
                column: "GrupoDeVeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_planoDeCobrancaId",
                table: "TBLocacao",
                column: "planoDeCobrancaId");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_veiculoId",
                table: "TBLocacao",
                column: "veiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoDeCobranca_grupoDeVeiculoId",
                table: "TBPlanoDeCobranca",
                column: "grupoDeVeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBTaxa_TBLocacao_LocacaoId",
                table: "TBTaxa",
                column: "LocacaoId",
                principalTable: "TBLocacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBTaxa_TBLocacao_LocacaoId",
                table: "TBTaxa");

            migrationBuilder.DropTable(
                name: "TBLocacao");

            migrationBuilder.DropTable(
                name: "TBPlanoDeCobranca");

            migrationBuilder.DropIndex(
                name: "IX_TBTaxa_LocacaoId",
                table: "TBTaxa");

            migrationBuilder.DropColumn(
                name: "LocacaoId",
                table: "TBTaxa");
        }
    }
}
