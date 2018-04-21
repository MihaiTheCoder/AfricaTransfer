using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AfricaTransfer.CoreLib.Migrations
{
    public partial class BuyerNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AuthModel_BuyerID",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerID",
                table: "Order",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AuthModel_BuyerID",
                table: "Order",
                column: "BuyerID",
                principalTable: "AuthModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AuthModel_BuyerID",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerID",
                table: "Order",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AuthModel_BuyerID",
                table: "Order",
                column: "BuyerID",
                principalTable: "AuthModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
