using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ES.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "TechMapJobs",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Index",
                table: "TechMapJobs");
        }
    }
}
