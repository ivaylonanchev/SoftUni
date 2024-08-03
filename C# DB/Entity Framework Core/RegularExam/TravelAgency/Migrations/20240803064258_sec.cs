using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Migrations
{
    public partial class sec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Customer_CustomerID",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_TourPackage_TourPackageId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_TourPackageGuide_Guide_GuideId",
                table: "TourPackageGuide");

            migrationBuilder.DropForeignKey(
                name: "FK_TourPackageGuide_TourPackage_TourPackageId",
                table: "TourPackageGuide");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourPackageGuide",
                table: "TourPackageGuide");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourPackage",
                table: "TourPackage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guide",
                table: "Guide");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.RenameTable(
                name: "TourPackageGuide",
                newName: "TourPackageGuides");

            migrationBuilder.RenameTable(
                name: "TourPackage",
                newName: "TourPackages");

            migrationBuilder.RenameTable(
                name: "Guide",
                newName: "Guides");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameIndex(
                name: "IX_TourPackageGuide_TourPackageId",
                table: "TourPackageGuides",
                newName: "IX_TourPackageGuides_TourPackageId");

            migrationBuilder.RenameIndex(
                name: "IX_TourPackageGuide_GuideId",
                table: "TourPackageGuides",
                newName: "IX_TourPackageGuides_GuideId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_TourPackageId",
                table: "Bookings",
                newName: "IX_Bookings_TourPackageId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_CustomerID",
                table: "Bookings",
                newName: "IX_Bookings_CustomerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourPackageGuides",
                table: "TourPackageGuides",
                columns: new[] { "GuideId", "TourPackageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourPackages",
                table: "TourPackages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guides",
                table: "Guides",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_CustomerID",
                table: "Bookings",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_TourPackages_TourPackageId",
                table: "Bookings",
                column: "TourPackageId",
                principalTable: "TourPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourPackageGuides_Guides_GuideId",
                table: "TourPackageGuides",
                column: "GuideId",
                principalTable: "Guides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourPackageGuides_TourPackages_TourPackageId",
                table: "TourPackageGuides",
                column: "TourPackageId",
                principalTable: "TourPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_CustomerID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_TourPackages_TourPackageId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TourPackageGuides_Guides_GuideId",
                table: "TourPackageGuides");

            migrationBuilder.DropForeignKey(
                name: "FK_TourPackageGuides_TourPackages_TourPackageId",
                table: "TourPackageGuides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourPackages",
                table: "TourPackages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourPackageGuides",
                table: "TourPackageGuides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guides",
                table: "Guides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "TourPackages",
                newName: "TourPackage");

            migrationBuilder.RenameTable(
                name: "TourPackageGuides",
                newName: "TourPackageGuide");

            migrationBuilder.RenameTable(
                name: "Guides",
                newName: "Guide");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameIndex(
                name: "IX_TourPackageGuides_TourPackageId",
                table: "TourPackageGuide",
                newName: "IX_TourPackageGuide_TourPackageId");

            migrationBuilder.RenameIndex(
                name: "IX_TourPackageGuides_GuideId",
                table: "TourPackageGuide",
                newName: "IX_TourPackageGuide_GuideId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_TourPackageId",
                table: "Booking",
                newName: "IX_Booking_TourPackageId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_CustomerID",
                table: "Booking",
                newName: "IX_Booking_CustomerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourPackage",
                table: "TourPackage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourPackageGuide",
                table: "TourPackageGuide",
                columns: new[] { "GuideId", "TourPackageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guide",
                table: "Guide",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Customer_CustomerID",
                table: "Booking",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_TourPackage_TourPackageId",
                table: "Booking",
                column: "TourPackageId",
                principalTable: "TourPackage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourPackageGuide_Guide_GuideId",
                table: "TourPackageGuide",
                column: "GuideId",
                principalTable: "Guide",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourPackageGuide_TourPackage_TourPackageId",
                table: "TourPackageGuide",
                column: "TourPackageId",
                principalTable: "TourPackage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
