using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyER.Server.Migrations
{
    public partial class AddDocAndNurseForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "EasyER.Server.Data.IPatientContext.Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsBeingSeen",
                table: "EasyER.Server.Data.IPatientContext.Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NurseId",
                table: "EasyER.Server.Data.IPatientContext.Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeAdmitted",
                table: "EasyER.Server.Data.IPatientContext.Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            /*
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnCall = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "Nurse",
                columns: table => new
                {
                    NurseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurse", x => x.NurseId);
                });
            */

            migrationBuilder.CreateIndex(
                name: "IX_EasyER.Server.Data.IPatientContext.Patients_DoctorId",
                table: "EasyER.Server.Data.IPatientContext.Patients",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_EasyER.Server.Data.IPatientContext.Patients_NurseId",
                table: "EasyER.Server.Data.IPatientContext.Patients",
                column: "NurseId");

            migrationBuilder.AddForeignKey(
                name: "FK_EasyER.Server.Data.IPatientContext.Patients_Doctors_DoctorId",
                table: "EasyER.Server.Data.IPatientContext.Patients",
                column: "DoctorId",
                principalTable: "EasyER.Server.Data.IDoctorContext.Doctors", 
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EasyER.Server.Data.IPatientContext.Patients_Nurses_NurseId",
                table: "EasyER.Server.Data.IPatientContext.Patients",
                column: "NurseId",
                principalTable: "EasyER.Server.Data.INurseContext.Nurses",
                principalColumn: "NurseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EasyER.Server.Data.IPatientContext.Patients_Doctor_DoctorId",
                table: "EasyER.Server.Data.IPatientContext.Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_EasyER.Server.Data.IPatientContext.Patients_Nurse_NurseId",
                table: "EasyER.Server.Data.IPatientContext.Patients");

            /*
            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Nurse");
            */

            migrationBuilder.DropIndex(
                name: "IX_EasyER.Server.Data.IPatientContext.Patients_DoctorId",
                table: "EasyER.Server.Data.IPatientContext.Patients");

            migrationBuilder.DropIndex(
                name: "IX_EasyER.Server.Data.IPatientContext.Patients_NurseId",
                table: "EasyER.Server.Data.IPatientContext.Patients");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "EasyER.Server.Data.IPatientContext.Patients");

            migrationBuilder.DropColumn(
                name: "IsBeingSeen",
                table: "EasyER.Server.Data.IPatientContext.Patients");

            migrationBuilder.DropColumn(
                name: "NurseId",
                table: "EasyER.Server.Data.IPatientContext.Patients");

            migrationBuilder.DropColumn(
                name: "TimeAdmitted",
                table: "EasyER.Server.Data.IPatientContext.Patients");
        }
    }
}
