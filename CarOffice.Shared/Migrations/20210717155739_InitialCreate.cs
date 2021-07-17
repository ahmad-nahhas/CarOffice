using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarOffice.Shared.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<int>(type: "int", nullable: false),
                    Gearbox = table.Column<int>(type: "int", nullable: false),
                    ShowInHome = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(38,0)", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ModelYear = table.Column<int>(type: "int", nullable: true),
                    Mileage = table.Column<int>(type: "int", nullable: true),
                    SeatCount = table.Column<int>(type: "int", nullable: true),
                    WeightTotal = table.Column<decimal>(type: "decimal(38,0)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    CarExtras = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("fb6dd539-b181-434c-b9b8-e4fa8a319ed1"), new DateTime(2021, 7, 17, 18, 57, 39, 182, DateTimeKind.Local).AddTicks(8691), "Acura" },
                    { new Guid("2dd1f682-93bd-4ed4-a98b-fc999e6f1c7f"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3071), "Mazda" },
                    { new Guid("0a47936a-aabf-4c8a-abdd-8596d2cd4216"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3126), "Mercedes-Benz" },
                    { new Guid("d2214b5b-c84a-4d47-a003-3ea334f2affa"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3257), "Mercury" },
                    { new Guid("a643bec5-144a-40da-b750-4db008300452"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3312), "Mini" },
                    { new Guid("121e833f-3ba9-4a18-8e37-8c96ba9eb2e1"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3369), "Mitsubishi" },
                    { new Guid("fee08f06-01a4-427e-aa69-e952fba45d2f"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3423), "Nikola" },
                    { new Guid("c4339841-3a4f-4968-8a18-f1b3ddc89418"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3478), "Nissan" },
                    { new Guid("e3bc8c19-b663-4723-a9d9-d094ff5ed2ef"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3557), "Polestar" },
                    { new Guid("e1620323-b65c-4ff7-afac-e033852362a0"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3614), "Pontiac" },
                    { new Guid("95ce50b3-9026-4306-8d30-8b38c8197988"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3017), "Maserati" },
                    { new Guid("a307db04-6826-4067-b435-0bfb1e35dc40"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3668), "Porsche" },
                    { new Guid("3fc4863e-a1f8-4953-88fd-a6840edd3569"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3803), "Rivian" },
                    { new Guid("9c9f06f1-b12c-4537-80a5-6941efb7307a"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3860), "Rolls-Royce" },
                    { new Guid("3c8cfe34-1aff-40b1-8c89-3f7188f399db"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3914), "Saab" },
                    { new Guid("940322f9-6366-4a41-a8c4-d8b582d57543"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3969), "Scion" },
                    { new Guid("d7ce1beb-5f76-4309-8eea-f8d25342b65a"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4024), "Smart" },
                    { new Guid("3978cae5-b724-4083-b380-a82a251697fe"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4106), "Subaru" },
                    { new Guid("80e00fd5-cad7-4a2f-91d2-4247a94e2b71"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4161), "Suzuki" },
                    { new Guid("c4054cc8-4139-4e6b-ad02-7f3e4cdb45d2"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4256), "Tesla" },
                    { new Guid("5e0a3c06-701f-401b-bbb6-3ec394e67bfe"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4312), "Toyota" },
                    { new Guid("cc57a210-73ce-41dd-a864-3bf57f24c1c6"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3723), "Ram" },
                    { new Guid("0ae1c788-90bd-43c1-a628-b779e1dc9866"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4369), "Volkswagen" },
                    { new Guid("d65c41a8-107c-43a1-b490-64d485cc35e6"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2962), "Lotus" },
                    { new Guid("72905a84-deff-4967-bbec-7dd88ba5e0dd"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2823), "Lexus" },
                    { new Guid("2d43a677-e0c0-47f7-a2b2-00770a8e6bba"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1415), "Alfa Romeo" },
                    { new Guid("43665052-c621-41c2-9472-add36d50a700"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1545), "Audi" },
                    { new Guid("9dc5e2f0-cb08-42ce-99ed-49b7c9ca3f1c"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1606), "Bentley" },
                    { new Guid("ddca1294-f659-480f-8f7c-7c9462d69b7b"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1662), "Buick" },
                    { new Guid("25193a94-b283-4ea8-9d34-f923d62a93a9"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1723), "BMW" },
                    { new Guid("5e9c9d27-9441-4f03-ae90-5a48d04e169b"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1876), "Cadillac" },
                    { new Guid("4a6d292e-6949-414f-afd5-e6ae36338b47"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1937), "Chevrolet" },
                    { new Guid("949cf0ef-ee02-40d5-a57a-f47d6e226eae"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1992), "Chrysler" },
                    { new Guid("44cc229f-eb29-45e8-a75e-bd34b555c4f7"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2051), "Dodge" },
                    { new Guid("1da4f0f0-66a4-400d-b947-d6111e7ac5b7"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2906), "Lincoln" },
                    { new Guid("a4d6b65f-988f-42d9-8310-b990252ed0b7"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2158), "Fiat" },
                    { new Guid("5017042e-fafc-45b9-819a-8883e8380cb2"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2271), "GMC" },
                    { new Guid("5b387106-a7a0-45d8-8552-db0ff311431c"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2329), "Genesis" },
                    { new Guid("eee3caa9-6b7e-4280-919f-ca99709ae97e"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2409), "Honda" },
                    { new Guid("2e34fe9a-da37-4840-a134-d23f51f473a4"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2465), "Hyundai" },
                    { new Guid("13463b33-eba9-48e1-b475-75f31be07df9"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2519), "Infiniti" },
                    { new Guid("74a860fe-d5a4-4af0-b059-ad602204de83"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2577), "Jaguar" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("1d6bd0c2-6f5f-4485-8631-7cc5a519a488"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2632), "Jeep" },
                    { new Guid("974a7d09-53ff-4c4b-8d11-7a3270f1c0ff"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2712), "Kia" },
                    { new Guid("5dd047c1-a570-4120-ac4b-139bcecc0292"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2767), "Land Rover" },
                    { new Guid("5430790f-2a06-4c13-9163-3df410da76d8"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2216), "Ford" },
                    { new Guid("6fae6b22-2562-48d8-8b1f-69e9e977dd86"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4423), "Volvo" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandId", "CarExtras", "Color", "CreatedAt", "Description", "FuelType", "Gearbox", "Mileage", "ModelYear", "Price", "SeatCount", "ShowInHome", "Status", "Type", "WeightTotal" },
                values: new object[,]
                {
                    { new Guid("fb6dd539-b181-434c-b9b8-e4fa8a319ed1"), new Guid("fb6dd539-b181-434c-b9b8-e4fa8a319ed1"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 184, DateTimeKind.Local).AddTicks(6138), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("2dd1f682-93bd-4ed4-a98b-fc999e6f1c7f"), new Guid("2dd1f682-93bd-4ed4-a98b-fc999e6f1c7f"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3086), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("0a47936a-aabf-4c8a-abdd-8596d2cd4216"), new Guid("0a47936a-aabf-4c8a-abdd-8596d2cd4216"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3140), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("d2214b5b-c84a-4d47-a003-3ea334f2affa"), new Guid("d2214b5b-c84a-4d47-a003-3ea334f2affa"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3272), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("a643bec5-144a-40da-b750-4db008300452"), new Guid("a643bec5-144a-40da-b750-4db008300452"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3328), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("121e833f-3ba9-4a18-8e37-8c96ba9eb2e1"), new Guid("121e833f-3ba9-4a18-8e37-8c96ba9eb2e1"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3384), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("fee08f06-01a4-427e-aa69-e952fba45d2f"), new Guid("fee08f06-01a4-427e-aa69-e952fba45d2f"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3438), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("c4339841-3a4f-4968-8a18-f1b3ddc89418"), new Guid("c4339841-3a4f-4968-8a18-f1b3ddc89418"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3514), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("e3bc8c19-b663-4723-a9d9-d094ff5ed2ef"), new Guid("e3bc8c19-b663-4723-a9d9-d094ff5ed2ef"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3572), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("e1620323-b65c-4ff7-afac-e033852362a0"), new Guid("e1620323-b65c-4ff7-afac-e033852362a0"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3628), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("95ce50b3-9026-4306-8d30-8b38c8197988"), new Guid("95ce50b3-9026-4306-8d30-8b38c8197988"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3031), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("a307db04-6826-4067-b435-0bfb1e35dc40"), new Guid("a307db04-6826-4067-b435-0bfb1e35dc40"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3682), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("3fc4863e-a1f8-4953-88fd-a6840edd3569"), new Guid("3fc4863e-a1f8-4953-88fd-a6840edd3569"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3819), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("9c9f06f1-b12c-4537-80a5-6941efb7307a"), new Guid("9c9f06f1-b12c-4537-80a5-6941efb7307a"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3874), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("3c8cfe34-1aff-40b1-8c89-3f7188f399db"), new Guid("3c8cfe34-1aff-40b1-8c89-3f7188f399db"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3929), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("940322f9-6366-4a41-a8c4-d8b582d57543"), new Guid("940322f9-6366-4a41-a8c4-d8b582d57543"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3984), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("d7ce1beb-5f76-4309-8eea-f8d25342b65a"), new Guid("d7ce1beb-5f76-4309-8eea-f8d25342b65a"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4064), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("3978cae5-b724-4083-b380-a82a251697fe"), new Guid("3978cae5-b724-4083-b380-a82a251697fe"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4121), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("80e00fd5-cad7-4a2f-91d2-4247a94e2b71"), new Guid("80e00fd5-cad7-4a2f-91d2-4247a94e2b71"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4175), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("c4054cc8-4139-4e6b-ad02-7f3e4cdb45d2"), new Guid("c4054cc8-4139-4e6b-ad02-7f3e4cdb45d2"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4270), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("5e0a3c06-701f-401b-bbb6-3ec394e67bfe"), new Guid("5e0a3c06-701f-401b-bbb6-3ec394e67bfe"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4328), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("cc57a210-73ce-41dd-a864-3bf57f24c1c6"), new Guid("cc57a210-73ce-41dd-a864-3bf57f24c1c6"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3736), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("0ae1c788-90bd-43c1-a628-b779e1dc9866"), new Guid("0ae1c788-90bd-43c1-a628-b779e1dc9866"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4382), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("d65c41a8-107c-43a1-b490-64d485cc35e6"), new Guid("d65c41a8-107c-43a1-b490-64d485cc35e6"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2976), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("72905a84-deff-4967-bbec-7dd88ba5e0dd"), new Guid("72905a84-deff-4967-bbec-7dd88ba5e0dd"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2837), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("2d43a677-e0c0-47f7-a2b2-00770a8e6bba"), new Guid("2d43a677-e0c0-47f7-a2b2-00770a8e6bba"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1489), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("43665052-c621-41c2-9472-add36d50a700"), new Guid("43665052-c621-41c2-9472-add36d50a700"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1560), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("9dc5e2f0-cb08-42ce-99ed-49b7c9ca3f1c"), new Guid("9dc5e2f0-cb08-42ce-99ed-49b7c9ca3f1c"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1620), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("ddca1294-f659-480f-8f7c-7c9462d69b7b"), new Guid("ddca1294-f659-480f-8f7c-7c9462d69b7b"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1681), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("25193a94-b283-4ea8-9d34-f923d62a93a9"), new Guid("25193a94-b283-4ea8-9d34-f923d62a93a9"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1764), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("5e9c9d27-9441-4f03-ae90-5a48d04e169b"), new Guid("5e9c9d27-9441-4f03-ae90-5a48d04e169b"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1895), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("4a6d292e-6949-414f-afd5-e6ae36338b47"), new Guid("4a6d292e-6949-414f-afd5-e6ae36338b47"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1951), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("949cf0ef-ee02-40d5-a57a-f47d6e226eae"), new Guid("949cf0ef-ee02-40d5-a57a-f47d6e226eae"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2008), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("44cc229f-eb29-45e8-a75e-bd34b555c4f7"), new Guid("44cc229f-eb29-45e8-a75e-bd34b555c4f7"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2064), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("1da4f0f0-66a4-400d-b947-d6111e7ac5b7"), new Guid("1da4f0f0-66a4-400d-b947-d6111e7ac5b7"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2921), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("a4d6b65f-988f-42d9-8310-b990252ed0b7"), new Guid("a4d6b65f-988f-42d9-8310-b990252ed0b7"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2173), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("5017042e-fafc-45b9-819a-8883e8380cb2"), new Guid("5017042e-fafc-45b9-819a-8883e8380cb2"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2288), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("5b387106-a7a0-45d8-8552-db0ff311431c"), new Guid("5b387106-a7a0-45d8-8552-db0ff311431c"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2343), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("eee3caa9-6b7e-4280-919f-ca99709ae97e"), new Guid("eee3caa9-6b7e-4280-919f-ca99709ae97e"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2423), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("2e34fe9a-da37-4840-a134-d23f51f473a4"), new Guid("2e34fe9a-da37-4840-a134-d23f51f473a4"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2479), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("13463b33-eba9-48e1-b475-75f31be07df9"), new Guid("13463b33-eba9-48e1-b475-75f31be07df9"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2535), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("74a860fe-d5a4-4af0-b059-ad602204de83"), new Guid("74a860fe-d5a4-4af0-b059-ad602204de83"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2592), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandId", "CarExtras", "Color", "CreatedAt", "Description", "FuelType", "Gearbox", "Mileage", "ModelYear", "Price", "SeatCount", "ShowInHome", "Status", "Type", "WeightTotal" },
                values: new object[,]
                {
                    { new Guid("1d6bd0c2-6f5f-4485-8631-7cc5a519a488"), new Guid("1d6bd0c2-6f5f-4485-8631-7cc5a519a488"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2669), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("974a7d09-53ff-4c4b-8d11-7a3270f1c0ff"), new Guid("974a7d09-53ff-4c4b-8d11-7a3270f1c0ff"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2726), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("5dd047c1-a570-4120-ac4b-139bcecc0292"), new Guid("5dd047c1-a570-4120-ac4b-139bcecc0292"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2783), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("5430790f-2a06-4c13-9163-3df410da76d8"), new Guid("5430790f-2a06-4c13-9163-3df410da76d8"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2230), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("6fae6b22-2562-48d8-8b1f-69e9e977dd86"), new Guid("6fae6b22-2562-48d8-8b1f-69e9e977dd86"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4437), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("a837b6b7-3149-446b-a0ba-5643853a40b1"), new Guid("fb6dd539-b181-434c-b9b8-e4fa8a319ed1"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(665), "product-1-720x480.jpg" },
                    { new Guid("ea6cfde6-ae9b-4d4e-b760-29e215bc4f93"), new Guid("121e833f-3ba9-4a18-8e37-8c96ba9eb2e1"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3405), "product-5-720x480.jpg" },
                    { new Guid("9d076c76-77e3-466b-b029-f4c74296e946"), new Guid("121e833f-3ba9-4a18-8e37-8c96ba9eb2e1"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3407), "product-6-720x480.jpg" },
                    { new Guid("a9100bb7-24ba-4867-b0ec-76b0bad9abef"), new Guid("fee08f06-01a4-427e-aa69-e952fba45d2f"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3453), "product-1-720x480.jpg" },
                    { new Guid("611a0f6a-b850-4970-b792-55d39ac238e5"), new Guid("fee08f06-01a4-427e-aa69-e952fba45d2f"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3455), "product-2-720x480.jpg" },
                    { new Guid("21a601a6-4b0f-4ab8-9f6e-0a42749c7c58"), new Guid("fee08f06-01a4-427e-aa69-e952fba45d2f"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3456), "product-3-720x480.jpg" },
                    { new Guid("bbf92485-ed7f-49da-bdd5-71d1b35f7fc2"), new Guid("fee08f06-01a4-427e-aa69-e952fba45d2f"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3458), "product-4-720x480.jpg" },
                    { new Guid("c051cb2a-9701-4000-b3f2-c6f20faf9e58"), new Guid("fee08f06-01a4-427e-aa69-e952fba45d2f"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3460), "product-5-720x480.jpg" },
                    { new Guid("d7712b1c-9727-4bd4-975e-06f248c21bea"), new Guid("fee08f06-01a4-427e-aa69-e952fba45d2f"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3463), "product-6-720x480.jpg" },
                    { new Guid("9f6a50f3-c7ac-42f8-b24d-1e89d1008fdd"), new Guid("c4339841-3a4f-4968-8a18-f1b3ddc89418"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3531), "product-1-720x480.jpg" },
                    { new Guid("33f8a2b5-b35d-4280-b10e-311640ad067b"), new Guid("c4339841-3a4f-4968-8a18-f1b3ddc89418"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3533), "product-2-720x480.jpg" },
                    { new Guid("ee5f5082-03d9-4450-be9e-9432080e7ac0"), new Guid("c4339841-3a4f-4968-8a18-f1b3ddc89418"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3535), "product-3-720x480.jpg" },
                    { new Guid("f710c832-7ca3-4873-8f33-c0833ac826b1"), new Guid("c4339841-3a4f-4968-8a18-f1b3ddc89418"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3537), "product-4-720x480.jpg" },
                    { new Guid("6cf68c28-9140-48e8-a215-2a5ed8befd71"), new Guid("c4339841-3a4f-4968-8a18-f1b3ddc89418"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3540), "product-5-720x480.jpg" },
                    { new Guid("4da3f7a1-0c5b-49c5-9d6f-64779a8e6421"), new Guid("c4339841-3a4f-4968-8a18-f1b3ddc89418"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3542), "product-6-720x480.jpg" },
                    { new Guid("eaf4160c-9306-4eb1-bc85-490340ab2ba2"), new Guid("e3bc8c19-b663-4723-a9d9-d094ff5ed2ef"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3589), "product-1-720x480.jpg" },
                    { new Guid("f3c37931-2e0a-430c-8b3c-ba4506de21b8"), new Guid("e3bc8c19-b663-4723-a9d9-d094ff5ed2ef"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3590), "product-2-720x480.jpg" },
                    { new Guid("e384a75a-ea24-4686-81c7-838003b4023e"), new Guid("e3bc8c19-b663-4723-a9d9-d094ff5ed2ef"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3592), "product-3-720x480.jpg" },
                    { new Guid("56fec8c3-ae32-4c89-aee8-6b3e9affc58a"), new Guid("a307db04-6826-4067-b435-0bfb1e35dc40"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3706), "product-5-720x480.jpg" },
                    { new Guid("6c1217aa-b28b-45a7-a97d-7c33825cfb18"), new Guid("a307db04-6826-4067-b435-0bfb1e35dc40"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3704), "product-4-720x480.jpg" },
                    { new Guid("65f1893e-0c35-40c6-9fa2-7e5b95b7ee2e"), new Guid("a307db04-6826-4067-b435-0bfb1e35dc40"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3702), "product-3-720x480.jpg" },
                    { new Guid("3076443d-4c38-4420-b547-7f73c0e9dc55"), new Guid("a307db04-6826-4067-b435-0bfb1e35dc40"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3701), "product-2-720x480.jpg" },
                    { new Guid("4ae5ad5b-89d3-43ad-b0a8-744c7e799379"), new Guid("a307db04-6826-4067-b435-0bfb1e35dc40"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3697), "product-1-720x480.jpg" },
                    { new Guid("449ea095-c0e8-4f0f-a8f2-324783a50dc2"), new Guid("e1620323-b65c-4ff7-afac-e033852362a0"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3653), "product-6-720x480.jpg" },
                    { new Guid("d25a4527-903c-486a-b63a-ab6760192ddf"), new Guid("121e833f-3ba9-4a18-8e37-8c96ba9eb2e1"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3403), "product-4-720x480.jpg" },
                    { new Guid("86b90ea1-8d8c-4a62-a84a-bf10790ab0fd"), new Guid("e1620323-b65c-4ff7-afac-e033852362a0"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3652), "product-5-720x480.jpg" },
                    { new Guid("450a0281-0833-4adf-a859-22a4baf91e9c"), new Guid("e1620323-b65c-4ff7-afac-e033852362a0"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3648), "product-3-720x480.jpg" },
                    { new Guid("0abb3108-c1b5-41b4-99f9-43fb8e54227a"), new Guid("e1620323-b65c-4ff7-afac-e033852362a0"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3645), "product-2-720x480.jpg" },
                    { new Guid("1a457e1c-1349-4a18-b08e-aff598cbd231"), new Guid("e1620323-b65c-4ff7-afac-e033852362a0"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3643), "product-1-720x480.jpg" },
                    { new Guid("b1d01d85-a708-46a6-a547-aea7230bfe0f"), new Guid("e3bc8c19-b663-4723-a9d9-d094ff5ed2ef"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3599), "product-6-720x480.jpg" },
                    { new Guid("3d940db1-ebf8-417f-b50f-850ebcb9a11d"), new Guid("e3bc8c19-b663-4723-a9d9-d094ff5ed2ef"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3597), "product-5-720x480.jpg" },
                    { new Guid("d7b70853-aeb5-4718-b65c-37f6246f8f90"), new Guid("e3bc8c19-b663-4723-a9d9-d094ff5ed2ef"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3596), "product-4-720x480.jpg" },
                    { new Guid("12930a38-23ee-4dd7-bdfb-82402a5bed2d"), new Guid("e1620323-b65c-4ff7-afac-e033852362a0"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3650), "product-4-720x480.jpg" },
                    { new Guid("30e399a6-22f4-4a8c-aa93-689fb2c34b71"), new Guid("a307db04-6826-4067-b435-0bfb1e35dc40"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3708), "product-6-720x480.jpg" },
                    { new Guid("64b06aa1-594e-43b0-8dba-b0d7ea21695b"), new Guid("121e833f-3ba9-4a18-8e37-8c96ba9eb2e1"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3402), "product-3-720x480.jpg" },
                    { new Guid("92bb306b-3a8c-495d-91cb-1da90547b534"), new Guid("121e833f-3ba9-4a18-8e37-8c96ba9eb2e1"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3398), "product-1-720x480.jpg" },
                    { new Guid("b1f68ff0-ec36-4704-b635-21b8ae0c8d41"), new Guid("d65c41a8-107c-43a1-b490-64d485cc35e6"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3002), "product-6-720x480.jpg" },
                    { new Guid("eca9bc6c-5108-478d-9be7-6e6458709678"), new Guid("95ce50b3-9026-4306-8d30-8b38c8197988"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3046), "product-1-720x480.jpg" },
                    { new Guid("5de4fa54-9495-4c52-bdb5-374cadb9ab7f"), new Guid("95ce50b3-9026-4306-8d30-8b38c8197988"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3047), "product-2-720x480.jpg" },
                    { new Guid("2a5b8668-75b9-4969-a16f-794df1542c43"), new Guid("95ce50b3-9026-4306-8d30-8b38c8197988"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3049), "product-3-720x480.jpg" },
                    { new Guid("cfacc862-9c1a-45fa-9a29-7a90f3da5439"), new Guid("95ce50b3-9026-4306-8d30-8b38c8197988"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3053), "product-4-720x480.jpg" },
                    { new Guid("8aea121d-0c35-40fc-9f62-50cda6159669"), new Guid("95ce50b3-9026-4306-8d30-8b38c8197988"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3054), "product-5-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("05edec56-b31b-4318-8c78-437283470b9f"), new Guid("95ce50b3-9026-4306-8d30-8b38c8197988"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3056), "product-6-720x480.jpg" },
                    { new Guid("1b6c56ec-1bc2-4b78-9baf-395e1397351b"), new Guid("2dd1f682-93bd-4ed4-a98b-fc999e6f1c7f"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3100), "product-1-720x480.jpg" },
                    { new Guid("1084ee50-74c3-4d32-b912-12a0271980f7"), new Guid("2dd1f682-93bd-4ed4-a98b-fc999e6f1c7f"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3102), "product-2-720x480.jpg" },
                    { new Guid("b3605dfd-f036-4255-bc55-7590ff83a49d"), new Guid("2dd1f682-93bd-4ed4-a98b-fc999e6f1c7f"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3106), "product-3-720x480.jpg" },
                    { new Guid("5d984a00-d2b8-4104-a0e5-b00e9721cc37"), new Guid("2dd1f682-93bd-4ed4-a98b-fc999e6f1c7f"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3107), "product-4-720x480.jpg" },
                    { new Guid("ff9cbc16-72c0-4e92-9e93-550b614e172b"), new Guid("2dd1f682-93bd-4ed4-a98b-fc999e6f1c7f"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3109), "product-5-720x480.jpg" },
                    { new Guid("f71463f7-d4a7-441d-abcf-84771a8d990f"), new Guid("2dd1f682-93bd-4ed4-a98b-fc999e6f1c7f"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3111), "product-6-720x480.jpg" },
                    { new Guid("d2a131f4-eaef-4540-8a28-3fc54c9aebbc"), new Guid("0a47936a-aabf-4c8a-abdd-8596d2cd4216"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3230), "product-1-720x480.jpg" },
                    { new Guid("639bef40-95fb-4c96-9cb4-c8c93a79ef64"), new Guid("0a47936a-aabf-4c8a-abdd-8596d2cd4216"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3234), "product-2-720x480.jpg" },
                    { new Guid("a02d5b09-5f0d-48a9-9270-1876c90ba068"), new Guid("0a47936a-aabf-4c8a-abdd-8596d2cd4216"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3236), "product-3-720x480.jpg" },
                    { new Guid("1cdb71c8-8d23-4ad3-9ddc-511508abfa9f"), new Guid("0a47936a-aabf-4c8a-abdd-8596d2cd4216"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3237), "product-4-720x480.jpg" },
                    { new Guid("0028ef4d-fa0b-4d19-be7b-78fa82887b76"), new Guid("a643bec5-144a-40da-b750-4db008300452"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3352), "product-6-720x480.jpg" },
                    { new Guid("d6d2e888-8b53-4a5a-a515-d9f2c490cc7e"), new Guid("a643bec5-144a-40da-b750-4db008300452"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3350), "product-5-720x480.jpg" },
                    { new Guid("8c02213f-0117-4739-add3-cacd13fa3aa1"), new Guid("a643bec5-144a-40da-b750-4db008300452"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3349), "product-4-720x480.jpg" },
                    { new Guid("8060ee48-ae4a-4f09-bb94-ebbd66927759"), new Guid("a643bec5-144a-40da-b750-4db008300452"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3347), "product-3-720x480.jpg" },
                    { new Guid("4cbf9934-2407-485a-b510-089cd95856ce"), new Guid("a643bec5-144a-40da-b750-4db008300452"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3345), "product-2-720x480.jpg" },
                    { new Guid("f89b6258-f106-49eb-8386-17ceca692a32"), new Guid("a643bec5-144a-40da-b750-4db008300452"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3344), "product-1-720x480.jpg" },
                    { new Guid("7ff61a06-45e8-4f9e-b955-525f2ac6caf6"), new Guid("121e833f-3ba9-4a18-8e37-8c96ba9eb2e1"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3400), "product-2-720x480.jpg" },
                    { new Guid("cdcb8874-97c3-4f74-b7c3-2520a83d77d3"), new Guid("d2214b5b-c84a-4d47-a003-3ea334f2affa"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3297), "product-6-720x480.jpg" },
                    { new Guid("cc2b0f6a-2a23-4d05-aacf-126dae724648"), new Guid("d2214b5b-c84a-4d47-a003-3ea334f2affa"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3294), "product-4-720x480.jpg" },
                    { new Guid("b4cfc324-e2a1-4286-bf9a-65c8e684f3df"), new Guid("d2214b5b-c84a-4d47-a003-3ea334f2affa"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3292), "product-3-720x480.jpg" },
                    { new Guid("19d5d6c6-c4dd-4210-9129-5d0dc28d4e02"), new Guid("d2214b5b-c84a-4d47-a003-3ea334f2affa"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3290), "product-2-720x480.jpg" },
                    { new Guid("aef65f55-2069-409d-ab60-8b2761135c03"), new Guid("d2214b5b-c84a-4d47-a003-3ea334f2affa"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3289), "product-1-720x480.jpg" },
                    { new Guid("694a65bf-8832-4c23-a1e6-887b61e02030"), new Guid("0a47936a-aabf-4c8a-abdd-8596d2cd4216"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3241), "product-6-720x480.jpg" },
                    { new Guid("52474fb5-80fc-4f0a-9cd2-71533221140d"), new Guid("0a47936a-aabf-4c8a-abdd-8596d2cd4216"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3239), "product-5-720x480.jpg" },
                    { new Guid("37cf5c00-378b-4d75-bf8a-60ff56fabad8"), new Guid("d2214b5b-c84a-4d47-a003-3ea334f2affa"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3296), "product-5-720x480.jpg" },
                    { new Guid("3d2a6d83-d604-4f39-9905-b9c3d8936922"), new Guid("cc57a210-73ce-41dd-a864-3bf57f24c1c6"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3779), "product-1-720x480.jpg" },
                    { new Guid("094136ba-8882-41c3-8bd2-3755db2328c0"), new Guid("cc57a210-73ce-41dd-a864-3bf57f24c1c6"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3781), "product-2-720x480.jpg" },
                    { new Guid("678725ab-6146-4460-a973-f0ee9a88a3d2"), new Guid("cc57a210-73ce-41dd-a864-3bf57f24c1c6"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3783), "product-3-720x480.jpg" },
                    { new Guid("96c7622a-3a11-4c8b-86b6-2b16ccf54980"), new Guid("3978cae5-b724-4083-b380-a82a251697fe"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4143), "product-4-720x480.jpg" },
                    { new Guid("5fb8c2bd-9926-44af-b1a8-f6db891ef854"), new Guid("3978cae5-b724-4083-b380-a82a251697fe"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4145), "product-5-720x480.jpg" },
                    { new Guid("684dac10-1f63-4570-a896-a1ef3d707d16"), new Guid("3978cae5-b724-4083-b380-a82a251697fe"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4146), "product-6-720x480.jpg" },
                    { new Guid("ce6af268-1758-4313-bb43-636c9bda7d44"), new Guid("80e00fd5-cad7-4a2f-91d2-4247a94e2b71"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4190), "product-1-720x480.jpg" },
                    { new Guid("04003adc-906c-4059-bd2d-eb0332811ddb"), new Guid("80e00fd5-cad7-4a2f-91d2-4247a94e2b71"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4193), "product-2-720x480.jpg" },
                    { new Guid("42c97175-989c-48f9-b6fe-8e6bb1b97b7b"), new Guid("80e00fd5-cad7-4a2f-91d2-4247a94e2b71"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4195), "product-3-720x480.jpg" },
                    { new Guid("514ea048-e590-439e-bf45-a8df2593736c"), new Guid("80e00fd5-cad7-4a2f-91d2-4247a94e2b71"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4197), "product-4-720x480.jpg" },
                    { new Guid("a32fe5e8-3248-4909-9f62-8d0438b33b25"), new Guid("80e00fd5-cad7-4a2f-91d2-4247a94e2b71"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4199), "product-5-720x480.jpg" },
                    { new Guid("0d6580b7-816c-433d-aa7c-7a23ee4f1c85"), new Guid("80e00fd5-cad7-4a2f-91d2-4247a94e2b71"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4200), "product-6-720x480.jpg" },
                    { new Guid("f8a08199-bdf1-48c8-a02b-eac28e8d69cc"), new Guid("c4054cc8-4139-4e6b-ad02-7f3e4cdb45d2"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4288), "product-1-720x480.jpg" },
                    { new Guid("e4b2ffcb-3979-4abe-ae80-ea949b2493c9"), new Guid("c4054cc8-4139-4e6b-ad02-7f3e4cdb45d2"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4290), "product-2-720x480.jpg" },
                    { new Guid("27bc3a6d-380b-4710-b466-74bb88a7d884"), new Guid("c4054cc8-4139-4e6b-ad02-7f3e4cdb45d2"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4292), "product-3-720x480.jpg" },
                    { new Guid("7ce57009-2d94-4069-984a-0233f41b1c42"), new Guid("c4054cc8-4139-4e6b-ad02-7f3e4cdb45d2"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4293), "product-4-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("75bcd3b6-18e6-4a58-9236-b83322a7f6c0"), new Guid("c4054cc8-4139-4e6b-ad02-7f3e4cdb45d2"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4295), "product-5-720x480.jpg" },
                    { new Guid("0b947ccb-f7a9-4fd5-bccd-202c21043482"), new Guid("c4054cc8-4139-4e6b-ad02-7f3e4cdb45d2"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4297), "product-6-720x480.jpg" },
                    { new Guid("e3c3e070-ff77-4be6-85f6-a5a55618b790"), new Guid("5e0a3c06-701f-401b-bbb6-3ec394e67bfe"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4343), "product-1-720x480.jpg" },
                    { new Guid("13ef0733-77cd-4059-a2dd-bc3a493c82cd"), new Guid("5e0a3c06-701f-401b-bbb6-3ec394e67bfe"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4345), "product-2-720x480.jpg" },
                    { new Guid("65c96b47-6051-4e40-a60d-deca14175e89"), new Guid("6fae6b22-2562-48d8-8b1f-69e9e977dd86"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4457), "product-4-720x480.jpg" },
                    { new Guid("ecf1131a-075b-4a38-8b85-fa9be2132736"), new Guid("6fae6b22-2562-48d8-8b1f-69e9e977dd86"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4455), "product-3-720x480.jpg" },
                    { new Guid("e331427e-e6ff-4586-963e-aad92a122aa0"), new Guid("6fae6b22-2562-48d8-8b1f-69e9e977dd86"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4453), "product-2-720x480.jpg" },
                    { new Guid("0bf94389-1297-483e-a974-ee36a937b183"), new Guid("6fae6b22-2562-48d8-8b1f-69e9e977dd86"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4452), "product-1-720x480.jpg" },
                    { new Guid("9b0366f8-2540-4300-9be7-1831f159556d"), new Guid("0ae1c788-90bd-43c1-a628-b779e1dc9866"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4405), "product-6-720x480.jpg" },
                    { new Guid("c1b2154b-07cd-43ef-80c6-9e529cdba130"), new Guid("0ae1c788-90bd-43c1-a628-b779e1dc9866"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4404), "product-5-720x480.jpg" },
                    { new Guid("aeed816c-3aa6-4660-a096-8ae0d88b3635"), new Guid("3978cae5-b724-4083-b380-a82a251697fe"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4141), "product-3-720x480.jpg" },
                    { new Guid("8cc8d741-6cd5-4313-9290-a310a1f55534"), new Guid("0ae1c788-90bd-43c1-a628-b779e1dc9866"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4402), "product-4-720x480.jpg" },
                    { new Guid("cd372fc6-2cb2-44cf-aa5c-a7fee8c147c4"), new Guid("0ae1c788-90bd-43c1-a628-b779e1dc9866"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4399), "product-2-720x480.jpg" },
                    { new Guid("72a1f9f0-92c8-4dc6-893c-15cefe61db13"), new Guid("0ae1c788-90bd-43c1-a628-b779e1dc9866"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4397), "product-1-720x480.jpg" },
                    { new Guid("d95f19d0-2b81-45bf-ae2c-9b96d5c60244"), new Guid("5e0a3c06-701f-401b-bbb6-3ec394e67bfe"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4352), "product-6-720x480.jpg" },
                    { new Guid("de02bbc0-5105-4d38-ba1c-7ead14a2ae31"), new Guid("5e0a3c06-701f-401b-bbb6-3ec394e67bfe"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4350), "product-5-720x480.jpg" },
                    { new Guid("9016ae7f-154e-424a-8893-8bbe6cf6c6fe"), new Guid("5e0a3c06-701f-401b-bbb6-3ec394e67bfe"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4348), "product-4-720x480.jpg" },
                    { new Guid("c27a1f60-fcac-489d-a152-008e94582c67"), new Guid("5e0a3c06-701f-401b-bbb6-3ec394e67bfe"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4347), "product-3-720x480.jpg" },
                    { new Guid("e20c0af4-c523-4754-ac73-a5e2cadaae78"), new Guid("0ae1c788-90bd-43c1-a628-b779e1dc9866"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4400), "product-3-720x480.jpg" },
                    { new Guid("fefeb961-8b69-48fe-9450-5a2c9ef4a892"), new Guid("3978cae5-b724-4083-b380-a82a251697fe"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4138), "product-2-720x480.jpg" },
                    { new Guid("5cfc95ac-b54f-409f-907d-72f4b503b42a"), new Guid("3978cae5-b724-4083-b380-a82a251697fe"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4136), "product-1-720x480.jpg" },
                    { new Guid("639e6337-cd87-4ba4-8f55-989058c8a406"), new Guid("d7ce1beb-5f76-4309-8eea-f8d25342b65a"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4091), "product-6-720x480.jpg" },
                    { new Guid("000ef6d1-6c59-470b-9019-bbc2b61b6d27"), new Guid("9c9f06f1-b12c-4537-80a5-6941efb7307a"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3896), "product-5-720x480.jpg" },
                    { new Guid("13ff9078-e357-46dd-a28f-04b7845e2ef2"), new Guid("9c9f06f1-b12c-4537-80a5-6941efb7307a"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3894), "product-4-720x480.jpg" },
                    { new Guid("ee5289b9-05ac-426a-83b4-942101c75112"), new Guid("9c9f06f1-b12c-4537-80a5-6941efb7307a"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3893), "product-3-720x480.jpg" },
                    { new Guid("6f6fa6e5-3ab4-4231-9165-de6b18771a54"), new Guid("9c9f06f1-b12c-4537-80a5-6941efb7307a"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3891), "product-2-720x480.jpg" },
                    { new Guid("154fb47e-2e14-4a3e-b43f-34754bd0e105"), new Guid("9c9f06f1-b12c-4537-80a5-6941efb7307a"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3889), "product-1-720x480.jpg" },
                    { new Guid("ba80caa2-faa4-48c4-b722-b99f47077cea"), new Guid("3fc4863e-a1f8-4953-88fd-a6840edd3569"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3843), "product-6-720x480.jpg" },
                    { new Guid("f65fd0b6-a1c9-4cb3-aaa2-d7eb83f79838"), new Guid("9c9f06f1-b12c-4537-80a5-6941efb7307a"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3898), "product-6-720x480.jpg" },
                    { new Guid("cefe38e2-6b44-4ac2-a152-c39f555b422b"), new Guid("3fc4863e-a1f8-4953-88fd-a6840edd3569"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3841), "product-5-720x480.jpg" },
                    { new Guid("e00f1627-070f-49ae-aa28-40cd8f5a23c5"), new Guid("3fc4863e-a1f8-4953-88fd-a6840edd3569"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3838), "product-3-720x480.jpg" },
                    { new Guid("9a63b822-68e6-4c50-bc30-a68674681fad"), new Guid("3fc4863e-a1f8-4953-88fd-a6840edd3569"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3836), "product-2-720x480.jpg" },
                    { new Guid("8d431a69-2d67-419a-a280-594086f9eaeb"), new Guid("3fc4863e-a1f8-4953-88fd-a6840edd3569"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3834), "product-1-720x480.jpg" },
                    { new Guid("4041ce13-8b2e-498e-a8f8-be416483a73f"), new Guid("cc57a210-73ce-41dd-a864-3bf57f24c1c6"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3788), "product-6-720x480.jpg" },
                    { new Guid("f74fcaad-e3c3-4365-aa9f-ce370a0e4250"), new Guid("cc57a210-73ce-41dd-a864-3bf57f24c1c6"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3786), "product-5-720x480.jpg" },
                    { new Guid("f400dda9-b555-488b-a1d6-0684c091d79b"), new Guid("cc57a210-73ce-41dd-a864-3bf57f24c1c6"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3785), "product-4-720x480.jpg" },
                    { new Guid("6107ebc5-6429-4d2c-9d4f-a607699a019a"), new Guid("3fc4863e-a1f8-4953-88fd-a6840edd3569"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3839), "product-4-720x480.jpg" },
                    { new Guid("1a60fe35-3e69-4436-b3d6-dc9d21705c16"), new Guid("d65c41a8-107c-43a1-b490-64d485cc35e6"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3000), "product-5-720x480.jpg" },
                    { new Guid("57e294cd-15dc-4221-bc1f-cb5a9deaf425"), new Guid("3c8cfe34-1aff-40b1-8c89-3f7188f399db"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3944), "product-1-720x480.jpg" },
                    { new Guid("0fcec457-c2d6-41ac-ba43-8d6f8067dcce"), new Guid("3c8cfe34-1aff-40b1-8c89-3f7188f399db"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3947), "product-3-720x480.jpg" },
                    { new Guid("03b3dc85-cb75-4922-ae44-2d45fea5a132"), new Guid("d7ce1beb-5f76-4309-8eea-f8d25342b65a"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4089), "product-5-720x480.jpg" },
                    { new Guid("986537c9-6085-4168-8494-61e6527edba6"), new Guid("d7ce1beb-5f76-4309-8eea-f8d25342b65a"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4088), "product-4-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("10d4155b-b63b-4986-8c6c-8c31a91ea70a"), new Guid("d7ce1beb-5f76-4309-8eea-f8d25342b65a"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4084), "product-3-720x480.jpg" },
                    { new Guid("0a34acc1-eb5b-4f1c-bb3b-09e58585331e"), new Guid("d7ce1beb-5f76-4309-8eea-f8d25342b65a"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4082), "product-2-720x480.jpg" },
                    { new Guid("7b4360b7-cf82-4ca0-9fe1-776a93faed06"), new Guid("d7ce1beb-5f76-4309-8eea-f8d25342b65a"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4080), "product-1-720x480.jpg" },
                    { new Guid("d08ba33f-f3c6-4555-b423-45cb9296cc31"), new Guid("940322f9-6366-4a41-a8c4-d8b582d57543"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4009), "product-6-720x480.jpg" },
                    { new Guid("47ef35c1-35c2-430c-9ab8-c0f37c5c5d18"), new Guid("3c8cfe34-1aff-40b1-8c89-3f7188f399db"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3945), "product-2-720x480.jpg" },
                    { new Guid("22a66769-1b30-4fe6-91ee-aff2b036e3e5"), new Guid("940322f9-6366-4a41-a8c4-d8b582d57543"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4008), "product-5-720x480.jpg" },
                    { new Guid("1af60110-6fc0-4eee-93c5-1b2b5557f68d"), new Guid("940322f9-6366-4a41-a8c4-d8b582d57543"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4002), "product-3-720x480.jpg" },
                    { new Guid("7a1838a0-c735-450d-9852-93d1820911e3"), new Guid("940322f9-6366-4a41-a8c4-d8b582d57543"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4000), "product-2-720x480.jpg" },
                    { new Guid("1f9ff750-8ce1-402c-a995-12ae81660197"), new Guid("940322f9-6366-4a41-a8c4-d8b582d57543"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3998), "product-1-720x480.jpg" },
                    { new Guid("366c777c-fcee-4aee-a5b4-425bac2b0959"), new Guid("3c8cfe34-1aff-40b1-8c89-3f7188f399db"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3955), "product-6-720x480.jpg" },
                    { new Guid("d9f31c98-8488-4c60-8514-fcb66689ff6f"), new Guid("3c8cfe34-1aff-40b1-8c89-3f7188f399db"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3951), "product-5-720x480.jpg" },
                    { new Guid("26b72323-289f-4068-b8a6-b70de9c3c8b6"), new Guid("3c8cfe34-1aff-40b1-8c89-3f7188f399db"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(3949), "product-4-720x480.jpg" },
                    { new Guid("e2d46d52-0d9d-4753-bc69-358737bd682e"), new Guid("940322f9-6366-4a41-a8c4-d8b582d57543"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4004), "product-4-720x480.jpg" },
                    { new Guid("0490c7b6-c43c-459c-8413-40df4e742ac1"), new Guid("d65c41a8-107c-43a1-b490-64d485cc35e6"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2996), "product-4-720x480.jpg" },
                    { new Guid("cb0bc6b7-8c2e-44e6-a800-4fef49d569c8"), new Guid("d65c41a8-107c-43a1-b490-64d485cc35e6"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2995), "product-3-720x480.jpg" },
                    { new Guid("d4441d53-d81b-4d89-9114-d7e3a6dc354f"), new Guid("d65c41a8-107c-43a1-b490-64d485cc35e6"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2993), "product-2-720x480.jpg" },
                    { new Guid("088a4647-a934-4192-9ab6-e60ecbfb795c"), new Guid("5e9c9d27-9441-4f03-ae90-5a48d04e169b"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1913), "product-2-720x480.jpg" },
                    { new Guid("9deeeaac-587e-4033-8c4d-29c88194968f"), new Guid("5e9c9d27-9441-4f03-ae90-5a48d04e169b"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1915), "product-3-720x480.jpg" },
                    { new Guid("745bb696-ef95-4268-a46e-8ecc29501474"), new Guid("5e9c9d27-9441-4f03-ae90-5a48d04e169b"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1917), "product-4-720x480.jpg" },
                    { new Guid("757dd0e8-ebec-4c44-94c4-162bdc89cf02"), new Guid("5e9c9d27-9441-4f03-ae90-5a48d04e169b"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1918), "product-5-720x480.jpg" },
                    { new Guid("d277a785-f5f3-4b23-8a82-0eee466e7f6e"), new Guid("5e9c9d27-9441-4f03-ae90-5a48d04e169b"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1922), "product-6-720x480.jpg" },
                    { new Guid("cbd8ace7-f84c-472d-a420-23c3bbe2d06c"), new Guid("4a6d292e-6949-414f-afd5-e6ae36338b47"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1967), "product-1-720x480.jpg" },
                    { new Guid("3942e173-2899-406a-b4da-a007bed2340d"), new Guid("4a6d292e-6949-414f-afd5-e6ae36338b47"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1969), "product-2-720x480.jpg" },
                    { new Guid("18a09148-f5b8-48a7-830a-9c98953fb95a"), new Guid("4a6d292e-6949-414f-afd5-e6ae36338b47"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1971), "product-3-720x480.jpg" },
                    { new Guid("3a31353e-47bd-4c9f-9303-92cb5b5574b2"), new Guid("4a6d292e-6949-414f-afd5-e6ae36338b47"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1972), "product-4-720x480.jpg" },
                    { new Guid("cfde39d6-6f1c-407d-b42b-6d9f5ddbf911"), new Guid("4a6d292e-6949-414f-afd5-e6ae36338b47"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1976), "product-5-720x480.jpg" },
                    { new Guid("d29926ad-55b4-47c1-b9b0-ade589361412"), new Guid("4a6d292e-6949-414f-afd5-e6ae36338b47"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1978), "product-6-720x480.jpg" },
                    { new Guid("0473fc7c-9ec0-4582-b8a4-d0d2434f47a0"), new Guid("949cf0ef-ee02-40d5-a57a-f47d6e226eae"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2025), "product-1-720x480.jpg" },
                    { new Guid("60895e4b-eda5-4d4d-8446-c9b4a90e96c2"), new Guid("949cf0ef-ee02-40d5-a57a-f47d6e226eae"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2027), "product-2-720x480.jpg" },
                    { new Guid("cdb4105d-eeeb-460c-8436-6b99b08d4ce0"), new Guid("949cf0ef-ee02-40d5-a57a-f47d6e226eae"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2028), "product-3-720x480.jpg" },
                    { new Guid("c4919a0c-1606-4b80-9dcf-dc2a244bd4eb"), new Guid("949cf0ef-ee02-40d5-a57a-f47d6e226eae"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2032), "product-4-720x480.jpg" },
                    { new Guid("fec85347-6ea5-4a0a-8830-492141586d0c"), new Guid("949cf0ef-ee02-40d5-a57a-f47d6e226eae"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2034), "product-5-720x480.jpg" },
                    { new Guid("fa91e586-34f6-4795-be38-fdd964acd3f9"), new Guid("949cf0ef-ee02-40d5-a57a-f47d6e226eae"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2035), "product-6-720x480.jpg" },
                    { new Guid("acceb9a4-be9c-4ec7-98ad-be3891ea4925"), new Guid("5430790f-2a06-4c13-9163-3df410da76d8"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2249), "product-2-720x480.jpg" },
                    { new Guid("db6b6249-b6fe-42d3-a2a4-c989fc9711ac"), new Guid("5430790f-2a06-4c13-9163-3df410da76d8"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2248), "product-1-720x480.jpg" },
                    { new Guid("57e591a8-de4a-44d1-976c-e2f029c66ca3"), new Guid("a4d6b65f-988f-42d9-8310-b990252ed0b7"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2199), "product-6-720x480.jpg" },
                    { new Guid("8ba308bc-25db-44c9-a27b-6d98923fa187"), new Guid("a4d6b65f-988f-42d9-8310-b990252ed0b7"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2197), "product-5-720x480.jpg" },
                    { new Guid("0a670d96-7f76-46a6-b881-ad6b37a42c8a"), new Guid("a4d6b65f-988f-42d9-8310-b990252ed0b7"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2196), "product-4-720x480.jpg" },
                    { new Guid("040285d8-282e-4f09-a2a3-f20cbf96ba04"), new Guid("a4d6b65f-988f-42d9-8310-b990252ed0b7"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2194), "product-3-720x480.jpg" },
                    { new Guid("56c993fe-a650-4ab5-b95d-2e61b56d35b2"), new Guid("5e9c9d27-9441-4f03-ae90-5a48d04e169b"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1911), "product-1-720x480.jpg" },
                    { new Guid("57a7ca68-25fe-458b-9cd0-b8fe4ee698fc"), new Guid("a4d6b65f-988f-42d9-8310-b990252ed0b7"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2192), "product-2-720x480.jpg" },
                    { new Guid("ca957b00-da7a-43fc-a251-ee0f6b6bc80e"), new Guid("44cc229f-eb29-45e8-a75e-bd34b555c4f7"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2140), "product-6-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("f63e47bd-5091-4463-bfa7-af60bb8d488c"), new Guid("44cc229f-eb29-45e8-a75e-bd34b555c4f7"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2138), "product-5-720x480.jpg" },
                    { new Guid("2f8cb6bc-5f61-4232-8d9f-44977e588b7b"), new Guid("44cc229f-eb29-45e8-a75e-bd34b555c4f7"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2136), "product-4-720x480.jpg" },
                    { new Guid("482ab749-a448-4bba-942b-4e574cba08cf"), new Guid("44cc229f-eb29-45e8-a75e-bd34b555c4f7"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2135), "product-3-720x480.jpg" },
                    { new Guid("b51b6c9e-888b-442d-86b6-d105cadb6412"), new Guid("44cc229f-eb29-45e8-a75e-bd34b555c4f7"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2131), "product-2-720x480.jpg" },
                    { new Guid("791d010d-7147-41bd-8cf7-d089db6db2e1"), new Guid("44cc229f-eb29-45e8-a75e-bd34b555c4f7"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2129), "product-1-720x480.jpg" },
                    { new Guid("e84b866c-3050-40c1-ae5d-1e5b530814c8"), new Guid("a4d6b65f-988f-42d9-8310-b990252ed0b7"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2189), "product-1-720x480.jpg" },
                    { new Guid("4c57117a-e2ec-4337-be33-ec73955db1e7"), new Guid("25193a94-b283-4ea8-9d34-f923d62a93a9"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1791), "product-6-720x480.jpg" },
                    { new Guid("c14a2be2-b5b2-45bf-a3da-ed3e36ec1738"), new Guid("25193a94-b283-4ea8-9d34-f923d62a93a9"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1789), "product-5-720x480.jpg" },
                    { new Guid("698bb78f-b324-460a-a838-b83c213e7c19"), new Guid("25193a94-b283-4ea8-9d34-f923d62a93a9"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1787), "product-4-720x480.jpg" },
                    { new Guid("854a32a5-9541-4190-903d-32337205af39"), new Guid("43665052-c621-41c2-9472-add36d50a700"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1583), "product-3-720x480.jpg" },
                    { new Guid("691f9fbf-2712-491f-8a68-cf9abaec310f"), new Guid("43665052-c621-41c2-9472-add36d50a700"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1581), "product-2-720x480.jpg" },
                    { new Guid("d7ebe927-0837-486e-9bf4-b3bad5636bea"), new Guid("43665052-c621-41c2-9472-add36d50a700"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1576), "product-1-720x480.jpg" },
                    { new Guid("609ada8f-fc88-4846-a035-a11af3a55fe0"), new Guid("2d43a677-e0c0-47f7-a2b2-00770a8e6bba"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1524), "product-6-720x480.jpg" },
                    { new Guid("dd32fbee-fad4-45e2-86db-e72d6bc7e23f"), new Guid("2d43a677-e0c0-47f7-a2b2-00770a8e6bba"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1522), "product-5-720x480.jpg" },
                    { new Guid("2e677538-4d3e-43cb-9b43-8bbe9ce92a19"), new Guid("2d43a677-e0c0-47f7-a2b2-00770a8e6bba"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1521), "product-4-720x480.jpg" },
                    { new Guid("04ad160f-da2f-4c6c-9309-da06a72a06d0"), new Guid("43665052-c621-41c2-9472-add36d50a700"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1585), "product-4-720x480.jpg" },
                    { new Guid("f0aac057-ad94-47fc-8ab6-c5ea70b86824"), new Guid("2d43a677-e0c0-47f7-a2b2-00770a8e6bba"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1519), "product-3-720x480.jpg" },
                    { new Guid("db63422d-c977-4908-9fb8-985db43f62f6"), new Guid("2d43a677-e0c0-47f7-a2b2-00770a8e6bba"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1511), "product-1-720x480.jpg" },
                    { new Guid("ada77997-4885-4745-8fda-ce6f87f1076e"), new Guid("fb6dd539-b181-434c-b9b8-e4fa8a319ed1"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1213), "product-6-720x480.jpg" },
                    { new Guid("2414d684-9f7d-4f1f-8cfe-4eb79c30430a"), new Guid("fb6dd539-b181-434c-b9b8-e4fa8a319ed1"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1212), "product-5-720x480.jpg" },
                    { new Guid("abed5f7e-9c17-40ff-b007-d2f4520289b1"), new Guid("fb6dd539-b181-434c-b9b8-e4fa8a319ed1"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1209), "product-4-720x480.jpg" },
                    { new Guid("ba25f5dd-f793-4272-aaae-7e86c73fc3bf"), new Guid("fb6dd539-b181-434c-b9b8-e4fa8a319ed1"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1198), "product-3-720x480.jpg" },
                    { new Guid("e2ccd0f2-f5f4-4752-89a6-91fe8e6720e6"), new Guid("fb6dd539-b181-434c-b9b8-e4fa8a319ed1"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1192), "product-2-720x480.jpg" },
                    { new Guid("0cfc9af6-8a65-4a6c-8a70-6c22472b69e5"), new Guid("2d43a677-e0c0-47f7-a2b2-00770a8e6bba"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1513), "product-2-720x480.jpg" },
                    { new Guid("5e4b2c8b-17ee-46ce-b53a-2e2cd5aeb00c"), new Guid("5430790f-2a06-4c13-9163-3df410da76d8"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2251), "product-3-720x480.jpg" },
                    { new Guid("af829630-71d4-4f06-9968-867164763e66"), new Guid("43665052-c621-41c2-9472-add36d50a700"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1586), "product-5-720x480.jpg" },
                    { new Guid("37b7b7b4-1b07-4f1b-91a6-e8d361256454"), new Guid("9dc5e2f0-cb08-42ce-99ed-49b7c9ca3f1c"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1638), "product-1-720x480.jpg" },
                    { new Guid("cdb24f78-eb9a-4d87-83f3-2d14de17dd62"), new Guid("25193a94-b283-4ea8-9d34-f923d62a93a9"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1785), "product-3-720x480.jpg" },
                    { new Guid("229abd19-f8a3-4aa5-b9ea-6bffa9b20331"), new Guid("25193a94-b283-4ea8-9d34-f923d62a93a9"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1784), "product-2-720x480.jpg" },
                    { new Guid("edb33f3c-0cc3-409c-8dfc-1a3b78f10786"), new Guid("25193a94-b283-4ea8-9d34-f923d62a93a9"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1782), "product-1-720x480.jpg" },
                    { new Guid("f73c8666-63e6-4f77-80d9-82da60e5269e"), new Guid("ddca1294-f659-480f-8f7c-7c9462d69b7b"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1707), "product-6-720x480.jpg" },
                    { new Guid("ce3b9d9d-98e7-4fb0-92ad-bdc1f91c0e4c"), new Guid("ddca1294-f659-480f-8f7c-7c9462d69b7b"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1705), "product-5-720x480.jpg" },
                    { new Guid("6089ef03-39e4-411f-9833-b4f818061949"), new Guid("ddca1294-f659-480f-8f7c-7c9462d69b7b"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1703), "product-4-720x480.jpg" },
                    { new Guid("4a48afbd-48f7-45d9-a1c8-f6da22ff99f5"), new Guid("43665052-c621-41c2-9472-add36d50a700"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1588), "product-6-720x480.jpg" },
                    { new Guid("e945ca7d-df90-4a71-bdf3-74a71d8cd483"), new Guid("ddca1294-f659-480f-8f7c-7c9462d69b7b"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1702), "product-3-720x480.jpg" },
                    { new Guid("608a01ef-cb66-443f-9d7b-fe96dd5a7117"), new Guid("ddca1294-f659-480f-8f7c-7c9462d69b7b"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1698), "product-1-720x480.jpg" },
                    { new Guid("c2724885-4752-44b5-980d-68a4a5c30515"), new Guid("9dc5e2f0-cb08-42ce-99ed-49b7c9ca3f1c"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1647), "product-6-720x480.jpg" },
                    { new Guid("81c07c37-e17a-4bdf-8ed6-4d428b3e41a0"), new Guid("9dc5e2f0-cb08-42ce-99ed-49b7c9ca3f1c"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1646), "product-5-720x480.jpg" },
                    { new Guid("928ea52b-8919-4c1e-8450-2a01d5698b48"), new Guid("9dc5e2f0-cb08-42ce-99ed-49b7c9ca3f1c"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1643), "product-4-720x480.jpg" },
                    { new Guid("cad29324-8ee3-4f46-9c8f-465b4dfb58ac"), new Guid("9dc5e2f0-cb08-42ce-99ed-49b7c9ca3f1c"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1642), "product-3-720x480.jpg" },
                    { new Guid("5cdabb3d-327a-4b18-bae4-00d9b3da113a"), new Guid("9dc5e2f0-cb08-42ce-99ed-49b7c9ca3f1c"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1640), "product-2-720x480.jpg" },
                    { new Guid("f93e69d7-8ac4-44c5-b4a5-aa714000fe52"), new Guid("ddca1294-f659-480f-8f7c-7c9462d69b7b"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(1700), "product-2-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("2c0318a6-2b3a-4872-b40f-0d53e5637e50"), new Guid("6fae6b22-2562-48d8-8b1f-69e9e977dd86"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4458), "product-5-720x480.jpg" },
                    { new Guid("b62b8b1b-25d6-4058-a7a8-a311b9c98949"), new Guid("5430790f-2a06-4c13-9163-3df410da76d8"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2253), "product-4-720x480.jpg" },
                    { new Guid("f2d8da05-1f59-4141-98ba-a1f899401500"), new Guid("5430790f-2a06-4c13-9163-3df410da76d8"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2256), "product-6-720x480.jpg" },
                    { new Guid("4f55ae2c-8fe7-4a5c-b9b8-98a44981cdf6"), new Guid("1d6bd0c2-6f5f-4485-8631-7cc5a519a488"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2686), "product-1-720x480.jpg" },
                    { new Guid("2ef76040-070c-4633-ac17-26ae325e8549"), new Guid("1d6bd0c2-6f5f-4485-8631-7cc5a519a488"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2690), "product-2-720x480.jpg" },
                    { new Guid("3441d122-a8c2-4b08-a4b2-72880170e4a4"), new Guid("1d6bd0c2-6f5f-4485-8631-7cc5a519a488"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2692), "product-3-720x480.jpg" },
                    { new Guid("b1df9a66-4c68-43ff-8c2d-a0157e2124a1"), new Guid("1d6bd0c2-6f5f-4485-8631-7cc5a519a488"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2693), "product-4-720x480.jpg" },
                    { new Guid("6017fa63-4ede-4f17-a87e-e342d43e8fa2"), new Guid("1d6bd0c2-6f5f-4485-8631-7cc5a519a488"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2695), "product-5-720x480.jpg" },
                    { new Guid("3f1e51d5-e9bd-4351-ae8f-2f17feb0d3aa"), new Guid("1d6bd0c2-6f5f-4485-8631-7cc5a519a488"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2697), "product-6-720x480.jpg" },
                    { new Guid("ee8faa05-564b-4998-a048-ac1105b17117"), new Guid("974a7d09-53ff-4c4b-8d11-7a3270f1c0ff"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2743), "product-1-720x480.jpg" },
                    { new Guid("0ab51c96-8a4d-4bcf-8e6c-7d748466111a"), new Guid("974a7d09-53ff-4c4b-8d11-7a3270f1c0ff"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2745), "product-2-720x480.jpg" },
                    { new Guid("13e15ad0-8f38-4607-8a4b-70137803b21e"), new Guid("974a7d09-53ff-4c4b-8d11-7a3270f1c0ff"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2747), "product-3-720x480.jpg" },
                    { new Guid("eac7b0d9-02a0-4b51-81f1-29974f0b9e43"), new Guid("974a7d09-53ff-4c4b-8d11-7a3270f1c0ff"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2748), "product-4-720x480.jpg" },
                    { new Guid("e2cb3933-56a2-43c0-b314-bb35598e5740"), new Guid("974a7d09-53ff-4c4b-8d11-7a3270f1c0ff"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2750), "product-5-720x480.jpg" },
                    { new Guid("17749fb8-6dfa-42ad-b789-8491ca2ec8a1"), new Guid("974a7d09-53ff-4c4b-8d11-7a3270f1c0ff"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2752), "product-6-720x480.jpg" },
                    { new Guid("b103dec5-dc35-4840-841c-60e33a34eb2f"), new Guid("5dd047c1-a570-4120-ac4b-139bcecc0292"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2798), "product-1-720x480.jpg" },
                    { new Guid("113e3281-2b67-4e89-9e20-6b0b3a5e2c9b"), new Guid("5dd047c1-a570-4120-ac4b-139bcecc0292"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2800), "product-2-720x480.jpg" },
                    { new Guid("b16cbf98-f425-46b4-9ae1-22a0d51dfb9a"), new Guid("5dd047c1-a570-4120-ac4b-139bcecc0292"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2801), "product-3-720x480.jpg" },
                    { new Guid("0ec1198b-0a35-4fa9-b478-f0f0b0d9118b"), new Guid("5dd047c1-a570-4120-ac4b-139bcecc0292"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2803), "product-4-720x480.jpg" },
                    { new Guid("69ba0810-3d8b-4a85-8145-9d6fafe13d23"), new Guid("5dd047c1-a570-4120-ac4b-139bcecc0292"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2805), "product-5-720x480.jpg" },
                    { new Guid("bd83e773-69ee-4531-b906-95bcb99023a2"), new Guid("d65c41a8-107c-43a1-b490-64d485cc35e6"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2991), "product-1-720x480.jpg" },
                    { new Guid("93200c0b-f483-4df5-946d-613b304484b8"), new Guid("1da4f0f0-66a4-400d-b947-d6111e7ac5b7"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2947), "product-6-720x480.jpg" },
                    { new Guid("b38b269f-297d-4fd0-9cfe-0e40dca497a9"), new Guid("1da4f0f0-66a4-400d-b947-d6111e7ac5b7"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2943), "product-5-720x480.jpg" },
                    { new Guid("71dcb496-ffea-43ab-a0cf-415d186ab34b"), new Guid("1da4f0f0-66a4-400d-b947-d6111e7ac5b7"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2942), "product-4-720x480.jpg" },
                    { new Guid("8f40fd2b-5c52-4b40-a3c3-bb275878849c"), new Guid("1da4f0f0-66a4-400d-b947-d6111e7ac5b7"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2940), "product-3-720x480.jpg" },
                    { new Guid("1d163cd8-b19e-4785-92a5-176cfc5d7fc0"), new Guid("1da4f0f0-66a4-400d-b947-d6111e7ac5b7"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2938), "product-2-720x480.jpg" },
                    { new Guid("b6692853-b3fe-4f4e-9062-ffa5454339b2"), new Guid("74a860fe-d5a4-4af0-b059-ad602204de83"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2617), "product-6-720x480.jpg" },
                    { new Guid("c009652e-66c2-473f-90dd-92085229eb44"), new Guid("1da4f0f0-66a4-400d-b947-d6111e7ac5b7"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2937), "product-1-720x480.jpg" },
                    { new Guid("4f14528a-15bd-4a2f-95b4-424f2f2585ff"), new Guid("72905a84-deff-4967-bbec-7dd88ba5e0dd"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2859), "product-5-720x480.jpg" },
                    { new Guid("613781da-3c8f-407b-97d3-5370306ee784"), new Guid("72905a84-deff-4967-bbec-7dd88ba5e0dd"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2857), "product-4-720x480.jpg" },
                    { new Guid("60c289ca-7b47-4ca7-8f00-fe12f16665fb"), new Guid("72905a84-deff-4967-bbec-7dd88ba5e0dd"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2856), "product-3-720x480.jpg" },
                    { new Guid("23f19473-87f2-4614-9fda-0487b2cbf58b"), new Guid("72905a84-deff-4967-bbec-7dd88ba5e0dd"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2854), "product-2-720x480.jpg" },
                    { new Guid("6db72c3b-f40d-42ce-99b5-fa8533524813"), new Guid("72905a84-deff-4967-bbec-7dd88ba5e0dd"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2852), "product-1-720x480.jpg" },
                    { new Guid("4724bc94-3a8f-4ab1-8bf8-83d16e33efd6"), new Guid("5dd047c1-a570-4120-ac4b-139bcecc0292"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2806), "product-6-720x480.jpg" },
                    { new Guid("9984d558-220a-4b51-a1e4-f222ee9520e7"), new Guid("72905a84-deff-4967-bbec-7dd88ba5e0dd"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2861), "product-6-720x480.jpg" },
                    { new Guid("e3114a60-9723-4968-804a-7cb43375a9b4"), new Guid("74a860fe-d5a4-4af0-b059-ad602204de83"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2615), "product-5-720x480.jpg" },
                    { new Guid("9f8885cc-2303-4ebc-8599-4d537ec2d071"), new Guid("74a860fe-d5a4-4af0-b059-ad602204de83"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2613), "product-4-720x480.jpg" },
                    { new Guid("c29e9ef9-53a8-49ca-a06c-58384c0b8179"), new Guid("74a860fe-d5a4-4af0-b059-ad602204de83"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2612), "product-3-720x480.jpg" },
                    { new Guid("0bf47232-739e-4c52-9f77-486aebd9dad4"), new Guid("eee3caa9-6b7e-4280-919f-ca99709ae97e"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2441), "product-2-720x480.jpg" },
                    { new Guid("c4fa88f6-8431-4632-9d0b-51ea0c7f2f75"), new Guid("eee3caa9-6b7e-4280-919f-ca99709ae97e"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2439), "product-1-720x480.jpg" },
                    { new Guid("1ea240ad-f201-4d85-a6a3-59d13c37debe"), new Guid("5b387106-a7a0-45d8-8552-db0ff311431c"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2390), "product-6-720x480.jpg" },
                    { new Guid("76584063-68e0-40da-8f6c-e263dfed7f2a"), new Guid("5b387106-a7a0-45d8-8552-db0ff311431c"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2388), "product-5-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("6acb990e-e74d-4136-8771-ee17d66bd74e"), new Guid("5b387106-a7a0-45d8-8552-db0ff311431c"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2387), "product-4-720x480.jpg" },
                    { new Guid("73ede3b9-0500-473b-9f19-240f5993de65"), new Guid("5b387106-a7a0-45d8-8552-db0ff311431c"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2385), "product-3-720x480.jpg" },
                    { new Guid("e95a742c-3c53-4d27-bbb8-f354da34277e"), new Guid("eee3caa9-6b7e-4280-919f-ca99709ae97e"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2442), "product-3-720x480.jpg" },
                    { new Guid("71c82962-edfa-4d88-9149-c42936dbf6ed"), new Guid("5b387106-a7a0-45d8-8552-db0ff311431c"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2360), "product-2-720x480.jpg" },
                    { new Guid("5e0f10c4-4e14-435e-8d22-eacb0d392e30"), new Guid("5017042e-fafc-45b9-819a-8883e8380cb2"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2312), "product-6-720x480.jpg" },
                    { new Guid("965a7ffd-a322-4a53-b543-60b810e2f597"), new Guid("5017042e-fafc-45b9-819a-8883e8380cb2"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2310), "product-5-720x480.jpg" },
                    { new Guid("6af8adbb-a94b-435b-b9dc-0b91c4b5ae48"), new Guid("5017042e-fafc-45b9-819a-8883e8380cb2"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2309), "product-4-720x480.jpg" },
                    { new Guid("63fe0a6c-79c6-42c9-8106-ce1eb3827258"), new Guid("5017042e-fafc-45b9-819a-8883e8380cb2"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2307), "product-3-720x480.jpg" },
                    { new Guid("a85d4a2d-51f4-4ca8-8ddb-1028402cb37e"), new Guid("5017042e-fafc-45b9-819a-8883e8380cb2"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2305), "product-2-720x480.jpg" },
                    { new Guid("25839543-6cb3-48df-aef8-c488449ed5e7"), new Guid("5017042e-fafc-45b9-819a-8883e8380cb2"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2303), "product-1-720x480.jpg" },
                    { new Guid("1b32850e-4712-4520-a80c-211722f7707c"), new Guid("5b387106-a7a0-45d8-8552-db0ff311431c"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2358), "product-1-720x480.jpg" },
                    { new Guid("241a3c0b-205b-4158-b7c9-0cb600d837fb"), new Guid("5430790f-2a06-4c13-9163-3df410da76d8"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2255), "product-5-720x480.jpg" },
                    { new Guid("bed3d50b-cc4c-4889-890e-8612e6164dc7"), new Guid("eee3caa9-6b7e-4280-919f-ca99709ae97e"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2444), "product-4-720x480.jpg" },
                    { new Guid("4e1a6f2b-6782-4afd-9edb-de27c3b01ed5"), new Guid("eee3caa9-6b7e-4280-919f-ca99709ae97e"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2450), "product-6-720x480.jpg" },
                    { new Guid("66807f43-478a-41f8-b9e1-d3f84618dc80"), new Guid("74a860fe-d5a4-4af0-b059-ad602204de83"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2608), "product-2-720x480.jpg" },
                    { new Guid("a4a4e4b2-1a75-442d-817c-15de5f62a66c"), new Guid("74a860fe-d5a4-4af0-b059-ad602204de83"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2606), "product-1-720x480.jpg" },
                    { new Guid("b249c752-4f62-4158-9302-7ba201cd7c9c"), new Guid("13463b33-eba9-48e1-b475-75f31be07df9"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2562), "product-6-720x480.jpg" },
                    { new Guid("7ffdcfcc-55e9-4ded-b96d-cf9e06b35a58"), new Guid("13463b33-eba9-48e1-b475-75f31be07df9"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2560), "product-5-720x480.jpg" },
                    { new Guid("f21436eb-5489-4b5e-9162-d18356a29904"), new Guid("13463b33-eba9-48e1-b475-75f31be07df9"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2559), "product-4-720x480.jpg" },
                    { new Guid("b93d57d6-77d0-4e3c-bf95-3ba5d39e5edb"), new Guid("13463b33-eba9-48e1-b475-75f31be07df9"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2555), "product-3-720x480.jpg" },
                    { new Guid("32063d5b-37a3-45b1-9923-af0e62a80813"), new Guid("eee3caa9-6b7e-4280-919f-ca99709ae97e"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2446), "product-5-720x480.jpg" },
                    { new Guid("1ecbcfa2-6124-4bc1-9cce-e0e08152d472"), new Guid("13463b33-eba9-48e1-b475-75f31be07df9"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2553), "product-2-720x480.jpg" },
                    { new Guid("88a0f526-bed1-4d74-96f3-16671341bfe8"), new Guid("2e34fe9a-da37-4840-a134-d23f51f473a4"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2504), "product-6-720x480.jpg" },
                    { new Guid("edadaa10-8221-4e9c-a21a-080da40907fc"), new Guid("2e34fe9a-da37-4840-a134-d23f51f473a4"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2502), "product-5-720x480.jpg" },
                    { new Guid("25ab9013-38f0-4b03-8168-e40807752258"), new Guid("2e34fe9a-da37-4840-a134-d23f51f473a4"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2499), "product-4-720x480.jpg" },
                    { new Guid("1ea1cfa6-cbbc-416d-9823-c352ab997fe4"), new Guid("2e34fe9a-da37-4840-a134-d23f51f473a4"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2497), "product-3-720x480.jpg" },
                    { new Guid("036f51d0-821c-4bec-9bfe-4dc84f3a0f52"), new Guid("2e34fe9a-da37-4840-a134-d23f51f473a4"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2495), "product-2-720x480.jpg" },
                    { new Guid("9003c475-b620-4ae3-be10-2dcf4910dfdb"), new Guid("2e34fe9a-da37-4840-a134-d23f51f473a4"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2494), "product-1-720x480.jpg" },
                    { new Guid("cc40bbc8-a1a7-49da-ad04-79eb84d58412"), new Guid("13463b33-eba9-48e1-b475-75f31be07df9"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(2551), "product-1-720x480.jpg" },
                    { new Guid("5d388a18-2318-4ac6-acee-601b25372123"), new Guid("6fae6b22-2562-48d8-8b1f-69e9e977dd86"), new DateTime(2021, 7, 17, 18, 57, 39, 185, DateTimeKind.Local).AddTicks(4462), "product-6-720x480.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId",
                table: "Cars",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_CarId",
                table: "Images",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
