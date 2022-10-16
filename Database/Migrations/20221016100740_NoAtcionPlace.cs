using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class NoAtcionPlace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Places_PlaceId",
                table: "Images");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Places_PlaceId",
                table: "Images",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Places_PlaceId",
                table: "Images");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Places_PlaceId",
                table: "Images",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
