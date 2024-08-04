using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boardgames.Migrations
{
    public partial class sec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boardgame_Creator_CreatorId",
                table: "Boardgame");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardgameSeller_Boardgame_BoardgameId",
                table: "BoardgameSeller");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardgameSeller_Seller_SellerId",
                table: "BoardgameSeller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seller",
                table: "Seller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Creator",
                table: "Creator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardgameSeller",
                table: "BoardgameSeller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boardgame",
                table: "Boardgame");

            migrationBuilder.RenameTable(
                name: "Seller",
                newName: "Sellers");

            migrationBuilder.RenameTable(
                name: "Creator",
                newName: "Creators");

            migrationBuilder.RenameTable(
                name: "BoardgameSeller",
                newName: "BoardgamesSellers");

            migrationBuilder.RenameTable(
                name: "Boardgame",
                newName: "Boardgames");

            migrationBuilder.RenameIndex(
                name: "IX_BoardgameSeller_SellerId",
                table: "BoardgamesSellers",
                newName: "IX_BoardgamesSellers_SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_Boardgame_CreatorId",
                table: "Boardgames",
                newName: "IX_Boardgames_CreatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Creators",
                table: "Creators",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardgamesSellers",
                table: "BoardgamesSellers",
                columns: new[] { "BoardgameId", "SellerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boardgames",
                table: "Boardgames",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Boardgames_Creators_CreatorId",
                table: "Boardgames",
                column: "CreatorId",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardgamesSellers_Boardgames_BoardgameId",
                table: "BoardgamesSellers",
                column: "BoardgameId",
                principalTable: "Boardgames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardgamesSellers_Sellers_SellerId",
                table: "BoardgamesSellers",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boardgames_Creators_CreatorId",
                table: "Boardgames");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardgamesSellers_Boardgames_BoardgameId",
                table: "BoardgamesSellers");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardgamesSellers_Sellers_SellerId",
                table: "BoardgamesSellers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Creators",
                table: "Creators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardgamesSellers",
                table: "BoardgamesSellers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boardgames",
                table: "Boardgames");

            migrationBuilder.RenameTable(
                name: "Sellers",
                newName: "Seller");

            migrationBuilder.RenameTable(
                name: "Creators",
                newName: "Creator");

            migrationBuilder.RenameTable(
                name: "BoardgamesSellers",
                newName: "BoardgameSeller");

            migrationBuilder.RenameTable(
                name: "Boardgames",
                newName: "Boardgame");

            migrationBuilder.RenameIndex(
                name: "IX_BoardgamesSellers_SellerId",
                table: "BoardgameSeller",
                newName: "IX_BoardgameSeller_SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_Boardgames_CreatorId",
                table: "Boardgame",
                newName: "IX_Boardgame_CreatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seller",
                table: "Seller",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Creator",
                table: "Creator",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardgameSeller",
                table: "BoardgameSeller",
                columns: new[] { "BoardgameId", "SellerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boardgame",
                table: "Boardgame",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Boardgame_Creator_CreatorId",
                table: "Boardgame",
                column: "CreatorId",
                principalTable: "Creator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardgameSeller_Boardgame_BoardgameId",
                table: "BoardgameSeller",
                column: "BoardgameId",
                principalTable: "Boardgame",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardgameSeller_Seller_SellerId",
                table: "BoardgameSeller",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
