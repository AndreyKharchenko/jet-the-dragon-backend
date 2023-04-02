using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ES.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class productCharaksConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCharaks_Product_ProductId",
                table: "ProductCharaks");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "ProductCharaks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ProductCharaks",
                type: "bytea",
                rowVersion: true,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCharaks_ProductId1",
                table: "ProductCharaks",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCharaks_Product_ProductId",
                table: "ProductCharaks",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCharaks_Product_ProductId1",
                table: "ProductCharaks",
                column: "ProductId1",
                principalTable: "Product",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCharaks_Product_ProductId",
                table: "ProductCharaks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCharaks_Product_ProductId1",
                table: "ProductCharaks");

            migrationBuilder.DropIndex(
                name: "IX_ProductCharaks_ProductId1",
                table: "ProductCharaks");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductCharaks");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ProductCharaks");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCharaks_Product_ProductId",
                table: "ProductCharaks",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
