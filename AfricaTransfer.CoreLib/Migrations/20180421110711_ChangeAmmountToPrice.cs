using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AfricaTransfer.CoreLib.Migrations
{
    public partial class ChangeAmmountToPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ammount",
                table: "Product");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Product",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ProductPrice",
                table: "OrderLine",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_OrderID",
                table: "OrderLine",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Order_OrderID",
                table: "OrderLine",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_Order_OrderID",
                table: "OrderLine");

            migrationBuilder.DropIndex(
                name: "IX_OrderLine_OrderID",
                table: "OrderLine");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "OrderLine");

            migrationBuilder.AddColumn<string>(
                name: "Ammount",
                table: "Product",
                nullable: true);
        }
    }
}
