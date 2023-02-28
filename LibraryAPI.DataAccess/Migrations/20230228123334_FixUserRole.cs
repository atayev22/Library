using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserRoles",
                newName: "RoleName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "UserRoles",
                newName: "Name");
        }
    }
}
