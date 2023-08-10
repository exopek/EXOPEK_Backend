using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXOPEK_Backend.Migrations
{
    /// <inheritdoc />
    public partial class _20230810js1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Video",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Video");
        }
    }
}
