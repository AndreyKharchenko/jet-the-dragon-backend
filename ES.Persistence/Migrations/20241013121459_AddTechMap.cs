using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ES.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTechMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TechMap",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uuid", nullable: false),
                    JobName = table.Column<string>(type: "text", nullable: false),
                    JobDescription = table.Column<string>(type: "text", nullable: false),
                    JobDuration = table.Column<string>(type: "text", nullable: false),
                    JobDependence = table.Column<string>(type: "text", nullable: false),
                    JobResources = table.Column<string>(type: "text", nullable: false),
                    JobCompleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechMap_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechMap_SupplierId",
                table: "TechMap",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TechMap");
        }
    }
}
