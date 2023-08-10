using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXOPEK_Backend.Migrations
{
    /// <inheritdoc />
    public partial class _20230810js4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "previewImage",
                table: "Workouts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "previewImage",
                table: "Workouts");
        }
    }
}
