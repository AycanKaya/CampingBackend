using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    public partial class CommentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Campsite_CampsiteID",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_CampsiteID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CampsiteID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "CampsiteVacationSpotID",
                table: "Comment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CampsiteVacationSpotID",
                table: "Comment",
                column: "CampsiteVacationSpotID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Campsite_CampsiteVacationSpotID",
                table: "Comment",
                column: "CampsiteVacationSpotID",
                principalTable: "Campsite",
                principalColumn: "VacationSpotID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Campsite_CampsiteVacationSpotID",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_CampsiteVacationSpotID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CampsiteVacationSpotID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "CampsiteID",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CampsiteID",
                table: "Comment",
                column: "CampsiteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Campsite_CampsiteID",
                table: "Comment",
                column: "CampsiteID",
                principalTable: "Campsite",
                principalColumn: "VacationSpotID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
