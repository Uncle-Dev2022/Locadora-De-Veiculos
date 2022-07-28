using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    public partial class PrimeiraMigrationDaRefatoracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBCliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CNH = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CPF_CNPJ = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Endereco = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    tipoCliente = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBFuncionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Login = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Gerente = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFuncionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBGrupoDeVeiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGrupoDeVeiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBTaxa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    descricao = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    tipoCalculo = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    valor = table.Column<double>(type: "FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTaxa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBCondutor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CNH = table.Column<string>(type: "VARCHAR(70)", nullable: true),
                    CPF = table.Column<string>(type: "VARCHAR(70)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(70)", nullable: false),
                    Endereco = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(70)", nullable: false),
                    clienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCondutor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCondutor_TBCliente_clienteId",
                        column: x => x.clienteId,
                        principalTable: "TBCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBVeiculo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoDeVeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Marca = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Modelo = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Cor = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    AnoModelo = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    TipoCombustivel = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Placa = table.Column<string>(type: "VARCHAR(7)", nullable: false),
                    Quilometragem = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    CapacidadeTanque = table.Column<int>(type: "INT", nullable: false),
                    Imagem = table.Column<byte[]>(type: "VARBINARY(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBVeiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBVeiculo_TBGrupoDeVeiculos_GrupoDeVeiculoId",
                        column: x => x.GrupoDeVeiculoId,
                        principalTable: "TBGrupoDeVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutor_clienteId",
                table: "TBCondutor",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBVeiculo_GrupoDeVeiculoId",
                table: "TBVeiculo",
                column: "GrupoDeVeiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBCondutor");

            migrationBuilder.DropTable(
                name: "TBFuncionario");

            migrationBuilder.DropTable(
                name: "TBTaxa");

            migrationBuilder.DropTable(
                name: "TBVeiculo");

            migrationBuilder.DropTable(
                name: "TBCliente");

            migrationBuilder.DropTable(
                name: "TBGrupoDeVeiculos");
        }
    }
}
