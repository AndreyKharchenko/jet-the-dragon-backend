using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ES.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ProductCustomerRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Address_FlatNumber",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Address_HouseNumber",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Address_PostalCode",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Address_Region",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "IsStock",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductImageId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ExpirationDate",
                table: "Product",
                newName: "ManufactureDate");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Product",
                newName: "Rating");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Supplier",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Product",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ShelfLife",
                table: "Product",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Favourities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favourities_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favourities_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCharaks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCharaks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCharaks_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_CustomerId",
                table: "Supplier",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favourities_CustomerId",
                table: "Favourities",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Favourities_ProductId",
                table: "Favourities",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCharaks_ProductId",
                table: "ProductCharaks",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Customer_CustomerId",
                table: "Supplier",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Customer_CustomerId",
                table: "Supplier");

            migrationBuilder.DropTable(
                name: "Favourities");

            migrationBuilder.DropTable(
                name: "ProductCharaks");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_CustomerId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ShelfLife",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Product",
                newName: "Cost");

            migrationBuilder.RenameColumn(
                name: "ManufactureDate",
                table: "Product",
                newName: "ExpirationDate");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Supplier",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "Supplier",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_FlatNumber",
                table: "Supplier",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_HouseNumber",
                table: "Supplier",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalCode",
                table: "Supplier",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Region",
                table: "Supplier",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Supplier",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Supplier",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Supplier",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Supplier",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Supplier",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsStock",
                table: "Product",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductImageId",
                table: "Product",
                type: "uuid",
                nullable: true);
        }
    }
}
