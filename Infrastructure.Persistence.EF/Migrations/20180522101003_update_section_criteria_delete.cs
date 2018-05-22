using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.EF.Migrations
{
    public partial class update_section_criteria_delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Criteria_Section_SectionId",
                table: "Criteria");

            migrationBuilder.AddForeignKey(
                name: "FK_Criteria_Section_SectionId",
                table: "Criteria",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Criteria_Section_SectionId",
                table: "Criteria");

            migrationBuilder.AddForeignKey(
                name: "FK_Criteria_Section_SectionId",
                table: "Criteria",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
