using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaOnline.Migrations
{
    /// <inheritdoc />
    public partial class LinkIdentityUserToLibraryMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "LibraryMembers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LibraryMembers_IdentityUserId",
                table: "LibraryMembers",
                column: "IdentityUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryMembers_AspNetUsers_IdentityUserId",
                table: "LibraryMembers",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryMembers_AspNetUsers_IdentityUserId",
                table: "LibraryMembers");

            migrationBuilder.DropIndex(
                name: "IX_LibraryMembers_IdentityUserId",
                table: "LibraryMembers");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "LibraryMembers");
        }
    }
}
