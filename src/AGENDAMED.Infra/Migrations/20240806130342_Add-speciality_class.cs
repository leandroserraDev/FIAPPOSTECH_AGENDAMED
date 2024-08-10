using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AGENDAMED.Infra.Migrations
{
    public partial class Addspeciality_class : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "DoctorSpecialities");

            migrationBuilder.AddColumn<long>(
                name: "SpecialtyID",
                table: "DoctorSpecialities",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Speciality",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DtCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DtModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speciality", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecialities_SpecialtyID",
                table: "DoctorSpecialities",
                column: "SpecialtyID");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpecialities_Speciality_SpecialtyID",
                table: "DoctorSpecialities",
                column: "SpecialtyID",
                principalTable: "Speciality",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpecialities_Speciality_SpecialtyID",
                table: "DoctorSpecialities");

            migrationBuilder.DropTable(
                name: "Speciality");

            migrationBuilder.DropIndex(
                name: "IX_DoctorSpecialities_SpecialtyID",
                table: "DoctorSpecialities");

            migrationBuilder.DropColumn(
                name: "SpecialtyID",
                table: "DoctorSpecialities");

            migrationBuilder.AddColumn<int>(
                name: "Specialty",
                table: "DoctorSpecialities",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
