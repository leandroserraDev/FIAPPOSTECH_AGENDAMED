using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGENDAMED.Infra.Migrations
{
    public partial class Add_Speciality_To_Appointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_AspNetUsers_DoctorID",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_AspNetUsers_PatientID",
                table: "Appointment");

            migrationBuilder.AddColumn<long>(
                name: "SpecialityID",
                table: "Appointment",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_SpecialityID",
                table: "Appointment",
                column: "SpecialityID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Speciality_SpecialityID",
                table: "Appointment",
                column: "SpecialityID",
                principalTable: "Speciality",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Doctor_DoctorID",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Patient_PatientID",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Speciality_SpecialityID",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_SpecialityID",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "SpecialityID",
                table: "Appointment");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AspNetUsers_DoctorID",
                table: "Appointment",
                column: "DoctorID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AspNetUsers_PatientID",
                table: "Appointment",
                column: "PatientID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
