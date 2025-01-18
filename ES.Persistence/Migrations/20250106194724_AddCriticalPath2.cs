using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ES.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCriticalPath2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechMapCriticalPath_TechMap_TechMapId1",
                table: "TechMapCriticalPath");

            migrationBuilder.DropIndex(
                name: "IX_TechMapCriticalPath_TechMapId",
                table: "TechMapCriticalPath");

            migrationBuilder.DropIndex(
                name: "IX_TechMapCriticalPath_TechMapId1",
                table: "TechMapCriticalPath");

            migrationBuilder.DropColumn(
                name: "TechMapId1",
                table: "TechMapCriticalPath");

            migrationBuilder.CreateIndex(
                name: "IX_TechMapCriticalPath_TechMapId",
                table: "TechMapCriticalPath",
                column: "TechMapId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TechMapCriticalPath_TechMapId",
                table: "TechMapCriticalPath");

            migrationBuilder.AddColumn<Guid>(
                name: "TechMapId1",
                table: "TechMapCriticalPath",
                type: "uuid",
                nullable: true);

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
                name: "FK_TechMapCriticalPath_TechMap_TechMapId1",
                table: "TechMapCriticalPath",
                column: "TechMapId1",
                principalTable: "TechMap",
                principalColumn: "Id");
        }
    }
}
