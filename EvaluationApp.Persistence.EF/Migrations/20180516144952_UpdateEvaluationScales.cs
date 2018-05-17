using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaluationApp.Persistence.EF.Migrations
{
    public partial class UpdateEvaluationScales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationScaleOption_EvaluationScale_EvaluationScaleId",
                table: "EvaluationScaleOption");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_EvaluationScale_EvaluationScaleId",
                table: "Section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EvaluationScale",
                table: "EvaluationScale");

            migrationBuilder.RenameTable(
                name: "EvaluationScale",
                newName: "EvaluationScales");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EvaluationScales",
                table: "EvaluationScales",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationScaleOption_EvaluationScales_EvaluationScaleId",
                table: "EvaluationScaleOption",
                column: "EvaluationScaleId",
                principalTable: "EvaluationScales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_EvaluationScales_EvaluationScaleId",
                table: "Section",
                column: "EvaluationScaleId",
                principalTable: "EvaluationScales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationScaleOption_EvaluationScales_EvaluationScaleId",
                table: "EvaluationScaleOption");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_EvaluationScales_EvaluationScaleId",
                table: "Section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EvaluationScales",
                table: "EvaluationScales");

            migrationBuilder.RenameTable(
                name: "EvaluationScales",
                newName: "EvaluationScale");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EvaluationScale",
                table: "EvaluationScale",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationScaleOption_EvaluationScale_EvaluationScaleId",
                table: "EvaluationScaleOption",
                column: "EvaluationScaleId",
                principalTable: "EvaluationScale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_EvaluationScale_EvaluationScaleId",
                table: "Section",
                column: "EvaluationScaleId",
                principalTable: "EvaluationScale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
