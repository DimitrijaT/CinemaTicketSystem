using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaTicketSystem.Web.Data.Migrations
{
    public partial class UpdateNewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketOrder_Order_OrderId",
                table: "TicketOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketOrder_Tickets_TicketId",
                table: "TicketOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketOrder",
                table: "TicketOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "TicketOrder",
                newName: "TicketOrders");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_TicketOrder_OrderId",
                table: "TicketOrders",
                newName: "IX_TicketOrders_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketOrders",
                table: "TicketOrders",
                columns: new[] { "TicketId", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketOrders_Orders_OrderId",
                table: "TicketOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketOrders_Tickets_TicketId",
                table: "TicketOrders",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketOrders_Orders_OrderId",
                table: "TicketOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketOrders_Tickets_TicketId",
                table: "TicketOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketOrders",
                table: "TicketOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "TicketOrders",
                newName: "TicketOrder");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_TicketOrders_OrderId",
                table: "TicketOrder",
                newName: "IX_TicketOrder_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketOrder",
                table: "TicketOrder",
                columns: new[] { "TicketId", "OrderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketOrder_Order_OrderId",
                table: "TicketOrder",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketOrder_Tickets_TicketId",
                table: "TicketOrder",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
