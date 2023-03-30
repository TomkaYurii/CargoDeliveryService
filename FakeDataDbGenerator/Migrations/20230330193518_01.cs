using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FakeDataDriverDbGenerator.Migrations
{
    public partial class _01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoID);
                });

            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    TruckID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TruckNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FuelConsumption = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VIN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EngineNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChassisNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InsurancePolicyNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InsuranceExpirationDate = table.Column<DateTime>(type: "date", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.TruckID);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IdentificationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdentificationExpirationDate = table.Column<DateTime>(type: "date", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DriverLicenseNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DriverLicenseCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DriverLicenseIssuingDate = table.Column<DateTime>(type: "date", nullable: false),
                    DriverLicenseExpirationDate = table.Column<DateTime>(type: "date", nullable: false),
                    DriverLicenseIssuingAuthority = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmploymentStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmploymentStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    EmploymentEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    PhotoID = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverID);
                    table.ForeignKey(
                        name: "FK__Drivers__Company__3B75D760",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID");
                    table.ForeignKey(
                        name: "FK__Drivers__PhotoID__3C69FB99",
                        column: x => x.PhotoID,
                        principalTable: "Photos",
                        principalColumn: "PhotoID");
                });

            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    InspectionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionDate = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Result = table.Column<bool>(type: "bit", nullable: false),
                    TruckID = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.InspectionID);
                    table.ForeignKey(
                        name: "FK__Inspectio__Truck__300424B4",
                        column: x => x.TruckID,
                        principalTable: "Trucks",
                        principalColumn: "TruckID");
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    RepairID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepairDate = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TruckID = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.RepairID);
                    table.ForeignKey(
                        name: "FK__Repairs__TruckID__34C8D9D1",
                        column: x => x.TruckID,
                        principalTable: "Trucks",
                        principalColumn: "TruckID");
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpensesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverID = table.Column<int>(type: "int", nullable: false),
                    TruckID = table.Column<int>(type: "int", nullable: false),
                    DriverPayment = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FuelCost = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    MaintenanceCost = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Category = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Expenses__DFC8A07C5CE04B84", x => x.ExpensesID);
                    table.ForeignKey(
                        name: "FK__Expenses__Driver__412EB0B6",
                        column: x => x.DriverID,
                        principalTable: "Drivers",
                        principalColumn: "DriverID");
                    table.ForeignKey(
                        name: "FK__Expenses__TruckI__4222D4EF",
                        column: x => x.TruckID,
                        principalTable: "Trucks",
                        principalColumn: "TruckID");
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyID", "Address", "CompanyName", "ContactEmail", "ContactPerson", "ContactPhone", "CreatedAt", "DeletedAt", "Email", "Phone" },
                values: new object[,]
                {
                    { 1, "1602 Fidel Village, Port Marisol, Niue", "Brown and Sons", "Maria.Pagac@yahoo.com", "Maximillian Ankunding", "980-855-2963", new DateTime(2022, 11, 21, 22, 4, 3, 674, DateTimeKind.Local).AddTicks(2264), null, "Elody_Senger71@hotmail.com", "477-690-1371" },
                    { 2, "07005 Kilback Flat, East Mayra, Djibouti", "Jakubowski, Cummerata and Wyman", "Jeffery_Heaney@gmail.com", "Evan Stanton", "760-702-2495", new DateTime(2022, 8, 16, 14, 16, 10, 143, DateTimeKind.Local).AddTicks(9548), null, "Mathew.Walsh3@gmail.com", "703-237-8869" },
                    { 3, "3358 Demarco Village, Alexanderton, Trinidad and Tobago", "Predovic Group", "Jeffery_Kertzmann@yahoo.com", "Dedrick Labadie", "285-748-6858", new DateTime(2022, 10, 21, 9, 0, 37, 672, DateTimeKind.Local).AddTicks(2637), null, "Karson.Hirthe@yahoo.com", "274-825-4094" },
                    { 4, "72535 Kirlin Mall, Legrosmouth, Kuwait", "Zboncak, Maggio and Jenkins", "Maxime_Leannon@gmail.com", "Ashtyn Batz", "910-425-8470", new DateTime(2022, 5, 15, 15, 25, 17, 614, DateTimeKind.Local).AddTicks(4344), null, "Elizabeth_Ondricka@yahoo.com", "838-864-0031" },
                    { 5, "5193 Corkery Village, North Jaylanland, Venezuela", "Graham - Gislason", "Clotilde_Batz@yahoo.com", "Eloise Bruen", "517-917-3198", new DateTime(2022, 5, 12, 22, 51, 10, 530, DateTimeKind.Local).AddTicks(5650), null, "Timothy77@hotmail.com", "224-808-7172" },
                    { 6, "471 Klein Roads, McLaughlinville, San Marino", "Mayert, Windler and Smitham", "Ariel_Hoeger@gmail.com", "Melyna Conn", "704-233-1359", new DateTime(2023, 3, 25, 17, 2, 57, 244, DateTimeKind.Local).AddTicks(6392), null, "Gunner.Doyle3@gmail.com", "586-763-0123" },
                    { 7, "8849 Baumbach Villages, North Shanny, India", "Swaniawski - Olson", "Vesta_Raynor@yahoo.com", "Berta Cruickshank", "281-259-8610", new DateTime(2023, 2, 5, 11, 14, 43, 958, DateTimeKind.Local).AddTicks(7105), null, "Albin_Kshlerin29@hotmail.com", "880-475-1430" },
                    { 8, "2171 Jacklyn Vista, Kristintown, Cyprus", "Cruickshank, Hessel and Gleason", "Rolando_Beer@gmail.com", "Jordan Dickens", "568-274-6961", new DateTime(2022, 12, 19, 5, 26, 30, 672, DateTimeKind.Local).AddTicks(7837), null, "Nigel56@yahoo.com", "948-983-8468" },
                    { 9, "05948 Trevion Ville, East Macfurt, Micronesia", "Koch - Beer", "Laverne.Balistreri@yahoo.com", "Ozella Cremin", "580-642-2267", new DateTime(2022, 6, 21, 1, 19, 3, 487, DateTimeKind.Local).AddTicks(8798), null, "Ernestine_Langosh21@gmail.com", "900-851-5362" },
                    { 10, "96256 Jadon Field, Gorczanyton, Comoros", "Rolfson, Rosenbaum and Pouros", "Myrtis54@yahoo.com", "Dawn Collier", "310-461-4841", new DateTime(2022, 9, 3, 5, 2, 2, 574, DateTimeKind.Local).AddTicks(5528), null, "Briana31@gmail.com", "913-365-6958" },
                    { 11, "33301 Roberta Vista, New Stellaport, Slovenia", "Bayer - Koch", "Arlene67@yahoo.com", "Diego Kub", "382-329-7457", new DateTime(2022, 7, 22, 19, 18, 10, 67, DateTimeKind.Local).AddTicks(9034), null, "Trisha_Friesen@yahoo.com", "925-688-7635" },
                    { 12, "61887 Jakob Lodge, South Sven, Jamaica", "Hayes, Crist and Carter", "Heber80@yahoo.com", "Edythe Sipes", "453-977-0962", new DateTime(2022, 6, 10, 9, 34, 17, 561, DateTimeKind.Local).AddTicks(2587), null, "Nathanial.Morissette@hotmail.com", "247-902-8221" },
                    { 13, "50865 Renner Vista, North Callieborough, Austria", "Murray - Steuber", "Magnus_Johnson57@hotmail.com", "Chloe Hansen", "853-343-5772", new DateTime(2023, 3, 6, 5, 43, 40, 277, DateTimeKind.Local).AddTicks(7371), null, "Kathryn_Yost31@gmail.com", "250-415-9817" },
                    { 14, "7463 Daugherty Lodge, Lake Oswald, Samoa", "Walsh LLC", "Edwin67@hotmail.com", "Brown Walter", "436-697-9261", new DateTime(2022, 9, 24, 3, 14, 40, 713, DateTimeKind.Local).AddTicks(3364), null, "Francesco.Jerde@hotmail.com", "707-762-3905" },
                    { 15, "883 Murazik Vista, Port Dorcasport, Iceland", "Erdman - Funk", "Raven_Abshire@hotmail.com", "Guiseppe Harber", "444-969-4087", new DateTime(2022, 8, 19, 11, 26, 51, 898, DateTimeKind.Local).AddTicks(8874), null, "Willie72@hotmail.com", "301-485-5211" },
                    { 16, "9109 Blanda Loop, Pedroville, Angola", "Langworth Group", "Shayne_Sauer33@yahoo.com", "Mortimer Hudson", "322-500-7120", new DateTime(2022, 12, 22, 18, 38, 47, 534, DateTimeKind.Local).AddTicks(6634), null, "Lea.Wisoky66@hotmail.com", "615-997-6628" },
                    { 17, "058 Juana Walk, Emmanuelburgh, Thailand", "Schneider - O'Conner", "Clint.Strosin72@hotmail.com", "Jalen Waters", "354-519-2654", new DateTime(2022, 6, 9, 3, 51, 14, 269, DateTimeKind.Local).AddTicks(9858), null, "Katheryn77@yahoo.com", "751-280-0893" },
                    { 18, "29550 Wallace Mall, McCulloughburgh, Israel", "Boyle and Sons", "Jaime_Ritchie50@yahoo.com", "Idell Walter", "664-913-7433", new DateTime(2022, 5, 31, 12, 5, 37, 787, DateTimeKind.Local).AddTicks(1854), null, "Joshua.Mayert53@hotmail.com", "322-320-3414" },
                    { 19, "322 Heather Walks, New Filiberto, Falkland Islands (Malvinas)", "Huel - Beatty", "Thurman_Legros0@yahoo.com", "Jada Wehner", "557-435-7099", new DateTime(2022, 7, 6, 13, 36, 4, 527, DateTimeKind.Local).AddTicks(5679), null, "Dominic.Koelpin20@hotmail.com", "971-863-5265" },
                    { 20, "46003 Sandra Manor, Wunschport, Estonia", "Pfannerstill LLC", "Gwendolyn.Connelly86@yahoo.com", "Eunice Kuhn", "750-773-8255", new DateTime(2022, 7, 6, 3, 43, 17, 508, DateTimeKind.Local).AddTicks(663), null, "Antonetta_Dickens@gmail.com", "504-373-0631" }
                });

            migrationBuilder.InsertData(
                table: "Trucks",
                columns: new[] { "TruckID", "Capacity", "ChassisNumber", "CreatedAt", "DeletedAt", "EngineNumber", "FuelConsumption", "FuelType", "InsuranceExpirationDate", "InsurancePolicyNumber", "Model", "RegistrationNumber", "TruckNumber", "VIN", "Year" },
                values: new object[,]
                {
                    { 1, 690, "3d1a3e2c-eee3-4666-9d0b-7cfb72350517", new DateTime(2022, 7, 27, 10, 2, 9, 790, DateTimeKind.Local).AddTicks(5610), null, "1e9cf761-f142-4269-be61-7de5a9d52b0b", 3.461385633079980m, "Electric", new DateTime(2023, 9, 5, 21, 46, 39, 782, DateTimeKind.Local).AddTicks(2636), "f332a97c-2b3e-4f54-9e13-cc15e45df38a", "CX-9", "PPY35DS6SBVV60067", "83GRNFCX3NA838810", "PP0ZTU2II9ZO44795", 2022 },
                    { 2, 351, "6265caa3-9194-4b2a-b2ab-3cf79b7d6eb6", new DateTime(2022, 9, 8, 23, 37, 48, 760, DateTimeKind.Local).AddTicks(8795), null, "d90345b6-f65a-4782-be1a-28bb71027a9d", 1.941382941296968m, "Gasoline", new DateTime(2024, 3, 16, 21, 1, 6, 760, DateTimeKind.Local).AddTicks(2522), "7651155a-c6cb-4625-9920-a00927c6ba93", "Wrangler", "Q32CBQWTNXCO93294", "RE5Z3BSG80T110680", "Z31CUOQO31H954980", 2022 },
                    { 3, 914, "5c306bdb-6370-4803-b547-5c989dfdc0ab", new DateTime(2022, 10, 22, 13, 13, 27, 731, DateTimeKind.Local).AddTicks(1897), null, "ff517cc2-a5d2-4e42-907e-c3b5cd1d5042", 4.421380249513956m, "Diesel", new DateTime(2023, 9, 25, 20, 15, 33, 738, DateTimeKind.Local).AddTicks(2290), "9555d697-56fb-4ce3-983c-eab992a2dc9b", "Focus", "RH7LH2ZGIJJH36519", "APV7K69YCDNT72551", "8I2OWIFUNTOU65165", 2023 },
                    { 4, 576, "165d4386-8c7e-44a9-8277-ea951fc96a6d", new DateTime(2022, 12, 5, 2, 49, 6, 701, DateTimeKind.Local).AddTicks(4990), null, "49697cfd-2a35-4811-bfca-2b49ba2a9000", 2.901377557730944m, "Gasoline", new DateTime(2023, 4, 5, 19, 30, 0, 716, DateTimeKind.Local).AddTicks(2048), "de0fb26a-299c-4496-b8b5-ccb0ddf472b9", "Roadster", "SVCTOF33D5QA69745", "TZKE01PGHQGL44422", "IW31XC318KVE75350", 2022 },
                    { 5, 237, "d4cd6d64-2a93-4b0f-9b47-95f239340fb7", new DateTime(2023, 1, 17, 16, 24, 45, 671, DateTimeKind.Local).AddTicks(8096), null, "a3820a10-46b3-4684-b050-8a0bb9aed9fe", 1.3813748659479316m, "Hybrid", new DateTime(2023, 10, 15, 18, 44, 27, 694, DateTimeKind.Local).AddTicks(1819), "337e40ab-8ecf-4419-a43a-93b1ccb167f7", "Explorer", "T9H2US6Q8SY312971", "CA9MGX5YL4ZD16292", "RB4DZ6S7SCCZ85535", 2022 },
                    { 6, 800, "b606e629-06a6-4cee-88ea-91b69b26e8f3", new DateTime(2023, 3, 2, 6, 0, 24, 642, DateTimeKind.Local).AddTicks(1195), null, "b6e19656-0b23-4521-a6c7-2e5858ba5873", 3.86137217416492m, "Electric", new DateTime(2023, 4, 25, 17, 58, 54, 672, DateTimeKind.Local).AddTicks(1580), "550c98cc-6cd7-40ed-af81-1989a4c54219", "Camry", "UMMB04AD3EFW46197", "UKYUWSLGPHS578163", "1P5Q00GDD4JJ95720", 2023 },
                    { 7, 462, "46f17355-0399-4e4f-8a8b-9449cb28915f", new DateTime(2022, 4, 14, 19, 36, 3, 612, DateTimeKind.Local).AddTicks(4340), null, "ad581d10-ba36-4662-8a81-94a08945191b", 2.341369482381908m, "Hybrid", new DateTime(2023, 11, 4, 17, 13, 21, 650, DateTimeKind.Local).AddTicks(1387), "e8b93164-f883-4f42-be56-b593edb21878", "F-150", "V0QK6HD1Y0MP79423", "DVN1DO1YUULX50033", "A4532T5JXVR415904", 2022 },
                    { 8, 123, "07f77817-0fbe-4305-b302-67299c74a863", new DateTime(2022, 5, 28, 9, 11, 42, 582, DateTimeKind.Local).AddTicks(7464), null, "7e4fcee2-79d3-445c-9d49-063cd8522487", 4.821366790598896m, "Diesel", new DateTime(2023, 5, 15, 16, 27, 48, 628, DateTimeKind.Local).AddTicks(1185), "31226960-babd-4154-907a-c3a091eb2053", "Land Cruiser", "WEVTCTHOTNTI22649", "W5C9TJHGY8EP21904", "KI6F3NTPHNYP26088", 2022 },
                    { 9, 686, "29aa2f73-e9c9-45fd-8bc9-19189fc9c8fc", new DateTime(2022, 7, 10, 22, 47, 21, 553, DateTimeKind.Local).AddTicks(556), null, "ea995827-e385-4ea6-a38d-222a2a3f320a", 3.301364098815884m, "Gasoline", new DateTime(2023, 11, 24, 15, 42, 15, 606, DateTimeKind.Local).AddTicks(942), "d3c01138-ae59-4492-927b-7630deba6acd", "Ranchero", "XS02I6KBO9AB55875", "FG2H9FXY3LXH83775", "TW7S5HIV2EF936273", 2022 },
                    { 10, 348, "be106360-d41e-4a5b-ab3e-43509e3332b4", new DateTime(2022, 8, 23, 12, 23, 0, 523, DateTimeKind.Local).AddTicks(3649), null, "660b8061-da07-4c28-90b4-facc510d7db5", 1.781361407032872m, "Diesel", new DateTime(2023, 6, 4, 14, 56, 42, 584, DateTimeKind.Local).AddTicks(699), "7167c019-d79c-4f86-be1a-670c40b00e47", "Civic", "Y65AOIOYJVI489102", "YRROPADG7YR955645", "3B847B72M6MU46458", 2022 },
                    { 11, 910, "1e1003a5-f589-4141-9c64-9eb5bd77c10e", new DateTime(2022, 10, 6, 1, 58, 39, 493, DateTimeKind.Local).AddTicks(6744), null, "8dc9a12b-bed2-49fa-bb1d-4377eeb31b37", 4.261358715249856m, "Electric", new DateTime(2023, 12, 14, 14, 11, 9, 562, DateTimeKind.Local).AddTicks(460), "935ffeef-f5d2-4a73-a5ef-36f79e3d6f90", "Malibu", "ZKAJUVSLEIPX32327", "H1GW66UYCBK127516", "CP9H85V87YUE56643", 2022 },
                    { 12, 572, "ae19fe12-3407-4a9d-8ea1-320689da2863", new DateTime(2022, 11, 18, 15, 34, 18, 463, DateTimeKind.Local).AddTicks(9834), null, "ba01248d-3bb4-4b2a-9483-98ba3e697e1f", 2.741356023466848m, "Hybrid", new DateTime(2023, 6, 24, 13, 25, 36, 540, DateTimeKind.Local).AddTicks(217), "ab3b0987-e4bd-4f02-aa0f-0ec67933a290", "Altima", "0YES08V894WQ65553", "ZC54M1AGGPDU89387", "M4ATAYKERPBZ66828", 2022 },
                    { 13, 234, "dc3fb9c0-ff1e-4ad8-baae-997c9768f81a", new DateTime(2023, 1, 1, 5, 9, 57, 434, DateTimeKind.Local).AddTicks(2923), null, "b420c212-303e-4e71-9718-b49e39d6d3ba", 1.2213533316838336m, "Electric", new DateTime(2024, 1, 3, 12, 40, 3, 517, DateTimeKind.Local).AddTicks(9970), "8d452613-960c-4db0-8eee-56f0bd3d9247", "Camaro", "1CJ16KZV3QDJ98780", "IMUB2XQYL2WM61257", "VIB6BS8KCHIK77013", 2023 },
                    { 14, 797, "fb85a490-14c0-4860-8946-773b10030f0e", new DateTime(2023, 2, 13, 18, 45, 36, 404, DateTimeKind.Local).AddTicks(6016), null, "cb728112-5dd7-41a9-bc5a-36cc91653f30", 3.701350639900820m, "Gasoline", new DateTime(2023, 7, 14, 11, 54, 30, 495, DateTimeKind.Local).AddTicks(9730), "9542e603-b8cb-4b24-954a-aa72d63c00ae", "A4", "2QOACX2JYDKC42005", "1XJJIS6GPFPE33127", "5XCJDMXQW9P487198", 2022 },
                    { 15, 458, "12e0f2bd-3530-4591-a79a-6cfdf3bec48c", new DateTime(2023, 3, 29, 8, 21, 15, 374, DateTimeKind.Local).AddTicks(9106), null, "9434fefa-877f-43da-984f-89de6530e35d", 2.181347948117808m, "Diesel", new DateTime(2024, 1, 23, 11, 8, 57, 473, DateTimeKind.Local).AddTicks(9485), "36299c77-209f-4cee-9496-ad468bd34068", "Colorado", "24TJI966TZR575231", "K79RZOMYTSI694999", "EBDVEGLWH0WP97383", 2022 },
                    { 16, 120, "d70f4e6f-e1bb-4ecc-9f67-e3cb6a5b4cb4", new DateTime(2022, 5, 11, 21, 56, 54, 345, DateTimeKind.Local).AddTicks(2201), null, "0ffabacf-cb42-4a7e-b277-75dfc0dd91e1", 4.661345256334796m, "Gasoline", new DateTime(2023, 8, 3, 10, 23, 24, 451, DateTimeKind.Local).AddTicks(9245), "c59c2dfd-0ebd-4ae7-bbbe-638e260b5142", "Golf", "3IXRPM9TOLZY18457", "3IYZFJ2GY6CY66869", "OQE8GAA21SE917566", 2023 },
                    { 17, 683, "c48594ff-97f4-4c9c-bd7d-d0600b042e30", new DateTime(2022, 6, 24, 11, 32, 33, 315, DateTimeKind.Local).AddTicks(5294), null, "74ccc2fe-8b2d-476a-899d-c5b08ce38b0e", 3.141342564551784m, "Diesel", new DateTime(2024, 2, 12, 9, 37, 51, 429, DateTimeKind.Local).AddTicks(9004), "21fe38a9-2186-485e-a531-4fd1d1897736", "CTS", "4W20VYDGJ7GR51683", "LSN6VEIY2JVQ38739", "X4EKH4Y9LKLU27751", 2022 },
                    { 18, 344, "c69e6327-5c2e-43d8-af15-11586ea232af", new DateTime(2022, 8, 7, 1, 8, 12, 285, DateTimeKind.Local).AddTicks(8384), null, "05a21273-69a6-46b7-8dcc-4901a1147b81", 1.621339872768772m, "Electric", new DateTime(2023, 8, 23, 8, 52, 18, 407, DateTimeKind.Local).AddTicks(8759), "1a31dfeb-3317-4f09-8b95-26b86f824f4f", "Spyder", "5A791BG3EUNK84909", "43CEBAYH7WOI10610", "7JFXJXNF6BSF37936", 2022 },
                    { 19, 907, "22833f03-9460-4fe7-977c-200bc73f9cc1", new DateTime(2022, 9, 19, 14, 43, 51, 256, DateTimeKind.Local).AddTicks(1472), null, "314bca01-c5c0-4493-907f-7b92a5a5631f", 4.10133718098576m, "Hybrid", new DateTime(2024, 3, 3, 8, 6, 45, 385, DateTimeKind.Local).AddTicks(8513), "dd3ba6fe-ca6a-4633-80b3-f3ffbacc7da6", "ATS", "6OCI7OKQ9GUD28135", "NE1MS5FZBAHA72481", "GXG9LRBLQ3ZZ48121", 2022 },
                    { 20, 569, "c1f72f8b-8480-4dbd-81fc-aef5093f2598", new DateTime(2022, 11, 2, 4, 19, 30, 226, DateTimeKind.Local).AddTicks(4567), null, "dbdd9c4a-ff0a-478d-8228-68b102feffe5", 2.581334489202748m, "Electric", new DateTime(2023, 9, 12, 7, 21, 12, 363, DateTimeKind.Local).AddTicks(8273), "79eacf2c-5c59-4726-89b9-ea24cdf4e88c", "Mercielago", "72HRD0NE42B661361", "6OQT81VHGNA244351", "PCHMML0RBUHK58306", 2022 }
                });

            migrationBuilder.InsertData(
                table: "Inspections",
                columns: new[] { "InspectionID", "CreatedAt", "DeletedAt", "Description", "InspectionDate", "Result", "TruckID" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 23, 23, 24, 46, 474, DateTimeKind.Local).AddTicks(5947), null, "totam", new DateTime(2022, 12, 30, 4, 15, 6, 119, DateTimeKind.Local).AddTicks(2247), false, 14 },
                    { 2, new DateTime(2023, 3, 26, 20, 25, 5, 581, DateTimeKind.Local).AddTicks(475), null, "Maiores aut nemo et.", new DateTime(2022, 6, 22, 11, 48, 21, 410, DateTimeKind.Local).AddTicks(9929), true, 5 },
                    { 3, new DateTime(2022, 10, 21, 9, 0, 37, 675, DateTimeKind.Local).AddTicks(1377), null, "Natus dolor magnam rerum.\nVel quas consequatur optio doloremque.\nEt quia at.\nVoluptatum numquam qui et vitae asperiores blanditiis excepturi unde.\nDolores exercitationem et quas veritatis est.\nSint nihil vero distinctio consequatur unde quo laborum corrupti iusto.", new DateTime(2022, 12, 13, 19, 21, 36, 702, DateTimeKind.Local).AddTicks(7340), true, 11 },
                    { 4, new DateTime(2022, 6, 1, 23, 43, 19, 268, DateTimeKind.Local).AddTicks(7794), null, "Aut illo optio ducimus rem placeat. Officia eum omnis dolor. Perspiciatis voluptatum repellendus eos ut eum libero. Sunt aspernatur quis dolorem et corporis. Molestias et sunt eaque itaque nisi odit doloremque.", new DateTime(2022, 6, 6, 2, 54, 51, 994, DateTimeKind.Local).AddTicks(4861), true, 12 },
                    { 5, new DateTime(2022, 4, 8, 20, 41, 32, 346, DateTimeKind.Local).AddTicks(9704), null, "Fuga laudantium non ratione hic.", new DateTime(2022, 11, 27, 10, 28, 7, 286, DateTimeKind.Local).AddTicks(2320), false, 3 },
                    { 6, new DateTime(2022, 9, 3, 4, 42, 7, 944, DateTimeKind.Local).AddTicks(8094), null, "Repudiandae et deserunt qui quisquam corrupti quo voluptatem possimus.\nSit omnis eum porro voluptas quidem laborum.\nConsequatur magni quis eum explicabo.\nSed repudiandae ea aperiam impedit eos.\nVoluptatem alias rem quis commodi aut eum omnis.\nQuasi beatae vel omnis minus perferendis odit nihil voluptatibus impedit.", new DateTime(2022, 5, 20, 18, 1, 22, 577, DateTimeKind.Local).AddTicks(9695), true, 11 },
                    { 7, new DateTime(2022, 8, 1, 18, 30, 41, 640, DateTimeKind.Local).AddTicks(8444), null, "Consequatur cum ipsa. Nulla at ducimus recusandae dignissimos aut aut ea aut suscipit. Accusantium placeat error quia deleniti iure doloremque tenetur accusantium. Porro est exercitationem aut neque dicta. Eum voluptatem ut.", new DateTime(2022, 11, 11, 1, 34, 37, 869, DateTimeKind.Local).AddTicks(7187), false, 18 },
                    { 8, new DateTime(2022, 9, 11, 3, 59, 57, 853, DateTimeKind.Local).AddTicks(9090), null, "ea", new DateTime(2022, 5, 4, 9, 7, 53, 161, DateTimeKind.Local).AddTicks(4702), true, 17 },
                    { 9, new DateTime(2023, 2, 25, 17, 25, 40, 795, DateTimeKind.Local).AddTicks(9463), null, "Deleniti enim nihil.", new DateTime(2022, 10, 25, 16, 41, 8, 453, DateTimeKind.Local).AddTicks(2052), false, 20 },
                    { 10, new DateTime(2023, 1, 17, 23, 1, 41, 915, DateTimeKind.Local).AddTicks(642), null, "Quisquam ullam iure praesentium numquam sapiente distinctio ad. Tempore voluptatibus ad et adipisci hic amet. Corporis soluta cupiditate soluta. Provident rerum nemo dolores debitis dicta voluptatem labore dolores adipisci. Adipisci illo quidem sit dolores. Ea dolor animi quod laborum quia perspiciatis sunt tempora.", new DateTime(2022, 4, 18, 0, 14, 23, 744, DateTimeKind.Local).AddTicks(9416), false, 11 },
                    { 11, new DateTime(2023, 1, 27, 5, 57, 54, 159, DateTimeKind.Local).AddTicks(3113), null, "blanditiis", new DateTime(2022, 10, 9, 7, 47, 39, 36, DateTimeKind.Local).AddTicks(6922), false, 4 },
                    { 12, new DateTime(2022, 7, 18, 21, 49, 19, 428, DateTimeKind.Local).AddTicks(7070), null, "Sed fuga quae veniam.", new DateTime(2022, 4, 1, 15, 20, 54, 328, DateTimeKind.Local).AddTicks(4271), true, 10 },
                    { 13, new DateTime(2022, 9, 4, 2, 29, 54, 765, DateTimeKind.Local).AddTicks(5337), null, "Architecto sint qui delectus qui.\nAccusamus et similique.\nVitae voluptatem voluptas illo.\nUt perspiciatis eaque.\nSunt aut necessitatibus aut.\nEos omnis maiores debitis cupiditate ipsam sit voluptas.", new DateTime(2022, 9, 22, 22, 54, 9, 620, DateTimeKind.Local).AddTicks(1630), false, 5 },
                    { 14, new DateTime(2022, 4, 28, 9, 58, 26, 339, DateTimeKind.Local).AddTicks(810), null, "Non autem dolor laudantium impedit iusto id. Aliquam facere dolor est placeat cum. Id cum veniam. Et quasi provident ut commodi. Ex ex qui molestiae laboriosam provident.", new DateTime(2023, 3, 16, 6, 27, 24, 911, DateTimeKind.Local).AddTicks(9066), true, 13 },
                    { 15, new DateTime(2022, 7, 30, 8, 35, 9, 233, DateTimeKind.Local).AddTicks(1752), null, "magnam", new DateTime(2022, 9, 6, 14, 0, 40, 203, DateTimeKind.Local).AddTicks(6491), false, 20 },
                    { 16, new DateTime(2022, 12, 22, 18, 38, 47, 537, DateTimeKind.Local).AddTicks(2593), null, "Et ut architecto totam a quia beatae a harum autem.\nVoluptatem officia repudiandae aut.\nEarum est optio dolorum ut illum est.\nDelectus delectus explicabo libero minus reprehenderit incidunt.\nVeniam veniam vitae ipsa temporibus neque.\nVitae nisi rerum dolor impedit.", new DateTime(2023, 2, 27, 21, 33, 55, 495, DateTimeKind.Local).AddTicks(3839), false, 7 },
                    { 17, new DateTime(2023, 2, 17, 22, 33, 20, 939, DateTimeKind.Local).AddTicks(5574), null, "Aut esse cupiditate ut. Perspiciatis illum quod. Ipsam aut est aut sed. Eveniet architecto sit et. Consequatur praesentium unde modi et est laudantium non dolores esse.", new DateTime(2022, 8, 21, 5, 7, 10, 787, DateTimeKind.Local).AddTicks(1298), false, 10 },
                    { 18, new DateTime(2022, 12, 15, 10, 33, 5, 538, DateTimeKind.Local).AddTicks(5782), null, "aliquid", new DateTime(2023, 2, 11, 12, 40, 26, 78, DateTimeKind.Local).AddTicks(8718), true, 7 },
                    { 19, new DateTime(2022, 12, 1, 3, 50, 42, 153, DateTimeKind.Local).AddTicks(4527), null, "Laborum repellendus neque.", new DateTime(2022, 8, 4, 20, 13, 41, 370, DateTimeKind.Local).AddTicks(6066), true, 20 },
                    { 20, new DateTime(2022, 9, 6, 20, 25, 1, 881, DateTimeKind.Local).AddTicks(4740), null, "Ut eaque et voluptatum qui est accusantium vitae eum.\nVoluptatibus occaecati enim qui eius inventore voluptatum facere quis.\nDistinctio reprehenderit magni.\nQuasi amet sunt.\nLaboriosam corrupti fuga et mollitia aut assumenda ipsam.", new DateTime(2023, 1, 26, 3, 46, 56, 662, DateTimeKind.Local).AddTicks(3421), false, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Drivers__21B7B583AB601A5C",
                table: "Drivers",
                column: "PhotoID",
                unique: true,
                filter: "[PhotoID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Drivers__2D971C4D3AD2DF5B",
                table: "Drivers",
                column: "CompanyID",
                unique: true,
                filter: "[CompanyID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_DriverID",
                table: "Expenses",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_TruckID",
                table: "Expenses",
                column: "TruckID");

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_TruckID",
                table: "Inspections",
                column: "TruckID");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_TruckID",
                table: "Repairs",
                column: "TruckID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Inspections");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Trucks");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Photos");
        }
    }
}
