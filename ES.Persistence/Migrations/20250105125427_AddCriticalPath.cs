using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ES.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCriticalPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TechMapCriticalPathId",
                table: "TechMapJobs",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TechMapCriticalPath",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TechMapId = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalDuration = table.Column<int>(type: "integer", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    TechMapId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechMapCriticalPath", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechMapCriticalPath_TechMap_TechMapId",
                        column: x => x.TechMapId,
                        principalTable: "TechMap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TechMapCriticalPath_TechMap_TechMapId1",
                        column: x => x.TechMapId1,
                        principalTable: "TechMap",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechMapJobs_TechMapCriticalPathId",
                table: "TechMapJobs",
                column: "TechMapCriticalPathId");

            migrationBuilder.CreateIndex(
                name: "IX_TechMapCriticalPath_TechMapId",
                table: "TechMapCriticalPath",
                column: "TechMapId");

            migrationBuilder.CreateIndex(
                name: "IX_TechMapCriticalPath_TechMapId1",
                table: "TechMapCriticalPath",
                column: "TechMapId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TechMapJobs_TechMapCriticalPath_TechMapCriticalPathId",
                table: "TechMapJobs",
                column: "TechMapCriticalPathId",
                principalTable: "TechMapCriticalPath",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechMapJobs_TechMapCriticalPath_TechMapCriticalPathId",
                table: "TechMapJobs");

            migrationBuilder.DropTable(
                name: "TechMapCriticalPath");

            migrationBuilder.DropIndex(
                name: "IX_TechMapJobs_TechMapCriticalPathId",
                table: "TechMapJobs");

            migrationBuilder.DropColumn(
                name: "TechMapCriticalPathId",
                table: "TechMapJobs");
        }
    }
}
