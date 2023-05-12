using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublicProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedsocialmedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YouTube",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "YouTube",
                table: "Blog");
        }
    }
}
