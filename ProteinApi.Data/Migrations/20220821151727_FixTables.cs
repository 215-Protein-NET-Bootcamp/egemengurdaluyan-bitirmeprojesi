using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProteinApi.Data.Migrations
{
    public partial class FixTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Account_AccountId",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Product",
                type: "integer",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Account_AccountId",
                table: "Product",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Account_AccountId",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Product",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Account_AccountId",
                table: "Product",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id");
        }
    }
}
