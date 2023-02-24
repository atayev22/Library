using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUserss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contct",
                table: "PublishingHouses",
                newName: "Contact");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contact",
                table: "PublishingHouses",
                newName: "Contct");
        }
    }
}
