using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXOPEK_Backend.Migrations
{
    /// <inheritdoc />
    public partial class _20230810js3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Exercise",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Exercise",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Exercise");
        }
    }
}
