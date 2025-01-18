using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ES.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTechMapJobs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobCompleteDate",
                table: "TechMap");

            migrationBuilder.DropColumn(
                name: "JobDependence",
                table: "TechMap");

            migrationBuilder.DropColumn(
                name: "JobDescription",
                table: "TechMap");

            migrationBuilder.DropColumn(
                name: "JobDuration",
                table: "TechMap");

            migrationBuilder.DropColumn(
                name: "JobName",
                table: "TechMap");

            migrationBuilder.RenameColumn(
                name: "JobResources",
                table: "TechMap",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "TechMapJobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TechMapId = table.Column<Guid>(type: "uuid", nullable: false),
                    JobName = table.Column<string>(type: "text", nullable: false),
                    JobDescription = table.Column<string>(type: "text", nullable: false),
                    JobDuration = table.Column<string>(type: "text", nullable: false),
                    JobDependence = table.Column<string>(type: "text", nullable: false),
                    JobResources = table.Column<string>(type: "text", nullable: false),
                    JobCompleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    TechMapId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechMapJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechMapJobs_TechMap_TechMapId",
                        column: x => x.TechMapId,
                        principalTable: "TechMap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TechMapJobs_TechMap_TechMapId1",
                        column: x => x.TechMapId1,
                        principalTable: "TechMap",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechMapJobs_TechMapId",
                table: "TechMapJobs",
                column: "TechMapId");

            migrationBuilder.CreateIndex(
                name: "IX_TechMapJobs_TechMapId1",
                table: "TechMapJobs",
                column: "TechMapId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechMapJobs");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TechMap",
                newName: "JobResources");

            migrationBuilder.AddColumn<DateTime>(
                name: "JobCompleteDate",
                table: "TechMap",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "JobDependence",
                table: "TechMap",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobDescription",
                table: "TechMap",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobDuration",
                table: "TechMap",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobName",
                table: "TechMap",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
