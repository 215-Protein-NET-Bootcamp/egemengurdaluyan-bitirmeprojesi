using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProteinApi.Data.Migrations
{
    public partial class FixingColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Account_AccountId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_AccountId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Product",
                type: "integer",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_AccountId",
                table: "Product",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Account_AccountId",
                table: "Product",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
