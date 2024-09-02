using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication8.Migrations.Store_contextMigrations
{
    public partial class MyMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Product_Name",
                table: "Store",
                type: "varchar(150)",
                unicode: false,
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Product_Name",
                table: "Store");
        }
    }
}
