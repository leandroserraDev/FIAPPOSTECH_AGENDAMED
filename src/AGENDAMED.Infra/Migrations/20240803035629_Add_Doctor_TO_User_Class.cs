using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AGENDAMED.Infra.Migrations
{
    public partial class Add_Doctor_TO_User_Class : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DoctorID",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserID = table.Column<string>(type: "text", nullable: false),
                    DtCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DtModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DoctorID",
                table: "AspNetUsers",
                column: "DoctorID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Doctor_DoctorID",
                table: "AspNetUsers",
                column: "DoctorID",
                principalTable: "Doctor",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Doctor_DoctorID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DoctorID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "AspNetUsers");
        }
    }
}
