using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyER.Server.Migrations
{
    public partial class MadeNurseNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EasyER.Server.Data.IPatientContext.Patients_Nurses_NurseId",
                table: "EasyER.Server.Data.IPatientContext.Patients");

            migrationBuilder.AlterColumn<int>(
                name: "NurseId",
                table: "EasyER.Server.Data.IPatientContext.Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EasyER.Server.Data.IPatientContext.Patients_Nurses_NurseId",
                table: "EasyER.Server.Data.IPatientContext.Patients",
                column: "NurseId",
                principalTable: "EasyER.Server.Data.INurseContext.Nurses",
                principalColumn: "NurseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EasyER.Server.Data.IPatientContext.Patients_Nurses_NurseId",
                table: "EasyER.Server.Data.IPatientContext.Patients");

            migrationBuilder.AlterColumn<int>(
                name: "NurseId",
                table: "EasyER.Server.Data.IPatientContext.Patients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EasyER.Server.Data.IPatientContext.Patients_Nurses_NurseId",
                table: "EasyER.Server.Data.IPatientContext.Patients",
                column: "NurseId",
                principalTable: "EasyER.Server.Data.INurseContext.Nurses",
                principalColumn: "NurseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
