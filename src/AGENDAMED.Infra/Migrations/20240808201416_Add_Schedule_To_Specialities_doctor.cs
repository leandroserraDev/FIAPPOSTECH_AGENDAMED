using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AGENDAMED.Infra.Migrations
{
    public partial class Add_Schedule_To_Specialities_doctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_ScheduleSpecialityDoctor_DoctorID_Speciality",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleSpecialityDoctor_Doctor_DoctorID",
                table: "ScheduleSpecialityDoctor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleSpecialityDoctor",
                table: "ScheduleSpecialityDoctor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorSpecialities",
                table: "DoctorSpecialities");

            migrationBuilder.DropIndex(
                name: "IX_DoctorSpecialities_DoctorID",
                table: "DoctorSpecialities");

            migrationBuilder.DropColumn(
                name: "Speciality",
                table: "ScheduleSpecialityDoctor");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "DoctorSpecialities");

            migrationBuilder.AddColumn<long>(
                name: "SpecialityID",
                table: "ScheduleSpecialityDoctor",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "Speciality",
                table: "ScheduleHour",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "Speciality",
                table: "Schedule",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleSpecialityDoctor",
                table: "ScheduleSpecialityDoctor",
                columns: new[] { "DoctorID", "SpecialityID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorSpecialities",
                table: "DoctorSpecialities",
                columns: new[] { "DoctorID", "SpecialtyID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_ScheduleSpecialityDoctor_DoctorID_Speciality",
                table: "Schedule",
                columns: new[] { "DoctorID", "Speciality" },
                principalTable: "ScheduleSpecialityDoctor",
                principalColumns: new[] { "DoctorID", "SpecialityID" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleSpecialityDoctor_DoctorSpecialities_DoctorID_Specia~",
                table: "ScheduleSpecialityDoctor",
                columns: new[] { "DoctorID", "SpecialityID" },
                principalTable: "DoctorSpecialities",
                principalColumns: new[] { "DoctorID", "SpecialtyID" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_ScheduleSpecialityDoctor_DoctorID_Speciality",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleSpecialityDoctor_DoctorSpecialities_DoctorID_Specia~",
                table: "ScheduleSpecialityDoctor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleSpecialityDoctor",
                table: "ScheduleSpecialityDoctor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorSpecialities",
                table: "DoctorSpecialities");

            migrationBuilder.DropColumn(
                name: "SpecialityID",
                table: "ScheduleSpecialityDoctor");

            migrationBuilder.AddColumn<int>(
                name: "Speciality",
                table: "ScheduleSpecialityDoctor",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Speciality",
                table: "ScheduleHour",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Speciality",
                table: "Schedule",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "ID",
                table: "DoctorSpecialities",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleSpecialityDoctor",
                table: "ScheduleSpecialityDoctor",
                columns: new[] { "DoctorID", "Speciality" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorSpecialities",
                table: "DoctorSpecialities",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecialities_DoctorID",
                table: "DoctorSpecialities",
                column: "DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_ScheduleSpecialityDoctor_DoctorID_Speciality",
                table: "Schedule",
                columns: new[] { "DoctorID", "Speciality" },
                principalTable: "ScheduleSpecialityDoctor",
                principalColumns: new[] { "DoctorID", "Speciality" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleSpecialityDoctor_Doctor_DoctorID",
                table: "ScheduleSpecialityDoctor",
                column: "DoctorID",
                principalTable: "Doctor",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
