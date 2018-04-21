using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AfricaTransfer.CoreLib.Migrations
{
    public partial class AddPhoneCredit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneCredit",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthModelID = table.Column<int>(nullable: false),
                    Credit = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneCredit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PhoneCredit_AuthModel_AuthModelID",
                        column: x => x.AuthModelID,
                        principalTable: "AuthModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneCredit_AuthModelID",
                table: "PhoneCredit",
                column: "AuthModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneCredit");
        }
    }
}
