using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyER.Server.Migrations.Doctor
{
    public partial class AddCurrentPatientIdColumnToDoctorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentPatientId",
                table: "EasyER.Server.Data.IDoctorContext.Doctors",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentPatientId",
                table: "EasyER.Server.Data.IDoctorContext.Doctors");
        }
    }
}
