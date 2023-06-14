using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApi.Migrations
{
    public partial class m25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_IdCustomer",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Customer_IdCustomer",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "IdCustomer",
                table: "Review",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Review_IdCustomer",
                table: "Review",
                newName: "IX_Review_IdUser");

            migrationBuilder.RenameColumn(
                name: "IdCustomer",
                table: "Order",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Order_IdCustomer",
                table: "Order",
                newName: "IX_Order_IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_IdUser",
                table: "Order",
                column: "IdUser",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Customer_IdUser",
                table: "Review",
                column: "IdUser",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_IdUser",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Customer_IdUser",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Review",
                newName: "IdCustomer");

            migrationBuilder.RenameIndex(
                name: "IX_Review_IdUser",
                table: "Review",
                newName: "IX_Review_IdCustomer");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Order",
                newName: "IdCustomer");

            migrationBuilder.RenameIndex(
                name: "IX_Order_IdUser",
                table: "Order",
                newName: "IX_Order_IdCustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_IdCustomer",
                table: "Order",
                column: "IdCustomer",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Customer_IdCustomer",
                table: "Review",
                column: "IdCustomer",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
