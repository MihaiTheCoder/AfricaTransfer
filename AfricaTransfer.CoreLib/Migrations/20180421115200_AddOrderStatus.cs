using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AfricaTransfer.CoreLib.Migrations
{
    public partial class AddOrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerID",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_BuyerID",
                table: "Order",
                column: "BuyerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AuthModel_BuyerID",
                table: "Order",
                column: "BuyerID",
                principalTable: "AuthModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AuthModel_BuyerID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_BuyerID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "BuyerID",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Order");
        }
    }
}
