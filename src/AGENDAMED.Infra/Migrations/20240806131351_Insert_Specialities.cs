using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AGENDAMED.Infra.Migrations
{
    public partial class Insert_Specialities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
   table: "Speciality",
  columns: new[] { "ID","Name", "Description", "DtCreated", "DtModified", "Deleted" },
  values: new object[]
       { "1", "Clínico Geral", "Médico clínico geral", DateTime.Now, DateTime.Now, false});

            migrationBuilder.InsertData(
              table: "Speciality",
             columns: new[] { "ID", "Name", "Description", "DtCreated", "DtModified", "Deleted" },
             values: new object[]
      { "2", "Ortopedista", "Médico ortopedista", DateTime.Now, DateTime.Now, false});

            migrationBuilder.InsertData(
      table: "Speciality",
     columns: new[] { "ID", "Name", "Description", "DtCreated", "DtModified", "Deleted" },
     values: new object[]
{ "3", "Pediatra", "Médico pediatra", DateTime.Now, DateTime.Now, false});

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Speciality", "ID", new object[1, 2, 3]);

        }
    }
}
