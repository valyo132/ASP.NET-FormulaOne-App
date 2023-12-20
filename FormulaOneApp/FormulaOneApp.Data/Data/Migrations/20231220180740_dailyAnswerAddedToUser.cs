using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaOneApp.Web.Data.Migrations
{
    public partial class dailyAnswerAddedToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DailyQuestionAnswer",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyQuestionAnswer",
                table: "AspNetUsers");
        }
    }
}
