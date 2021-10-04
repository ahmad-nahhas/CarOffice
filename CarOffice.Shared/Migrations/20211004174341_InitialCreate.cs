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
                    { new Guid("be075f1e-13f1-4932-b3bd-30ba7f628ece"), new DateTime(2021, 10, 4, 20, 43, 40, 462, DateTimeKind.Local).AddTicks(8032), "Acura" },
                    { new Guid("9f60cd39-14aa-4373-82b3-948e037abf81"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6371), "Mazda" },
                    { new Guid("9ca1973f-5bd9-4f5a-a7a0-c361b2b250cb"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6451), "Mercedes-Benz" },
                    { new Guid("26dc37df-4233-4463-9f16-c46dd0239bc9"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6508), "Mercury" },
                    { new Guid("2f1b1203-7c6f-4943-b45f-b9197f18c783"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6562), "Mini" },
                    { new Guid("bdb5460e-c6f3-432b-bbea-b2ba034ce04a"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6617), "Mitsubishi" },
                    { new Guid("83b8ae79-0c93-413f-8bf7-f8b1f38c34be"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6671), "Nikola" },
                    { new Guid("721c7b75-9875-4517-9a1f-34942e290fd7"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6754), "Nissan" },
                    { new Guid("f83d5405-8a9d-4f4f-8fd2-e5743f3be5ae"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6811), "Polestar" },
                    { new Guid("07b311ba-d4cf-4477-9989-3036004cb36a"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6869), "Pontiac" },
                    { new Guid("616ed4f2-a9d9-4c00-8c96-07c448ac9552"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6316), "Maserati" },
                    { new Guid("e1e07aaf-9645-4cff-84ee-5ca5b2acb95e"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6924), "Porsche" },
                    { new Guid("f1b0cd6c-dba8-43e5-b9d9-1bbefb1bcea9"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7061), "Rivian" },
                    { new Guid("48126190-3b54-4dcc-911b-5e9fd9a4deb4"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7116), "Rolls-Royce" },
                    { new Guid("3fed8a85-85a0-4ff7-b66c-773ad0400212"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7171), "Saab" },
                    { new Guid("bedc0642-3145-4812-88ef-2a377db84f64"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7228), "Scion" },
                    { new Guid("65edbb49-f3b3-4e01-bc9c-cf5ecd7852df"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7309), "Smart" },
                    { new Guid("fdc77c70-fec9-4dd5-8592-29329a79d2e0"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7364), "Subaru" },
                    { new Guid("60821bde-594f-4f99-b4e1-afc71ec2eed9"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7419), "Suzuki" },
                    { new Guid("507ebe10-f394-4916-b660-ff32d671b080"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7511), "Tesla" },
                    { new Guid("42ac7199-c708-407e-98eb-dd7d56c15fe4"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7568), "Toyota" },
                    { new Guid("6a3777ef-8f0a-4938-a6ab-c31d63907a8f"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7006), "Ram" },
                    { new Guid("bad96ffc-5fee-4cdc-a99b-df9c54f6c08f"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7622), "Volkswagen" },
                    { new Guid("e2402c75-86ba-449c-8793-c1e3f14f8cab"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6260), "Lotus" },
                    { new Guid("b2bf5119-29f3-43f0-b826-1b317e148bff"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6117), "Lexus" },
                    { new Guid("a1121b52-bc7d-4642-a1bb-89eab4642d03"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4787), "Alfa Romeo" },
                    { new Guid("bdeb0f49-dd3a-4fb3-9735-b07cb82d24bb"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4910), "Audi" },
                    { new Guid("45a5453c-5d6e-45ea-bb4f-3b6ee1514c12"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4969), "Bentley" },
                    { new Guid("5e132645-bb61-4a04-8000-2534e0dcad05"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5025), "Buick" },
                    { new Guid("d7478587-ebc1-4292-a5cf-337a95f36967"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5116), "BMW" },
                    { new Guid("7f2addb9-e050-4ff6-831c-8413a8e07d70"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5174), "Cadillac" },
                    { new Guid("64403cd0-5a75-419a-b1bd-e0e138df0288"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5231), "Chevrolet" },
                    { new Guid("8535929f-16b1-41b1-862b-9b03a0b90346"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5286), "Chrysler" },
                    { new Guid("e9838e80-07bb-4242-bf6a-00513fc65f4a"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5390), "Dodge" },
                    { new Guid("8b5ca1a3-2591-488a-9908-dacc1e3135e8"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6202), "Lincoln" },
                    { new Guid("0c22bd14-3182-4ac0-87e4-e6900b686200"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5447), "Fiat" },
                    { new Guid("81651c38-5bc4-48e6-aed9-7bd4e075c200"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5560), "GMC" },
                    { new Guid("c8aeb7cb-eaf8-464a-898b-af3628714454"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5642), "Genesis" },
                    { new Guid("08f08604-fd3e-4667-bfe2-136fbfc2d1cc"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5699), "Honda" },
                    { new Guid("a261a1a0-71b7-422c-abf7-e32f8996f3ba"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5756), "Hyundai" },
                    { new Guid("257b9770-9173-47ff-99e6-fd5e2722a840"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5811), "Infiniti" },
                    { new Guid("6e777935-04e6-4bec-b847-65f5b2e9624d"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5871), "Jaguar" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("59daa3b4-7268-4ea8-80de-94ff4655b0e4"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5953), "Jeep" },
                    { new Guid("5794e310-0363-4b82-b520-a45d9f828632"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6008), "Kia" },
                    { new Guid("409574f1-415c-484e-8a04-292e54a46987"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6062), "Land Rover" },
                    { new Guid("a6061979-15a5-427d-8563-f5d247ce7af5"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5504), "Ford" },
                    { new Guid("921fb099-c8c0-4a2e-8c90-6c4af522a8a6"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7678), "Volvo" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandId", "CarExtras", "Color", "CreatedAt", "Description", "FuelType", "Gearbox", "Mileage", "ModelYear", "Price", "SeatCount", "ShowInHome", "Status", "Type", "WeightTotal" },
                values: new object[,]
                {
                    { new Guid("be075f1e-13f1-4932-b3bd-30ba7f628ece"), new Guid("be075f1e-13f1-4932-b3bd-30ba7f628ece"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 464, DateTimeKind.Local).AddTicks(9034), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("9f60cd39-14aa-4373-82b3-948e037abf81"), new Guid("9f60cd39-14aa-4373-82b3-948e037abf81"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6385), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("9ca1973f-5bd9-4f5a-a7a0-c361b2b250cb"), new Guid("9ca1973f-5bd9-4f5a-a7a0-c361b2b250cb"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6466), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("26dc37df-4233-4463-9f16-c46dd0239bc9"), new Guid("26dc37df-4233-4463-9f16-c46dd0239bc9"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6522), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("2f1b1203-7c6f-4943-b45f-b9197f18c783"), new Guid("2f1b1203-7c6f-4943-b45f-b9197f18c783"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6576), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("bdb5460e-c6f3-432b-bbea-b2ba034ce04a"), new Guid("bdb5460e-c6f3-432b-bbea-b2ba034ce04a"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6631), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("83b8ae79-0c93-413f-8bf7-f8b1f38c34be"), new Guid("83b8ae79-0c93-413f-8bf7-f8b1f38c34be"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6710), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("721c7b75-9875-4517-9a1f-34942e290fd7"), new Guid("721c7b75-9875-4517-9a1f-34942e290fd7"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6769), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("f83d5405-8a9d-4f4f-8fd2-e5743f3be5ae"), new Guid("f83d5405-8a9d-4f4f-8fd2-e5743f3be5ae"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6827), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("07b311ba-d4cf-4477-9989-3036004cb36a"), new Guid("07b311ba-d4cf-4477-9989-3036004cb36a"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6883), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("616ed4f2-a9d9-4c00-8c96-07c448ac9552"), new Guid("616ed4f2-a9d9-4c00-8c96-07c448ac9552"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6330), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("e1e07aaf-9645-4cff-84ee-5ca5b2acb95e"), new Guid("e1e07aaf-9645-4cff-84ee-5ca5b2acb95e"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6938), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("f1b0cd6c-dba8-43e5-b9d9-1bbefb1bcea9"), new Guid("f1b0cd6c-dba8-43e5-b9d9-1bbefb1bcea9"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7075), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("48126190-3b54-4dcc-911b-5e9fd9a4deb4"), new Guid("48126190-3b54-4dcc-911b-5e9fd9a4deb4"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7130), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("3fed8a85-85a0-4ff7-b66c-773ad0400212"), new Guid("3fed8a85-85a0-4ff7-b66c-773ad0400212"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7187), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("bedc0642-3145-4812-88ef-2a377db84f64"), new Guid("bedc0642-3145-4812-88ef-2a377db84f64"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7266), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("65edbb49-f3b3-4e01-bc9c-cf5ecd7852df"), new Guid("65edbb49-f3b3-4e01-bc9c-cf5ecd7852df"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7323), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("fdc77c70-fec9-4dd5-8592-29329a79d2e0"), new Guid("fdc77c70-fec9-4dd5-8592-29329a79d2e0"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7378), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("60821bde-594f-4f99-b4e1-afc71ec2eed9"), new Guid("60821bde-594f-4f99-b4e1-afc71ec2eed9"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7434), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("507ebe10-f394-4916-b660-ff32d671b080"), new Guid("507ebe10-f394-4916-b660-ff32d671b080"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7526), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("42ac7199-c708-407e-98eb-dd7d56c15fe4"), new Guid("42ac7199-c708-407e-98eb-dd7d56c15fe4"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7582), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("6a3777ef-8f0a-4938-a6ab-c31d63907a8f"), new Guid("6a3777ef-8f0a-4938-a6ab-c31d63907a8f"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7020), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("bad96ffc-5fee-4cdc-a99b-df9c54f6c08f"), new Guid("bad96ffc-5fee-4cdc-a99b-df9c54f6c08f"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7637), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("e2402c75-86ba-449c-8793-c1e3f14f8cab"), new Guid("e2402c75-86ba-449c-8793-c1e3f14f8cab"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6275), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("b2bf5119-29f3-43f0-b826-1b317e148bff"), new Guid("b2bf5119-29f3-43f0-b826-1b317e148bff"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6131), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("a1121b52-bc7d-4642-a1bb-89eab4642d03"), new Guid("a1121b52-bc7d-4642-a1bb-89eab4642d03"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4856), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("bdeb0f49-dd3a-4fb3-9735-b07cb82d24bb"), new Guid("bdeb0f49-dd3a-4fb3-9735-b07cb82d24bb"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4925), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("45a5453c-5d6e-45ea-bb4f-3b6ee1514c12"), new Guid("45a5453c-5d6e-45ea-bb4f-3b6ee1514c12"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4983), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("5e132645-bb61-4a04-8000-2534e0dcad05"), new Guid("5e132645-bb61-4a04-8000-2534e0dcad05"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5068), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("d7478587-ebc1-4292-a5cf-337a95f36967"), new Guid("d7478587-ebc1-4292-a5cf-337a95f36967"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5131), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("7f2addb9-e050-4ff6-831c-8413a8e07d70"), new Guid("7f2addb9-e050-4ff6-831c-8413a8e07d70"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5189), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("64403cd0-5a75-419a-b1bd-e0e138df0288"), new Guid("64403cd0-5a75-419a-b1bd-e0e138df0288"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5245), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("8535929f-16b1-41b1-862b-9b03a0b90346"), new Guid("8535929f-16b1-41b1-862b-9b03a0b90346"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5302), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("e9838e80-07bb-4242-bf6a-00513fc65f4a"), new Guid("e9838e80-07bb-4242-bf6a-00513fc65f4a"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5405), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("8b5ca1a3-2591-488a-9908-dacc1e3135e8"), new Guid("8b5ca1a3-2591-488a-9908-dacc1e3135e8"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6219), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("0c22bd14-3182-4ac0-87e4-e6900b686200"), new Guid("0c22bd14-3182-4ac0-87e4-e6900b686200"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5461), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("81651c38-5bc4-48e6-aed9-7bd4e075c200"), new Guid("81651c38-5bc4-48e6-aed9-7bd4e075c200"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5573), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("c8aeb7cb-eaf8-464a-898b-af3628714454"), new Guid("c8aeb7cb-eaf8-464a-898b-af3628714454"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5657), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("08f08604-fd3e-4667-bfe2-136fbfc2d1cc"), new Guid("08f08604-fd3e-4667-bfe2-136fbfc2d1cc"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5715), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("a261a1a0-71b7-422c-abf7-e32f8996f3ba"), new Guid("a261a1a0-71b7-422c-abf7-e32f8996f3ba"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5771), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("257b9770-9173-47ff-99e6-fd5e2722a840"), new Guid("257b9770-9173-47ff-99e6-fd5e2722a840"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5827), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("6e777935-04e6-4bec-b847-65f5b2e9624d"), new Guid("6e777935-04e6-4bec-b847-65f5b2e9624d"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5909), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandId", "CarExtras", "Color", "CreatedAt", "Description", "FuelType", "Gearbox", "Mileage", "ModelYear", "Price", "SeatCount", "ShowInHome", "Status", "Type", "WeightTotal" },
                values: new object[,]
                {
                    { new Guid("59daa3b4-7268-4ea8-80de-94ff4655b0e4"), new Guid("59daa3b4-7268-4ea8-80de-94ff4655b0e4"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5967), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("5794e310-0363-4b82-b520-a45d9f828632"), new Guid("5794e310-0363-4b82-b520-a45d9f828632"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6022), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("409574f1-415c-484e-8a04-292e54a46987"), new Guid("409574f1-415c-484e-8a04-292e54a46987"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6076), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("a6061979-15a5-427d-8563-f5d247ce7af5"), new Guid("a6061979-15a5-427d-8563-f5d247ce7af5"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5518), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m },
                    { new Guid("921fb099-c8c0-4a2e-8c90-6c4af522a8a6"), new Guid("921fb099-c8c0-4a2e-8c90-6c4af522a8a6"), "- ABS - Leather seats - Power Assisted Steering - Electric heated seats - New HU and AU - Xenon headlights", "White", new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7717), "Looking for a luxury car without the luxury price? You've found the right car. This car is in great condition! This 2005 Cadillac CTS 3.6L has just under 71K gentle miles. I am the second owner, and have the maintenance logs from the previous owner. This car has been constantly serviced at Cadillac dealerships and is up to date on scheduled maintenance.", 0, 1, 100, 2021, 2500000000m, 6, true, 0, 1, 5000m }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("cce8b451-ad36-43eb-990a-2f22751fac45"), new Guid("be075f1e-13f1-4932-b3bd-30ba7f628ece"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4054), "product-1-720x480.jpg" },
                    { new Guid("6dcdefc9-26dd-4cff-8f65-9a9c0bbc5970"), new Guid("bdb5460e-c6f3-432b-bbea-b2ba034ce04a"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6654), "product-5-720x480.jpg" },
                    { new Guid("5f08d00d-121f-43d5-84a9-5c99c2440d2f"), new Guid("bdb5460e-c6f3-432b-bbea-b2ba034ce04a"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6656), "product-6-720x480.jpg" },
                    { new Guid("5a7cd599-1319-4b2f-82f5-981d4589d88a"), new Guid("83b8ae79-0c93-413f-8bf7-f8b1f38c34be"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6728), "product-1-720x480.jpg" },
                    { new Guid("7fde48ce-25b0-494a-9e64-24a7d733d047"), new Guid("83b8ae79-0c93-413f-8bf7-f8b1f38c34be"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6730), "product-2-720x480.jpg" },
                    { new Guid("5ff6c0b4-d45d-4d96-b182-1da72d9d10f9"), new Guid("83b8ae79-0c93-413f-8bf7-f8b1f38c34be"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6732), "product-3-720x480.jpg" },
                    { new Guid("8b69208b-2d07-47a2-b95b-2e8b54bf8e62"), new Guid("83b8ae79-0c93-413f-8bf7-f8b1f38c34be"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6733), "product-4-720x480.jpg" },
                    { new Guid("b01b2019-36ac-4499-889a-ca980f8c79e3"), new Guid("83b8ae79-0c93-413f-8bf7-f8b1f38c34be"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6735), "product-5-720x480.jpg" },
                    { new Guid("90477464-c296-4975-984a-090fce3a9ecc"), new Guid("83b8ae79-0c93-413f-8bf7-f8b1f38c34be"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6737), "product-6-720x480.jpg" },
                    { new Guid("276b1a4b-70fd-45ec-9e27-c35856773aec"), new Guid("721c7b75-9875-4517-9a1f-34942e290fd7"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6784), "product-1-720x480.jpg" },
                    { new Guid("685ebada-1353-45e5-9beb-d215dd35b6c6"), new Guid("721c7b75-9875-4517-9a1f-34942e290fd7"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6786), "product-2-720x480.jpg" },
                    { new Guid("507b9066-1571-4a9b-9886-e6ef83bd640b"), new Guid("721c7b75-9875-4517-9a1f-34942e290fd7"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6788), "product-3-720x480.jpg" },
                    { new Guid("cfe1b86a-3a9c-4a81-8415-2dadabee0c61"), new Guid("721c7b75-9875-4517-9a1f-34942e290fd7"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6789), "product-4-720x480.jpg" },
                    { new Guid("482464fc-b570-48bb-bf67-eb9883b67b12"), new Guid("721c7b75-9875-4517-9a1f-34942e290fd7"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6791), "product-5-720x480.jpg" },
                    { new Guid("232158e5-4749-42ef-ad6b-0c916639e979"), new Guid("721c7b75-9875-4517-9a1f-34942e290fd7"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6793), "product-6-720x480.jpg" },
                    { new Guid("23d912e4-fc71-401d-b629-b1d7c9459e8a"), new Guid("f83d5405-8a9d-4f4f-8fd2-e5743f3be5ae"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6843), "product-1-720x480.jpg" },
                    { new Guid("8d9c8c41-6870-42e3-80be-448396033820"), new Guid("f83d5405-8a9d-4f4f-8fd2-e5743f3be5ae"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6845), "product-2-720x480.jpg" },
                    { new Guid("be387cd8-999f-47f8-9583-0871e3dd5b08"), new Guid("f83d5405-8a9d-4f4f-8fd2-e5743f3be5ae"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6847), "product-3-720x480.jpg" },
                    { new Guid("50581746-4f00-4e99-9428-3594cac561d8"), new Guid("e1e07aaf-9645-4cff-84ee-5ca5b2acb95e"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6988), "product-5-720x480.jpg" },
                    { new Guid("638c6e54-c036-402a-a782-aaf5950ba6cd"), new Guid("e1e07aaf-9645-4cff-84ee-5ca5b2acb95e"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6987), "product-4-720x480.jpg" },
                    { new Guid("22d71c17-e567-4d2b-a771-d3f4796a7dfc"), new Guid("e1e07aaf-9645-4cff-84ee-5ca5b2acb95e"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6983), "product-3-720x480.jpg" },
                    { new Guid("e892ee57-c651-486f-8a46-98034ea6746a"), new Guid("e1e07aaf-9645-4cff-84ee-5ca5b2acb95e"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6982), "product-2-720x480.jpg" },
                    { new Guid("55dde18b-581c-4341-b0c6-04468a85e495"), new Guid("e1e07aaf-9645-4cff-84ee-5ca5b2acb95e"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6980), "product-1-720x480.jpg" },
                    { new Guid("f438475f-c95a-4bdd-bfb4-8cd5a632c4c3"), new Guid("07b311ba-d4cf-4477-9989-3036004cb36a"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6908), "product-6-720x480.jpg" },
                    { new Guid("57d04cbf-d16b-446a-9409-cd8aa8b235ab"), new Guid("bdb5460e-c6f3-432b-bbea-b2ba034ce04a"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6653), "product-4-720x480.jpg" },
                    { new Guid("528bf76d-eb95-4b3d-b5ca-21d42b64d686"), new Guid("07b311ba-d4cf-4477-9989-3036004cb36a"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6907), "product-5-720x480.jpg" },
                    { new Guid("624e2579-9153-43f6-8f9f-3d55a4fedd86"), new Guid("07b311ba-d4cf-4477-9989-3036004cb36a"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6902), "product-3-720x480.jpg" },
                    { new Guid("45dda671-ff29-4c04-881f-631b17c5462e"), new Guid("07b311ba-d4cf-4477-9989-3036004cb36a"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6900), "product-2-720x480.jpg" },
                    { new Guid("672b9ec8-9579-4982-818e-4d76f76ba7e3"), new Guid("07b311ba-d4cf-4477-9989-3036004cb36a"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6899), "product-1-720x480.jpg" },
                    { new Guid("768720f8-83bd-482d-a658-41bf7b367d75"), new Guid("f83d5405-8a9d-4f4f-8fd2-e5743f3be5ae"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6853), "product-6-720x480.jpg" },
                    { new Guid("79b6303f-ad3b-4a90-90d4-61a4eef16e22"), new Guid("f83d5405-8a9d-4f4f-8fd2-e5743f3be5ae"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6850), "product-5-720x480.jpg" },
                    { new Guid("9008668a-4baf-4056-bd00-c8c6d0106e5c"), new Guid("f83d5405-8a9d-4f4f-8fd2-e5743f3be5ae"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6848), "product-4-720x480.jpg" },
                    { new Guid("3de4b4b2-7bd4-46b9-adc7-03177f0d65c5"), new Guid("07b311ba-d4cf-4477-9989-3036004cb36a"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6903), "product-4-720x480.jpg" },
                    { new Guid("c865a8cd-6278-4149-b57e-a125021960f7"), new Guid("e1e07aaf-9645-4cff-84ee-5ca5b2acb95e"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6990), "product-6-720x480.jpg" },
                    { new Guid("0dbb116b-3e00-4b43-9018-197405a5afd6"), new Guid("bdb5460e-c6f3-432b-bbea-b2ba034ce04a"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6651), "product-3-720x480.jpg" },
                    { new Guid("f8556f3f-5737-4869-ab8b-610bd1f32121"), new Guid("bdb5460e-c6f3-432b-bbea-b2ba034ce04a"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6648), "product-1-720x480.jpg" },
                    { new Guid("533dc9ef-b881-41a8-9a43-68aed3833a5b"), new Guid("e2402c75-86ba-449c-8793-c1e3f14f8cab"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6299), "product-6-720x480.jpg" },
                    { new Guid("ca622051-149f-4c82-982e-e54d660d2db8"), new Guid("616ed4f2-a9d9-4c00-8c96-07c448ac9552"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6346), "product-1-720x480.jpg" },
                    { new Guid("71864d61-e3be-4100-9e96-7d136c5f7048"), new Guid("616ed4f2-a9d9-4c00-8c96-07c448ac9552"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6348), "product-2-720x480.jpg" },
                    { new Guid("5ce695f8-555c-40b7-b865-a13d70739303"), new Guid("616ed4f2-a9d9-4c00-8c96-07c448ac9552"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6349), "product-3-720x480.jpg" },
                    { new Guid("5cb4fbe6-993b-48ea-8bfe-0f644c045ecb"), new Guid("616ed4f2-a9d9-4c00-8c96-07c448ac9552"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6351), "product-4-720x480.jpg" },
                    { new Guid("47c3c884-8705-4695-8795-c6af80cbb0cf"), new Guid("616ed4f2-a9d9-4c00-8c96-07c448ac9552"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6352), "product-5-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("6273288b-9c35-4089-b47a-80dbe31c47bb"), new Guid("616ed4f2-a9d9-4c00-8c96-07c448ac9552"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6356), "product-6-720x480.jpg" },
                    { new Guid("7a545661-7af0-42f8-8f3b-c3afddcf3bf7"), new Guid("9f60cd39-14aa-4373-82b3-948e037abf81"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6423), "product-1-720x480.jpg" },
                    { new Guid("6e9b1c90-9f89-4b81-9b3f-7fd0503ef533"), new Guid("9f60cd39-14aa-4373-82b3-948e037abf81"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6425), "product-2-720x480.jpg" },
                    { new Guid("e959eaab-7ffd-4beb-b897-54fb18288a8b"), new Guid("9f60cd39-14aa-4373-82b3-948e037abf81"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6427), "product-3-720x480.jpg" },
                    { new Guid("eff154e1-db35-45aa-b3cd-9a3410a1fb6b"), new Guid("9f60cd39-14aa-4373-82b3-948e037abf81"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6428), "product-4-720x480.jpg" },
                    { new Guid("a1a15e1f-31e8-4b2c-9531-1695eb4e8122"), new Guid("9f60cd39-14aa-4373-82b3-948e037abf81"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6432), "product-5-720x480.jpg" },
                    { new Guid("45cc8c84-ea5d-48cb-a0da-5e18f1c0927d"), new Guid("9f60cd39-14aa-4373-82b3-948e037abf81"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6433), "product-6-720x480.jpg" },
                    { new Guid("752fe058-a764-45bd-a2de-4964d3e64e53"), new Guid("9ca1973f-5bd9-4f5a-a7a0-c361b2b250cb"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6482), "product-1-720x480.jpg" },
                    { new Guid("20cab1e6-ecf3-4083-bafc-5db1ec562d16"), new Guid("9ca1973f-5bd9-4f5a-a7a0-c361b2b250cb"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6483), "product-2-720x480.jpg" },
                    { new Guid("7b7d26ef-648d-488b-83c2-0dd8c7604173"), new Guid("9ca1973f-5bd9-4f5a-a7a0-c361b2b250cb"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6485), "product-3-720x480.jpg" },
                    { new Guid("767f4dcd-e35d-4a65-817d-ab2f55576568"), new Guid("9ca1973f-5bd9-4f5a-a7a0-c361b2b250cb"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6489), "product-4-720x480.jpg" },
                    { new Guid("86224718-0a61-4531-8a8c-5916ab637143"), new Guid("2f1b1203-7c6f-4943-b45f-b9197f18c783"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6601), "product-6-720x480.jpg" },
                    { new Guid("3e5dd6b6-ee7f-4484-b2b1-f546dc147a67"), new Guid("2f1b1203-7c6f-4943-b45f-b9197f18c783"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6600), "product-5-720x480.jpg" },
                    { new Guid("644063dd-59b0-4e2e-9aa7-90218cdf6670"), new Guid("2f1b1203-7c6f-4943-b45f-b9197f18c783"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6598), "product-4-720x480.jpg" },
                    { new Guid("8ec76f7c-1e2d-490a-973a-51347f3c2daf"), new Guid("2f1b1203-7c6f-4943-b45f-b9197f18c783"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6596), "product-3-720x480.jpg" },
                    { new Guid("55fc1015-c1ae-440a-8830-5323cf82f7ce"), new Guid("2f1b1203-7c6f-4943-b45f-b9197f18c783"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6595), "product-2-720x480.jpg" },
                    { new Guid("1dda6886-ef27-4a5f-b828-9531f766ac1f"), new Guid("2f1b1203-7c6f-4943-b45f-b9197f18c783"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6591), "product-1-720x480.jpg" },
                    { new Guid("4bc7e141-503a-41c6-9d1b-d01219eec79f"), new Guid("bdb5460e-c6f3-432b-bbea-b2ba034ce04a"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6650), "product-2-720x480.jpg" },
                    { new Guid("a4de8fd4-b07a-47af-b725-eb8fcd73f36d"), new Guid("26dc37df-4233-4463-9f16-c46dd0239bc9"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6547), "product-6-720x480.jpg" },
                    { new Guid("299bb04d-109a-4eb8-a701-ba57bd7a658a"), new Guid("26dc37df-4233-4463-9f16-c46dd0239bc9"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6544), "product-4-720x480.jpg" },
                    { new Guid("e5bfff42-7aba-418e-b7d6-09538f38d795"), new Guid("26dc37df-4233-4463-9f16-c46dd0239bc9"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6542), "product-3-720x480.jpg" },
                    { new Guid("dc12223e-328c-4acf-ac99-9571a5fedb9e"), new Guid("26dc37df-4233-4463-9f16-c46dd0239bc9"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6539), "product-2-720x480.jpg" },
                    { new Guid("c2b7ddad-9938-41d8-8b15-50ea84891264"), new Guid("26dc37df-4233-4463-9f16-c46dd0239bc9"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6537), "product-1-720x480.jpg" },
                    { new Guid("a5e49962-046a-443c-98de-735d63aea77e"), new Guid("9ca1973f-5bd9-4f5a-a7a0-c361b2b250cb"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6492), "product-6-720x480.jpg" },
                    { new Guid("e9cf386e-e891-4dd8-a6d6-97b272b57dc8"), new Guid("9ca1973f-5bd9-4f5a-a7a0-c361b2b250cb"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6490), "product-5-720x480.jpg" },
                    { new Guid("644200c1-0aed-436c-8f00-9509335764e3"), new Guid("26dc37df-4233-4463-9f16-c46dd0239bc9"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6546), "product-5-720x480.jpg" },
                    { new Guid("eea17bae-3981-418f-a3a6-5863bd7ec978"), new Guid("6a3777ef-8f0a-4938-a6ab-c31d63907a8f"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7036), "product-1-720x480.jpg" },
                    { new Guid("ec04c715-b9a1-40fb-8195-76e8959538d1"), new Guid("6a3777ef-8f0a-4938-a6ab-c31d63907a8f"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7038), "product-2-720x480.jpg" },
                    { new Guid("ccaf91c3-064a-4f55-94a3-c372654538b2"), new Guid("6a3777ef-8f0a-4938-a6ab-c31d63907a8f"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7041), "product-3-720x480.jpg" },
                    { new Guid("7f3cd2ea-36a3-4d41-a73a-977f4c3cf862"), new Guid("fdc77c70-fec9-4dd5-8592-29329a79d2e0"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7398), "product-4-720x480.jpg" },
                    { new Guid("b63b41a6-0f1a-4abd-8bb1-e71e89c819fd"), new Guid("fdc77c70-fec9-4dd5-8592-29329a79d2e0"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7402), "product-5-720x480.jpg" },
                    { new Guid("d95afd01-1f6f-4e15-92bd-5d7d445d5059"), new Guid("fdc77c70-fec9-4dd5-8592-29329a79d2e0"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7403), "product-6-720x480.jpg" },
                    { new Guid("c9a6abc2-a857-4cd0-a25d-4f1e84f3df9a"), new Guid("60821bde-594f-4f99-b4e1-afc71ec2eed9"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7448), "product-1-720x480.jpg" },
                    { new Guid("a4125b68-e71c-46f6-8e8b-f3319b19f67f"), new Guid("60821bde-594f-4f99-b4e1-afc71ec2eed9"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7450), "product-2-720x480.jpg" },
                    { new Guid("b7bb20a5-74c5-4582-993d-ec697a657aff"), new Guid("60821bde-594f-4f99-b4e1-afc71ec2eed9"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7452), "product-3-720x480.jpg" },
                    { new Guid("61a45bc9-c65f-401d-8cc7-ec8161c84934"), new Guid("60821bde-594f-4f99-b4e1-afc71ec2eed9"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7455), "product-4-720x480.jpg" },
                    { new Guid("5c302be2-278c-4807-8efd-d6c7d58b1477"), new Guid("60821bde-594f-4f99-b4e1-afc71ec2eed9"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7457), "product-5-720x480.jpg" },
                    { new Guid("86a5276a-7eb9-42c3-ad11-9c6b36591b2a"), new Guid("60821bde-594f-4f99-b4e1-afc71ec2eed9"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7458), "product-6-720x480.jpg" },
                    { new Guid("84ab8365-1b1e-4561-bc43-08e883bbbde7"), new Guid("507ebe10-f394-4916-b660-ff32d671b080"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7542), "product-1-720x480.jpg" },
                    { new Guid("143949e2-ac28-43bd-9373-3c6dcd865c51"), new Guid("507ebe10-f394-4916-b660-ff32d671b080"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7544), "product-2-720x480.jpg" },
                    { new Guid("23efb298-fd48-445a-a029-6822a9a270d4"), new Guid("507ebe10-f394-4916-b660-ff32d671b080"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7548), "product-3-720x480.jpg" },
                    { new Guid("6faad40e-a57a-4ece-bb1a-1fe436659363"), new Guid("507ebe10-f394-4916-b660-ff32d671b080"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7549), "product-4-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("83db326b-4888-477f-9ec4-6a3bcf205515"), new Guid("507ebe10-f394-4916-b660-ff32d671b080"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7551), "product-5-720x480.jpg" },
                    { new Guid("a89263c7-1620-40d0-9392-55ef3118d1b9"), new Guid("507ebe10-f394-4916-b660-ff32d671b080"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7552), "product-6-720x480.jpg" },
                    { new Guid("930cde10-d156-4c87-b18f-88097fb74958"), new Guid("42ac7199-c708-407e-98eb-dd7d56c15fe4"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7597), "product-1-720x480.jpg" },
                    { new Guid("52efde1c-1002-4cbf-bab5-f0dee1cafc20"), new Guid("42ac7199-c708-407e-98eb-dd7d56c15fe4"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7601), "product-2-720x480.jpg" },
                    { new Guid("5bc02078-4fb7-4ae5-b267-d12583e413e3"), new Guid("921fb099-c8c0-4a2e-8c90-6c4af522a8a6"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7740), "product-4-720x480.jpg" },
                    { new Guid("d64500dc-bbdb-407f-b087-7c15c9a0ab34"), new Guid("921fb099-c8c0-4a2e-8c90-6c4af522a8a6"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7738), "product-3-720x480.jpg" },
                    { new Guid("99f53238-6157-4393-aaba-e9ac29cfaf92"), new Guid("921fb099-c8c0-4a2e-8c90-6c4af522a8a6"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7736), "product-2-720x480.jpg" },
                    { new Guid("f0c3f60e-cc5f-410d-b904-e32343a02158"), new Guid("921fb099-c8c0-4a2e-8c90-6c4af522a8a6"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7735), "product-1-720x480.jpg" },
                    { new Guid("cd0f198a-c23d-4c65-8316-7f32131e514f"), new Guid("bad96ffc-5fee-4cdc-a99b-df9c54f6c08f"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7662), "product-6-720x480.jpg" },
                    { new Guid("e0c35b65-558c-4fd5-bcff-5390ce08cc05"), new Guid("bad96ffc-5fee-4cdc-a99b-df9c54f6c08f"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7661), "product-5-720x480.jpg" },
                    { new Guid("157c506a-14a1-4df7-96a2-c007a91596a4"), new Guid("fdc77c70-fec9-4dd5-8592-29329a79d2e0"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7397), "product-3-720x480.jpg" },
                    { new Guid("f39c5ec7-79bb-432e-8f01-46def35cb29e"), new Guid("bad96ffc-5fee-4cdc-a99b-df9c54f6c08f"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7659), "product-4-720x480.jpg" },
                    { new Guid("12d306af-f8df-4dff-9c24-abae4c2aa115"), new Guid("bad96ffc-5fee-4cdc-a99b-df9c54f6c08f"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7656), "product-2-720x480.jpg" },
                    { new Guid("dbedb00c-7fbb-492b-b504-ad11909edd11"), new Guid("bad96ffc-5fee-4cdc-a99b-df9c54f6c08f"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7654), "product-1-720x480.jpg" },
                    { new Guid("7ca39946-3695-4858-a0b9-804c5d161239"), new Guid("42ac7199-c708-407e-98eb-dd7d56c15fe4"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7607), "product-6-720x480.jpg" },
                    { new Guid("15144574-470a-4621-8aa6-c1bdd86521e1"), new Guid("42ac7199-c708-407e-98eb-dd7d56c15fe4"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7606), "product-5-720x480.jpg" },
                    { new Guid("1ab5ba8a-e73a-4522-809e-c71372be7c3b"), new Guid("42ac7199-c708-407e-98eb-dd7d56c15fe4"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7604), "product-4-720x480.jpg" },
                    { new Guid("485bb38b-5b2a-4753-9678-c630fe7efbc0"), new Guid("42ac7199-c708-407e-98eb-dd7d56c15fe4"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7602), "product-3-720x480.jpg" },
                    { new Guid("c5585a6f-bdb1-4f56-9e49-a228c1f58a9d"), new Guid("bad96ffc-5fee-4cdc-a99b-df9c54f6c08f"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7658), "product-3-720x480.jpg" },
                    { new Guid("9c83387d-9949-4e48-b147-1036c8b5d027"), new Guid("fdc77c70-fec9-4dd5-8592-29329a79d2e0"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7395), "product-2-720x480.jpg" },
                    { new Guid("47e8d065-4a24-464e-b93f-73e18d5fc84d"), new Guid("fdc77c70-fec9-4dd5-8592-29329a79d2e0"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7393), "product-1-720x480.jpg" },
                    { new Guid("2a92e678-8f4c-4df9-bc0b-8582aea3ffb2"), new Guid("65edbb49-f3b3-4e01-bc9c-cf5ecd7852df"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7349), "product-6-720x480.jpg" },
                    { new Guid("f114e90c-9de1-4911-9332-2ed6b69603b4"), new Guid("48126190-3b54-4dcc-911b-5e9fd9a4deb4"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7154), "product-5-720x480.jpg" },
                    { new Guid("6efb6f4b-b870-43e7-a2d9-377fa90bf16f"), new Guid("48126190-3b54-4dcc-911b-5e9fd9a4deb4"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7152), "product-4-720x480.jpg" },
                    { new Guid("eabcff13-4910-47a1-9d72-36b110b9bded"), new Guid("48126190-3b54-4dcc-911b-5e9fd9a4deb4"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7151), "product-3-720x480.jpg" },
                    { new Guid("d46cadd1-1a8d-4ee8-ad3e-dbc4575e04e9"), new Guid("48126190-3b54-4dcc-911b-5e9fd9a4deb4"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7149), "product-2-720x480.jpg" },
                    { new Guid("b2af9a76-9cf0-4c9f-ac51-9012344dd311"), new Guid("48126190-3b54-4dcc-911b-5e9fd9a4deb4"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7147), "product-1-720x480.jpg" },
                    { new Guid("51b767ee-ab1c-4bfd-84a1-493c70b5d17b"), new Guid("f1b0cd6c-dba8-43e5-b9d9-1bbefb1bcea9"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7101), "product-6-720x480.jpg" },
                    { new Guid("3d8fab8c-5853-48c2-920a-700d5c90cde7"), new Guid("48126190-3b54-4dcc-911b-5e9fd9a4deb4"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7155), "product-6-720x480.jpg" },
                    { new Guid("e7b77f3b-fd71-459e-8f8c-cd035a2f7bff"), new Guid("f1b0cd6c-dba8-43e5-b9d9-1bbefb1bcea9"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7099), "product-5-720x480.jpg" },
                    { new Guid("d810b329-168f-4e3b-8e61-8eedd0cd78b1"), new Guid("f1b0cd6c-dba8-43e5-b9d9-1bbefb1bcea9"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7096), "product-3-720x480.jpg" },
                    { new Guid("92d9014e-fd91-4948-8bb6-5c8f5a943d07"), new Guid("f1b0cd6c-dba8-43e5-b9d9-1bbefb1bcea9"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7094), "product-2-720x480.jpg" },
                    { new Guid("6839759f-f310-4e76-9120-7fdb98c48fae"), new Guid("f1b0cd6c-dba8-43e5-b9d9-1bbefb1bcea9"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7091), "product-1-720x480.jpg" },
                    { new Guid("6a6b15f8-db5d-4abe-b525-3dca593e77b5"), new Guid("6a3777ef-8f0a-4938-a6ab-c31d63907a8f"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7046), "product-6-720x480.jpg" },
                    { new Guid("052f40c4-6bac-48fe-9ff5-04e9d23f99af"), new Guid("6a3777ef-8f0a-4938-a6ab-c31d63907a8f"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7044), "product-5-720x480.jpg" },
                    { new Guid("eb908329-51e7-4256-be87-0d36be970793"), new Guid("6a3777ef-8f0a-4938-a6ab-c31d63907a8f"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7043), "product-4-720x480.jpg" },
                    { new Guid("e29db049-ff88-4b9d-be15-51125af38906"), new Guid("f1b0cd6c-dba8-43e5-b9d9-1bbefb1bcea9"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7098), "product-4-720x480.jpg" },
                    { new Guid("473d8d64-c6f1-49fc-8f72-d40a98b2915e"), new Guid("e2402c75-86ba-449c-8793-c1e3f14f8cab"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6297), "product-5-720x480.jpg" },
                    { new Guid("0cbfcd3b-54f0-4db2-a827-9e031ff330e2"), new Guid("3fed8a85-85a0-4ff7-b66c-773ad0400212"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7203), "product-1-720x480.jpg" },
                    { new Guid("9d5bf338-8af8-4bcd-8728-8662026040ca"), new Guid("3fed8a85-85a0-4ff7-b66c-773ad0400212"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7206), "product-3-720x480.jpg" },
                    { new Guid("42ecc62c-2d49-4d82-9403-eb749a48fdbc"), new Guid("65edbb49-f3b3-4e01-bc9c-cf5ecd7852df"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7345), "product-5-720x480.jpg" },
                    { new Guid("b5686669-35fc-4bfe-b85b-d9bea0dafb9b"), new Guid("65edbb49-f3b3-4e01-bc9c-cf5ecd7852df"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7344), "product-4-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("441b5dcd-7090-48c2-b2ed-44f3e819db94"), new Guid("65edbb49-f3b3-4e01-bc9c-cf5ecd7852df"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7342), "product-3-720x480.jpg" },
                    { new Guid("13054606-b762-4c9f-a0cd-83ecee103780"), new Guid("65edbb49-f3b3-4e01-bc9c-cf5ecd7852df"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7340), "product-2-720x480.jpg" },
                    { new Guid("e08352c6-3027-418b-bf75-bac18925cfff"), new Guid("65edbb49-f3b3-4e01-bc9c-cf5ecd7852df"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7339), "product-1-720x480.jpg" },
                    { new Guid("8cf84424-fbdc-46a4-9b01-fd867e31c3a9"), new Guid("bedc0642-3145-4812-88ef-2a377db84f64"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7291), "product-6-720x480.jpg" },
                    { new Guid("7f27c606-7b55-490a-8df5-970dad6744e2"), new Guid("3fed8a85-85a0-4ff7-b66c-773ad0400212"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7205), "product-2-720x480.jpg" },
                    { new Guid("5c9065eb-9a3a-41cc-9567-db05a70b75d6"), new Guid("bedc0642-3145-4812-88ef-2a377db84f64"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7290), "product-5-720x480.jpg" },
                    { new Guid("be4ef2b9-8810-4a77-976c-e34f62043b5f"), new Guid("bedc0642-3145-4812-88ef-2a377db84f64"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7286), "product-3-720x480.jpg" },
                    { new Guid("883e6d8a-518d-4f63-9e03-53048f4d7e63"), new Guid("bedc0642-3145-4812-88ef-2a377db84f64"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7285), "product-2-720x480.jpg" },
                    { new Guid("dbb328c8-40f1-4c46-ab44-9c32b9b1742a"), new Guid("bedc0642-3145-4812-88ef-2a377db84f64"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7283), "product-1-720x480.jpg" },
                    { new Guid("9c4591d2-ca8f-4827-8d4a-00bdf9e1f093"), new Guid("3fed8a85-85a0-4ff7-b66c-773ad0400212"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7211), "product-6-720x480.jpg" },
                    { new Guid("e6b73aaf-96e6-4e0c-b6cc-e41e05f22e93"), new Guid("3fed8a85-85a0-4ff7-b66c-773ad0400212"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7210), "product-5-720x480.jpg" },
                    { new Guid("2fd911bb-92a0-4b2d-acd0-9651914bd3bc"), new Guid("3fed8a85-85a0-4ff7-b66c-773ad0400212"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7208), "product-4-720x480.jpg" },
                    { new Guid("3bd58707-e075-4a66-a4f7-6685d60e2f51"), new Guid("bedc0642-3145-4812-88ef-2a377db84f64"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7288), "product-4-720x480.jpg" },
                    { new Guid("e1c6b5dc-54eb-4514-a576-fe42da4fcd91"), new Guid("e2402c75-86ba-449c-8793-c1e3f14f8cab"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6295), "product-4-720x480.jpg" },
                    { new Guid("02576a8e-0f2b-4668-b2a3-52b3c5587ebc"), new Guid("e2402c75-86ba-449c-8793-c1e3f14f8cab"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6294), "product-3-720x480.jpg" },
                    { new Guid("50bdf385-2ec8-4221-b976-d2b31dc662e8"), new Guid("e2402c75-86ba-449c-8793-c1e3f14f8cab"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6292), "product-2-720x480.jpg" },
                    { new Guid("a9f2acad-270b-4f04-8f9f-6c5c4e2b71f8"), new Guid("7f2addb9-e050-4ff6-831c-8413a8e07d70"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5207), "product-2-720x480.jpg" },
                    { new Guid("4a4ce882-6cb5-4852-8cae-5c20b21d8f8a"), new Guid("7f2addb9-e050-4ff6-831c-8413a8e07d70"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5209), "product-3-720x480.jpg" },
                    { new Guid("daf8919c-7603-4a2a-b88b-37eb8c0439c9"), new Guid("7f2addb9-e050-4ff6-831c-8413a8e07d70"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5210), "product-4-720x480.jpg" },
                    { new Guid("5720ffdc-1272-4796-99b4-50143ceb2341"), new Guid("7f2addb9-e050-4ff6-831c-8413a8e07d70"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5212), "product-5-720x480.jpg" },
                    { new Guid("bdd0cffe-0892-438d-8841-804465964c03"), new Guid("7f2addb9-e050-4ff6-831c-8413a8e07d70"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5213), "product-6-720x480.jpg" },
                    { new Guid("f45b9d0f-7259-42e3-b187-12ef2b107c68"), new Guid("64403cd0-5a75-419a-b1bd-e0e138df0288"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5261), "product-1-720x480.jpg" },
                    { new Guid("c7c0298e-83bb-4a7c-8ae1-c65bd6ee1432"), new Guid("64403cd0-5a75-419a-b1bd-e0e138df0288"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5263), "product-2-720x480.jpg" },
                    { new Guid("676571ee-75e8-4e6c-bb48-1293af1f11e0"), new Guid("64403cd0-5a75-419a-b1bd-e0e138df0288"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5264), "product-3-720x480.jpg" },
                    { new Guid("f5124e74-94ea-49e3-a333-3db3219de1b7"), new Guid("64403cd0-5a75-419a-b1bd-e0e138df0288"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5266), "product-4-720x480.jpg" },
                    { new Guid("1fbec141-94d7-4d76-8bbd-654a68670767"), new Guid("64403cd0-5a75-419a-b1bd-e0e138df0288"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5267), "product-5-720x480.jpg" },
                    { new Guid("662a8e47-3af6-4463-88ab-434cee1d526c"), new Guid("64403cd0-5a75-419a-b1bd-e0e138df0288"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5269), "product-6-720x480.jpg" },
                    { new Guid("7fbf763e-e735-47b7-a150-98b80b7147de"), new Guid("8535929f-16b1-41b1-862b-9b03a0b90346"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5360), "product-1-720x480.jpg" },
                    { new Guid("abda593f-379a-41cc-9750-368ee2bb95b7"), new Guid("8535929f-16b1-41b1-862b-9b03a0b90346"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5362), "product-2-720x480.jpg" },
                    { new Guid("b41bac4c-a531-45ba-a3fe-ebcfcd4651db"), new Guid("8535929f-16b1-41b1-862b-9b03a0b90346"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5364), "product-3-720x480.jpg" },
                    { new Guid("a02f6bbd-26f7-41d4-a26f-ff1928c8ceeb"), new Guid("8535929f-16b1-41b1-862b-9b03a0b90346"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5365), "product-4-720x480.jpg" },
                    { new Guid("fb33b0bf-dad2-4c4f-b3a8-508a204d0a53"), new Guid("8535929f-16b1-41b1-862b-9b03a0b90346"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5367), "product-5-720x480.jpg" },
                    { new Guid("45131ac6-fbc5-4581-a3f5-4e0bfbfecb8d"), new Guid("8535929f-16b1-41b1-862b-9b03a0b90346"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5370), "product-6-720x480.jpg" },
                    { new Guid("6a678351-06e4-4488-835a-2ff692575b6e"), new Guid("a6061979-15a5-427d-8563-f5d247ce7af5"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5535), "product-2-720x480.jpg" },
                    { new Guid("b12e384f-fdb3-48cb-981e-82e45bc60f29"), new Guid("a6061979-15a5-427d-8563-f5d247ce7af5"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5533), "product-1-720x480.jpg" },
                    { new Guid("d2d1e75e-4544-4651-8f12-3fdcbcfeaa8e"), new Guid("0c22bd14-3182-4ac0-87e4-e6900b686200"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5487), "product-6-720x480.jpg" },
                    { new Guid("b2326ae0-f18c-4411-81d8-61f35aa23fb0"), new Guid("0c22bd14-3182-4ac0-87e4-e6900b686200"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5485), "product-5-720x480.jpg" },
                    { new Guid("6e34d801-0374-411c-8fc7-13b90d009e78"), new Guid("0c22bd14-3182-4ac0-87e4-e6900b686200"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5484), "product-4-720x480.jpg" },
                    { new Guid("a4a8ad50-fb4f-4eb4-b860-116954ededac"), new Guid("0c22bd14-3182-4ac0-87e4-e6900b686200"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5480), "product-3-720x480.jpg" },
                    { new Guid("5e541e7a-7aff-4ace-8bd7-e0c8ae3b39ba"), new Guid("7f2addb9-e050-4ff6-831c-8413a8e07d70"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5205), "product-1-720x480.jpg" },
                    { new Guid("adb076bd-e5e2-4288-b83e-465da4941cad"), new Guid("0c22bd14-3182-4ac0-87e4-e6900b686200"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5479), "product-2-720x480.jpg" },
                    { new Guid("0731316c-a421-4b04-97c4-d4929834db1b"), new Guid("e9838e80-07bb-4242-bf6a-00513fc65f4a"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5431), "product-6-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("b41844e7-0fc9-4758-80cf-d78037623437"), new Guid("e9838e80-07bb-4242-bf6a-00513fc65f4a"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5429), "product-5-720x480.jpg" },
                    { new Guid("d8ac003b-6e46-4d02-979d-3902624939b2"), new Guid("e9838e80-07bb-4242-bf6a-00513fc65f4a"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5426), "product-4-720x480.jpg" },
                    { new Guid("467b532c-0776-420e-9109-26482d6ee54b"), new Guid("e9838e80-07bb-4242-bf6a-00513fc65f4a"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5424), "product-3-720x480.jpg" },
                    { new Guid("54808504-67f8-407f-a069-e5ec3299d926"), new Guid("e9838e80-07bb-4242-bf6a-00513fc65f4a"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5423), "product-2-720x480.jpg" },
                    { new Guid("6b78c23f-b84b-4016-86ed-5e850e4784cb"), new Guid("e9838e80-07bb-4242-bf6a-00513fc65f4a"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5421), "product-1-720x480.jpg" },
                    { new Guid("6f518cd3-30ce-42a5-acf6-ddb71c8c4f8a"), new Guid("0c22bd14-3182-4ac0-87e4-e6900b686200"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5477), "product-1-720x480.jpg" },
                    { new Guid("b046b17c-31fe-4f58-9c6c-fb8f2238a4b6"), new Guid("d7478587-ebc1-4292-a5cf-337a95f36967"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5156), "product-6-720x480.jpg" },
                    { new Guid("01e12731-6d96-4ebe-aae1-97102ccd07f0"), new Guid("d7478587-ebc1-4292-a5cf-337a95f36967"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5155), "product-5-720x480.jpg" },
                    { new Guid("405ce094-54f3-4780-8a74-c5fa62fbde64"), new Guid("d7478587-ebc1-4292-a5cf-337a95f36967"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5153), "product-4-720x480.jpg" },
                    { new Guid("b6f70c00-e782-491f-801a-ea8773c2b4b7"), new Guid("bdeb0f49-dd3a-4fb3-9735-b07cb82d24bb"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4945), "product-3-720x480.jpg" },
                    { new Guid("349bca94-1ae2-475e-a930-1c51345304a0"), new Guid("bdeb0f49-dd3a-4fb3-9735-b07cb82d24bb"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4943), "product-2-720x480.jpg" },
                    { new Guid("1660e72b-f623-471a-8079-7bc485fce47b"), new Guid("bdeb0f49-dd3a-4fb3-9735-b07cb82d24bb"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4941), "product-1-720x480.jpg" },
                    { new Guid("089b9e13-6160-4654-89ef-1762eaf81053"), new Guid("a1121b52-bc7d-4642-a1bb-89eab4642d03"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4891), "product-6-720x480.jpg" },
                    { new Guid("14b65934-bd95-4203-a0c3-5cc65d331570"), new Guid("a1121b52-bc7d-4642-a1bb-89eab4642d03"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4889), "product-5-720x480.jpg" },
                    { new Guid("c45746d2-f287-4398-9529-e861fb134629"), new Guid("a1121b52-bc7d-4642-a1bb-89eab4642d03"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4884), "product-4-720x480.jpg" },
                    { new Guid("72b7522e-086e-4ec9-8628-af6548b6359c"), new Guid("bdeb0f49-dd3a-4fb3-9735-b07cb82d24bb"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4948), "product-4-720x480.jpg" },
                    { new Guid("bbe1a9ec-851d-43d2-8e3d-59a0dbda9b92"), new Guid("a1121b52-bc7d-4642-a1bb-89eab4642d03"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4882), "product-3-720x480.jpg" },
                    { new Guid("eed535d1-8342-4207-bac9-257b8a5690e4"), new Guid("a1121b52-bc7d-4642-a1bb-89eab4642d03"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4878), "product-1-720x480.jpg" },
                    { new Guid("152d8897-a5fd-40b9-ba68-848740f2a60c"), new Guid("be075f1e-13f1-4932-b3bd-30ba7f628ece"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4634), "product-6-720x480.jpg" },
                    { new Guid("26a9586d-ac90-4d3f-ad34-c88d097c6fde"), new Guid("be075f1e-13f1-4932-b3bd-30ba7f628ece"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4621), "product-5-720x480.jpg" },
                    { new Guid("b1efb7e5-3e70-4ff5-aae3-8c86b5ac16ab"), new Guid("be075f1e-13f1-4932-b3bd-30ba7f628ece"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4620), "product-4-720x480.jpg" },
                    { new Guid("e1d698a0-36a1-405d-9905-f830dfc0617d"), new Guid("be075f1e-13f1-4932-b3bd-30ba7f628ece"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4618), "product-3-720x480.jpg" },
                    { new Guid("02598e07-3ddd-4a8e-8903-a604917e3aad"), new Guid("be075f1e-13f1-4932-b3bd-30ba7f628ece"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4613), "product-2-720x480.jpg" },
                    { new Guid("0ea91b3d-cf30-411e-a5a8-a66555d5c746"), new Guid("a1121b52-bc7d-4642-a1bb-89eab4642d03"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4880), "product-2-720x480.jpg" },
                    { new Guid("f2330521-3ccc-4f6e-a60c-e56c76d78fdb"), new Guid("a6061979-15a5-427d-8563-f5d247ce7af5"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5539), "product-3-720x480.jpg" },
                    { new Guid("629428b6-a6d4-4525-9cfd-3f1c9bd7dca4"), new Guid("bdeb0f49-dd3a-4fb3-9735-b07cb82d24bb"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4950), "product-5-720x480.jpg" },
                    { new Guid("7a66d937-5698-40b2-a3d7-9d3dfe606983"), new Guid("45a5453c-5d6e-45ea-bb4f-3b6ee1514c12"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4999), "product-1-720x480.jpg" },
                    { new Guid("942ea4c3-bda2-4004-9a58-bf42b151f8de"), new Guid("d7478587-ebc1-4292-a5cf-337a95f36967"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5151), "product-3-720x480.jpg" },
                    { new Guid("98c8db2a-82a4-4fa0-b69d-ef976193d447"), new Guid("d7478587-ebc1-4292-a5cf-337a95f36967"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5150), "product-2-720x480.jpg" },
                    { new Guid("050e7a94-343f-4753-b56d-eed2e7353db3"), new Guid("d7478587-ebc1-4292-a5cf-337a95f36967"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5148), "product-1-720x480.jpg" },
                    { new Guid("2d52a627-a291-43d4-879b-7dc1356344cb"), new Guid("5e132645-bb61-4a04-8000-2534e0dcad05"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5100), "product-6-720x480.jpg" },
                    { new Guid("7e4a90d1-918e-427c-a7b6-efef1d65dc16"), new Guid("5e132645-bb61-4a04-8000-2534e0dcad05"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5098), "product-5-720x480.jpg" },
                    { new Guid("ff29e3b9-b0cc-44b8-9031-aa485b90573c"), new Guid("5e132645-bb61-4a04-8000-2534e0dcad05"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5096), "product-4-720x480.jpg" },
                    { new Guid("7f62770a-5b36-48c7-9b31-a95f5caa1156"), new Guid("bdeb0f49-dd3a-4fb3-9735-b07cb82d24bb"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(4952), "product-6-720x480.jpg" },
                    { new Guid("aa99a935-cacd-492c-8d8c-3ed40ce68790"), new Guid("5e132645-bb61-4a04-8000-2534e0dcad05"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5095), "product-3-720x480.jpg" },
                    { new Guid("13350a7a-fe32-41b6-aa1b-3764834ff64f"), new Guid("5e132645-bb61-4a04-8000-2534e0dcad05"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5089), "product-1-720x480.jpg" },
                    { new Guid("3435c32a-4e5b-42a9-bf14-eb3526cf08f6"), new Guid("45a5453c-5d6e-45ea-bb4f-3b6ee1514c12"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5009), "product-6-720x480.jpg" },
                    { new Guid("f9441c23-ee53-4812-aedf-faa86234b925"), new Guid("45a5453c-5d6e-45ea-bb4f-3b6ee1514c12"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5008), "product-5-720x480.jpg" },
                    { new Guid("e2b5a13c-1818-437e-81e7-07e6db5e5b00"), new Guid("45a5453c-5d6e-45ea-bb4f-3b6ee1514c12"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5006), "product-4-720x480.jpg" },
                    { new Guid("410d2315-b412-44c9-89a4-c64b8d3806bb"), new Guid("45a5453c-5d6e-45ea-bb4f-3b6ee1514c12"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5005), "product-3-720x480.jpg" },
                    { new Guid("9eb84cdc-464b-4eb7-bd08-73c7ae304e99"), new Guid("45a5453c-5d6e-45ea-bb4f-3b6ee1514c12"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5001), "product-2-720x480.jpg" },
                    { new Guid("e46adec5-be1a-416a-8b88-b44071e76b19"), new Guid("5e132645-bb61-4a04-8000-2534e0dcad05"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5093), "product-2-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("02baa26f-2623-4fdc-91e6-f5c3a34608c1"), new Guid("921fb099-c8c0-4a2e-8c90-6c4af522a8a6"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7741), "product-5-720x480.jpg" },
                    { new Guid("80571e78-23c2-4522-8a22-b03015712e90"), new Guid("a6061979-15a5-427d-8563-f5d247ce7af5"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5541), "product-4-720x480.jpg" },
                    { new Guid("32be6c31-813c-4e1a-ac77-10131ab053ee"), new Guid("a6061979-15a5-427d-8563-f5d247ce7af5"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5544), "product-6-720x480.jpg" },
                    { new Guid("bc78f79a-fa78-4437-ab0a-54fb4cd5e276"), new Guid("59daa3b4-7268-4ea8-80de-94ff4655b0e4"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5983), "product-1-720x480.jpg" },
                    { new Guid("2873871b-f139-4b03-aecb-3eff2e0823af"), new Guid("59daa3b4-7268-4ea8-80de-94ff4655b0e4"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5984), "product-2-720x480.jpg" },
                    { new Guid("442a7958-f96f-4f42-8bf1-fd4ddd95a40a"), new Guid("59daa3b4-7268-4ea8-80de-94ff4655b0e4"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5986), "product-3-720x480.jpg" },
                    { new Guid("6b292a1a-d783-4db8-b5fe-93bd38967045"), new Guid("59daa3b4-7268-4ea8-80de-94ff4655b0e4"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5989), "product-4-720x480.jpg" },
                    { new Guid("230417b1-a000-4710-9ebf-804f076a3fb9"), new Guid("59daa3b4-7268-4ea8-80de-94ff4655b0e4"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5991), "product-5-720x480.jpg" },
                    { new Guid("7ffba96e-9160-4fa2-b6f4-6f91ed67c50e"), new Guid("59daa3b4-7268-4ea8-80de-94ff4655b0e4"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5993), "product-6-720x480.jpg" },
                    { new Guid("a8007b7f-008a-4366-80c5-c2901b5cacd8"), new Guid("5794e310-0363-4b82-b520-a45d9f828632"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6037), "product-1-720x480.jpg" },
                    { new Guid("0c4e9a29-e655-4e03-9888-b27d6453e61f"), new Guid("5794e310-0363-4b82-b520-a45d9f828632"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6039), "product-2-720x480.jpg" },
                    { new Guid("41bb69c8-42a2-41c7-844c-89d3b179a544"), new Guid("5794e310-0363-4b82-b520-a45d9f828632"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6042), "product-3-720x480.jpg" },
                    { new Guid("1b599409-fe47-421e-a7a9-cf285e57ab9e"), new Guid("5794e310-0363-4b82-b520-a45d9f828632"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6044), "product-4-720x480.jpg" },
                    { new Guid("dbc2764a-5aa1-457f-9bc1-698fec9b7633"), new Guid("5794e310-0363-4b82-b520-a45d9f828632"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6046), "product-5-720x480.jpg" },
                    { new Guid("df9d3718-471d-410e-801c-5844ce95e068"), new Guid("5794e310-0363-4b82-b520-a45d9f828632"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6047), "product-6-720x480.jpg" },
                    { new Guid("5d62b334-d8f3-49e3-9fc4-e5df34cc6c83"), new Guid("409574f1-415c-484e-8a04-292e54a46987"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6091), "product-1-720x480.jpg" },
                    { new Guid("c5ccab3d-9beb-4a98-bbc7-f3093abc728e"), new Guid("409574f1-415c-484e-8a04-292e54a46987"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6095), "product-2-720x480.jpg" },
                    { new Guid("54771ae8-5179-43ec-a07d-2038a764aed3"), new Guid("409574f1-415c-484e-8a04-292e54a46987"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6097), "product-3-720x480.jpg" },
                    { new Guid("514493de-1e51-4f17-ac91-ddd2a16b984d"), new Guid("409574f1-415c-484e-8a04-292e54a46987"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6098), "product-4-720x480.jpg" },
                    { new Guid("52d08e7a-83fd-41b1-9aaf-d0846daa1e65"), new Guid("409574f1-415c-484e-8a04-292e54a46987"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6100), "product-5-720x480.jpg" },
                    { new Guid("0e67b7ee-d3d7-449d-aed1-de60d71ae977"), new Guid("e2402c75-86ba-449c-8793-c1e3f14f8cab"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6290), "product-1-720x480.jpg" },
                    { new Guid("e641cefb-a609-4925-9dda-93c3bccfabab"), new Guid("8b5ca1a3-2591-488a-9908-dacc1e3135e8"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6243), "product-6-720x480.jpg" },
                    { new Guid("669b6fb4-0f3c-4232-bf76-d02cb8cef8f7"), new Guid("8b5ca1a3-2591-488a-9908-dacc1e3135e8"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6242), "product-5-720x480.jpg" },
                    { new Guid("528b6737-dac9-465c-9866-15a5680bba8d"), new Guid("8b5ca1a3-2591-488a-9908-dacc1e3135e8"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6240), "product-4-720x480.jpg" },
                    { new Guid("29945468-1520-4dc1-b8c0-653c1a7ba853"), new Guid("8b5ca1a3-2591-488a-9908-dacc1e3135e8"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6238), "product-3-720x480.jpg" },
                    { new Guid("38ed5705-7624-4234-bc34-c51eba5239c2"), new Guid("8b5ca1a3-2591-488a-9908-dacc1e3135e8"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6237), "product-2-720x480.jpg" },
                    { new Guid("579559ab-09af-411a-9485-e2439e59f47a"), new Guid("6e777935-04e6-4bec-b847-65f5b2e9624d"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5937), "product-6-720x480.jpg" },
                    { new Guid("ea1f0d34-11e2-4a2f-94d1-35a3cf5290b7"), new Guid("8b5ca1a3-2591-488a-9908-dacc1e3135e8"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6235), "product-1-720x480.jpg" },
                    { new Guid("9519e05a-1bf7-4720-9296-fff63611ef63"), new Guid("b2bf5119-29f3-43f0-b826-1b317e148bff"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6155), "product-5-720x480.jpg" },
                    { new Guid("594afbbe-c0d7-46a9-b9b9-843f40da9bef"), new Guid("b2bf5119-29f3-43f0-b826-1b317e148bff"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6153), "product-4-720x480.jpg" },
                    { new Guid("fd22caa9-282e-4059-ab42-63fe83e2464c"), new Guid("b2bf5119-29f3-43f0-b826-1b317e148bff"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6152), "product-3-720x480.jpg" },
                    { new Guid("d161c08c-95b0-4a90-aa05-143cdb485656"), new Guid("b2bf5119-29f3-43f0-b826-1b317e148bff"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6150), "product-2-720x480.jpg" },
                    { new Guid("494a18c5-b2b7-4fde-8cee-449578443ab9"), new Guid("b2bf5119-29f3-43f0-b826-1b317e148bff"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6148), "product-1-720x480.jpg" },
                    { new Guid("1678fbb8-bb4c-4947-b1a6-e884328e3363"), new Guid("409574f1-415c-484e-8a04-292e54a46987"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6101), "product-6-720x480.jpg" },
                    { new Guid("467fd91a-6da5-46f6-9e84-c07ed2f4d289"), new Guid("b2bf5119-29f3-43f0-b826-1b317e148bff"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(6156), "product-6-720x480.jpg" },
                    { new Guid("d5c5b1d6-acd5-4af5-a6e0-91e74683cc97"), new Guid("6e777935-04e6-4bec-b847-65f5b2e9624d"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5936), "product-5-720x480.jpg" },
                    { new Guid("969ae267-434c-44eb-a6b4-fc0e83301c90"), new Guid("6e777935-04e6-4bec-b847-65f5b2e9624d"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5932), "product-4-720x480.jpg" },
                    { new Guid("82e280b3-75bf-4383-bf93-260c8f10452e"), new Guid("6e777935-04e6-4bec-b847-65f5b2e9624d"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5930), "product-3-720x480.jpg" },
                    { new Guid("1cd73458-08c9-402c-88f6-64c887564d17"), new Guid("08f08604-fd3e-4667-bfe2-136fbfc2d1cc"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5733), "product-2-720x480.jpg" },
                    { new Guid("09a8f9ec-c683-4b72-aa94-313b020a7b25"), new Guid("08f08604-fd3e-4667-bfe2-136fbfc2d1cc"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5731), "product-1-720x480.jpg" },
                    { new Guid("888cec63-889b-478a-9bd9-da870fbf3e0b"), new Guid("c8aeb7cb-eaf8-464a-898b-af3628714454"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5683), "product-6-720x480.jpg" },
                    { new Guid("0cce9030-dc23-4a2a-aefe-d64e13122460"), new Guid("c8aeb7cb-eaf8-464a-898b-af3628714454"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5681), "product-5-720x480.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CarId", "CreatedAt", "Path" },
                values: new object[,]
                {
                    { new Guid("3f8dcdcb-b46b-4bff-b0d7-e6a7faa04acc"), new Guid("c8aeb7cb-eaf8-464a-898b-af3628714454"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5680), "product-4-720x480.jpg" },
                    { new Guid("6623f123-d904-445b-a71a-94210eafc868"), new Guid("c8aeb7cb-eaf8-464a-898b-af3628714454"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5678), "product-3-720x480.jpg" },
                    { new Guid("f389b178-5f4e-442e-8ce4-6843bf5558c5"), new Guid("08f08604-fd3e-4667-bfe2-136fbfc2d1cc"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5734), "product-3-720x480.jpg" },
                    { new Guid("45f437d2-0d07-4e5e-89db-b3096b7bbb86"), new Guid("c8aeb7cb-eaf8-464a-898b-af3628714454"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5677), "product-2-720x480.jpg" },
                    { new Guid("cdf2600c-bb9a-48a2-aaf5-41d77bcb920e"), new Guid("81651c38-5bc4-48e6-aed9-7bd4e075c200"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5624), "product-6-720x480.jpg" },
                    { new Guid("2eddbd6c-5225-49df-8306-a26f9a947aca"), new Guid("81651c38-5bc4-48e6-aed9-7bd4e075c200"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5622), "product-5-720x480.jpg" },
                    { new Guid("20cfdf42-b71e-45a5-aa76-a340d5ca3335"), new Guid("81651c38-5bc4-48e6-aed9-7bd4e075c200"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5620), "product-4-720x480.jpg" },
                    { new Guid("2568f250-bf0b-4a90-a9b8-15aeb5766854"), new Guid("81651c38-5bc4-48e6-aed9-7bd4e075c200"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5594), "product-3-720x480.jpg" },
                    { new Guid("1feaa1f2-895d-49e9-b265-d5f938cef2d6"), new Guid("81651c38-5bc4-48e6-aed9-7bd4e075c200"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5593), "product-2-720x480.jpg" },
                    { new Guid("848fb55f-deca-43c1-8dc9-9ea35e962ead"), new Guid("81651c38-5bc4-48e6-aed9-7bd4e075c200"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5589), "product-1-720x480.jpg" },
                    { new Guid("c01d012e-5fda-4938-b4e2-1058a8fcf4d6"), new Guid("c8aeb7cb-eaf8-464a-898b-af3628714454"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5675), "product-1-720x480.jpg" },
                    { new Guid("91070824-f744-4231-9859-e2f411a66953"), new Guid("a6061979-15a5-427d-8563-f5d247ce7af5"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5542), "product-5-720x480.jpg" },
                    { new Guid("7f928014-034e-49ad-b0e9-e4a468852ad0"), new Guid("08f08604-fd3e-4667-bfe2-136fbfc2d1cc"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5736), "product-4-720x480.jpg" },
                    { new Guid("878fc27b-8ef9-4fdd-a807-766a6cdc1e14"), new Guid("08f08604-fd3e-4667-bfe2-136fbfc2d1cc"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5739), "product-6-720x480.jpg" },
                    { new Guid("3396d9a3-2ef7-410d-9145-e0768292b575"), new Guid("6e777935-04e6-4bec-b847-65f5b2e9624d"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5929), "product-2-720x480.jpg" },
                    { new Guid("20e7aed1-8478-424a-a8ac-ecffda6cacb4"), new Guid("6e777935-04e6-4bec-b847-65f5b2e9624d"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5927), "product-1-720x480.jpg" },
                    { new Guid("1117f14b-72a0-4ee3-9076-2537a3155ee4"), new Guid("257b9770-9173-47ff-99e6-fd5e2722a840"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5855), "product-6-720x480.jpg" },
                    { new Guid("d44121f6-9d70-44d6-8e81-5c1e21125038"), new Guid("257b9770-9173-47ff-99e6-fd5e2722a840"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5852), "product-5-720x480.jpg" },
                    { new Guid("b9289fcc-1707-4058-a7e0-8605359fc99d"), new Guid("257b9770-9173-47ff-99e6-fd5e2722a840"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5850), "product-4-720x480.jpg" },
                    { new Guid("3c91c2cd-3427-4222-ba7f-f8ba24a5cab1"), new Guid("257b9770-9173-47ff-99e6-fd5e2722a840"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5848), "product-3-720x480.jpg" },
                    { new Guid("4e16281c-9b9a-440f-b5c8-223d22ed39b7"), new Guid("08f08604-fd3e-4667-bfe2-136fbfc2d1cc"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5737), "product-5-720x480.jpg" },
                    { new Guid("869c7065-803a-4814-8f31-b5d76cac0f26"), new Guid("257b9770-9173-47ff-99e6-fd5e2722a840"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5847), "product-2-720x480.jpg" },
                    { new Guid("1a1511a8-e666-40d8-996a-7407c0edaa84"), new Guid("a261a1a0-71b7-422c-abf7-e32f8996f3ba"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5794), "product-6-720x480.jpg" },
                    { new Guid("3f87b380-635d-48d2-8bbe-983b646c00bc"), new Guid("a261a1a0-71b7-422c-abf7-e32f8996f3ba"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5793), "product-5-720x480.jpg" },
                    { new Guid("fdc1c43d-0fe9-4b58-89a0-f0a89df59e33"), new Guid("a261a1a0-71b7-422c-abf7-e32f8996f3ba"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5791), "product-4-720x480.jpg" },
                    { new Guid("bd86bed5-671d-4cfd-9eb2-0bb98f41380c"), new Guid("a261a1a0-71b7-422c-abf7-e32f8996f3ba"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5789), "product-3-720x480.jpg" },
                    { new Guid("804c9ce4-5e58-4a72-b80c-6abde592c4fa"), new Guid("a261a1a0-71b7-422c-abf7-e32f8996f3ba"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5788), "product-2-720x480.jpg" },
                    { new Guid("1910fb46-274d-452c-a560-ec00e364d448"), new Guid("a261a1a0-71b7-422c-abf7-e32f8996f3ba"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5786), "product-1-720x480.jpg" },
                    { new Guid("2636355f-38b1-44d6-8da8-838e54379adc"), new Guid("257b9770-9173-47ff-99e6-fd5e2722a840"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(5845), "product-1-720x480.jpg" },
                    { new Guid("251aa7b4-bafa-446f-a7bb-b23aa39c9299"), new Guid("921fb099-c8c0-4a2e-8c90-6c4af522a8a6"), new DateTime(2021, 10, 4, 20, 43, 40, 465, DateTimeKind.Local).AddTicks(7743), "product-6-720x480.jpg" }
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
