using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class BookDesc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookDescription",
                table: "Books",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Books",
                newName: "BookDescription");
        }
    }
}
