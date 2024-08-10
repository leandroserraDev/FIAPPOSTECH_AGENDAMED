using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGENDAMED.Infra.Migrations
{
    public partial class remove_schedule_to_doctor_specialities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleSpecialityDoctor_DoctorSpecialities_DoctorID_Specia~",
                table: "ScheduleSpecialityDoctor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleSpecialityDoctor_DoctorSpecialities_DoctorID_Specia~",
                table: "ScheduleSpecialityDoctor",
                columns: new[] { "DoctorID", "SpecialityID" },
                principalTable: "DoctorSpecialities",
                principalColumns: new[] { "DoctorID", "SpecialtyID" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
