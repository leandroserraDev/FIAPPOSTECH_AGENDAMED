using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGENDAMED.Infra.Migrations
{
    public partial class Add_Schedule_Doctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduleSpecialityDoctor",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    DoctorID = table.Column<string>(type: "text", nullable: false),
                    Speciality = table.Column<int>(type: "integer", nullable: false),
                    DtCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DtModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleSpecialityDoctor", x => new { x.ID, x.DoctorID, x.Speciality });
                    table.ForeignKey(
                        name: "FK_ScheduleSpecialityDoctor_Doctor_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctor",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleDoctorID = table.Column<long>(type: "bigint", nullable: false),
                    DoctorID = table.Column<string>(type: "text", nullable: false),
                    Speciality = table.Column<int>(type: "integer", nullable: false),
                    DayOfWeek = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => new { x.ScheduleDoctorID, x.DoctorID, x.DayOfWeek, x.Speciality });
                    table.ForeignKey(
                        name: "FK_Schedule_ScheduleSpecialityDoctor_ScheduleDoctorID_DoctorID~",
                        columns: x => new { x.ScheduleDoctorID, x.DoctorID, x.Speciality },
                        principalTable: "ScheduleSpecialityDoctor",
                        principalColumns: new[] { "ID", "DoctorID", "Speciality" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleHour",
                columns: table => new
                {
                    ScheduleDoctorID = table.Column<long>(type: "bigint", nullable: false),
                    DoctorID = table.Column<string>(type: "text", nullable: false),
                    Speciality = table.Column<int>(type: "integer", nullable: false),
                    DayOfWeek = table.Column<int>(type: "integer", nullable: false),
                    Hour = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleHour", x => new { x.ScheduleDoctorID, x.DoctorID, x.DayOfWeek, x.Speciality, x.Hour });
                    table.ForeignKey(
                        name: "FK_ScheduleHour_Schedule_ScheduleDoctorID_DoctorID_DayOfWeek_S~",
                        columns: x => new { x.ScheduleDoctorID, x.DoctorID, x.DayOfWeek, x.Speciality },
                        principalTable: "Schedule",
                        principalColumns: new[] { "ScheduleDoctorID", "DoctorID", "DayOfWeek", "Speciality" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_ScheduleDoctorID_DoctorID_Speciality",
                table: "Schedule",
                columns: new[] { "ScheduleDoctorID", "DoctorID", "Speciality" });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSpecialityDoctor_DoctorID",
                table: "ScheduleSpecialityDoctor",
                column: "DoctorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleHour");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "ScheduleSpecialityDoctor");
        }
    }
}
