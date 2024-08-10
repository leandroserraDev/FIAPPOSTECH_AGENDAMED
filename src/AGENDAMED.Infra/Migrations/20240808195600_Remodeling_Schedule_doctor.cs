using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGENDAMED.Infra.Migrations
{
    public partial class Remodeling_Schedule_doctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_ScheduleSpecialityDoctor_ScheduleDoctorID_DoctorID~",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleHour_Schedule_ScheduleDoctorID_DoctorID_DayOfWeek_S~",
                table: "ScheduleHour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleSpecialityDoctor",
                table: "ScheduleSpecialityDoctor");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleSpecialityDoctor_DoctorID",
                table: "ScheduleSpecialityDoctor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleHour",
                table: "ScheduleHour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_ScheduleDoctorID_DoctorID_Speciality",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "ScheduleSpecialityDoctor");

            migrationBuilder.DropColumn(
                name: "ScheduleDoctorID",
                table: "ScheduleHour");

            migrationBuilder.DropColumn(
                name: "ScheduleDoctorID",
                table: "Schedule");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleSpecialityDoctor",
                table: "ScheduleSpecialityDoctor",
                columns: new[] { "DoctorID", "Speciality" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleHour",
                table: "ScheduleHour",
                columns: new[] { "DoctorID", "DayOfWeek", "Speciality", "Hour" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                columns: new[] { "DoctorID", "DayOfWeek", "Speciality" });

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_DoctorID_Speciality",
                table: "Schedule",
                columns: new[] { "DoctorID", "Speciality" });

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_ScheduleSpecialityDoctor_DoctorID_Speciality",
                table: "Schedule",
                columns: new[] { "DoctorID", "Speciality" },
                principalTable: "ScheduleSpecialityDoctor",
                principalColumns: new[] { "DoctorID", "Speciality" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleHour_Schedule_DoctorID_DayOfWeek_Speciality",
                table: "ScheduleHour",
                columns: new[] { "DoctorID", "DayOfWeek", "Speciality" },
                principalTable: "Schedule",
                principalColumns: new[] { "DoctorID", "DayOfWeek", "Speciality" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_ScheduleSpecialityDoctor_DoctorID_Speciality",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleHour_Schedule_DoctorID_DayOfWeek_Speciality",
                table: "ScheduleHour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleSpecialityDoctor",
                table: "ScheduleSpecialityDoctor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleHour",
                table: "ScheduleHour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_DoctorID_Speciality",
                table: "Schedule");

            migrationBuilder.AddColumn<long>(
                name: "ID",
                table: "ScheduleSpecialityDoctor",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ScheduleDoctorID",
                table: "ScheduleHour",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ScheduleDoctorID",
                table: "Schedule",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleSpecialityDoctor",
                table: "ScheduleSpecialityDoctor",
                columns: new[] { "ID", "DoctorID", "Speciality" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleHour",
                table: "ScheduleHour",
                columns: new[] { "ScheduleDoctorID", "DoctorID", "DayOfWeek", "Speciality", "Hour" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                columns: new[] { "ScheduleDoctorID", "DoctorID", "DayOfWeek", "Speciality" });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSpecialityDoctor_DoctorID",
                table: "ScheduleSpecialityDoctor",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_ScheduleDoctorID_DoctorID_Speciality",
                table: "Schedule",
                columns: new[] { "ScheduleDoctorID", "DoctorID", "Speciality" });

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_ScheduleSpecialityDoctor_ScheduleDoctorID_DoctorID~",
                table: "Schedule",
                columns: new[] { "ScheduleDoctorID", "DoctorID", "Speciality" },
                principalTable: "ScheduleSpecialityDoctor",
                principalColumns: new[] { "ID", "DoctorID", "Speciality" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleHour_Schedule_ScheduleDoctorID_DoctorID_DayOfWeek_S~",
                table: "ScheduleHour",
                columns: new[] { "ScheduleDoctorID", "DoctorID", "DayOfWeek", "Speciality" },
                principalTable: "Schedule",
                principalColumns: new[] { "ScheduleDoctorID", "DoctorID", "DayOfWeek", "Speciality" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
