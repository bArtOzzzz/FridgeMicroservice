using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeMicroservice.Migrations
{
    public partial class FridgeMicro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionYear = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LinkImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fridges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fridges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fridges_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FridgeProduct",
                columns: table => new
                {
                    FridgeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeProduct", x => new { x.FridgeId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_FridgeProduct_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FridgeProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "CreatedDate", "Name", "ProductionYear" },
                values: new object[,]
                {
                    { new Guid("4aaec8d1-ae2e-44a3-a5e0-4bbeebebfe76"), new DateTime(2022, 10, 14, 7, 14, 18, 263, DateTimeKind.Utc).AddTicks(1683), "HG50", 2010 },
                    { new Guid("f539773d-17a6-42fe-be14-f6c44b00b447"), new DateTime(2022, 10, 14, 7, 14, 18, 263, DateTimeKind.Utc).AddTicks(1682), "RT-700", 2019 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "LinkImage", "Name" },
                values: new object[,]
                {
                    { new Guid("311c92af-ef71-43e7-a060-669c648a7e04"), new DateTime(2022, 10, 14, 7, 14, 18, 263, DateTimeKind.Utc).AddTicks(1701), "https://craves.everybodyshops.com/wp-content/uploads/ThinkstockPhotos-535489242-1024x683@2x.jpg", "Milk" },
                    { new Guid("55999c85-cc72-4eff-88a2-3756885cd0e5"), new DateTime(2022, 10, 14, 7, 14, 18, 263, DateTimeKind.Utc).AddTicks(1702), "https://www.expatica.com/app/uploads/sites/2/2014/05/bread.jpg", "Bread" },
                    { new Guid("9cc94f48-214b-4305-b954-422fbfca7fb4"), new DateTime(2022, 10, 14, 7, 14, 18, 263, DateTimeKind.Utc).AddTicks(1704), "https://pm1.narvii.com/6810/05dbd7aaebf3454313b99edfd566b06356a59be3v2_hq.jpg", "Cheese" },
                    { new Guid("b12e1773-2148-4727-b9aa-0e54a27d358d"), new DateTime(2022, 10, 14, 7, 14, 18, 263, DateTimeKind.Utc).AddTicks(1703), "https://images5.alphacoders.com/102/1022723.jpg", "Juice" },
                    { new Guid("ef002825-d377-4c0b-9bbe-e4d15ca5f7e1"), new DateTime(2022, 10, 14, 7, 14, 18, 263, DateTimeKind.Utc).AddTicks(1705), "https://g.foolcdn.com/image/?url=https%3A//g.foolcdn.com/editorial/images/218648/eggs-brown-getty_BSCxkDW.jpg&w=2000&op=resize", "Egg" }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "CreatedDate", "Manufacturer", "ModelId", "OwnerName", "UserId" },
                values: new object[] { new Guid("23f740ee-0b12-4801-b7e4-e4d6d9944e58"), new DateTime(2022, 10, 14, 7, 14, 18, 263, DateTimeKind.Utc).AddTicks(1622), "LG", new Guid("f539773d-17a6-42fe-be14-f6c44b00b447"), "Alex", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "CreatedDate", "Manufacturer", "ModelId", "OwnerName", "UserId" },
                values: new object[] { new Guid("371c4696-dbb8-4238-ac71-4be945f56993"), new DateTime(2022, 10, 14, 7, 14, 18, 263, DateTimeKind.Utc).AddTicks(1624), "Samsung", new Guid("4aaec8d1-ae2e-44a3-a5e0-4bbeebebfe76"), "Martin", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "CreatedDate", "Manufacturer", "ModelId", "OwnerName", "UserId" },
                values: new object[] { new Guid("a70797f7-6d0f-45db-847d-55ebe82dc049"), new DateTime(2022, 10, 14, 7, 14, 18, 263, DateTimeKind.Utc).AddTicks(1625), "Atlant", new Guid("4aaec8d1-ae2e-44a3-a5e0-4bbeebebfe76"), "Espio", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.CreateIndex(
                name: "IX_FridgeProduct_ProductId",
                table: "FridgeProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Fridges_ModelId",
                table: "Fridges",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FridgeProduct");

            migrationBuilder.DropTable(
                name: "Fridges");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Models");
        }
    }
}
