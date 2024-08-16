using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AGENDAMED.Infra.Migrations
{
    public partial class Entities_System : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CEP = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    UF = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    DtCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DtModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "text", nullable: false),
                    CRM = table.Column<string>(type: "text", nullable: false),
                    DtCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DtModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Doctor_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "text", nullable: false),
                    DtCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DtModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Patient_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Speciality",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DtCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DtModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speciality", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID = table.Column<string>(type: "text", nullable: false),
                    DoctorID = table.Column<string>(type: "text", nullable: false),
                    SpecialityID = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DtCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DtModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Appointment_AspNetUsers_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointment_AspNetUsers_PatientID",
                        column: x => x.PatientID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointment_Speciality_SpecialityID",
                        column: x => x.SpecialityID,
                        principalTable: "Speciality",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DoctorSpecialities",
                columns: table => new
                {
                    SpecialtyID = table.Column<long>(type: "bigint", nullable: false),
                    DoctorID = table.Column<string>(type: "text", nullable: false),
                    DtCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DtModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpecialities", x => new { x.DoctorID, x.SpecialtyID });
                    table.ForeignKey(
                        name: "FK_DoctorSpecialities_Doctor_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctor",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSpecialities_Speciality_SpecialtyID",
                        column: x => x.SpecialtyID,
                        principalTable: "Speciality",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleSpecialityDoctor",
                columns: table => new
                {
                    DoctorID = table.Column<string>(type: "text", nullable: false),
                    SpecialityID = table.Column<long>(type: "bigint", nullable: false),
                    DtCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DtModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleSpecialityDoctor", x => new { x.DoctorID, x.SpecialityID });
                    table.ForeignKey(
                        name: "FK_ScheduleSpecialityDoctor_DoctorSpecialities_DoctorID_Specia~",
                        columns: x => new { x.DoctorID, x.SpecialityID },
                        principalTable: "DoctorSpecialities",
                        principalColumns: new[] { "DoctorID", "SpecialtyID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    DoctorID = table.Column<string>(type: "text", nullable: false),
                    Speciality = table.Column<long>(type: "bigint", nullable: false),
                    DayOfWeek = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => new { x.DoctorID, x.DayOfWeek, x.Speciality });
                    table.ForeignKey(
                        name: "FK_Schedule_ScheduleSpecialityDoctor_DoctorID_Speciality",
                        columns: x => new { x.DoctorID, x.Speciality },
                        principalTable: "ScheduleSpecialityDoctor",
                        principalColumns: new[] { "DoctorID", "SpecialityID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleHour",
                columns: table => new
                {
                    DoctorID = table.Column<string>(type: "text", nullable: false),
                    Speciality = table.Column<long>(type: "bigint", nullable: false),
                    DayOfWeek = table.Column<long>(type: "bigint", nullable: false),
                    Time = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleHour", x => new { x.DoctorID, x.DayOfWeek, x.Speciality, x.Time });
                    table.ForeignKey(
                        name: "FK_ScheduleHour_Schedule_DoctorID_DayOfWeek_Speciality",
                        columns: x => new { x.DoctorID, x.DayOfWeek, x.Speciality },
                        principalTable: "Schedule",
                        principalColumns: new[] { "DoctorID", "DayOfWeek", "Speciality" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7fbdb6ec-32de-4d1f-9856-de3c5bb9eeb1", 0, "56f0007e-84e2-4865-b825-e063828f9301", "administrador@administrador.com", true, "administrador@administrador.com", false, null, "administrador@administrador.com", null, null, "AQAAAAEAACcQAAAAEPaxooTLLI7WsPfgIBM+dLgjtI2CN13XRZTl5aLSPgLuXgSTKC/wGOMiYlfiK5QwPg==", null, false, "a7b565ef-b7a6-4fa3-afc1-ca2a0ed7ab23", false, "administrador@administrador.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "7fbdb6ec-32de-4d1f-9856-de3c5bb9eeb1" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DoctorID",
                table: "Appointment",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientID",
                table: "Appointment",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_SpecialityID",
                table: "Appointment",
                column: "SpecialityID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecialities_SpecialtyID",
                table: "DoctorSpecialities",
                column: "SpecialtyID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_DoctorID_Speciality",
                table: "Schedule",
                columns: new[] { "DoctorID", "Speciality" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "ScheduleHour");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "ScheduleSpecialityDoctor");

            migrationBuilder.DropTable(
                name: "DoctorSpecialities");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Speciality");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "7fbdb6ec-32de-4d1f-9856-de3c5bb9eeb1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7fbdb6ec-32de-4d1f-9856-de3c5bb9eeb1");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");
        }
    }
}
