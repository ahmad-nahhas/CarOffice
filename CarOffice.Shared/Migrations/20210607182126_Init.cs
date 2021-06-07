using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarOffice.Shared.Migrations
{
    public partial class Init : Migration
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
                    { new Guid("27752cd9-cc74-4999-a9b6-d1bc0caef6dd"), new DateTime(2021, 6, 7, 21, 21, 26, 47, DateTimeKind.Local).AddTicks(7796), "Acura" },
                    { new Guid("caaff101-5f6d-4790-934b-8c1857d47b6a"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2258), "Mazda" },
                    { new Guid("4eb1c157-3906-4d7b-b7a0-03bde35fb548"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2327), "Mercedes-Benz" },
                    { new Guid("f6c98e00-6f71-4e5c-a366-9a696907e262"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2491), "Mercury" },
                    { new Guid("b9ccad2d-0544-471f-bee8-0b502041c510"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2557), "Mini" },
                    { new Guid("9062304b-8027-48e0-a74c-f234ec11ef50"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2625), "Mitsubishi" },
                    { new Guid("48596c22-409e-4ce2-9cef-0c879caa9293"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2696), "Nikola" },
                    { new Guid("a13a5620-849f-4a47-ac2c-cd147cb9a832"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2798), "Nissan" },
                    { new Guid("48cd664d-9aeb-42d1-979c-fcaf203fe4d3"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2869), "Polestar" },
                    { new Guid("6c893c4b-8cc8-4ca6-81cf-61f7816b5eef"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2943), "Pontiac" },
                    { new Guid("107441f4-8e6e-451f-8ad3-cff2c7a87d76"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2189), "Maserati" },
                    { new Guid("39875906-7ed0-4247-ae0a-75d85ba3cb88"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3012), "Porsche" },
                    { new Guid("150e4c40-e41b-4c4c-bab0-be10f9efada3"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3180), "Rivian" },
                    { new Guid("007bf198-dade-475b-a699-8038bd78adca"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3249), "Rolls-Royce" },
                    { new Guid("462e4beb-ac7a-44cd-b076-b04f735cc38f"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3320), "Saab" },
                    { new Guid("4d43cfb2-8f99-4aab-a6ed-ca2643593d66"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3389), "Scion" },
                    { new Guid("2ee8fd4e-a529-4b33-9b0b-f8a73463f7d0"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3491), "Smart" },
                    { new Guid("da0f0c0f-0e71-4096-be69-4a24b2fe2782"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3559), "Subaru" },
                    { new Guid("8918bb29-ef01-4995-b971-66dadc617a83"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3628), "Suzuki" },
                    { new Guid("45bf8f63-2b83-4749-b696-dca0e3ef01a4"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3734), "Tesla" },
                    { new Guid("ae5903e4-2b40-4138-a110-1b6b00c78e87"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3804), "Toyota" },
                    { new Guid("786bef22-7260-4b9f-8142-206a9f436e28"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3108), "Ram" },
                    { new Guid("68797a68-681d-426f-86c1-4f87ee77c16d"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3873), "Volkswagen" },
                    { new Guid("52d89f92-4402-4f50-882c-2282ab9aca1c"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2121), "Lotus" },
                    { new Guid("be9ffbb4-10ca-4c18-9f8b-cbdb445b4e61"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1944), "Lexus" },
                    { new Guid("2a087e01-c71c-422c-8557-216575e11a68"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(271), "Alfa Romeo" },
                    { new Guid("1c7fb64e-e778-4a24-a978-b936748f7f4a"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(445), "Audi" },
                    { new Guid("8b8f6066-a6bf-4940-9189-22c9677058dd"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(524), "Bentley" },
                    { new Guid("c73639d0-a5b0-498c-be36-532b4da2a44d"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(597), "Buick" },
                    { new Guid("cacb0843-0f25-447b-bfb4-7e005eff249b"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(716), "BMW" },
                    { new Guid("7e514a55-34c6-4a30-983a-a20cec6ba392"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(795), "Cadillac" },
                    { new Guid("35e04e93-5e16-422f-96ee-f89e3edc705c"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(865), "Chevrolet" },
                    { new Guid("483f66f4-bd6f-4b8e-98e9-68d90ecd9080"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(934), "Chrysler" },
                    { new Guid("349c25b3-4e5f-4b41-b51d-0f963e2fdc48"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1008), "Dodge" },
                    { new Guid("d7ab6c82-5a42-45f8-9587-0dbdfd85ff3e"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2050), "Lincoln" },
                    { new Guid("1360526e-c8c1-4262-8dad-be6a9afb3735"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1111), "Fiat" },
                    { new Guid("39b390de-b2f2-4d30-91be-12170d437329"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1250), "GMC" },
                    { new Guid("6c80706f-3a65-4e71-868d-fe5bad92251c"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1319), "Genesis" },
                    { new Guid("74d2ac31-d09a-4181-a2a0-0a31f26a38dd"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1423), "Honda" },
                    { new Guid("9b62354d-f5fd-49f2-a8a2-05988bd1f31b"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1492), "Hyundai" },
                    { new Guid("2fb237f6-a4e9-4395-8c2c-c0fa09d58b43"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1562), "Infiniti" },
                    { new Guid("2a15d983-d1ab-4c90-9a0c-7dcf70c88fcf"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1636), "Jaguar" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("daa5f48e-a58d-459a-aa14-136d75aeaa40"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1736), "Jeep" },
                    { new Guid("dba617f0-65f5-4a73-938e-8def2620200f"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1806), "Kia" },
                    { new Guid("17e3c245-7304-46ed-b04b-9e9616201b08"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1876), "Land Rover" },
                    { new Guid("0f1bcb56-c33f-4514-bc00-877910b4201b"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1182), "Ford" },
                    { new Guid("664c678f-ecbd-41da-adf8-30f14ce67da1"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3944), "Volvo" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandId", "CarExtras", "Color", "CreatedAt", "Description", "FuelType", "Gearbox", "Mileage", "ModelYear", "Price", "SeatCount", "ShowInHome", "Status", "Type", "WeightTotal" },
                values: new object[,]
                {
                    { new Guid("27752cd9-cc74-4999-a9b6-d1bc0caef6dd"), new Guid("27752cd9-cc74-4999-a9b6-d1bc0caef6dd"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 50, DateTimeKind.Local).AddTicks(3785), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("caaff101-5f6d-4790-934b-8c1857d47b6a"), new Guid("caaff101-5f6d-4790-934b-8c1857d47b6a"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2276), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("4eb1c157-3906-4d7b-b7a0-03bde35fb548"), new Guid("4eb1c157-3906-4d7b-b7a0-03bde35fb548"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2437), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("f6c98e00-6f71-4e5c-a366-9a696907e262"), new Guid("f6c98e00-6f71-4e5c-a366-9a696907e262"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2508), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("b9ccad2d-0544-471f-bee8-0b502041c510"), new Guid("b9ccad2d-0544-471f-bee8-0b502041c510"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2575), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("9062304b-8027-48e0-a74c-f234ec11ef50"), new Guid("9062304b-8027-48e0-a74c-f234ec11ef50"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2645), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("48596c22-409e-4ce2-9cef-0c879caa9293"), new Guid("48596c22-409e-4ce2-9cef-0c879caa9293"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2714), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("a13a5620-849f-4a47-ac2c-cd147cb9a832"), new Guid("a13a5620-849f-4a47-ac2c-cd147cb9a832"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2818), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("48cd664d-9aeb-42d1-979c-fcaf203fe4d3"), new Guid("48cd664d-9aeb-42d1-979c-fcaf203fe4d3"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2890), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("6c893c4b-8cc8-4ca6-81cf-61f7816b5eef"), new Guid("6c893c4b-8cc8-4ca6-81cf-61f7816b5eef"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2961), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("107441f4-8e6e-451f-8ad3-cff2c7a87d76"), new Guid("107441f4-8e6e-451f-8ad3-cff2c7a87d76"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2208), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("39875906-7ed0-4247-ae0a-75d85ba3cb88"), new Guid("39875906-7ed0-4247-ae0a-75d85ba3cb88"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3030), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("150e4c40-e41b-4c4c-bab0-be10f9efada3"), new Guid("150e4c40-e41b-4c4c-bab0-be10f9efada3"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3198), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("007bf198-dade-475b-a699-8038bd78adca"), new Guid("007bf198-dade-475b-a699-8038bd78adca"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3269), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("462e4beb-ac7a-44cd-b076-b04f735cc38f"), new Guid("462e4beb-ac7a-44cd-b076-b04f735cc38f"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3338), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("4d43cfb2-8f99-4aab-a6ed-ca2643593d66"), new Guid("4d43cfb2-8f99-4aab-a6ed-ca2643593d66"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3407), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("2ee8fd4e-a529-4b33-9b0b-f8a73463f7d0"), new Guid("2ee8fd4e-a529-4b33-9b0b-f8a73463f7d0"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3508), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("da0f0c0f-0e71-4096-be69-4a24b2fe2782"), new Guid("da0f0c0f-0e71-4096-be69-4a24b2fe2782"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3577), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("8918bb29-ef01-4995-b971-66dadc617a83"), new Guid("8918bb29-ef01-4995-b971-66dadc617a83"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3645), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("45bf8f63-2b83-4749-b696-dca0e3ef01a4"), new Guid("45bf8f63-2b83-4749-b696-dca0e3ef01a4"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3752), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("ae5903e4-2b40-4138-a110-1b6b00c78e87"), new Guid("ae5903e4-2b40-4138-a110-1b6b00c78e87"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3822), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("786bef22-7260-4b9f-8142-206a9f436e28"), new Guid("786bef22-7260-4b9f-8142-206a9f436e28"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3129), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("68797a68-681d-426f-86c1-4f87ee77c16d"), new Guid("68797a68-681d-426f-86c1-4f87ee77c16d"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3893), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("52d89f92-4402-4f50-882c-2282ab9aca1c"), new Guid("52d89f92-4402-4f50-882c-2282ab9aca1c"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2139), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("be9ffbb4-10ca-4c18-9f8b-cbdb445b4e61"), new Guid("be9ffbb4-10ca-4c18-9f8b-cbdb445b4e61"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1964), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("2a087e01-c71c-422c-8557-216575e11a68"), new Guid("2a087e01-c71c-422c-8557-216575e11a68"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(371), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("1c7fb64e-e778-4a24-a978-b936748f7f4a"), new Guid("1c7fb64e-e778-4a24-a978-b936748f7f4a"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(466), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("8b8f6066-a6bf-4940-9189-22c9677058dd"), new Guid("8b8f6066-a6bf-4940-9189-22c9677058dd"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(544), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("c73639d0-a5b0-498c-be36-532b4da2a44d"), new Guid("c73639d0-a5b0-498c-be36-532b4da2a44d"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(617), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("cacb0843-0f25-447b-bfb4-7e005eff249b"), new Guid("cacb0843-0f25-447b-bfb4-7e005eff249b"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(740), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("7e514a55-34c6-4a30-983a-a20cec6ba392"), new Guid("7e514a55-34c6-4a30-983a-a20cec6ba392"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(814), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("35e04e93-5e16-422f-96ee-f89e3edc705c"), new Guid("35e04e93-5e16-422f-96ee-f89e3edc705c"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(884), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("483f66f4-bd6f-4b8e-98e9-68d90ecd9080"), new Guid("483f66f4-bd6f-4b8e-98e9-68d90ecd9080"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(955), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("349c25b3-4e5f-4b41-b51d-0f963e2fdc48"), new Guid("349c25b3-4e5f-4b41-b51d-0f963e2fdc48"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1056), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("d7ab6c82-5a42-45f8-9587-0dbdfd85ff3e"), new Guid("d7ab6c82-5a42-45f8-9587-0dbdfd85ff3e"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2070), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("1360526e-c8c1-4262-8dad-be6a9afb3735"), new Guid("1360526e-c8c1-4262-8dad-be6a9afb3735"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1129), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("39b390de-b2f2-4d30-91be-12170d437329"), new Guid("39b390de-b2f2-4d30-91be-12170d437329"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1269), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("6c80706f-3a65-4e71-868d-fe5bad92251c"), new Guid("6c80706f-3a65-4e71-868d-fe5bad92251c"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1368), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("74d2ac31-d09a-4181-a2a0-0a31f26a38dd"), new Guid("74d2ac31-d09a-4181-a2a0-0a31f26a38dd"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1442), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("9b62354d-f5fd-49f2-a8a2-05988bd1f31b"), new Guid("9b62354d-f5fd-49f2-a8a2-05988bd1f31b"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1510), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("2fb237f6-a4e9-4395-8c2c-c0fa09d58b43"), new Guid("2fb237f6-a4e9-4395-8c2c-c0fa09d58b43"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1582), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("2a15d983-d1ab-4c90-9a0c-7dcf70c88fcf"), new Guid("2a15d983-d1ab-4c90-9a0c-7dcf70c88fcf"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1654), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandId", "CarExtras", "Color", "CreatedAt", "Description", "FuelType", "Gearbox", "Mileage", "ModelYear", "Price", "SeatCount", "ShowInHome", "Status", "Type", "WeightTotal" },
                values: new object[,]
                {
                    { new Guid("daa5f48e-a58d-459a-aa14-136d75aeaa40"), new Guid("daa5f48e-a58d-459a-aa14-136d75aeaa40"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1755), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("dba617f0-65f5-4a73-938e-8def2620200f"), new Guid("dba617f0-65f5-4a73-938e-8def2620200f"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1825), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("17e3c245-7304-46ed-b04b-9e9616201b08"), new Guid("17e3c245-7304-46ed-b04b-9e9616201b08"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1894), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("0f1bcb56-c33f-4514-bc00-877910b4201b"), new Guid("0f1bcb56-c33f-4514-bc00-877910b4201b"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1200), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("664c678f-ecbd-41da-adf8-30f14ce67da1"), new Guid("664c678f-ecbd-41da-adf8-30f14ce67da1"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3962), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("9c604fc0-fb71-48d1-b2f7-3ef617016ae8"), new Guid("27752cd9-cc74-4999-a9b6-d1bc0caef6dd"), new DateTime(2021, 6, 7, 21, 21, 26, 50, DateTimeKind.Local).AddTicks(9350), "product-1-720x480.jpg" },
                    { new Guid("e0771d74-b087-405f-9944-243a72f90006"), new Guid("9062304b-8027-48e0-a74c-f234ec11ef50"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2673), "product-5-720x480.jpg" },
                    { new Guid("58f6e47b-870e-4bda-8f4a-c93039cebe92"), new Guid("9062304b-8027-48e0-a74c-f234ec11ef50"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2675), "product-6-720x480.jpg" },
                    { new Guid("d7ec4c74-3d96-45b3-b7cb-8d7272f85c6e"), new Guid("48596c22-409e-4ce2-9cef-0c879caa9293"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2733), "product-1-720x480.jpg" },
                    { new Guid("15f80d23-70e5-468e-ad54-74be64622b20"), new Guid("48596c22-409e-4ce2-9cef-0c879caa9293"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2735), "product-2-720x480.jpg" },
                    { new Guid("170522f4-0439-4e40-b194-8175e7ee141d"), new Guid("48596c22-409e-4ce2-9cef-0c879caa9293"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2737), "product-3-720x480.jpg" },
                    { new Guid("2525d7a7-d087-4529-9453-38a70571868e"), new Guid("48596c22-409e-4ce2-9cef-0c879caa9293"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2740), "product-4-720x480.jpg" },
                    { new Guid("b923a430-0990-49ae-898f-3d382d0a469e"), new Guid("48596c22-409e-4ce2-9cef-0c879caa9293"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2741), "product-5-720x480.jpg" },
                    { new Guid("a4131bbb-3355-4cb3-b056-f0edbbfb73b7"), new Guid("48596c22-409e-4ce2-9cef-0c879caa9293"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2743), "product-6-720x480.jpg" },
                    { new Guid("6372a564-d86b-49ac-8901-85b6f9beefe3"), new Guid("a13a5620-849f-4a47-ac2c-cd147cb9a832"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2837), "product-1-720x480.jpg" },
                    { new Guid("b8073b27-023f-4227-89a4-13f68a805db1"), new Guid("a13a5620-849f-4a47-ac2c-cd147cb9a832"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2839), "product-2-720x480.jpg" },
                    { new Guid("6ea9ab36-684d-4647-a5a4-a3f025ef31ae"), new Guid("a13a5620-849f-4a47-ac2c-cd147cb9a832"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2842), "product-3-720x480.jpg" },
                    { new Guid("d84034de-6ea9-4192-b5f7-e54b25816d5b"), new Guid("a13a5620-849f-4a47-ac2c-cd147cb9a832"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2844), "product-4-720x480.jpg" },
                    { new Guid("afcd7c5b-e799-46d9-890c-ee33e5d1dd45"), new Guid("a13a5620-849f-4a47-ac2c-cd147cb9a832"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2846), "product-5-720x480.jpg" },
                    { new Guid("14f5905c-0437-43a0-8b76-cf8097a225d7"), new Guid("a13a5620-849f-4a47-ac2c-cd147cb9a832"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2850), "product-6-720x480.jpg" },
                    { new Guid("8045c7b9-1e1b-46b1-b995-73d24e5282b4"), new Guid("48cd664d-9aeb-42d1-979c-fcaf203fe4d3"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2912), "product-1-720x480.jpg" },
                    { new Guid("215997a4-8a96-44f6-a8b0-152d6591f4c3"), new Guid("48cd664d-9aeb-42d1-979c-fcaf203fe4d3"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2914), "product-2-720x480.jpg" },
                    { new Guid("fcb4e1cf-e4e2-4dc7-8924-a3e10a79af3c"), new Guid("48cd664d-9aeb-42d1-979c-fcaf203fe4d3"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2916), "product-3-720x480.jpg" },
                    { new Guid("80ce5dff-bc78-4874-96b6-e24bd9dc35ad"), new Guid("39875906-7ed0-4247-ae0a-75d85ba3cb88"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3060), "product-5-720x480.jpg" },
                    { new Guid("1f869104-aa8c-4501-9534-bb49b8c07ba5"), new Guid("39875906-7ed0-4247-ae0a-75d85ba3cb88"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3058), "product-4-720x480.jpg" },
                    { new Guid("06335f86-b4ce-4dcc-928c-4f69871e7198"), new Guid("39875906-7ed0-4247-ae0a-75d85ba3cb88"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3056), "product-3-720x480.jpg" },
                    { new Guid("801e2141-e88e-4483-a468-2431d69d365c"), new Guid("39875906-7ed0-4247-ae0a-75d85ba3cb88"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3052), "product-2-720x480.jpg" },
                    { new Guid("8019d4d5-a6f1-4a00-98bf-4d5e3a2610cf"), new Guid("39875906-7ed0-4247-ae0a-75d85ba3cb88"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3049), "product-1-720x480.jpg" },
                    { new Guid("7e1b1c87-b7a8-4d59-b1b6-84467f4b1040"), new Guid("6c893c4b-8cc8-4ca6-81cf-61f7816b5eef"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2993), "product-6-720x480.jpg" },
                    { new Guid("942f44fe-8846-4b50-9750-e8c8be72e556"), new Guid("9062304b-8027-48e0-a74c-f234ec11ef50"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2671), "product-4-720x480.jpg" },
                    { new Guid("6ab532a7-01c2-4eb1-8e91-4311072ef710"), new Guid("6c893c4b-8cc8-4ca6-81cf-61f7816b5eef"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2991), "product-5-720x480.jpg" },
                    { new Guid("9fa19b69-a3d3-4022-8c38-0f7a8a08cac4"), new Guid("6c893c4b-8cc8-4ca6-81cf-61f7816b5eef"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2985), "product-3-720x480.jpg" },
                    { new Guid("a264ee98-f5da-483a-aba3-44f55fc26201"), new Guid("6c893c4b-8cc8-4ca6-81cf-61f7816b5eef"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2982), "product-2-720x480.jpg" },
                    { new Guid("f5feaa11-3dca-4864-8081-819c0bbf4854"), new Guid("6c893c4b-8cc8-4ca6-81cf-61f7816b5eef"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2980), "product-1-720x480.jpg" },
                    { new Guid("e5688702-f321-4e0d-bfcf-50c542158992"), new Guid("48cd664d-9aeb-42d1-979c-fcaf203fe4d3"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2925), "product-6-720x480.jpg" },
                    { new Guid("526ec58b-9bc7-4aa5-902c-c149a1a84e50"), new Guid("48cd664d-9aeb-42d1-979c-fcaf203fe4d3"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2923), "product-5-720x480.jpg" },
                    { new Guid("58252165-84e9-4c6e-97f9-04027d6c8ba6"), new Guid("48cd664d-9aeb-42d1-979c-fcaf203fe4d3"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2918), "product-4-720x480.jpg" },
                    { new Guid("bbfe8830-c941-44be-87ec-34bb0cf45982"), new Guid("6c893c4b-8cc8-4ca6-81cf-61f7816b5eef"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2989), "product-4-720x480.jpg" },
                    { new Guid("75340cbc-cbfc-4032-9618-07de21495ddd"), new Guid("39875906-7ed0-4247-ae0a-75d85ba3cb88"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3062), "product-6-720x480.jpg" },
                    { new Guid("8be21eea-d1f5-408b-8cc8-a919834c54a6"), new Guid("9062304b-8027-48e0-a74c-f234ec11ef50"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2669), "product-3-720x480.jpg" },
                    { new Guid("1df10691-26f4-415d-87c4-4de6cd3acf99"), new Guid("9062304b-8027-48e0-a74c-f234ec11ef50"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2665), "product-1-720x480.jpg" },
                    { new Guid("e6fbcc80-3341-4c7a-8790-19c398ae7126"), new Guid("52d89f92-4402-4f50-882c-2282ab9aca1c"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2171), "product-6-720x480.jpg" },
                    { new Guid("fea56ec3-0cab-46d2-8341-5acd5df051ce"), new Guid("107441f4-8e6e-451f-8ad3-cff2c7a87d76"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2226), "product-1-720x480.jpg" },
                    { new Guid("39fc6214-4abf-4890-b1b8-8b82cc5e536c"), new Guid("107441f4-8e6e-451f-8ad3-cff2c7a87d76"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2229), "product-2-720x480.jpg" },
                    { new Guid("ef86645b-2daa-48fc-9d27-220c6fd7ebaf"), new Guid("107441f4-8e6e-451f-8ad3-cff2c7a87d76"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2231), "product-3-720x480.jpg" },
                    { new Guid("8a658508-b5b3-4d04-9447-1cff2ee58f4d"), new Guid("107441f4-8e6e-451f-8ad3-cff2c7a87d76"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2233), "product-4-720x480.jpg" },
                    { new Guid("286d4ca3-252f-4aed-948e-c426a509a6b7"), new Guid("107441f4-8e6e-451f-8ad3-cff2c7a87d76"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2237), "product-5-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("7bc24dc8-d44d-434c-9555-cf0fe4dc96e4"), new Guid("107441f4-8e6e-451f-8ad3-cff2c7a87d76"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2239), "product-6-720x480.jpg" },
                    { new Guid("366fa371-c69f-42c7-ad5f-eda7e3a82fda"), new Guid("caaff101-5f6d-4790-934b-8c1857d47b6a"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2295), "product-1-720x480.jpg" },
                    { new Guid("05a0b6ff-55bf-462d-889e-cfaa6e4cdd49"), new Guid("caaff101-5f6d-4790-934b-8c1857d47b6a"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2298), "product-2-720x480.jpg" },
                    { new Guid("b4a1f6f4-1923-4e69-afbd-8cddcbd5bd77"), new Guid("caaff101-5f6d-4790-934b-8c1857d47b6a"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2300), "product-3-720x480.jpg" },
                    { new Guid("eb560129-65d5-4839-bede-3162cbbfbad1"), new Guid("caaff101-5f6d-4790-934b-8c1857d47b6a"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2304), "product-4-720x480.jpg" },
                    { new Guid("de50652b-00c8-471f-9922-55b52a7df04c"), new Guid("caaff101-5f6d-4790-934b-8c1857d47b6a"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2306), "product-5-720x480.jpg" },
                    { new Guid("a6e0fffb-2e2a-47e4-a754-83f6d6a5da3a"), new Guid("caaff101-5f6d-4790-934b-8c1857d47b6a"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2308), "product-6-720x480.jpg" },
                    { new Guid("3775ee57-1fd2-458e-b8b6-2c6dcea2ffd8"), new Guid("4eb1c157-3906-4d7b-b7a0-03bde35fb548"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2458), "product-1-720x480.jpg" },
                    { new Guid("c3321c7e-c8f8-417f-a206-4b3926b5ab43"), new Guid("4eb1c157-3906-4d7b-b7a0-03bde35fb548"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2460), "product-2-720x480.jpg" },
                    { new Guid("161a10a0-3b5f-4207-9a5b-11c804cf3a89"), new Guid("4eb1c157-3906-4d7b-b7a0-03bde35fb548"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2466), "product-3-720x480.jpg" },
                    { new Guid("47df4a17-e11e-492e-a14b-2ec040f88a46"), new Guid("4eb1c157-3906-4d7b-b7a0-03bde35fb548"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2468), "product-4-720x480.jpg" },
                    { new Guid("63b56f8f-e57b-4aeb-bafb-8345ffc88704"), new Guid("b9ccad2d-0544-471f-bee8-0b502041c510"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2607), "product-6-720x480.jpg" },
                    { new Guid("9f21bd51-4ba4-46d5-9161-811e43db79c4"), new Guid("b9ccad2d-0544-471f-bee8-0b502041c510"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2605), "product-5-720x480.jpg" },
                    { new Guid("0b0b2821-e029-4aca-926f-f9532b1486c6"), new Guid("b9ccad2d-0544-471f-bee8-0b502041c510"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2603), "product-4-720x480.jpg" },
                    { new Guid("a3a9e0bc-6e4c-4acf-ac54-21f1dc9efa46"), new Guid("b9ccad2d-0544-471f-bee8-0b502041c510"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2601), "product-3-720x480.jpg" },
                    { new Guid("ad8639bc-0324-4d2f-8617-5d9f25eb3af8"), new Guid("b9ccad2d-0544-471f-bee8-0b502041c510"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2599), "product-2-720x480.jpg" },
                    { new Guid("00e8803d-bf98-4731-98db-b99492e308b7"), new Guid("b9ccad2d-0544-471f-bee8-0b502041c510"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2596), "product-1-720x480.jpg" },
                    { new Guid("c05034fc-d0d0-42e9-b42b-38c68a3fe233"), new Guid("9062304b-8027-48e0-a74c-f234ec11ef50"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2667), "product-2-720x480.jpg" },
                    { new Guid("0be1d020-e910-4d66-b16a-300f1ea85747"), new Guid("f6c98e00-6f71-4e5c-a366-9a696907e262"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2539), "product-6-720x480.jpg" },
                    { new Guid("05c63e7f-ab43-4b93-b289-638fef3a432e"), new Guid("f6c98e00-6f71-4e5c-a366-9a696907e262"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2535), "product-4-720x480.jpg" },
                    { new Guid("92035af5-74f4-4799-9703-77021de9cc0a"), new Guid("f6c98e00-6f71-4e5c-a366-9a696907e262"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2533), "product-3-720x480.jpg" },
                    { new Guid("ff231f9a-fe54-4d5f-907e-1ef5467f1076"), new Guid("f6c98e00-6f71-4e5c-a366-9a696907e262"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2531), "product-2-720x480.jpg" },
                    { new Guid("b376a45c-bf2f-4fba-b4f6-71dcc7909e58"), new Guid("f6c98e00-6f71-4e5c-a366-9a696907e262"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2527), "product-1-720x480.jpg" },
                    { new Guid("a6cc7da0-4988-44be-a742-4909492c6684"), new Guid("4eb1c157-3906-4d7b-b7a0-03bde35fb548"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2472), "product-6-720x480.jpg" },
                    { new Guid("7d3968ae-9b03-4bbf-9cf5-24c7e5f710fb"), new Guid("4eb1c157-3906-4d7b-b7a0-03bde35fb548"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2470), "product-5-720x480.jpg" },
                    { new Guid("72340d9c-57c6-4829-896f-f5d20fb809a4"), new Guid("f6c98e00-6f71-4e5c-a366-9a696907e262"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2538), "product-5-720x480.jpg" },
                    { new Guid("bd033dd8-3a46-4d6a-99a3-f71802ffb3ea"), new Guid("786bef22-7260-4b9f-8142-206a9f436e28"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3148), "product-1-720x480.jpg" },
                    { new Guid("2ad95d2d-42f6-4ba3-bdbf-8757c3154028"), new Guid("786bef22-7260-4b9f-8142-206a9f436e28"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3153), "product-2-720x480.jpg" },
                    { new Guid("19dc28f3-696d-4dc0-87db-46bb99400dbc"), new Guid("786bef22-7260-4b9f-8142-206a9f436e28"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3155), "product-3-720x480.jpg" },
                    { new Guid("4eb6c875-6afc-497b-a07a-338e008fe135"), new Guid("da0f0c0f-0e71-4096-be69-4a24b2fe2782"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3605), "product-4-720x480.jpg" },
                    { new Guid("6d7a1dbb-4890-4ac9-9b78-996b72a09cac"), new Guid("da0f0c0f-0e71-4096-be69-4a24b2fe2782"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3607), "product-5-720x480.jpg" },
                    { new Guid("659a1cbe-e007-46cc-8f07-71b0b78fb1c6"), new Guid("da0f0c0f-0e71-4096-be69-4a24b2fe2782"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3609), "product-6-720x480.jpg" },
                    { new Guid("53eb91e1-1829-464e-aa43-bfc52145876f"), new Guid("8918bb29-ef01-4995-b971-66dadc617a83"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3666), "product-1-720x480.jpg" },
                    { new Guid("9f0b50c8-a036-4d29-b74f-4500a0fb8bd1"), new Guid("8918bb29-ef01-4995-b971-66dadc617a83"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3668), "product-2-720x480.jpg" },
                    { new Guid("1a0f78ac-1891-4ab0-a95b-25ca6e131bf8"), new Guid("8918bb29-ef01-4995-b971-66dadc617a83"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3672), "product-3-720x480.jpg" },
                    { new Guid("3f12a342-cf73-4211-9e1e-d8e41fe9c3f0"), new Guid("8918bb29-ef01-4995-b971-66dadc617a83"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3674), "product-4-720x480.jpg" },
                    { new Guid("81336165-cd1e-43c5-8a0c-99d866fcd315"), new Guid("8918bb29-ef01-4995-b971-66dadc617a83"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3676), "product-5-720x480.jpg" },
                    { new Guid("aba87beb-2d14-41bc-947f-41b8bda6fef7"), new Guid("8918bb29-ef01-4995-b971-66dadc617a83"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3679), "product-6-720x480.jpg" },
                    { new Guid("57b9f613-d8ee-40e4-84be-eaa1da3ba8e1"), new Guid("45bf8f63-2b83-4749-b696-dca0e3ef01a4"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3772), "product-1-720x480.jpg" },
                    { new Guid("5e668eaa-9847-4f8c-8eaa-2a8bd6f5d824"), new Guid("45bf8f63-2b83-4749-b696-dca0e3ef01a4"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3777), "product-2-720x480.jpg" },
                    { new Guid("574337f0-8411-4fb0-8f0d-474dfe855d28"), new Guid("45bf8f63-2b83-4749-b696-dca0e3ef01a4"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3779), "product-3-720x480.jpg" },
                    { new Guid("3b18a985-657d-44a3-985f-507793766068"), new Guid("45bf8f63-2b83-4749-b696-dca0e3ef01a4"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3781), "product-4-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("9fe63e57-0ed2-43d4-8aa5-0d605c435b25"), new Guid("45bf8f63-2b83-4749-b696-dca0e3ef01a4"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3783), "product-5-720x480.jpg" },
                    { new Guid("76d3b863-2bd4-452f-aaf8-bf90b06b7e58"), new Guid("45bf8f63-2b83-4749-b696-dca0e3ef01a4"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3785), "product-6-720x480.jpg" },
                    { new Guid("c048b5b8-0e79-4dda-a753-d788713101df"), new Guid("ae5903e4-2b40-4138-a110-1b6b00c78e87"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3844), "product-1-720x480.jpg" },
                    { new Guid("e20a11ae-c86e-4dce-aacc-1ff4aee777c3"), new Guid("ae5903e4-2b40-4138-a110-1b6b00c78e87"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3846), "product-2-720x480.jpg" },
                    { new Guid("317e3dd6-4578-4629-8f6c-aa8f9e9216e5"), new Guid("664c678f-ecbd-41da-adf8-30f14ce67da1"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3988), "product-4-720x480.jpg" },
                    { new Guid("36bb8f25-7043-49c3-b873-cdd7ec205567"), new Guid("664c678f-ecbd-41da-adf8-30f14ce67da1"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3986), "product-3-720x480.jpg" },
                    { new Guid("2504c612-c020-4ce1-8aa5-eeef56740578"), new Guid("664c678f-ecbd-41da-adf8-30f14ce67da1"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3984), "product-2-720x480.jpg" },
                    { new Guid("db089b33-9f21-432e-9658-454cd9252d4f"), new Guid("664c678f-ecbd-41da-adf8-30f14ce67da1"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3981), "product-1-720x480.jpg" },
                    { new Guid("3402bb38-26b8-4198-a27c-03b46bd63d55"), new Guid("68797a68-681d-426f-86c1-4f87ee77c16d"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3923), "product-6-720x480.jpg" },
                    { new Guid("68e2f851-3a95-4455-9c39-1aab67630ab7"), new Guid("68797a68-681d-426f-86c1-4f87ee77c16d"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3921), "product-5-720x480.jpg" },
                    { new Guid("8b4e4eaa-b5d0-475a-9175-a3e0271fe43f"), new Guid("da0f0c0f-0e71-4096-be69-4a24b2fe2782"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3601), "product-3-720x480.jpg" },
                    { new Guid("06df65a6-7ec0-4374-b4ad-d64f14802346"), new Guid("68797a68-681d-426f-86c1-4f87ee77c16d"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3919), "product-4-720x480.jpg" },
                    { new Guid("9c2c4ae6-790d-4dd6-8b7e-871c1dc8317c"), new Guid("68797a68-681d-426f-86c1-4f87ee77c16d"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3915), "product-2-720x480.jpg" },
                    { new Guid("2691dba4-e3cf-4c8f-9d45-a2557815d2f1"), new Guid("68797a68-681d-426f-86c1-4f87ee77c16d"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3912), "product-1-720x480.jpg" },
                    { new Guid("f690c208-bcc6-4442-b723-c565736e8cdb"), new Guid("ae5903e4-2b40-4138-a110-1b6b00c78e87"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3854), "product-6-720x480.jpg" },
                    { new Guid("ac3bfc18-07e6-4a8f-9d62-48053f60cf31"), new Guid("ae5903e4-2b40-4138-a110-1b6b00c78e87"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3852), "product-5-720x480.jpg" },
                    { new Guid("4faf91e7-54c9-4773-8dba-66c951f0f5ab"), new Guid("ae5903e4-2b40-4138-a110-1b6b00c78e87"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3850), "product-4-720x480.jpg" },
                    { new Guid("ea392093-b859-4b26-b329-6e08fc88d370"), new Guid("ae5903e4-2b40-4138-a110-1b6b00c78e87"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3848), "product-3-720x480.jpg" },
                    { new Guid("9418493f-d672-4398-9c86-b92be9c125ec"), new Guid("68797a68-681d-426f-86c1-4f87ee77c16d"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3917), "product-3-720x480.jpg" },
                    { new Guid("2f17bbb3-cab1-4416-80b9-95161c50edf9"), new Guid("da0f0c0f-0e71-4096-be69-4a24b2fe2782"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3599), "product-2-720x480.jpg" },
                    { new Guid("5d8910f2-e21a-4927-adb0-0a8d8e1ce489"), new Guid("da0f0c0f-0e71-4096-be69-4a24b2fe2782"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3596), "product-1-720x480.jpg" },
                    { new Guid("b58538c4-be82-4653-8479-2162360c7566"), new Guid("2ee8fd4e-a529-4b33-9b0b-f8a73463f7d0"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3541), "product-6-720x480.jpg" },
                    { new Guid("125c34dd-bb3a-4472-b9d1-c7a7e87a78ab"), new Guid("007bf198-dade-475b-a699-8038bd78adca"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3297), "product-5-720x480.jpg" },
                    { new Guid("2c1ee679-e4d6-4718-81ed-6e60af50434e"), new Guid("007bf198-dade-475b-a699-8038bd78adca"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3295), "product-4-720x480.jpg" },
                    { new Guid("cd957abd-cb7a-4370-bb66-cb3dce87b04a"), new Guid("007bf198-dade-475b-a699-8038bd78adca"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3293), "product-3-720x480.jpg" },
                    { new Guid("0afd9552-a451-424a-853d-2e033e9c910d"), new Guid("007bf198-dade-475b-a699-8038bd78adca"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3290), "product-2-720x480.jpg" },
                    { new Guid("d13bb05e-8f51-4f96-b11e-4bf81e88382d"), new Guid("007bf198-dade-475b-a699-8038bd78adca"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3288), "product-1-720x480.jpg" },
                    { new Guid("67926fe9-cc56-4612-8594-1ecff1b82b1e"), new Guid("150e4c40-e41b-4c4c-bab0-be10f9efada3"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3230), "product-6-720x480.jpg" },
                    { new Guid("5ebc5370-3ba8-4096-a9ea-57d836996bdf"), new Guid("007bf198-dade-475b-a699-8038bd78adca"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3299), "product-6-720x480.jpg" },
                    { new Guid("80328015-04d0-4338-bb10-02bbcd30bb8e"), new Guid("150e4c40-e41b-4c4c-bab0-be10f9efada3"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3228), "product-5-720x480.jpg" },
                    { new Guid("567055df-5deb-4822-85da-0accfc1c1ea7"), new Guid("150e4c40-e41b-4c4c-bab0-be10f9efada3"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3224), "product-3-720x480.jpg" },
                    { new Guid("421b36ef-6924-4da1-af30-509122e8937a"), new Guid("150e4c40-e41b-4c4c-bab0-be10f9efada3"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3221), "product-2-720x480.jpg" },
                    { new Guid("7a0c6448-30d3-4336-a04f-dc902c75a354"), new Guid("150e4c40-e41b-4c4c-bab0-be10f9efada3"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3219), "product-1-720x480.jpg" },
                    { new Guid("0f5f73ae-00b0-45a9-a059-885141a12ba8"), new Guid("786bef22-7260-4b9f-8142-206a9f436e28"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3161), "product-6-720x480.jpg" },
                    { new Guid("80b96678-ba5b-4c4b-ad86-38b20e2223ae"), new Guid("786bef22-7260-4b9f-8142-206a9f436e28"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3159), "product-5-720x480.jpg" },
                    { new Guid("c2a01681-85a4-48d2-b8d3-3776d86e8d90"), new Guid("786bef22-7260-4b9f-8142-206a9f436e28"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3157), "product-4-720x480.jpg" },
                    { new Guid("0dec2cae-1d72-4c6e-8aba-43bdccf0eb8b"), new Guid("150e4c40-e41b-4c4c-bab0-be10f9efada3"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3226), "product-4-720x480.jpg" },
                    { new Guid("a8b31956-a986-440d-ae46-1c6ccdcb3d1d"), new Guid("52d89f92-4402-4f50-882c-2282ab9aca1c"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2167), "product-5-720x480.jpg" },
                    { new Guid("7d10e2bd-1888-4d19-81ec-8bca8d6eb610"), new Guid("462e4beb-ac7a-44cd-b076-b04f735cc38f"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3357), "product-1-720x480.jpg" },
                    { new Guid("cde5b024-9025-4038-a292-58826c61767c"), new Guid("462e4beb-ac7a-44cd-b076-b04f735cc38f"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3362), "product-3-720x480.jpg" },
                    { new Guid("f5f5c004-eb1d-46a8-bf18-bbfc00fd7881"), new Guid("2ee8fd4e-a529-4b33-9b0b-f8a73463f7d0"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3539), "product-5-720x480.jpg" },
                    { new Guid("4c00d5d3-41ba-465c-a14e-c8fe960c81f8"), new Guid("2ee8fd4e-a529-4b33-9b0b-f8a73463f7d0"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3534), "product-4-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("0e55c852-2113-49b8-b6ea-df6b7d2c7906"), new Guid("2ee8fd4e-a529-4b33-9b0b-f8a73463f7d0"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3532), "product-3-720x480.jpg" },
                    { new Guid("bc6e3372-bce1-4abc-bac2-5006a7d59506"), new Guid("2ee8fd4e-a529-4b33-9b0b-f8a73463f7d0"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3530), "product-2-720x480.jpg" },
                    { new Guid("7e270521-a5af-40d0-90ae-cb5b617db187"), new Guid("2ee8fd4e-a529-4b33-9b0b-f8a73463f7d0"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3528), "product-1-720x480.jpg" },
                    { new Guid("8670c53e-7a18-4316-8490-5cdf3ce5aa58"), new Guid("4d43cfb2-8f99-4aab-a6ed-ca2643593d66"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3470), "product-6-720x480.jpg" },
                    { new Guid("b85446cd-f73c-41fb-a64a-0fcbae6b9c4b"), new Guid("462e4beb-ac7a-44cd-b076-b04f735cc38f"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3360), "product-2-720x480.jpg" },
                    { new Guid("e956b9bd-57c4-4d70-81ac-d8f95e0847d9"), new Guid("4d43cfb2-8f99-4aab-a6ed-ca2643593d66"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3465), "product-5-720x480.jpg" },
                    { new Guid("6274205c-f8ca-4621-8dc5-2b8bd47e9976"), new Guid("4d43cfb2-8f99-4aab-a6ed-ca2643593d66"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3430), "product-3-720x480.jpg" },
                    { new Guid("9fa81afb-8c68-4d9c-b269-4ed830cd55cd"), new Guid("4d43cfb2-8f99-4aab-a6ed-ca2643593d66"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3428), "product-2-720x480.jpg" },
                    { new Guid("323f9463-8246-46c4-8356-846e104b9e2c"), new Guid("4d43cfb2-8f99-4aab-a6ed-ca2643593d66"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3425), "product-1-720x480.jpg" },
                    { new Guid("5234f603-4428-439f-afc2-29351ad1268e"), new Guid("462e4beb-ac7a-44cd-b076-b04f735cc38f"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3368), "product-6-720x480.jpg" },
                    { new Guid("d6146d31-8b15-43de-b4cf-77c0a0e4ea2b"), new Guid("462e4beb-ac7a-44cd-b076-b04f735cc38f"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3366), "product-5-720x480.jpg" },
                    { new Guid("6fcfc7ad-9953-4303-a5be-90e3e7d955b9"), new Guid("462e4beb-ac7a-44cd-b076-b04f735cc38f"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3364), "product-4-720x480.jpg" },
                    { new Guid("bb7bd6da-efd2-4957-8f92-e50655c0911a"), new Guid("4d43cfb2-8f99-4aab-a6ed-ca2643593d66"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3432), "product-4-720x480.jpg" },
                    { new Guid("be2b6e54-0632-4722-b138-e1dd15d343fa"), new Guid("52d89f92-4402-4f50-882c-2282ab9aca1c"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2165), "product-4-720x480.jpg" },
                    { new Guid("c4f7bf4f-b018-446b-92fc-0b1dfced8408"), new Guid("52d89f92-4402-4f50-882c-2282ab9aca1c"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2163), "product-3-720x480.jpg" },
                    { new Guid("8eeede4b-9b1a-4142-8345-64b16ad0394d"), new Guid("52d89f92-4402-4f50-882c-2282ab9aca1c"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2161), "product-2-720x480.jpg" },
                    { new Guid("f72a7788-e519-4f6e-bf76-6e20afa96de4"), new Guid("7e514a55-34c6-4a30-983a-a20cec6ba392"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(835), "product-2-720x480.jpg" },
                    { new Guid("136c440a-36bb-43f2-87de-299310171e15"), new Guid("7e514a55-34c6-4a30-983a-a20cec6ba392"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(837), "product-3-720x480.jpg" },
                    { new Guid("431c968b-8093-4d08-b784-d1a4caa0e130"), new Guid("7e514a55-34c6-4a30-983a-a20cec6ba392"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(839), "product-4-720x480.jpg" },
                    { new Guid("154e1658-f46d-4193-80f6-0f203ddfac1d"), new Guid("7e514a55-34c6-4a30-983a-a20cec6ba392"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(841), "product-5-720x480.jpg" },
                    { new Guid("03ccdb3d-4c9f-418e-9cc1-18f1f5c1ee9d"), new Guid("7e514a55-34c6-4a30-983a-a20cec6ba392"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(843), "product-6-720x480.jpg" },
                    { new Guid("3e528010-f38b-4375-881d-0d32f1c04982"), new Guid("35e04e93-5e16-422f-96ee-f89e3edc705c"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(903), "product-1-720x480.jpg" },
                    { new Guid("81f73e34-9bb4-44d1-8113-c228a8ef55a9"), new Guid("35e04e93-5e16-422f-96ee-f89e3edc705c"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(906), "product-2-720x480.jpg" },
                    { new Guid("a0f93edc-e442-4f21-a10c-e97565e30a53"), new Guid("35e04e93-5e16-422f-96ee-f89e3edc705c"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(908), "product-3-720x480.jpg" },
                    { new Guid("80ed2c86-6c09-4a91-8b64-2d09e995d124"), new Guid("35e04e93-5e16-422f-96ee-f89e3edc705c"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(910), "product-4-720x480.jpg" },
                    { new Guid("29840ee0-67ba-4110-8076-1931ef198a77"), new Guid("35e04e93-5e16-422f-96ee-f89e3edc705c"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(912), "product-5-720x480.jpg" },
                    { new Guid("bbcdf4d4-3ea8-461e-aa04-628e296fc56d"), new Guid("35e04e93-5e16-422f-96ee-f89e3edc705c"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(916), "product-6-720x480.jpg" },
                    { new Guid("9a00a7e3-b224-44ee-8581-4fcd79a9ea44"), new Guid("483f66f4-bd6f-4b8e-98e9-68d90ecd9080"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(976), "product-1-720x480.jpg" },
                    { new Guid("24952afa-e592-4556-a5e2-e9a9a194a3ee"), new Guid("483f66f4-bd6f-4b8e-98e9-68d90ecd9080"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(978), "product-2-720x480.jpg" },
                    { new Guid("adbb82d3-9403-477f-bf5f-70ea6d923ef0"), new Guid("483f66f4-bd6f-4b8e-98e9-68d90ecd9080"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(980), "product-3-720x480.jpg" },
                    { new Guid("4f508255-7858-4f86-b86f-b817d1aac766"), new Guid("483f66f4-bd6f-4b8e-98e9-68d90ecd9080"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(982), "product-4-720x480.jpg" },
                    { new Guid("0ab49366-f2ef-4ed1-9e3d-a90be19a8c81"), new Guid("483f66f4-bd6f-4b8e-98e9-68d90ecd9080"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(986), "product-5-720x480.jpg" },
                    { new Guid("15ea1dba-9c03-47d5-b28c-bb883c4dfe51"), new Guid("483f66f4-bd6f-4b8e-98e9-68d90ecd9080"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(989), "product-6-720x480.jpg" },
                    { new Guid("2c29a23d-2e8b-40a8-a481-838932c8ad1d"), new Guid("0f1bcb56-c33f-4514-bc00-877910b4201b"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1224), "product-2-720x480.jpg" },
                    { new Guid("ac970641-aa6c-4621-a9ff-ba83a66b9300"), new Guid("0f1bcb56-c33f-4514-bc00-877910b4201b"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1219), "product-1-720x480.jpg" },
                    { new Guid("a8c1b645-4dee-4e42-9ca2-22fbdc4868fd"), new Guid("1360526e-c8c1-4262-8dad-be6a9afb3735"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1160), "product-6-720x480.jpg" },
                    { new Guid("fe959ea3-b53c-4254-ba0d-36393933b2dc"), new Guid("1360526e-c8c1-4262-8dad-be6a9afb3735"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1158), "product-5-720x480.jpg" },
                    { new Guid("eda98767-1fd9-446f-a849-329964f38cda"), new Guid("1360526e-c8c1-4262-8dad-be6a9afb3735"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1156), "product-4-720x480.jpg" },
                    { new Guid("033c2f28-f9c3-4fce-85e5-458cfb1449b7"), new Guid("1360526e-c8c1-4262-8dad-be6a9afb3735"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1154), "product-3-720x480.jpg" },
                    { new Guid("40009a0e-b84a-4644-8452-6b7761b1f9ad"), new Guid("7e514a55-34c6-4a30-983a-a20cec6ba392"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(833), "product-1-720x480.jpg" },
                    { new Guid("78b5669d-69f0-45a2-9c12-76f424565bcb"), new Guid("1360526e-c8c1-4262-8dad-be6a9afb3735"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1150), "product-2-720x480.jpg" },
                    { new Guid("9fc348c8-94e0-4c02-9800-e63f960f7095"), new Guid("349c25b3-4e5f-4b41-b51d-0f963e2fdc48"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1092), "product-6-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("54c45ebb-4736-48a3-8b8b-6b45890c1444"), new Guid("349c25b3-4e5f-4b41-b51d-0f963e2fdc48"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1090), "product-5-720x480.jpg" },
                    { new Guid("b5afe1dc-e28b-49c0-bd6e-91b646efb2b5"), new Guid("349c25b3-4e5f-4b41-b51d-0f963e2fdc48"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1088), "product-4-720x480.jpg" },
                    { new Guid("dc473d24-f254-4188-a382-7bca7e747ea5"), new Guid("349c25b3-4e5f-4b41-b51d-0f963e2fdc48"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1083), "product-3-720x480.jpg" },
                    { new Guid("5de70751-9f8b-4646-b9a8-748babc07c55"), new Guid("349c25b3-4e5f-4b41-b51d-0f963e2fdc48"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1081), "product-2-720x480.jpg" },
                    { new Guid("e3c2d619-650a-475d-92de-5c80a6b4fd94"), new Guid("349c25b3-4e5f-4b41-b51d-0f963e2fdc48"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1079), "product-1-720x480.jpg" },
                    { new Guid("0302475c-6f68-4433-8d8e-813baa584c7f"), new Guid("1360526e-c8c1-4262-8dad-be6a9afb3735"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1148), "product-1-720x480.jpg" },
                    { new Guid("d8790905-a696-431e-ba9b-8dad51edef77"), new Guid("cacb0843-0f25-447b-bfb4-7e005eff249b"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(771), "product-6-720x480.jpg" },
                    { new Guid("bc6fd334-7362-48d8-a44a-319eeef675d3"), new Guid("cacb0843-0f25-447b-bfb4-7e005eff249b"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(769), "product-5-720x480.jpg" },
                    { new Guid("a35a38f4-db94-43b3-a7f9-1c82b84769c8"), new Guid("cacb0843-0f25-447b-bfb4-7e005eff249b"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(767), "product-4-720x480.jpg" },
                    { new Guid("e99ee130-8995-44be-aded-2e7d02d20b3c"), new Guid("1c7fb64e-e778-4a24-a978-b936748f7f4a"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(495), "product-3-720x480.jpg" },
                    { new Guid("10dbfc07-fc5d-4dc3-8b29-dc7057eeeb47"), new Guid("1c7fb64e-e778-4a24-a978-b936748f7f4a"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(490), "product-2-720x480.jpg" },
                    { new Guid("1785d792-ad29-4ce4-9bc7-e44e23815d0d"), new Guid("1c7fb64e-e778-4a24-a978-b936748f7f4a"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(488), "product-1-720x480.jpg" },
                    { new Guid("79ab3d74-2aaa-443f-a9e0-a0cacabe67e6"), new Guid("2a087e01-c71c-422c-8557-216575e11a68"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(418), "product-6-720x480.jpg" },
                    { new Guid("f0b9b9a5-c4e3-42dd-9059-31181aa0de3a"), new Guid("2a087e01-c71c-422c-8557-216575e11a68"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(416), "product-5-720x480.jpg" },
                    { new Guid("039620b2-d39f-4383-a9fd-b59eef05b2d9"), new Guid("2a087e01-c71c-422c-8557-216575e11a68"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(414), "product-4-720x480.jpg" },
                    { new Guid("00addb7d-c6d2-43c5-86c8-e5a7d278e7ca"), new Guid("1c7fb64e-e778-4a24-a978-b936748f7f4a"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(497), "product-4-720x480.jpg" },
                    { new Guid("9cecb782-064d-4ac7-b588-8623ef2ae7ab"), new Guid("2a087e01-c71c-422c-8557-216575e11a68"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(407), "product-3-720x480.jpg" },
                    { new Guid("ed1fb5f7-1992-4c1b-a405-cf28a66f8da7"), new Guid("2a087e01-c71c-422c-8557-216575e11a68"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(402), "product-1-720x480.jpg" },
                    { new Guid("2a792430-7f36-4cd0-93b2-babc262568be"), new Guid("27752cd9-cc74-4999-a9b6-d1bc0caef6dd"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(5), "product-6-720x480.jpg" },
                    { new Guid("487c691f-2348-40a0-971d-0a6de4acbaf6"), new Guid("27752cd9-cc74-4999-a9b6-d1bc0caef6dd"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2), "product-5-720x480.jpg" },
                    { new Guid("a0ae6ad9-d878-4bbc-a6e2-4ec55d5c5d76"), new Guid("27752cd9-cc74-4999-a9b6-d1bc0caef6dd"), new DateTime(2021, 6, 7, 21, 21, 26, 50, DateTimeKind.Local).AddTicks(9987), "product-4-720x480.jpg" },
                    { new Guid("52a08522-1d3f-45e6-bf47-a52f22f853bd"), new Guid("27752cd9-cc74-4999-a9b6-d1bc0caef6dd"), new DateTime(2021, 6, 7, 21, 21, 26, 50, DateTimeKind.Local).AddTicks(9985), "product-3-720x480.jpg" },
                    { new Guid("bfe9c14d-bd00-4018-9f53-b6e08c855e92"), new Guid("27752cd9-cc74-4999-a9b6-d1bc0caef6dd"), new DateTime(2021, 6, 7, 21, 21, 26, 50, DateTimeKind.Local).AddTicks(9978), "product-2-720x480.jpg" },
                    { new Guid("96f5fb83-c30f-4833-bcc2-14c675bf4b2d"), new Guid("2a087e01-c71c-422c-8557-216575e11a68"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(405), "product-2-720x480.jpg" },
                    { new Guid("7323af8f-645f-4d92-ad21-a1b501fb5c9b"), new Guid("0f1bcb56-c33f-4514-bc00-877910b4201b"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1226), "product-3-720x480.jpg" },
                    { new Guid("372d6bdc-dfe3-4545-b52f-f54ed298301b"), new Guid("1c7fb64e-e778-4a24-a978-b936748f7f4a"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(500), "product-5-720x480.jpg" },
                    { new Guid("cad7ad96-7c20-49f8-8ee1-c218d37c89ef"), new Guid("8b8f6066-a6bf-4940-9189-22c9677058dd"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(565), "product-1-720x480.jpg" },
                    { new Guid("6d4a3380-003a-45b0-b69d-6b35af433f8a"), new Guid("cacb0843-0f25-447b-bfb4-7e005eff249b"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(765), "product-3-720x480.jpg" },
                    { new Guid("751219cb-737a-4ca9-a7ad-7b9920e96bf0"), new Guid("cacb0843-0f25-447b-bfb4-7e005eff249b"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(763), "product-2-720x480.jpg" },
                    { new Guid("4d2b77b6-442a-4c69-8ce9-af3a9f1d25b9"), new Guid("cacb0843-0f25-447b-bfb4-7e005eff249b"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(760), "product-1-720x480.jpg" },
                    { new Guid("6ff12990-e70b-4d16-8666-2d6cd6f83760"), new Guid("c73639d0-a5b0-498c-be36-532b4da2a44d"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(652), "product-6-720x480.jpg" },
                    { new Guid("04fca644-0cec-429e-8247-fec5a8b335b7"), new Guid("c73639d0-a5b0-498c-be36-532b4da2a44d"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(650), "product-5-720x480.jpg" },
                    { new Guid("899aa7c3-4708-45e8-ac0f-24243c9dbdcd"), new Guid("c73639d0-a5b0-498c-be36-532b4da2a44d"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(648), "product-4-720x480.jpg" },
                    { new Guid("de050897-cfa8-4af8-8a48-077ab5bff329"), new Guid("1c7fb64e-e778-4a24-a978-b936748f7f4a"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(502), "product-6-720x480.jpg" },
                    { new Guid("b4c0cc87-21b7-4591-8fa8-c6428cf3985e"), new Guid("c73639d0-a5b0-498c-be36-532b4da2a44d"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(646), "product-3-720x480.jpg" },
                    { new Guid("b2518240-7847-46c2-a586-31ff4b9c30b8"), new Guid("c73639d0-a5b0-498c-be36-532b4da2a44d"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(642), "product-1-720x480.jpg" },
                    { new Guid("276d86ca-2bcd-49ff-96c2-73c789368663"), new Guid("8b8f6066-a6bf-4940-9189-22c9677058dd"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(578), "product-6-720x480.jpg" },
                    { new Guid("8800d9fe-8c7a-4632-b76f-12801bde7079"), new Guid("8b8f6066-a6bf-4940-9189-22c9677058dd"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(576), "product-5-720x480.jpg" },
                    { new Guid("45262300-07f6-4ebb-9b39-4bdf61cba736"), new Guid("8b8f6066-a6bf-4940-9189-22c9677058dd"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(574), "product-4-720x480.jpg" },
                    { new Guid("bc4cf06c-429f-47e2-8066-2bc8e912d9e8"), new Guid("8b8f6066-a6bf-4940-9189-22c9677058dd"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(572), "product-3-720x480.jpg" },
                    { new Guid("4800c693-d9c0-4a1b-8bee-758d9ca8017a"), new Guid("8b8f6066-a6bf-4940-9189-22c9677058dd"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(570), "product-2-720x480.jpg" },
                    { new Guid("79b65b5c-09f1-4906-8bb4-9b61da504032"), new Guid("c73639d0-a5b0-498c-be36-532b4da2a44d"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(644), "product-2-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("90501e37-c8c0-44ec-822d-846cd8ab04d5"), new Guid("664c678f-ecbd-41da-adf8-30f14ce67da1"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3990), "product-5-720x480.jpg" },
                    { new Guid("d8afc321-3cde-4387-8d91-d8c75a576452"), new Guid("0f1bcb56-c33f-4514-bc00-877910b4201b"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1228), "product-4-720x480.jpg" },
                    { new Guid("afc82096-2ca2-46b1-8cbb-22c30ee6446a"), new Guid("0f1bcb56-c33f-4514-bc00-877910b4201b"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1232), "product-6-720x480.jpg" },
                    { new Guid("815c794f-5965-46af-b004-aae163f99bd7"), new Guid("daa5f48e-a58d-459a-aa14-136d75aeaa40"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1775), "product-1-720x480.jpg" },
                    { new Guid("94c57eaa-64eb-48a8-affb-0f44441a9275"), new Guid("daa5f48e-a58d-459a-aa14-136d75aeaa40"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1777), "product-2-720x480.jpg" },
                    { new Guid("560163a2-1278-489c-b405-cc2e6774d0ba"), new Guid("daa5f48e-a58d-459a-aa14-136d75aeaa40"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1782), "product-3-720x480.jpg" },
                    { new Guid("fae7c5b5-b81f-4d2e-a7d5-1785ae6f2c4c"), new Guid("daa5f48e-a58d-459a-aa14-136d75aeaa40"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1784), "product-4-720x480.jpg" },
                    { new Guid("c6cb17cb-f95d-4bd8-b1eb-c17b00fdb3b5"), new Guid("daa5f48e-a58d-459a-aa14-136d75aeaa40"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1786), "product-5-720x480.jpg" },
                    { new Guid("5df04837-c940-47c6-8b83-eec75d39272a"), new Guid("daa5f48e-a58d-459a-aa14-136d75aeaa40"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1788), "product-6-720x480.jpg" },
                    { new Guid("5c64ea33-799e-43a8-86f2-8fa0ca7d9fae"), new Guid("dba617f0-65f5-4a73-938e-8def2620200f"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1844), "product-1-720x480.jpg" },
                    { new Guid("4012f0b9-a4fa-4b71-bdf2-9189b8a9b198"), new Guid("dba617f0-65f5-4a73-938e-8def2620200f"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1849), "product-2-720x480.jpg" },
                    { new Guid("7b3426b6-b9ae-48f5-8f91-5f66a7b181cc"), new Guid("dba617f0-65f5-4a73-938e-8def2620200f"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1851), "product-3-720x480.jpg" },
                    { new Guid("ef5d46b0-f898-4fa4-b070-85fbb4c41c3c"), new Guid("dba617f0-65f5-4a73-938e-8def2620200f"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1853), "product-4-720x480.jpg" },
                    { new Guid("2869e506-646b-492e-87bf-5b925604af5a"), new Guid("dba617f0-65f5-4a73-938e-8def2620200f"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1855), "product-5-720x480.jpg" },
                    { new Guid("48b05702-240a-4bb1-907d-6549fc52e22e"), new Guid("dba617f0-65f5-4a73-938e-8def2620200f"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1857), "product-6-720x480.jpg" },
                    { new Guid("5c118b94-75d4-4b5a-8e8b-80d4de9308bc"), new Guid("17e3c245-7304-46ed-b04b-9e9616201b08"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1915), "product-1-720x480.jpg" },
                    { new Guid("b4ff2301-10a6-46df-b4f2-97010998f2cf"), new Guid("17e3c245-7304-46ed-b04b-9e9616201b08"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1918), "product-2-720x480.jpg" },
                    { new Guid("c094dc16-6133-433d-949c-19e4c52e5cf9"), new Guid("17e3c245-7304-46ed-b04b-9e9616201b08"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1920), "product-3-720x480.jpg" },
                    { new Guid("f5bd6b78-ba59-4337-8cf8-d607c4ffc1b4"), new Guid("17e3c245-7304-46ed-b04b-9e9616201b08"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1922), "product-4-720x480.jpg" },
                    { new Guid("78b2dd1c-1ffd-48c7-9b09-5fcca4d085c3"), new Guid("17e3c245-7304-46ed-b04b-9e9616201b08"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1924), "product-5-720x480.jpg" },
                    { new Guid("0ced2e42-36e1-42d3-baf7-6b1dc5869da2"), new Guid("52d89f92-4402-4f50-882c-2282ab9aca1c"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2158), "product-1-720x480.jpg" },
                    { new Guid("965798b6-c9b5-40d2-9f42-a5dd076d97d6"), new Guid("d7ab6c82-5a42-45f8-9587-0dbdfd85ff3e"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2100), "product-6-720x480.jpg" },
                    { new Guid("d049b6c6-3868-4edb-9827-786b997aa03f"), new Guid("d7ab6c82-5a42-45f8-9587-0dbdfd85ff3e"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2098), "product-5-720x480.jpg" },
                    { new Guid("7ed7d28b-7846-4973-ab4a-5f6a01c9d75d"), new Guid("d7ab6c82-5a42-45f8-9587-0dbdfd85ff3e"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2096), "product-4-720x480.jpg" },
                    { new Guid("636285f1-c26e-498d-8eef-dc85b8f3e9ad"), new Guid("d7ab6c82-5a42-45f8-9587-0dbdfd85ff3e"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2094), "product-3-720x480.jpg" },
                    { new Guid("665ff84f-e0f2-41d4-90fb-8c2c375ed3af"), new Guid("d7ab6c82-5a42-45f8-9587-0dbdfd85ff3e"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2092), "product-2-720x480.jpg" },
                    { new Guid("909cb048-345a-44e5-8b85-8d17c92176e7"), new Guid("2a15d983-d1ab-4c90-9a0c-7dcf70c88fcf"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1714), "product-6-720x480.jpg" },
                    { new Guid("4dae6a49-0a37-41fe-b075-699cd4f00f3c"), new Guid("d7ab6c82-5a42-45f8-9587-0dbdfd85ff3e"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(2090), "product-1-720x480.jpg" },
                    { new Guid("0f45abd8-e9c7-4e28-8ed7-eff2cecaf16e"), new Guid("be9ffbb4-10ca-4c18-9f8b-cbdb445b4e61"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1992), "product-5-720x480.jpg" },
                    { new Guid("248e39f4-4a07-4163-ba14-69d3c4351042"), new Guid("be9ffbb4-10ca-4c18-9f8b-cbdb445b4e61"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1990), "product-4-720x480.jpg" },
                    { new Guid("ca4dcb9c-53fe-47ab-a040-8f9d5dd06c27"), new Guid("be9ffbb4-10ca-4c18-9f8b-cbdb445b4e61"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1988), "product-3-720x480.jpg" },
                    { new Guid("565f142e-2067-4925-83d3-5dfb65538dbc"), new Guid("be9ffbb4-10ca-4c18-9f8b-cbdb445b4e61"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1986), "product-2-720x480.jpg" },
                    { new Guid("2ed66fb5-fb88-425c-a5a5-60bd4283b7a1"), new Guid("be9ffbb4-10ca-4c18-9f8b-cbdb445b4e61"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1983), "product-1-720x480.jpg" },
                    { new Guid("6df13b8d-147d-4234-a10e-0fd9d4c691bf"), new Guid("17e3c245-7304-46ed-b04b-9e9616201b08"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1926), "product-6-720x480.jpg" },
                    { new Guid("5ef487ef-9997-463a-a26e-9d8fbf325e06"), new Guid("be9ffbb4-10ca-4c18-9f8b-cbdb445b4e61"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1994), "product-6-720x480.jpg" },
                    { new Guid("ca614071-003a-4f3b-bf63-2399987c85e5"), new Guid("2a15d983-d1ab-4c90-9a0c-7dcf70c88fcf"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1712), "product-5-720x480.jpg" },
                    { new Guid("dbeabc63-8919-49c9-88e8-a36a7d7d736c"), new Guid("2a15d983-d1ab-4c90-9a0c-7dcf70c88fcf"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1682), "product-4-720x480.jpg" },
                    { new Guid("a1610afe-b730-446f-bd25-624b93138f33"), new Guid("2a15d983-d1ab-4c90-9a0c-7dcf70c88fcf"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1678), "product-3-720x480.jpg" },
                    { new Guid("06b2df74-e72e-4468-8d08-19cc9a040a32"), new Guid("74d2ac31-d09a-4181-a2a0-0a31f26a38dd"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1463), "product-2-720x480.jpg" },
                    { new Guid("d70a2933-e861-48c4-a21f-4b1c76a0be2f"), new Guid("74d2ac31-d09a-4181-a2a0-0a31f26a38dd"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1461), "product-1-720x480.jpg" },
                    { new Guid("b5c6a3e7-b459-4958-939b-7ea0ab2f5682"), new Guid("6c80706f-3a65-4e71-868d-fe5bad92251c"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1401), "product-6-720x480.jpg" },
                    { new Guid("b657141c-d6ab-49cb-ad52-4889aa893abd"), new Guid("6c80706f-3a65-4e71-868d-fe5bad92251c"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1399), "product-5-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("33181e8c-f35b-4a7b-8f31-9a9eaaee10cc"), new Guid("6c80706f-3a65-4e71-868d-fe5bad92251c"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1397), "product-4-720x480.jpg" },
                    { new Guid("92b0477c-6160-4676-99b9-3e731caf4a07"), new Guid("6c80706f-3a65-4e71-868d-fe5bad92251c"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1395), "product-3-720x480.jpg" },
                    { new Guid("d5b632ea-5ba1-4912-b32f-a2a2f1c4bb0c"), new Guid("74d2ac31-d09a-4181-a2a0-0a31f26a38dd"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1465), "product-3-720x480.jpg" },
                    { new Guid("678f9857-d592-456f-a623-ab413b23858f"), new Guid("6c80706f-3a65-4e71-868d-fe5bad92251c"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1393), "product-2-720x480.jpg" },
                    { new Guid("94a98d6c-fd66-441a-b0cc-d98c5b4dfbf2"), new Guid("39b390de-b2f2-4d30-91be-12170d437329"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1301), "product-6-720x480.jpg" },
                    { new Guid("ea1434d8-2d59-46d2-8b51-32bd9a76ced0"), new Guid("39b390de-b2f2-4d30-91be-12170d437329"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1299), "product-5-720x480.jpg" },
                    { new Guid("de56d6af-235d-49cd-9036-1115605b6b6a"), new Guid("39b390de-b2f2-4d30-91be-12170d437329"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1297), "product-4-720x480.jpg" },
                    { new Guid("05d1485c-366c-4eae-a92b-677a7a5d3a13"), new Guid("39b390de-b2f2-4d30-91be-12170d437329"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1295), "product-3-720x480.jpg" },
                    { new Guid("1db3ef50-9de1-4f67-99ff-e65cb6409dcf"), new Guid("39b390de-b2f2-4d30-91be-12170d437329"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1293), "product-2-720x480.jpg" },
                    { new Guid("f31c3a41-153b-4263-884b-7a0889488e1a"), new Guid("39b390de-b2f2-4d30-91be-12170d437329"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1290), "product-1-720x480.jpg" },
                    { new Guid("269c3cdb-91b6-4d23-96e1-b56e528457d3"), new Guid("6c80706f-3a65-4e71-868d-fe5bad92251c"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1391), "product-1-720x480.jpg" },
                    { new Guid("997cc2b8-8705-4746-bf13-a976e7687f52"), new Guid("0f1bcb56-c33f-4514-bc00-877910b4201b"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1230), "product-5-720x480.jpg" },
                    { new Guid("2829f1e8-ec05-48c6-a18f-83f9f8d1c373"), new Guid("74d2ac31-d09a-4181-a2a0-0a31f26a38dd"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1467), "product-4-720x480.jpg" },
                    { new Guid("63659a8e-13ab-4039-acab-7784306cb538"), new Guid("74d2ac31-d09a-4181-a2a0-0a31f26a38dd"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1471), "product-6-720x480.jpg" },
                    { new Guid("e2a301fb-90b9-4e81-940e-df0f97239d2b"), new Guid("2a15d983-d1ab-4c90-9a0c-7dcf70c88fcf"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1676), "product-2-720x480.jpg" },
                    { new Guid("089d6986-edcb-420c-b7ac-abbb487a6dba"), new Guid("2a15d983-d1ab-4c90-9a0c-7dcf70c88fcf"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1673), "product-1-720x480.jpg" },
                    { new Guid("864961d3-562f-4966-8d5b-1768ac82b589"), new Guid("2fb237f6-a4e9-4395-8c2c-c0fa09d58b43"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1617), "product-6-720x480.jpg" },
                    { new Guid("db1c95f7-a5b1-492b-9985-ced4e74394fb"), new Guid("2fb237f6-a4e9-4395-8c2c-c0fa09d58b43"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1615), "product-5-720x480.jpg" },
                    { new Guid("2da79e3d-85c7-43c4-9bb2-274433f44491"), new Guid("2fb237f6-a4e9-4395-8c2c-c0fa09d58b43"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1611), "product-4-720x480.jpg" },
                    { new Guid("ac1c5e3d-82e7-41e2-8826-2a1e45128f10"), new Guid("2fb237f6-a4e9-4395-8c2c-c0fa09d58b43"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1608), "product-3-720x480.jpg" },
                    { new Guid("f37a59d9-bfa4-4459-be56-e5d343c96d55"), new Guid("74d2ac31-d09a-4181-a2a0-0a31f26a38dd"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1469), "product-5-720x480.jpg" },
                    { new Guid("cbd176c2-3bbc-4586-94b7-bf81769e60d4"), new Guid("2fb237f6-a4e9-4395-8c2c-c0fa09d58b43"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1606), "product-2-720x480.jpg" },
                    { new Guid("a537bffd-e4c0-4aac-9447-5fabdd5792ab"), new Guid("9b62354d-f5fd-49f2-a8a2-05988bd1f31b"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1543), "product-6-720x480.jpg" },
                    { new Guid("6ad10b55-2d91-4adb-9c68-1a1088ba6a51"), new Guid("9b62354d-f5fd-49f2-a8a2-05988bd1f31b"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1539), "product-5-720x480.jpg" },
                    { new Guid("4a155985-09fc-43be-a93f-469745b77a98"), new Guid("9b62354d-f5fd-49f2-a8a2-05988bd1f31b"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1536), "product-4-720x480.jpg" },
                    { new Guid("f5a32fc5-5f7b-46b1-b587-9775d3bc477f"), new Guid("9b62354d-f5fd-49f2-a8a2-05988bd1f31b"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1534), "product-3-720x480.jpg" },
                    { new Guid("e442fc37-0e3d-4dda-b04c-89d37b3c19f4"), new Guid("9b62354d-f5fd-49f2-a8a2-05988bd1f31b"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1532), "product-2-720x480.jpg" },
                    { new Guid("c3ce41c8-0139-4586-86c8-8b61195d10b2"), new Guid("9b62354d-f5fd-49f2-a8a2-05988bd1f31b"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1530), "product-1-720x480.jpg" },
                    { new Guid("c4215e11-fc05-4e3b-842e-8133821257d6"), new Guid("2fb237f6-a4e9-4395-8c2c-c0fa09d58b43"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(1604), "product-1-720x480.jpg" },
                    { new Guid("2b2fc8fe-f757-4159-9d65-6638715aa23d"), new Guid("664c678f-ecbd-41da-adf8-30f14ce67da1"), new DateTime(2021, 6, 7, 21, 21, 26, 51, DateTimeKind.Local).AddTicks(3992), "product-6-720x480.jpg" }
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
