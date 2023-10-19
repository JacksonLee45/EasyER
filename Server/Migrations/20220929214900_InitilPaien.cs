using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyER.Server.Migrations
{
    public partial class InitilPaien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EasyER.Server.Data.IPatientContext.Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TraumaLevel = table.Column<int>(type: "int", nullable: false),
                    InjuryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InjuryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyER.Server.Data.IPatientContext.Patients", x => x.PatientId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EasyER.Server.Data.IPatientContext.Patients");
        }
    }
}
