using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication8.Migrations.Order_contextMigrations
{
    public partial class MyMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Product_Name",
                table: "Order",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Store_Name",
                table: "Order",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Product_Name",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Store_Name",
                table: "Order");
        }
    }
}
