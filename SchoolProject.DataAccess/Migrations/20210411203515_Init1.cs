using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolProject.DataAccess.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassNumbs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    classNumb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassNumbs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    avgScore = table.Column<int>(type: "int", nullable: false),
                    homeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    classID = table.Column<int>(type: "int", nullable: false),
                    classNumbid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                    table.ForeignKey(
                        name: "FK_Students_ClassNumbs_classNumbid",
                        column: x => x.classNumbid,
                        principalTable: "ClassNumbs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_classNumbid",
                table: "Students",
                column: "classNumbid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "ClassNumbs");
        }
    }
}
