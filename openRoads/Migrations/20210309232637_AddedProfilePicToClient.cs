using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace openRoadsWebAPI.Migrations
{
    public partial class AddedProfilePicToClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "Client",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePictureThumb",
                table: "Client",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "ProfilePictureThumb",
                table: "Client");
        }
    }
}
