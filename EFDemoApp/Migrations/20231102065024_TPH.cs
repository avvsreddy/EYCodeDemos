using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDemoApp.Migrations
{
    /// <inheritdoc />
    public partial class TPH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSupplier_Suppliers_SuppliersSupplierID",
                table: "ProductSupplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "People");

            migrationBuilder.RenameColumn(
                name: "SuppliersSupplierID",
                table: "ProductSupplier",
                newName: "SuppliersPersonID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSupplier_SuppliersSupplierID",
                table: "ProductSupplier",
                newName: "IX_ProductSupplier_SuppliersPersonID");

            migrationBuilder.RenameColumn(
                name: "SupplierID",
                table: "People",
                newName: "PersonID");

            migrationBuilder.AddColumn<string>(
                name: "CustType",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "People",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GSTNo",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PAN",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TradeNo",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSupplier_People_SuppliersPersonID",
                table: "ProductSupplier",
                column: "SuppliersPersonID",
                principalTable: "People",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSupplier_People_SuppliersPersonID",
                table: "ProductSupplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropColumn(
                name: "CustType",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "People");

            migrationBuilder.DropColumn(
                name: "GSTNo",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PAN",
                table: "People");

            migrationBuilder.DropColumn(
                name: "TradeNo",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Suppliers");

            migrationBuilder.RenameColumn(
                name: "SuppliersPersonID",
                table: "ProductSupplier",
                newName: "SuppliersSupplierID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSupplier_SuppliersPersonID",
                table: "ProductSupplier",
                newName: "IX_ProductSupplier_SuppliersSupplierID");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "Suppliers",
                newName: "SupplierID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "SupplierID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSupplier_Suppliers_SuppliersSupplierID",
                table: "ProductSupplier",
                column: "SuppliersSupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
