using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diego.MyBooks.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class _30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FormatBookIdId",
                table: "Books",
                newName: "FormatBookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FormatBookId",
                table: "Books",
                newName: "FormatBookIdId");
        }
    }
}
