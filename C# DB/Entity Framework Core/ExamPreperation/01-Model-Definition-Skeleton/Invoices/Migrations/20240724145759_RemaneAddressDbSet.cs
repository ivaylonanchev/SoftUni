using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoices.Migrations
{
    public partial class RemaneAddressDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresss_Clients_ClientId",
                table: "Addresss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresss",
                table: "Addresss");

            migrationBuilder.RenameTable(
                name: "Addresss",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_Addresss_ClientId",
                table: "Addresses",
                newName: "IX_Addresses_ClientId");

            migrationBuilder.AlterColumn<string>(
                name: "StreetName",
                table: "Addresses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Clients_ClientId",
                table: "Addresses",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Clients_ClientId",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Addresss");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_ClientId",
                table: "Addresss",
                newName: "IX_Addresss_ClientId");

            migrationBuilder.AlterColumn<string>(
                name: "StreetName",
                table: "Addresss",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresss",
                table: "Addresss",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresss_Clients_ClientId",
                table: "Addresss",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
