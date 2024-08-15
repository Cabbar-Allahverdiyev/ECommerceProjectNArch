using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class productAndBarcodeReleationshipsRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Barcodes_Products_Id",
                table: "Barcodes");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("5fac637e-4aab-443d-82fd-df142248ef1f"));

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("470bd373-660c-4c9a-846a-fc5968e777e3"));

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("a1a6eb70-3a04-433f-a9f5-e08f4bb1c264"));

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: new Guid("286bd8f3-e70c-4e7b-af84-6acb62446a4d"));

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: new Guid("cebfa3aa-47ef-4cd9-9b3e-69891773c2bb"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("62005739-1c00-4c6e-acf1-a8d91de16c87"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("fdebf5d9-3931-4337-b876-bdf1c0bbdbfa"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("1930c95e-461a-4c6a-aa9e-85a3d973b748"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("5a16a2ed-8665-4c79-ad52-4ea1f9cca598"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("86199dd2-94f0-4333-8836-de66bfc5bab7"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("f71a8ea6-7077-4bf2-9c62-f053348a8813"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("40d3e9dd-5596-4b64-aad9-56865e54895f"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("a352c4c0-eb1f-4e4a-919b-05e359b656d1"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("c2548d72-2ee3-40a5-8042-1a6ef974048f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3826063b-c321-42a8-a1cf-9695714d5b80"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("29681908-fabc-4eca-8fd1-a34927d1b9e6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("c5ac9bc7-9f3f-4d45-85c0-d188f88352dd"));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("ca23712f-5b5f-4d06-88d5-6a92e5a9a302"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Turkey", null },
                    { new Guid("f8bcc1a0-2c50-466c-b7af-4abb632cf5e3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Azerbaijan", null }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "DiscountPercent", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("73b3e472-3c95-499a-a704-7de5dcac86dc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", 15m, "Ucuz endirim", null },
                    { new Guid("ff04e34c-7714-49f2-8ed0-f52a004e0e44"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", 25m, "Ela endirim", null }
                });

            migrationBuilder.InsertData(
                table: "ProductBrands",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1f503738-40ce-4560-a481-9d4f621dd2da"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Azzaro", null },
                    { new Guid("ed9ab63e-2982-4e28-9209-dd795030df81"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sauvage", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "ParentId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("4b88bf6e-81f1-4505-847f-012e87232c63"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asan əlaqə", "Telefon", null, null },
                    { new Guid("72b2c499-400d-48c6-8018-c878ebce8086"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "rahat dasimaq", "Elektronika", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductColors",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("46818329-db35-43f7-9050-a167a4ec5992"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blue", null },
                    { new Guid("6ba8eb10-7a8d-4b75-9e1b-744100a20ad8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orange", null },
                    { new Guid("f8ced97f-708d-43fe-a38f-a7efa6c35392"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Red", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 0, 113, 0, 221, 238, 254, 76, 170, 144, 186, 109, 157, 245, 36, 105, 108, 210, 28, 48, 153, 54, 35, 203, 130, 13, 239, 220, 134, 217, 130, 21, 130, 115, 118, 134, 94, 199, 74, 59, 251, 32, 253, 204, 16, 27, 57, 246, 218, 255, 156, 187, 139, 48, 16, 180, 215, 172, 74, 199, 12, 126, 154, 31, 224 }, new byte[] { 196, 207, 104, 29, 204, 201, 63, 162, 249, 76, 213, 83, 82, 191, 196, 219, 205, 48, 36, 229, 47, 40, 3, 243, 213, 209, 204, 32, 140, 49, 245, 229, 86, 215, 72, 193, 221, 225, 38, 179, 67, 102, 249, 69, 168, 36, 19, 244, 109, 145, 59, 197, 54, 215, 137, 38, 249, 191, 11, 200, 130, 181, 39, 99, 23, 37, 12, 13, 217, 56, 218, 254, 125, 156, 200, 57, 110, 141, 123, 138, 140, 232, 172, 156, 198, 136, 135, 203, 196, 23, 73, 5, 110, 94, 102, 220, 96, 197, 222, 212, 40, 215, 51, 145, 21, 88, 96, 192, 166, 29, 51, 81, 29, 102, 64, 242, 122, 33, 236, 141, 231, 235, 119, 67, 100, 237, 25, 86 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 0, 113, 0, 221, 238, 254, 76, 170, 144, 186, 109, 157, 245, 36, 105, 108, 210, 28, 48, 153, 54, 35, 203, 130, 13, 239, 220, 134, 217, 130, 21, 130, 115, 118, 134, 94, 199, 74, 59, 251, 32, 253, 204, 16, 27, 57, 246, 218, 255, 156, 187, 139, 48, 16, 180, 215, 172, 74, 199, 12, 126, 154, 31, 224 }, new byte[] { 196, 207, 104, 29, 204, 201, 63, 162, 249, 76, 213, 83, 82, 191, 196, 219, 205, 48, 36, 229, 47, 40, 3, 243, 213, 209, 204, 32, 140, 49, 245, 229, 86, 215, 72, 193, 221, 225, 38, 179, 67, 102, 249, 69, 168, 36, 19, 244, 109, 145, 59, 197, 54, 215, 137, 38, 249, 191, 11, 200, 130, 181, 39, 99, 23, 37, 12, 13, 217, 56, 218, 254, 125, 156, 200, 57, 110, 141, 123, 138, 140, 232, 172, 156, 198, 136, 135, 203, 196, 23, 73, 5, 110, 94, 102, 220, 96, 197, 222, 212, 40, 215, 51, 145, 21, 88, 96, 192, 166, 29, 51, 81, 29, 102, 64, 242, 122, 33, 236, 141, 231, 235, 119, 67, 100, 237, 25, 86 } });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("8d98a2ea-063a-496a-8319-43d369a82ed1"), new Guid("f8bcc1a0-2c50-466c-b7af-4abb632cf5e3"), new DateTime(2024, 7, 19, 18, 37, 14, 71, DateTimeKind.Utc).AddTicks(480), null, "Baku", null },
                    { new Guid("ce2278e3-b830-4ff4-9281-a7bf0e1927a2"), new Guid("ca23712f-5b5f-4d06-88d5-6a92e5a9a302"), new DateTime(2024, 7, 19, 18, 37, 14, 71, DateTimeKind.Utc).AddTicks(514), null, "Yevlakh", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "ParentId", "UpdatedDate" },
                values: new object[] { new Guid("fab03e85-7e2b-4141-840f-1a53cd29a330"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asan əlaqə", "Telefon", new Guid("72b2c499-400d-48c6-8018-c878ebce8086"), null });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "CityId", "CreatedDate", "DeletedDate", "Email", "Name", "PhoneNumber", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("ebfbdd76-9ce3-4f23-a0bf-b399bbdf177c"), "aaaaaa", "aaaaaa", new Guid("ce2278e3-b830-4ff4-9281-a7bf0e1927a2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "avd@ads.com", "Telefon", "0554446655", null },
                    { new Guid("f1540355-62b6-4741-9d0e-fe1ab29b6387"), "yyyyy", "aaaa", new Guid("8d98a2ea-063a-496a-8319-43d369a82ed1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "aaa@aaa.com", "ABC", "0554696363", null }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "CompanyId", "CreatedDate", "DeletedDate", "Description", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("3442b77e-f912-4312-9c7b-40d2bf64ae63"), new Guid("f1540355-62b6-4741-9d0e-fe1ab29b6387"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "stajci satici", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Barcodes_ProductId",
                table: "Barcodes",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Barcodes_Products_ProductId",
                table: "Barcodes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Barcodes_Products_ProductId",
                table: "Barcodes");

            migrationBuilder.DropIndex(
                name: "IX_Barcodes_ProductId",
                table: "Barcodes");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("ebfbdd76-9ce3-4f23-a0bf-b399bbdf177c"));

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("73b3e472-3c95-499a-a704-7de5dcac86dc"));

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("ff04e34c-7714-49f2-8ed0-f52a004e0e44"));

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: new Guid("1f503738-40ce-4560-a481-9d4f621dd2da"));

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: new Guid("ed9ab63e-2982-4e28-9209-dd795030df81"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("4b88bf6e-81f1-4505-847f-012e87232c63"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("fab03e85-7e2b-4141-840f-1a53cd29a330"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("46818329-db35-43f7-9050-a167a4ec5992"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("6ba8eb10-7a8d-4b75-9e1b-744100a20ad8"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("f8ced97f-708d-43fe-a38f-a7efa6c35392"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("3442b77e-f912-4312-9c7b-40d2bf64ae63"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ce2278e3-b830-4ff4-9281-a7bf0e1927a2"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("f1540355-62b6-4741-9d0e-fe1ab29b6387"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("72b2c499-400d-48c6-8018-c878ebce8086"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8d98a2ea-063a-496a-8319-43d369a82ed1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ca23712f-5b5f-4d06-88d5-6a92e5a9a302"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f8bcc1a0-2c50-466c-b7af-4abb632cf5e3"));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("29681908-fabc-4eca-8fd1-a34927d1b9e6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Turkey", null },
                    { new Guid("c5ac9bc7-9f3f-4d45-85c0-d188f88352dd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Azerbaijan", null }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "DiscountPercent", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("470bd373-660c-4c9a-846a-fc5968e777e3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", 15m, "Ucuz endirim", null },
                    { new Guid("a1a6eb70-3a04-433f-a9f5-e08f4bb1c264"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", 25m, "Ela endirim", null }
                });

            migrationBuilder.InsertData(
                table: "ProductBrands",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("286bd8f3-e70c-4e7b-af84-6acb62446a4d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sauvage", null },
                    { new Guid("cebfa3aa-47ef-4cd9-9b3e-69891773c2bb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Azzaro", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "ParentId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("62005739-1c00-4c6e-acf1-a8d91de16c87"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asan əlaqə", "Telefon", null, null },
                    { new Guid("c2548d72-2ee3-40a5-8042-1a6ef974048f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "rahat dasimaq", "Elektronika", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductColors",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1930c95e-461a-4c6a-aa9e-85a3d973b748"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Red", null },
                    { new Guid("5a16a2ed-8665-4c79-ad52-4ea1f9cca598"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orange", null },
                    { new Guid("86199dd2-94f0-4333-8836-de66bfc5bab7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blue", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 210, 178, 173, 143, 201, 118, 182, 78, 176, 194, 106, 19, 106, 25, 249, 54, 25, 188, 91, 1, 8, 10, 119, 188, 158, 141, 170, 183, 10, 19, 3, 71, 97, 175, 236, 86, 63, 108, 84, 64, 200, 90, 207, 141, 248, 39, 76, 206, 138, 95, 194, 192, 120, 233, 77, 18, 119, 68, 238, 161, 68, 240, 145, 139 }, new byte[] { 113, 212, 102, 76, 85, 106, 52, 23, 35, 97, 175, 129, 21, 27, 149, 253, 154, 169, 105, 210, 118, 20, 83, 123, 25, 174, 25, 41, 12, 115, 187, 141, 162, 162, 219, 223, 138, 85, 161, 38, 12, 230, 178, 121, 232, 29, 9, 93, 130, 127, 207, 43, 158, 212, 155, 13, 101, 210, 140, 123, 201, 148, 222, 23, 177, 202, 60, 229, 227, 74, 169, 15, 139, 255, 38, 51, 103, 74, 231, 58, 83, 249, 237, 5, 47, 49, 16, 21, 17, 224, 7, 62, 15, 5, 241, 223, 246, 82, 34, 102, 231, 203, 183, 3, 151, 175, 206, 80, 182, 17, 238, 238, 21, 56, 70, 220, 110, 17, 27, 38, 196, 146, 94, 69, 40, 193, 111, 232 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 210, 178, 173, 143, 201, 118, 182, 78, 176, 194, 106, 19, 106, 25, 249, 54, 25, 188, 91, 1, 8, 10, 119, 188, 158, 141, 170, 183, 10, 19, 3, 71, 97, 175, 236, 86, 63, 108, 84, 64, 200, 90, 207, 141, 248, 39, 76, 206, 138, 95, 194, 192, 120, 233, 77, 18, 119, 68, 238, 161, 68, 240, 145, 139 }, new byte[] { 113, 212, 102, 76, 85, 106, 52, 23, 35, 97, 175, 129, 21, 27, 149, 253, 154, 169, 105, 210, 118, 20, 83, 123, 25, 174, 25, 41, 12, 115, 187, 141, 162, 162, 219, 223, 138, 85, 161, 38, 12, 230, 178, 121, 232, 29, 9, 93, 130, 127, 207, 43, 158, 212, 155, 13, 101, 210, 140, 123, 201, 148, 222, 23, 177, 202, 60, 229, 227, 74, 169, 15, 139, 255, 38, 51, 103, 74, 231, 58, 83, 249, 237, 5, 47, 49, 16, 21, 17, 224, 7, 62, 15, 5, 241, 223, 246, 82, 34, 102, 231, 203, 183, 3, 151, 175, 206, 80, 182, 17, 238, 238, 21, 56, 70, 220, 110, 17, 27, 38, 196, 146, 94, 69, 40, 193, 111, 232 } });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("3826063b-c321-42a8-a1cf-9695714d5b80"), new Guid("c5ac9bc7-9f3f-4d45-85c0-d188f88352dd"), new DateTime(2024, 6, 12, 18, 19, 37, 984, DateTimeKind.Utc).AddTicks(4541), null, "Baku", null },
                    { new Guid("40d3e9dd-5596-4b64-aad9-56865e54895f"), new Guid("29681908-fabc-4eca-8fd1-a34927d1b9e6"), new DateTime(2024, 6, 12, 18, 19, 37, 984, DateTimeKind.Utc).AddTicks(4576), null, "Yevlakh", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "ParentId", "UpdatedDate" },
                values: new object[] { new Guid("fdebf5d9-3931-4337-b876-bdf1c0bbdbfa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asan əlaqə", "Telefon", new Guid("c2548d72-2ee3-40a5-8042-1a6ef974048f"), null });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "CityId", "CreatedDate", "DeletedDate", "Email", "Name", "PhoneNumber", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("5fac637e-4aab-443d-82fd-df142248ef1f"), "aaaaaa", "aaaaaa", new Guid("40d3e9dd-5596-4b64-aad9-56865e54895f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "avd@ads.com", "Telefon", "0554446655", null },
                    { new Guid("a352c4c0-eb1f-4e4a-919b-05e359b656d1"), "yyyyy", "aaaa", new Guid("3826063b-c321-42a8-a1cf-9695714d5b80"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "aaa@aaa.com", "ABC", "0554696363", null }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "CompanyId", "CreatedDate", "DeletedDate", "Description", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("f71a8ea6-7077-4bf2-9c62-f053348a8813"), new Guid("a352c4c0-eb1f-4e4a-919b-05e359b656d1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "stajci satici", null, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Barcodes_Products_Id",
                table: "Barcodes",
                column: "Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
