using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AfricaTransfer.CoreLib.Migrations
{
    public partial class AddTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankTransaction",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ammount = table.Column<float>(nullable: false),
                    DestinationAuthModelID = table.Column<int>(nullable: false),
                    SourceBankID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransaction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BankTransaction_AuthModel_DestinationAuthModelID",
                        column: x => x.DestinationAuthModelID,
                        principalTable: "AuthModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MobileTransaction",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ammount = table.Column<float>(nullable: false),
                    DestinationAuthModelID = table.Column<int>(nullable: false),
                    DestinationModelAuthModelID = table.Column<int>(nullable: true),
                    SourceAuthModelID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileTransaction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MobileTransaction_AuthModel_DestinationModelAuthModelID",
                        column: x => x.DestinationModelAuthModelID,
                        principalTable: "AuthModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MobileTransaction_AuthModel_SourceAuthModelID",
                        column: x => x.SourceAuthModelID,
                        principalTable: "AuthModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankTransaction_DestinationAuthModelID",
                table: "BankTransaction",
                column: "DestinationAuthModelID");

            migrationBuilder.CreateIndex(
                name: "IX_MobileTransaction_DestinationModelAuthModelID",
                table: "MobileTransaction",
                column: "DestinationModelAuthModelID");

            migrationBuilder.CreateIndex(
                name: "IX_MobileTransaction_SourceAuthModelID",
                table: "MobileTransaction",
                column: "SourceAuthModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankTransaction");

            migrationBuilder.DropTable(
                name: "MobileTransaction");
        }
    }
}
