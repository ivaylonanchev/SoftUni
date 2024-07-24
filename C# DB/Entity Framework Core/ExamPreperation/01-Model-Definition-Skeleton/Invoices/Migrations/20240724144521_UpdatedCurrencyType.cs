using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoices.Migrations
{
    public partial class UpdatedCurrencyType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Invoices",
                newName: "CurrencyType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrencyType",
                table: "Invoices",
                newName: "Type");
        }
    }
}
