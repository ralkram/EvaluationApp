using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.EF.Migrations
{
    public partial class added_cascade_delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_Evaluations_EvaluationId",
                table: "Section");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Evaluations_EvaluationId",
                table: "Section",
                column: "EvaluationId",
                principalTable: "Evaluations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_Evaluations_EvaluationId",
                table: "Section");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Evaluations_EvaluationId",
                table: "Section",
                column: "EvaluationId",
                principalTable: "Evaluations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
