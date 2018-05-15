using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaluationApp.Persistence.EF.Migrations
{
    public partial class updated_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormId",
                table: "Evaluations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormId",
                table: "Evaluations");
        }
    }
}
