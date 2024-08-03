using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Migrations
{
    public partial class info : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_CustomerID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TourPackageGuides_Guides_GuideId",
                table: "TourPackageGuides");

            migrationBuilder.DropForeignKey(
                name: "FK_TourPackageGuides_TourPackages_TourPackageId",
                table: "TourPackageGuides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourPackageGuides",
                table: "TourPackageGuides");

            migrationBuilder.DropIndex(
                name: "IX_TourPackageGuides_GuideId",
                table: "TourPackageGuides");

            migrationBuilder.RenameTable(
                name: "TourPackageGuides",
                newName: "TourPackagesGuides");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Bookings",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_CustomerID",
                table: "Bookings",
                newName: "IX_Bookings_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_TourPackageGuides_TourPackageId",
                table: "TourPackagesGuides",
                newName: "IX_TourPackagesGuides_TourPackageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourPackagesGuides",
                table: "TourPackagesGuides",
                columns: new[] { "GuideId", "TourPackageId" });

            migrationBuilder.InsertData(
                table: "Guides",
                columns: new[] { "Id", "FullName", "Language" },
                values: new object[,]
                {
                    { 1, "John Doe", 4 },
                    { 2, "Jane Smith", 0 },
                    { 3, "Alex Johnson", 3 },
                    { 4, "Emily Davis", 2 },
                    { 5, "Michael Brown", 1 },
                    { 6, "Sarah Wilson", 4 },
                    { 7, "David Lee", 0 },
                    { 8, "Laura Garcia", 1 },
                    { 9, "Chris Martin", 3 },
                    { 10, "Anna Thompson", 2 }
                });

            migrationBuilder.InsertData(
                table: "TourPackages",
                columns: new[] { "Id", "Description", "PackageName", "Price" },
                values: new object[,]
                {
                    { 1, "Experience the thrill of a guided horse riding tour through picturesque landscapes. Suitable for all skill levels. Enjoy nature and create unforgettable memories. Duration: 3 hours.", "Horse Riding Tour", 199.99m },
                    { 2, "Explore the city's top attractions with a guided sightseeing tour. Visit historical landmarks, iconic buildings, and scenic spots. Perfect for all ages. Duration: 4 hours.", "Sightseeing Tour", 149.99m },
                    { 3, "Dive into the crystal-clear waters and explore vibrant coral reefs and marine life. Suitable for beginners and experienced divers. Equipment provided. Duration: 2 hours.", "Diving Tour", 299.99m },
                    { 4, "Embark on an exhilarating mountain hiking tour. Enjoy breathtaking views, fresh air, and challenging trails. Suitable for all fitness levels. Duration: 5 hours.", "Mountain Hiking", 179.99m },
                    { 5, "Discover the charm of the city with a guided tour. Visit famous landmarks, bustling markets, and hidden gems. Perfect for all ages. Duration: 3 hours.", "City Tour", 129.99m },
                    { 6, "Savor the local flavors on a guided food tour. Taste a variety of dishes, visit top eateries, and learn about the culinary culture. Suitable for all food lovers. Duration: 3 hours.", "Food Tour", 99.99m },
                    { 7, "Embark on an exciting wildlife safari. Spot exotic animals in their natural habitat, guided by experts. Perfect for nature enthusiasts. Duration: 4 hours.", "Wildlife Safari", 249.99m },
                    { 8, "Explore ancient ruins, museums, and landmarks on a guided tour. Learn about the rich history and culture of the area. Ideal for history buffs. Duration: 4 hours.", "Historical Sites", 159.99m },
                    { 9, "Experience a breathtaking sunset on a luxury cruise. Enjoy stunning views, delicious refreshments, and a relaxing atmosphere. Perfect for couples and families. Duration: 2 hours.", "Sunset Cruise", 399.99m }
                });

            migrationBuilder.InsertData(
                table: "TourPackagesGuides",
                columns: new[] { "GuideId", "TourPackageId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 4 },
                    { 1, 7 },
                    { 2, 1 },
                    { 2, 4 },
                    { 2, 8 },
                    { 3, 1 },
                    { 3, 5 },
                    { 3, 8 },
                    { 4, 2 },
                    { 4, 5 },
                    { 4, 8 },
                    { 5, 2 },
                    { 5, 5 },
                    { 5, 9 },
                    { 6, 2 },
                    { 6, 6 },
                    { 6, 9 },
                    { 7, 3 },
                    { 7, 6 },
                    { 7, 9 },
                    { 8, 3 },
                    { 8, 6 },
                    { 9, 3 },
                    { 9, 7 },
                    { 10, 4 },
                    { 10, 7 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_CustomerId",
                table: "Bookings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourPackagesGuides_Guides_GuideId",
                table: "TourPackagesGuides",
                column: "GuideId",
                principalTable: "Guides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TourPackagesGuides_TourPackages_TourPackageId",
                table: "TourPackagesGuides",
                column: "TourPackageId",
                principalTable: "TourPackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_CustomerId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TourPackagesGuides_Guides_GuideId",
                table: "TourPackagesGuides");

            migrationBuilder.DropForeignKey(
                name: "FK_TourPackagesGuides_TourPackages_TourPackageId",
                table: "TourPackagesGuides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TourPackagesGuides",
                table: "TourPackagesGuides");

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 9, 7 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "TourPackagesGuides",
                keyColumns: new[] { "GuideId", "TourPackageId" },
                keyValues: new object[] { 10, 7 });

            migrationBuilder.DeleteData(
                table: "Guides",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Guides",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Guides",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Guides",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Guides",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Guides",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Guides",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Guides",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Guides",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Guides",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TourPackages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TourPackages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TourPackages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TourPackages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TourPackages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TourPackages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TourPackages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TourPackages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TourPackages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.RenameTable(
                name: "TourPackagesGuides",
                newName: "TourPackageGuides");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Bookings",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                newName: "IX_Bookings_CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_TourPackagesGuides_TourPackageId",
                table: "TourPackageGuides",
                newName: "IX_TourPackageGuides_TourPackageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourPackageGuides",
                table: "TourPackageGuides",
                columns: new[] { "GuideId", "TourPackageId" });

            migrationBuilder.CreateIndex(
                name: "IX_TourPackageGuides_GuideId",
                table: "TourPackageGuides",
                column: "GuideId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_CustomerID",
                table: "Bookings",
                column: "CustomerID",
                principalTable: "Customers",
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
    }
}
