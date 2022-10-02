using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentUser_Users_LikeUsersId",
                table: "CommentUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentUser1_Users_DislikeUsersId",
                table: "CommentUser1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentUser1",
                table: "CommentUser1");

            migrationBuilder.DropIndex(
                name: "IX_CommentUser1_DislikedCommentsId",
                table: "CommentUser1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentUser",
                table: "CommentUser");

            migrationBuilder.DropIndex(
                name: "IX_CommentUser_LikedCommentsId",
                table: "CommentUser");

            migrationBuilder.RenameColumn(
                name: "DislikeUsersId",
                table: "CommentUser1",
                newName: "DislikedUsersId");

            migrationBuilder.RenameColumn(
                name: "LikeUsersId",
                table: "CommentUser",
                newName: "LikedUsersId");

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "EventTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Events",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Events",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsModerated",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnline",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "Site",
                table: "Events",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentUser1",
                table: "CommentUser1",
                columns: new[] { "DislikedCommentsId", "DislikedUsersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentUser",
                table: "CommentUser",
                columns: new[] { "LikedCommentsId", "LikedUsersId" });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Route = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Site = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GoogleMaps = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Place_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventTypePlace",
                columns: table => new
                {
                    PlaceTypesId = table.Column<int>(type: "int", nullable: false),
                    PlacesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypePlace", x => new { x.PlaceTypesId, x.PlacesId });
                    table.ForeignKey(
                        name: "FK_EventTypePlace_EventTypes_PlaceTypesId",
                        column: x => x.PlaceTypesId,
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTypePlace_Place_PlacesId",
                        column: x => x.PlacesId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaceUser",
                columns: table => new
                {
                    LikedPlacesId = table.Column<int>(type: "int", nullable: false),
                    LikedUsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceUser", x => new { x.LikedPlacesId, x.LikedUsersId });
                    table.ForeignKey(
                        name: "FK_PlaceUser_Place_LikedPlacesId",
                        column: x => x.LikedPlacesId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaceUser_Users_LikedUsersId",
                        column: x => x.LikedUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PlaceUser1",
                columns: table => new
                {
                    FavoritePlacesId = table.Column<int>(type: "int", nullable: false),
                    FavoriteUsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceUser1", x => new { x.FavoritePlacesId, x.FavoriteUsersId });
                    table.ForeignKey(
                        name: "FK_PlaceUser1_Place_FavoritePlacesId",
                        column: x => x.FavoritePlacesId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaceUser1_Users_FavoriteUsersId",
                        column: x => x.FavoriteUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_PlaceId",
                table: "Images",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTypes_ParentId",
                table: "EventTypes",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PlaceId",
                table: "Events",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentUser1_DislikedUsersId",
                table: "CommentUser1",
                column: "DislikedUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentUser_LikedUsersId",
                table: "CommentUser",
                column: "LikedUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EventId",
                table: "Comments",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PlaceId",
                table: "Comments",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTypePlace_PlacesId",
                table: "EventTypePlace",
                column: "PlacesId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_OwnerId",
                table: "Place",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceUser_LikedUsersId",
                table: "PlaceUser",
                column: "LikedUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceUser1_FavoriteUsersId",
                table: "PlaceUser1",
                column: "FavoriteUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Events_EventId",
                table: "Comments",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Place_PlaceId",
                table: "Comments",
                column: "PlaceId",
                principalTable: "Place",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentUser_Users_LikedUsersId",
                table: "CommentUser",
                column: "LikedUsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentUser1_Users_DislikedUsersId",
                table: "CommentUser1",
                column: "DislikedUsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Place_PlaceId",
                table: "Events",
                column: "PlaceId",
                principalTable: "Place",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventTypes_EventTypes_ParentId",
                table: "EventTypes",
                column: "ParentId",
                principalTable: "EventTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Place_PlaceId",
                table: "Images",
                column: "PlaceId",
                principalTable: "Place",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Events_EventId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Place_PlaceId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentUser_Users_LikedUsersId",
                table: "CommentUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentUser1_Users_DislikedUsersId",
                table: "CommentUser1");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Place_PlaceId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventTypes_EventTypes_ParentId",
                table: "EventTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Place_PlaceId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "EventTypePlace");

            migrationBuilder.DropTable(
                name: "PlaceUser");

            migrationBuilder.DropTable(
                name: "PlaceUser1");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropIndex(
                name: "IX_Images_PlaceId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_EventTypes_ParentId",
                table: "EventTypes");

            migrationBuilder.DropIndex(
                name: "IX_Events_PlaceId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentUser1",
                table: "CommentUser1");

            migrationBuilder.DropIndex(
                name: "IX_CommentUser1_DislikedUsersId",
                table: "CommentUser1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentUser",
                table: "CommentUser");

            migrationBuilder.DropIndex(
                name: "IX_CommentUser_LikedUsersId",
                table: "CommentUser");

            migrationBuilder.DropIndex(
                name: "IX_Comments_EventId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PlaceId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "EventTypes");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "IsModerated",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "IsOnline",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Site",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "DislikedUsersId",
                table: "CommentUser1",
                newName: "DislikeUsersId");

            migrationBuilder.RenameColumn(
                name: "LikedUsersId",
                table: "CommentUser",
                newName: "LikeUsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentUser1",
                table: "CommentUser1",
                columns: new[] { "DislikeUsersId", "DislikedCommentsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentUser",
                table: "CommentUser",
                columns: new[] { "LikeUsersId", "LikedCommentsId" });

            migrationBuilder.CreateIndex(
                name: "IX_CommentUser1_DislikedCommentsId",
                table: "CommentUser1",
                column: "DislikedCommentsId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentUser_LikedCommentsId",
                table: "CommentUser",
                column: "LikedCommentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentUser_Users_LikeUsersId",
                table: "CommentUser",
                column: "LikeUsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentUser1_Users_DislikeUsersId",
                table: "CommentUser1",
                column: "DislikeUsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
