using Microsoft.EntityFrameworkCore.Migrations;

namespace IgnitisTask.Migrations
{
    public partial class PrimaryKeyChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Junctions",
                table: "Junctions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Junctions",
                table: "Junctions",
                columns: new[] { "QuestionId", "AnswerId", "FormId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Junctions",
                table: "Junctions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Junctions",
                table: "Junctions",
                columns: new[] { "QuestionId", "AnswerId" });
        }
    }
}
