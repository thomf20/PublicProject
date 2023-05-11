using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedprops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Footer",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Popularity",
                table: "Blog",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Footer",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "Popularity",
                table: "Blog");
        }
    }
}
