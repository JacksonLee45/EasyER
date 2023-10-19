using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyER.Server.Migrations.Nurse
{
    public partial class AddNurseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EasyER.Server.Data.INurseContext.Nurses",
                columns: table => new
                {
                    NurseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyER.Server.Data.INurseContext.Nurses", x => x.NurseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EasyER.Server.Data.INurseContext.Nurses");
        }
    }
}
