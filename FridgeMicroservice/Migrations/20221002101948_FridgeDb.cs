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
                    { new Guid("418f528e-bd47-4e38-8ea6-7061ae5c3730"), new DateTime(2022, 10, 2, 10, 19, 45, 69, DateTimeKind.Utc).AddTicks(5545), "HG50", 2010 },
                    { new Guid("f45af848-0446-4887-988a-91c085e8752d"), new DateTime(2022, 10, 2, 10, 19, 45, 69, DateTimeKind.Utc).AddTicks(5543), "RT-700", 2019 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "LinkImage", "Name" },
                values: new object[,]
                {
                    { new Guid("17f4a9f2-6f80-4dad-951a-c4c446c08989"), new DateTime(2022, 10, 2, 10, 19, 45, 69, DateTimeKind.Utc).AddTicks(5757), "https://pm1.narvii.com/6810/05dbd7aaebf3454313b99edfd566b06356a59be3v2_hq.jpg", "Cheese" },
                    { new Guid("1a9bc728-9ff9-4388-95d0-ca0984d780dc"), new DateTime(2022, 10, 2, 10, 19, 45, 69, DateTimeKind.Utc).AddTicks(5749), "https://craves.everybodyshops.com/wp-content/uploads/ThinkstockPhotos-535489242-1024x683@2x.jpg", "Milk" },
                    { new Guid("3dfaa31a-3bc9-415b-ae2d-d7ca7335df49"), new DateTime(2022, 10, 2, 10, 19, 45, 69, DateTimeKind.Utc).AddTicks(5756), "https://images5.alphacoders.com/102/1022723.jpg", "Juice" },
                    { new Guid("54d223dc-f4f7-4bda-9d64-e412bde218e6"), new DateTime(2022, 10, 2, 10, 19, 45, 69, DateTimeKind.Utc).AddTicks(5750), "https://www.expatica.com/app/uploads/sites/2/2014/05/bread.jpg", "Bread" },
                    { new Guid("ef1e53a0-08b5-44b6-a986-5198e52d801e"), new DateTime(2022, 10, 2, 10, 19, 45, 69, DateTimeKind.Utc).AddTicks(5758), "https://g.foolcdn.com/image/?url=https%3A//g.foolcdn.com/editorial/images/218648/eggs-brown-getty_BSCxkDW.jpg&w=2000&op=resize", "Egg" }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "CreatedDate", "Manufacturer", "ModelId", "OwnerName" },
                values: new object[] { new Guid("06aa3d8f-2035-40fe-a1f8-cb8bae493669"), new DateTime(2022, 10, 2, 10, 19, 45, 69, DateTimeKind.Utc).AddTicks(5476), "Atlant", new Guid("418f528e-bd47-4e38-8ea6-7061ae5c3730"), "Espio" });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "CreatedDate", "Manufacturer", "ModelId", "OwnerName" },
                values: new object[] { new Guid("3c165161-00eb-4e3d-8201-3f9f246f1a60"), new DateTime(2022, 10, 2, 10, 19, 45, 69, DateTimeKind.Utc).AddTicks(5472), "LG", new Guid("f45af848-0446-4887-988a-91c085e8752d"), "Alex" });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "CreatedDate", "Manufacturer", "ModelId", "OwnerName" },
                values: new object[] { new Guid("cf0b48dc-e3ab-45cb-8df3-899241c43dab"), new DateTime(2022, 10, 2, 10, 19, 45, 69, DateTimeKind.Utc).AddTicks(5475), "Samsung", new Guid("418f528e-bd47-4e38-8ea6-7061ae5c3730"), "Martin" });

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
