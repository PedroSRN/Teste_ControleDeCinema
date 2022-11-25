using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste_ControleDeCinema.Orm.Migrations
{
    public partial class Configuração_Sala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TBSala",
                keyColumn: "Id",
                keyValue: new Guid("522e3d42-c336-456e-eaa7-08dacd110e22"));

            migrationBuilder.DeleteData(
                table: "TBSala",
                keyColumn: "Id",
                keyValue: new Guid("8a501246-209b-43eb-eaa6-08dacd110e22"));

            migrationBuilder.InsertData(
                table: "TBSala",
                columns: new[] { "Id", "Capacidade", "Nome", "UsuarioId" },
                values: new object[] { new Guid("2d8945bc-cd9e-44aa-e1a8-08dacccaa246"), 50, "Sala - 1", new Guid("dc58caf8-33c4-48ff-7a21-08daccc68b1f") });

            migrationBuilder.InsertData(
                table: "TBSala",
                columns: new[] { "Id", "Capacidade", "Nome", "UsuarioId" },
                values: new object[] { new Guid("ce823d9e-f388-4593-e1a9-08dacccaa246"), 50, "Sala - 2", new Guid("dc58caf8-33c4-48ff-7a21-08daccc68b1f") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TBSala",
                keyColumn: "Id",
                keyValue: new Guid("9f67d2ab-21d0-4a21-a73b-08dacd763184"));

            migrationBuilder.DeleteData(
                table: "TBSala",
                keyColumn: "Id",
                keyValue: new Guid("f75467ca-29b9-4077-a73a-08dacd763184"));

            migrationBuilder.InsertData(
                table: "TBSala",
                columns: new[] { "Id", "Capacidade", "Nome", "UsuarioId" },
                values: new object[] { new Guid("8a501246-209b-43eb-eaa6-08dacd110e22"), 50, "Sala - 1", new Guid("dc58caf8-33c4-48ff-7a21-08daccc68b1f") });

            migrationBuilder.InsertData(
                table: "TBSala",
                columns: new[] { "Id", "Capacidade", "Nome", "UsuarioId" },
                values: new object[] { new Guid("522e3d42-c336-456e-eaa7-08dacd110e22"), 50, "Sala - 2", new Guid("dc58caf8-33c4-48ff-7a21-08daccc68b1f") });
        }
    }
}
