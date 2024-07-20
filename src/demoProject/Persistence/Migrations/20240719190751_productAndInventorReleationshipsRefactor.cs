using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class productAndInventorReleationshipsRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInventors_Products_Id",
                table: "ProductInventors");

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
                    { new Guid("0ba4aa25-9ae8-4f78-9cc7-7d5bb31438e5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Turkey", null },
                    { new Guid("5f6a3a31-5c0d-4d22-8418-d3d39eb11ed4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Azerbaijan", null }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "DiscountPercent", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2266b295-02c1-43f8-a24b-18e876666e0d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", 25m, "Ela endirim", null },
                    { new Guid("2555afec-aa5a-4836-8fb6-e67685413750"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", 15m, "Ucuz endirim", null }
                });

            migrationBuilder.InsertData(
                table: "ProductBrands",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("39f982df-9def-404d-91b0-0cca86c4ad73"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Azzaro", null },
                    { new Guid("a9da6e9f-7430-44fc-acb5-8973e044ebf8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sauvage", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "ParentId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0d12fdbf-5b99-4f52-99d6-966eb3cfcb8e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asan əlaqə", "Telefon", null, null },
                    { new Guid("fed2f3b5-74a7-434c-8497-ba5f30ce269c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "rahat dasimaq", "Elektronika", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductColors",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("07892931-86ba-4f71-b1b2-d9b5ea6bd055"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orange", null },
                    { new Guid("95d01454-a91b-42b3-9f60-089c47c414e1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Red", null },
                    { new Guid("c43c0071-bf42-4459-8d85-d81bc88a879a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blue", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 3, 164, 22, 107, 246, 54, 90, 18, 200, 125, 115, 74, 188, 19, 4, 21, 112, 165, 167, 84, 53, 252, 6, 227, 192, 182, 59, 8, 18, 101, 35, 235, 188, 114, 219, 21, 201, 201, 161, 51, 44, 167, 5, 92, 142, 41, 119, 2, 147, 135, 40, 6, 170, 209, 107, 128, 245, 40, 72, 132, 205, 253, 222, 139 }, new byte[] { 192, 179, 97, 9, 84, 173, 252, 159, 205, 66, 46, 255, 99, 154, 67, 132, 246, 132, 48, 4, 18, 24, 190, 135, 139, 190, 183, 87, 133, 40, 29, 47, 243, 216, 57, 53, 255, 104, 188, 97, 188, 143, 37, 47, 47, 30, 191, 120, 177, 10, 185, 126, 18, 113, 128, 70, 188, 71, 159, 231, 210, 235, 165, 150, 95, 175, 76, 180, 77, 195, 38, 204, 39, 4, 60, 203, 27, 77, 81, 228, 105, 229, 171, 24, 171, 60, 175, 206, 21, 70, 85, 251, 192, 157, 216, 39, 101, 165, 124, 11, 205, 128, 145, 55, 68, 203, 185, 143, 207, 132, 135, 190, 149, 128, 192, 3, 116, 248, 248, 7, 45, 104, 72, 196, 110, 138, 209, 112 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 3, 164, 22, 107, 246, 54, 90, 18, 200, 125, 115, 74, 188, 19, 4, 21, 112, 165, 167, 84, 53, 252, 6, 227, 192, 182, 59, 8, 18, 101, 35, 235, 188, 114, 219, 21, 201, 201, 161, 51, 44, 167, 5, 92, 142, 41, 119, 2, 147, 135, 40, 6, 170, 209, 107, 128, 245, 40, 72, 132, 205, 253, 222, 139 }, new byte[] { 192, 179, 97, 9, 84, 173, 252, 159, 205, 66, 46, 255, 99, 154, 67, 132, 246, 132, 48, 4, 18, 24, 190, 135, 139, 190, 183, 87, 133, 40, 29, 47, 243, 216, 57, 53, 255, 104, 188, 97, 188, 143, 37, 47, 47, 30, 191, 120, 177, 10, 185, 126, 18, 113, 128, 70, 188, 71, 159, 231, 210, 235, 165, 150, 95, 175, 76, 180, 77, 195, 38, 204, 39, 4, 60, 203, 27, 77, 81, 228, 105, 229, 171, 24, 171, 60, 175, 206, 21, 70, 85, 251, 192, 157, 216, 39, 101, 165, 124, 11, 205, 128, 145, 55, 68, 203, 185, 143, 207, 132, 135, 190, 149, 128, 192, 3, 116, 248, 248, 7, 45, 104, 72, 196, 110, 138, 209, 112 } });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("ed5c8a30-9d03-4478-b5ee-a41ce1835fba"), new Guid("5f6a3a31-5c0d-4d22-8418-d3d39eb11ed4"), new DateTime(2024, 7, 19, 19, 7, 50, 905, DateTimeKind.Utc).AddTicks(3288), null, "Baku", null },
                    { new Guid("fd8cb7d5-9bad-4dad-b243-eb19c66290b7"), new Guid("0ba4aa25-9ae8-4f78-9cc7-7d5bb31438e5"), new DateTime(2024, 7, 19, 19, 7, 50, 905, DateTimeKind.Utc).AddTicks(3318), null, "Yevlakh", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "ParentId", "UpdatedDate" },
                values: new object[] { new Guid("24f84079-90ab-403b-8767-edd5fa9a9cc1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asan əlaqə", "Telefon", new Guid("fed2f3b5-74a7-434c-8497-ba5f30ce269c"), null });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "CityId", "CreatedDate", "DeletedDate", "Email", "Name", "PhoneNumber", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("3a7f5348-14a0-45cb-81ef-a8a367a313bb"), "aaaaaa", "aaaaaa", new Guid("fd8cb7d5-9bad-4dad-b243-eb19c66290b7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "avd@ads.com", "Telefon", "0554446655", null },
                    { new Guid("77adde36-920e-4fdd-ab43-f5811fe291bc"), "yyyyy", "aaaa", new Guid("ed5c8a30-9d03-4478-b5ee-a41ce1835fba"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "aaa@aaa.com", "ABC", "0554696363", null }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "CompanyId", "CreatedDate", "DeletedDate", "Description", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("70c78fac-ba80-400d-9291-bae78a41ccf3"), new Guid("77adde36-920e-4fdd-ab43-f5811fe291bc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "stajci satici", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventors_ProductId",
                table: "ProductInventors",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInventors_Products_ProductId",
                table: "ProductInventors",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInventors_Products_ProductId",
                table: "ProductInventors");

            migrationBuilder.DropIndex(
                name: "IX_ProductInventors_ProductId",
                table: "ProductInventors");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("3a7f5348-14a0-45cb-81ef-a8a367a313bb"));

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("2266b295-02c1-43f8-a24b-18e876666e0d"));

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("2555afec-aa5a-4836-8fb6-e67685413750"));

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: new Guid("39f982df-9def-404d-91b0-0cca86c4ad73"));

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: new Guid("a9da6e9f-7430-44fc-acb5-8973e044ebf8"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("0d12fdbf-5b99-4f52-99d6-966eb3cfcb8e"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("24f84079-90ab-403b-8767-edd5fa9a9cc1"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("07892931-86ba-4f71-b1b2-d9b5ea6bd055"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("95d01454-a91b-42b3-9f60-089c47c414e1"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("c43c0071-bf42-4459-8d85-d81bc88a879a"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("70c78fac-ba80-400d-9291-bae78a41ccf3"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("fd8cb7d5-9bad-4dad-b243-eb19c66290b7"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("77adde36-920e-4fdd-ab43-f5811fe291bc"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("fed2f3b5-74a7-434c-8497-ba5f30ce269c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ed5c8a30-9d03-4478-b5ee-a41ce1835fba"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("0ba4aa25-9ae8-4f78-9cc7-7d5bb31438e5"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5f6a3a31-5c0d-4d22-8418-d3d39eb11ed4"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInventors_Products_Id",
                table: "ProductInventors",
                column: "Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
