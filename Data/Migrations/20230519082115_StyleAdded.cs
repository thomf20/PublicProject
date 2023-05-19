using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class StyleAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Style",
                table: "Blog",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Style",
                table: "Blog");
        }
    }
}
