using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FridgeMicroservice.Migrations
{
    public partial class FridgeDb : Migration
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
                    { new Guid("633d9ada-fbf8-410a-98a3-d2d15a09a5fa"), new DateTime(2022, 10, 3, 15, 1, 48, 634, DateTimeKind.Utc).AddTicks(3934), "HG50", 2010 },
                    { new Guid("80771113-d807-4dde-aa15-6c9320038da2"), new DateTime(2022, 10, 3, 15, 1, 48, 634, DateTimeKind.Utc).AddTicks(3932), "RT-700", 2019 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "LinkImage", "Name" },
                values: new object[,]
                {
                    { new Guid("0b4cebcc-18af-4bd5-b4b2-5a410154866c"), new DateTime(2022, 10, 3, 15, 1, 48, 634, DateTimeKind.Utc).AddTicks(3964), "https://g.foolcdn.com/image/?url=https%3A//g.foolcdn.com/editorial/images/218648/eggs-brown-getty_BSCxkDW.jpg&w=2000&op=resize", "Egg" },
                    { new Guid("2ac12399-0105-4b96-887a-86d851e23fd2"), new DateTime(2022, 10, 3, 15, 1, 48, 634, DateTimeKind.Utc).AddTicks(3962), "https://images5.alphacoders.com/102/1022723.jpg", "Juice" },
                    { new Guid("41d3107d-b978-4475-98fc-216dbc89fc1a"), new DateTime(2022, 10, 3, 15, 1, 48, 634, DateTimeKind.Utc).AddTicks(3963), "https://pm1.narvii.com/6810/05dbd7aaebf3454313b99edfd566b06356a59be3v2_hq.jpg", "Cheese" },
                    { new Guid("88fdc2fa-09ba-47d4-a9fb-d33099c97929"), new DateTime(2022, 10, 3, 15, 1, 48, 634, DateTimeKind.Utc).AddTicks(3958), "https://craves.everybodyshops.com/wp-content/uploads/ThinkstockPhotos-535489242-1024x683@2x.jpg", "Milk" },
                    { new Guid("bfe35d1f-5d6a-4d22-b722-635a9f361738"), new DateTime(2022, 10, 3, 15, 1, 48, 634, DateTimeKind.Utc).AddTicks(3959), "https://www.expatica.com/app/uploads/sites/2/2014/05/bread.jpg", "Bread" }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "CreatedDate", "Manufacturer", "ModelId", "OwnerName", "UserId" },
                values: new object[] { new Guid("6b4aa808-48fc-4a63-aa81-aab2df7efea8"), new DateTime(2022, 10, 3, 15, 1, 48, 634, DateTimeKind.Utc).AddTicks(3869), "Samsung", new Guid("633d9ada-fbf8-410a-98a3-d2d15a09a5fa"), "Martin", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "CreatedDate", "Manufacturer", "ModelId", "OwnerName", "UserId" },
                values: new object[] { new Guid("84b45896-d651-42d6-b96e-aa38772e2ef6"), new DateTime(2022, 10, 3, 15, 1, 48, 634, DateTimeKind.Utc).AddTicks(3870), "Atlant", new Guid("633d9ada-fbf8-410a-98a3-d2d15a09a5fa"), "Espio", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "CreatedDate", "Manufacturer", "ModelId", "OwnerName", "UserId" },
                values: new object[] { new Guid("a2268d68-d201-4d29-867d-e35e79cf6a1c"), new DateTime(2022, 10, 3, 15, 1, 48, 634, DateTimeKind.Utc).AddTicks(3866), "LG", new Guid("80771113-d807-4dde-aa15-6c9320038da2"), "Alex", new Guid("00000000-0000-0000-0000-000000000000") });

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
