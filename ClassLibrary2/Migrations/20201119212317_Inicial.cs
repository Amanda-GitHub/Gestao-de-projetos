using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibrary1.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Funcao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdChefe = table.Column<int>(type: "int", nullable: true),
                    IdSubChefe = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Funcionarios_IdChefe",
                        column: x => x.IdChefe,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Funcionarios_IdSubChefe",
                        column: x => x.IdSubChefe,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    IdResponsavel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projetos_Funcionarios_IdResponsavel",
                        column: x => x.IdResponsavel,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssociacaoProjetos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProjeto = table.Column<int>(type: "int", nullable: true),
                    IdFuncionario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociacaoProjetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssociacaoProjetos_Funcionarios_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssociacaoProjetos_Projetos_IdProjeto",
                        column: x => x.IdProjeto,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Atividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    IdProjeto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atividades_Projetos_IdProjeto",
                        column: x => x.IdProjeto,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "Funcao", "IdChefe", "IdSubChefe", "Nome" },
                values: new object[] { 1, "Programador", 1, null, "Aline Dantas" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "Funcao", "IdChefe", "IdSubChefe", "Nome" },
                values: new object[] { 3, "Programador", null, null, "Marcos Silva" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "Funcao", "IdChefe", "IdSubChefe", "Nome" },
                values: new object[] { 2, "Programador", null, 1, "Sergio Rodrigues" });

            migrationBuilder.InsertData(
                table: "Projetos",
                columns: new[] { "Id", "DataFim", "DataInicio", "Duracao", "IdResponsavel", "Nome" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 160, 1, "Sistema de faturacao" });

            migrationBuilder.InsertData(
                table: "Projetos",
                columns: new[] { "Id", "DataFim", "DataInicio", "Duracao", "IdResponsavel", "Nome" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, 3, "App mobile" });

            migrationBuilder.InsertData(
                table: "AssociacaoProjetos",
                columns: new[] { "Id", "IdFuncionario", "IdProjeto" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 3, 2, 2 },
                    { 2, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Atividades",
                columns: new[] { "Id", "Duracao", "IdProjeto", "Nome" },
                values: new object[,]
                {
                    { 3, 24, 2, "Populate BD" },
                    { 4, 60, 2, "Teste produção" },
                    { 5, 16, 3, "Criação parte gráfica" },
                    { 6, 20, 3, "Populate BD" }
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "Funcao", "IdChefe", "IdSubChefe", "Nome" },
                values: new object[] { 4, "Programador", null, 2, "Paula Machado" });

            migrationBuilder.InsertData(
                table: "Projetos",
                columns: new[] { "Id", "DataFim", "DataInicio", "Duracao", "IdResponsavel", "Nome" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 2, "Site Vendas" });

            migrationBuilder.InsertData(
                table: "AssociacaoProjetos",
                columns: new[] { "Id", "IdFuncionario", "IdProjeto" },
                values: new object[,]
                {
                    { 4, 4, 3 },
                    { 5, 3, 1 },
                    { 6, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Atividades",
                columns: new[] { "Id", "Duracao", "IdProjeto", "Nome" },
                values: new object[,]
                {
                    { 1, 24, 1, "Criação código" },
                    { 2, 8, 1, "Criação BD" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssociacaoProjetos_IdFuncionario",
                table: "AssociacaoProjetos",
                column: "IdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_AssociacaoProjetos_IdProjeto",
                table: "AssociacaoProjetos",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_IdProjeto",
                table: "Atividades",
                column: "IdProjeto");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_IdChefe",
                table: "Funcionarios",
                column: "IdChefe");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_IdSubChefe",
                table: "Funcionarios",
                column: "IdSubChefe");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_IdResponsavel",
                table: "Projetos",
                column: "IdResponsavel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssociacaoProjetos");

            migrationBuilder.DropTable(
                name: "Atividades");

            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
