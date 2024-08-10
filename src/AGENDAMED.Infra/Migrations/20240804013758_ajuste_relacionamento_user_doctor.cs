using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AGENDAMED.Infra.Migrations
{
    public partial class ajuste_relacionamento_user_doctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Doctor_DoctorID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpecialities_Doctor_DoctorID",
                table: "DoctorSpecialities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DoctorID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorID",
                table: "DoctorSpecialities",
                type: "text",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_AspNetUsers_UserID",
                table: "Doctor",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpecialities_Doctor_DoctorID",
                table: "DoctorSpecialities",
                column: "DoctorID",
                principalTable: "Doctor",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_AspNetUsers_UserID",
                table: "Doctor");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpecialities_Doctor_DoctorID",
                table: "DoctorSpecialities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor");

            migrationBuilder.AlterColumn<long>(
                name: "DoctorID",
                table: "DoctorSpecialities",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<long>(
                name: "ID",
                table: "Doctor",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "DoctorID",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor",
                column: "ID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpecialities_Doctor_DoctorID",
                table: "DoctorSpecialities",
                column: "DoctorID",
                principalTable: "Doctor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
