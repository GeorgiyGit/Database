using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class Ilitial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Place_PlaceId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Place_PlaceId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventTypePlace_Place_PlacesId",
                table: "EventTypePlace");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Place_PlaceId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Place_Users_OwnerId",
                table: "Place");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceUser_Place_LikedPlacesId",
                table: "PlaceUser");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceUser1_Place_FavoritePlacesId",
                table: "PlaceUser1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Place",
                table: "Place");

            migrationBuilder.RenameTable(
                name: "Place",
                newName: "Places");

            migrationBuilder.RenameIndex(
                name: "IX_Place_OwnerId",
                table: "Places",
                newName: "IX_Places_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Places",
                table: "Places",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Places_PlaceId",
                table: "Comments",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Places_PlaceId",
                table: "Events",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventTypePlace_Places_PlacesId",
                table: "EventTypePlace",
                column: "PlacesId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Places_PlaceId",
                table: "Images",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Users_OwnerId",
                table: "Places",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceUser_Places_LikedPlacesId",
                table: "PlaceUser",
                column: "LikedPlacesId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceUser1_Places_FavoritePlacesId",
                table: "PlaceUser1",
                column: "FavoritePlacesId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Places_PlaceId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Places_PlaceId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventTypePlace_Places_PlacesId",
                table: "EventTypePlace");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Places_PlaceId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_Users_OwnerId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceUser_Places_LikedPlacesId",
                table: "PlaceUser");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceUser1_Places_FavoritePlacesId",
                table: "PlaceUser1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Places",
                table: "Places");

            migrationBuilder.RenameTable(
                name: "Places",
                newName: "Place");

            migrationBuilder.RenameIndex(
                name: "IX_Places_OwnerId",
                table: "Place",
                newName: "IX_Place_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Place",
                table: "Place",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Place_PlaceId",
                table: "Comments",
                column: "PlaceId",
                principalTable: "Place",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Place_PlaceId",
                table: "Events",
                column: "PlaceId",
                principalTable: "Place",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventTypePlace_Place_PlacesId",
                table: "EventTypePlace",
                column: "PlacesId",
                principalTable: "Place",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Place_PlaceId",
                table: "Images",
                column: "PlaceId",
                principalTable: "Place",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Place_Users_OwnerId",
                table: "Place",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceUser_Place_LikedPlacesId",
                table: "PlaceUser",
                column: "LikedPlacesId",
                principalTable: "Place",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceUser1_Place_FavoritePlacesId",
                table: "PlaceUser1",
                column: "FavoritePlacesId",
                principalTable: "Place",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
