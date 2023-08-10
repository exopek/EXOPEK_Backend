using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXOPEK_Backend.Migrations
{
    /// <inheritdoc />
    public partial class _20230810js : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_Workouts_WorkoutId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Video_WorkoutId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "Video");

            migrationBuilder.CreateTable(
                name: "WorkoutVideo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkoutId = table.Column<Guid>(type: "uuid", nullable: false),
                    VideoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutVideo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutVideo_Video_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Video",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutVideo_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutVideo_VideoId",
                table: "WorkoutVideo",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutVideo_WorkoutId",
                table: "WorkoutVideo",
                column: "WorkoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutVideo");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkoutId",
                table: "Video",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Video_WorkoutId",
                table: "Video",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Workouts_WorkoutId",
                table: "Video",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id");
        }
    }
}
