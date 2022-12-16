using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeMicroservice.Migrations
{
    public partial class FridgeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionYear = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LinkImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                columns: new[] { "Id", "CreatedDate", "Name", "ProductionYear", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("155d3afc-575d-4360-905e-3dbcc5710589"), new DateTime(2022, 12, 16, 13, 57, 37, 340, DateTimeKind.Utc).AddTicks(3648), "RT-700", 2019, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f4b65cbd-d0c6-4754-a973-cec4994a006d"), new DateTime(2022, 12, 16, 13, 57, 37, 340, DateTimeKind.Utc).AddTicks(3650), "HG50", 2010, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "LinkImage", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("37ad541b-d101-46e6-89cf-07fe2848f3fa"), new DateTime(2022, 12, 16, 13, 57, 37, 340, DateTimeKind.Utc).AddTicks(3661), "https://pm1.narvii.com/6810/05dbd7aaebf3454313b99edfd566b06356a59be3v2_hq.jpg", "Cheese", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("438167bf-46cf-47b1-8ca8-307ff3299063"), new DateTime(2022, 12, 16, 13, 57, 37, 340, DateTimeKind.Utc).AddTicks(3662), "https://g.foolcdn.com/image/?url=https%3A//g.foolcdn.com/editorial/images/218648/eggs-brown-getty_BSCxkDW.jpg&w=2000&op=resize", "Egg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("997d3739-f810-48a2-9363-d5bcddde1a10"), new DateTime(2022, 12, 16, 13, 57, 37, 340, DateTimeKind.Utc).AddTicks(3658), "https://craves.everybodyshops.com/wp-content/uploads/ThinkstockPhotos-535489242-1024x683@2x.jpg", "Milk", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a6bea552-82df-4bd6-b372-df456969e59a"), new DateTime(2022, 12, 16, 13, 57, 37, 340, DateTimeKind.Utc).AddTicks(3659), "https://images5.alphacoders.com/102/1022723.jpg", "Juice", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bba48c53-6c71-4924-98f1-f710d9baecf5"), new DateTime(2022, 12, 16, 13, 57, 37, 340, DateTimeKind.Utc).AddTicks(3658), "https://www.expatica.com/app/uploads/sites/2/2014/05/bread.jpg", "Bread", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "CreatedDate", "Manufacturer", "ModelId", "OwnerName", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("7c1e20d7-9cb4-43fa-a0c6-d4c433c0871d"), new DateTime(2022, 12, 16, 13, 57, 37, 340, DateTimeKind.Utc).AddTicks(3587), "LG", new Guid("155d3afc-575d-4360-905e-3dbcc5710589"), "Alex", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "CreatedDate", "Manufacturer", "ModelId", "OwnerName", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("981d0ee4-837b-4d5d-ba77-d9acf6f7d12a"), new DateTime(2022, 12, 16, 13, 57, 37, 340, DateTimeKind.Utc).AddTicks(3588), "Samsung", new Guid("f4b65cbd-d0c6-4754-a973-cec4994a006d"), "Martin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "CreatedDate", "Manufacturer", "ModelId", "OwnerName", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("f9ae681c-861d-4cea-8d9a-d197d8e9f0f4"), new DateTime(2022, 12, 16, 13, 57, 37, 340, DateTimeKind.Utc).AddTicks(3590), "Atlant", new Guid("f4b65cbd-d0c6-4754-a973-cec4994a006d"), "Espio", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "FridgeProduct",
                columns: new[] { "FridgeId", "ProductId", "CreatedDate", "Id", "ProductCount", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("7c1e20d7-9cb4-43fa-a0c6-d4c433c0871d"), new Guid("37ad541b-d101-46e6-89cf-07fe2848f3fa"), new DateTime(2022, 12, 16, 13, 57, 37, 340, DateTimeKind.Utc).AddTicks(3694), new Guid("7c30ab4f-787a-442d-82cd-d798cbd05e95"), 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7c1e20d7-9cb4-43fa-a0c6-d4c433c0871d"), new Guid("997d3739-f810-48a2-9363-d5bcddde1a10"), new DateTime(2022, 12, 16, 13, 57, 37, 340, DateTimeKind.Utc).AddTicks(3687), new Guid("9964863e-0fcd-4a06-86d5-c9cef628966b"), 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("981d0ee4-837b-4d5d-ba77-d9acf6f7d12a"), new Guid("438167bf-46cf-47b1-8ca8-307ff3299063"), new DateTime(2022, 12, 16, 13, 57, 37, 340, DateTimeKind.Utc).AddTicks(3699), new Guid("51d360f2-4f78-4843-9a17-f9cd9672ce9b"), 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("981d0ee4-837b-4d5d-ba77-d9acf6f7d12a"), new Guid("a6bea552-82df-4bd6-b372-df456969e59a"), new DateTime(2022, 12, 16, 13, 57, 37, 340, DateTimeKind.Utc).AddTicks(3705), new Guid("33257432-4fae-4090-853e-00e0d52222e1"), 123, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f9ae681c-861d-4cea-8d9a-d197d8e9f0f4"), new Guid("438167bf-46cf-47b1-8ca8-307ff3299063"), new DateTime(2022, 12, 16, 13, 57, 37, 340, DateTimeKind.Utc).AddTicks(3767), new Guid("32912f07-0a96-4205-9422-537c2048fc0f"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f9ae681c-861d-4cea-8d9a-d197d8e9f0f4"), new Guid("997d3739-f810-48a2-9363-d5bcddde1a10"), new DateTime(2022, 12, 16, 13, 57, 37, 340, DateTimeKind.Utc).AddTicks(3715), new Guid("49faef6a-52e5-4d92-a25c-d84542188b8a"), 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f9ae681c-861d-4cea-8d9a-d197d8e9f0f4"), new Guid("bba48c53-6c71-4924-98f1-f710d9baecf5"), new DateTime(2022, 12, 16, 13, 57, 37, 340, DateTimeKind.Utc).AddTicks(3722), new Guid("09ba8519-4010-4db5-8d7d-cca6bcd7cae9"), 454, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

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
                unique: true,
                filter: "[Name] IS NOT NULL");
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
