using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyER.Server.Migrations
{
    public partial class MakeDoctorColumnNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EasyER.Server.Data.IPatientContext.Patients_Doctors_DoctorId",
                table: "EasyER.Server.Data.IPatientContext.Patients");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "EasyER.Server.Data.IPatientContext.Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EasyER.Server.Data.IPatientContext.Patients_Doctor_DoctorId",
                table: "EasyER.Server.Data.IPatientContext.Patients",
                column: "DoctorId",
                principalTable: "EasyER.Server.Data.IDoctorContext.Doctors",
                principalColumn: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EasyER.Server.Data.IPatientContext.Patients_Doctor_DoctorId",
                table: "EasyER.Server.Data.IPatientContext.Patients");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "EasyER.Server.Data.IPatientContext.Patients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EasyER.Server.Data.IPatientContext.Patients_Doctor_DoctorId",
                table: "EasyER.Server.Data.IPatientContext.Patients",
                column: "DoctorId",
                principalTable: "EasyER.Server.Data.IDoctorContext.Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
