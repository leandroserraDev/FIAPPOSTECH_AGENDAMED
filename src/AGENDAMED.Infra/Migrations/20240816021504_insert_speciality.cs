using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGENDAMED.Infra.Migrations
{
    public partial class insert_speciality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "7fbdb6ec-32de-4d1f-9856-de3c5bb9eeb1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7fbdb6ec-32de-4d1f-9856-de3c5bb9eeb1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f1f3e99f-9814-46ad-aead-3b5e4aaad646", 0, "af8df446-c141-49bd-bc2b-d6dcb3e94429", "administrador@administrador.com", true, "administrador@administrador.com", false, null, "administrador@administrador.com", "ADMINISTRADOR@ADMINISTRADOR.COM", "ADMINISTRADOR@ADMINISTRADOR.COM", "AQAAAAEAACcQAAAAELB3uV+nKROoADNampaDfd/otIm0sGXcg3lY87ztipzRWnf9gnjz++wtlGB2nQDPRg==", null, false, "0c64c1b5-05aa-460e-b273-286c9984533f", false, "administrador@administrador.com" });

            migrationBuilder.InsertData(
                table: "Speciality",
                columns: new[] { "ID", "Deleted", "Description", "DtCreated", "DtModified", "Name" },
                values: new object[,]
                {
                    { 1L, false, "CLÍNICO GERAL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clínico Geral" },
                    { 2L, false, "ORTOPEDISTA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ortopedista" },
                    { 3L, false, "PEDIATRA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pediatra" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "f1f3e99f-9814-46ad-aead-3b5e4aaad646" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "f1f3e99f-9814-46ad-aead-3b5e4aaad646" });

            migrationBuilder.DeleteData(
                table: "Speciality",
                keyColumn: "ID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Speciality",
                keyColumn: "ID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Speciality",
                keyColumn: "ID",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1f3e99f-9814-46ad-aead-3b5e4aaad646");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7fbdb6ec-32de-4d1f-9856-de3c5bb9eeb1", 0, "56f0007e-84e2-4865-b825-e063828f9301", "administrador@administrador.com", true, "administrador@administrador.com", false, null, "administrador@administrador.com", null, null, "AQAAAAEAACcQAAAAEPaxooTLLI7WsPfgIBM+dLgjtI2CN13XRZTl5aLSPgLuXgSTKC/wGOMiYlfiK5QwPg==", null, false, "a7b565ef-b7a6-4fa3-afc1-ca2a0ed7ab23", false, "administrador@administrador.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "7fbdb6ec-32de-4d1f-9856-de3c5bb9eeb1" });
        }
    }
}
