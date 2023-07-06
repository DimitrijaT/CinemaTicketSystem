using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaTicketSystem.Web.Data.Migrations
{
    public partial class TicketImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Tickets",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Tickets");
        }
    }
}
