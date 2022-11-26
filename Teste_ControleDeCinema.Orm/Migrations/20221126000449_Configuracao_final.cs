using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste_ControleDeCinema.Orm.Migrations
{
    public partial class Configuracao_final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TBSala",
                keyColumn: "Id",
                keyValue: new Guid("44a12f42-1905-4e10-4a55-08dacf110c11"));

            migrationBuilder.DeleteData(
                table: "TBSala",
                keyColumn: "Id",
                keyValue: new Guid("dfd10bcf-142c-486a-4a56-08dacf110c11"));

            migrationBuilder.AlterColumn<string>(
                name: "UrlImagem",
                table: "TBFilme",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)");

            migrationBuilder.InsertData(
                table: "TBSala",
                columns: new[] { "Id", "Capacidade", "Nome", "UsuarioId" },
                values: new object[] { new Guid("cd0e93cb-bdaf-464a-4e92-08dacf41d5d3"), 50, "Sala - 1", new Guid("dc58caf8-33c4-48ff-7a21-08daccc68b1f") });

            migrationBuilder.InsertData(
                table: "TBSala",
                columns: new[] { "Id", "Capacidade", "Nome", "UsuarioId" },
                values: new object[] { new Guid("a91afe0e-39a5-4014-4e93-08dacf41d5d3"), 50, "Sala - 2", new Guid("dc58caf8-33c4-48ff-7a21-08daccc68b1f") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TBSala",
                keyColumn: "Id",
                keyValue: new Guid("a91afe0e-39a5-4014-4e93-08dacf41d5d3"));

            migrationBuilder.DeleteData(
                table: "TBSala",
                keyColumn: "Id",
                keyValue: new Guid("cd0e93cb-bdaf-464a-4e92-08dacf41d5d3"));

            migrationBuilder.AlterColumn<string>(
                name: "UrlImagem",
                table: "TBFilme",
                type: "varchar(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "TBSala",
                columns: new[] { "Id", "Capacidade", "Nome", "UsuarioId" },
                values: new object[] { new Guid("44a12f42-1905-4e10-4a55-08dacf110c11"), 50, "Sala - 1", new Guid("dc58caf8-33c4-48ff-7a21-08daccc68b1f") });

            migrationBuilder.InsertData(
                table: "TBSala",
                columns: new[] { "Id", "Capacidade", "Nome", "UsuarioId" },
                values: new object[] { new Guid("dfd10bcf-142c-486a-4a56-08dacf110c11"), 50, "Sala - 2", new Guid("dc58caf8-33c4-48ff-7a21-08daccc68b1f") });
        }
    }
}
