using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary.Migrations
{
    public partial class createinitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PoSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrNumber = table.Column<int>(type: "int", nullable: false),
                    PrDate = table.Column<DateTime>(type: "Date", nullable: false),
                    PoNumber = table.Column<int>(type: "int", nullable: false),
                    PoDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ItemCodes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ordered = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Delivered = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unitprice = table.Column<int>(type: "int", nullable: false),
                    Vendorname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ImportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImportCancelled = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoSummaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UomCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UomDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Addedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dateadded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uoms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendorNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorcodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Addedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCodes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UomId = table.Column<int>(type: "int", nullable: false),
                    Dateadded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Addedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCodes_Uoms_UomId",
                        column: x => x.UomId,
                        principalTable: "Uoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemCodes_UomId",
                table: "ItemCodes",
                column: "UomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCodes");

            migrationBuilder.DropTable(
                name: "PoSummaries");

            migrationBuilder.DropTable(
                name: "VendorNames");

            migrationBuilder.DropTable(
                name: "Uoms");
        }
    }
}
