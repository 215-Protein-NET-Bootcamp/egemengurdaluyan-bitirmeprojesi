using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProteinApi.Data.Migrations
{
    public partial class FixingColumnOnProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Product",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Product");
        }
    }
}
