using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaTicketSystem.Repository.Migrations
{
    public partial class PrimaryKeyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketOrders",
                table: "TicketOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartTickets",
                table: "ShoppingCartTickets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketOrders",
                table: "TicketOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartTickets",
                table: "ShoppingCartTickets",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TicketOrders_TicketId",
                table: "TicketOrders",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartTickets_TicketId",
                table: "ShoppingCartTickets",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketOrders",
                table: "TicketOrders");

            migrationBuilder.DropIndex(
                name: "IX_TicketOrders_TicketId",
                table: "TicketOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartTickets",
                table: "ShoppingCartTickets");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartTickets_TicketId",
                table: "ShoppingCartTickets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketOrders",
                table: "TicketOrders",
                columns: new[] { "TicketId", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartTickets",
                table: "ShoppingCartTickets",
                columns: new[] { "TicketId", "ShoppingCartId" });
        }
    }
}
