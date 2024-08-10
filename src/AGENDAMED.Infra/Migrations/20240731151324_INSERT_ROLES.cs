using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Xml.Linq;

#nullable disable

namespace AGENDAMED.Infra.Migrations
{
    public partial class INSERT_ROLES : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
            table: "AspNetRoles",
           columns: new[] { "Id", "Name", "NormalizedName" },
           values: new object[]
                { "1", "Administrador", "ADMINISTRADOR"});

            migrationBuilder.InsertData(
           table: "AspNetRoles",
          columns: new[] { "Id", "Name", "NormalizedName" },
          values: new object[]
           { "2", "Doctor", "DOCTOR"});

            migrationBuilder.InsertData(
           table: "AspNetRoles",
          columns: new[] { "Id", "Name", "NormalizedName" },
          values: new object[] { "3", "Patient", "PATIENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "AspNetRoles", "Id", new object[1, 2,3]);
        }
    }
}
