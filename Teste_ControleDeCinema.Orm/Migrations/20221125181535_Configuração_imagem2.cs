using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste_ControleDeCinema.Orm.Migrations
{
    public partial class Configuração_imagem2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TBSala",
                keyColumn: "Id",
                keyValue: new Guid("03c95a78-7241-4151-54f0-08dace403c4c"));

            migrationBuilder.DeleteData(
                table: "TBSala",
                keyColumn: "Id",
                keyValue: new Guid("72edcc6c-9290-4051-54ef-08dace403c4c"));

            migrationBuilder.DropColumn(
                name: "ConteudoImagem",
                table: "TBFilme");

            migrationBuilder.DropColumn(
                name: "TituloImagem",
                table: "TBFilme");

            migrationBuilder.AddColumn<string>(
                name: "UrlImagem",
                table: "TBFilme",
                type: "varchar(MAX)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "TBSala",
                columns: new[] { "Id", "Capacidade", "Nome", "UsuarioId" },
                values: new object[] { new Guid("44a12f42-1905-4e10-4a55-08dacf110c11"), 50, "Sala - 1", new Guid("dc58caf8-33c4-48ff-7a21-08daccc68b1f") });

            migrationBuilder.InsertData(
                table: "TBSala",
                columns: new[] { "Id", "Capacidade", "Nome", "UsuarioId" },
                values: new object[] { new Guid("dfd10bcf-142c-486a-4a56-08dacf110c11"), 50, "Sala - 2", new Guid("dc58caf8-33c4-48ff-7a21-08daccc68b1f") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TBSala",
                keyColumn: "Id",
                keyValue: new Guid("44a12f42-1905-4e10-4a55-08dacf110c11"));

            migrationBuilder.DeleteData(
                table: "TBSala",
                keyColumn: "Id",
                keyValue: new Guid("dfd10bcf-142c-486a-4a56-08dacf110c11"));

            migrationBuilder.DropColumn(
                name: "UrlImagem",
                table: "TBFilme");

            migrationBuilder.AddColumn<byte[]>(
                name: "ConteudoImagem",
                table: "TBFilme",
                type: "varbinary(MAX)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "TituloImagem",
                table: "TBFilme",
                type: "varchar(500)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "TBSala",
                columns: new[] { "Id", "Capacidade", "Nome", "UsuarioId" },
                values: new object[] { new Guid("72edcc6c-9290-4051-54ef-08dace403c4c"), 50, "Sala - 1", new Guid("dc58caf8-33c4-48ff-7a21-08daccc68b1f") });

            migrationBuilder.InsertData(
                table: "TBSala",
                columns: new[] { "Id", "Capacidade", "Nome", "UsuarioId" },
                values: new object[] { new Guid("03c95a78-7241-4151-54f0-08dace403c4c"), 50, "Sala - 2", new Guid("dc58caf8-33c4-48ff-7a21-08daccc68b1f") });
        }
    }
}
