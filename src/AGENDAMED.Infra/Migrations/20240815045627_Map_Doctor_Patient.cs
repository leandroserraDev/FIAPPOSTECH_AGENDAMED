using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGENDAMED.Infra.Migrations
{
    public partial class Map_Doctor_Patient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Doctor_DoctorID",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Patient_PatientID",
                table: "Appointment");

            migrationBuilder.AlterColumn<long>(
                name: "DayOfWeek",
                table: "ScheduleHour",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "DayOfWeek",
                table: "Schedule",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AspNetUsers_DoctorID",
                table: "Appointment",
                column: "DoctorID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AspNetUsers_PatientID",
                table: "Appointment",
                column: "PatientID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_AspNetUsers_DoctorID",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_AspNetUsers_PatientID",
                table: "Appointment");

            migrationBuilder.AlterColumn<int>(
                name: "DayOfWeek",
                table: "ScheduleHour",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "DayOfWeek",
                table: "Schedule",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Doctor_DoctorID",
                table: "Appointment",
                column: "DoctorID",
                principalTable: "Doctor",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Patient_PatientID",
                table: "Appointment",
                column: "PatientID",
                principalTable: "Patient",
                principalColumn: "UserID");
        }
    }
}
