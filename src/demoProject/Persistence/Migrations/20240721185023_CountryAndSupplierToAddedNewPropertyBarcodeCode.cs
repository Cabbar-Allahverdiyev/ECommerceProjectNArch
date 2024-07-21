using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CountryAndSupplierToAddedNewPropertyBarcodeCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "BarcodeCode",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BarcodeCode",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "BarcodeCode", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("183ba9fa-ec6b-4b79-bb4a-9f6632a89b17"), "476", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Azerbaijan", null },
                    { new Guid("837f70ba-e67c-47dd-8fb7-c1a3d9fa6c88"), "869", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Turkey", null }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "DiscountPercent", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("232bb34f-3555-4b92-8de1-cc98dba57e9a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", 25m, "Ela endirim", null },
                    { new Guid("f3ad9925-41e6-4ecf-8f1a-3b07817ad2d4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", 15m, "Ucuz endirim", null }
                });

            migrationBuilder.InsertData(
                table: "ProductBrands",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("a0277573-d35b-42e6-8f06-e79af782c6d7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sauvage", null },
                    { new Guid("da089afe-b428-45ce-9738-7f2185b746d0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Azzaro", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "ParentId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("3461d6d8-38eb-4b5b-9e74-405002194a4e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "rahat dasimaq", "Elektronika", null, null },
                    { new Guid("52ebb90c-1345-4091-a182-9e0290b93e52"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asan əlaqə", "Telefon", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductColors",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("7d7a61e4-5b39-486e-b218-ed5919dcd33a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Red", null },
                    { new Guid("86188477-6697-426c-a9d7-205d895bfe08"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orange", null },
                    { new Guid("c8805ab4-0408-4ba7-b7d8-70920dbd3546"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blue", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 106, 191, 52, 214, 40, 246, 124, 110, 162, 141, 168, 222, 91, 206, 235, 216, 34, 166, 15, 167, 4, 106, 56, 212, 167, 14, 48, 166, 180, 20, 47, 48, 193, 16, 1, 2, 15, 30, 38, 208, 54, 60, 70, 165, 187, 194, 12, 237, 136, 85, 164, 167, 229, 55, 141, 164, 148, 217, 143, 174, 179, 6, 139, 67 }, new byte[] { 213, 214, 58, 153, 73, 27, 119, 147, 47, 155, 44, 250, 242, 202, 223, 154, 119, 233, 211, 60, 62, 185, 162, 15, 195, 78, 75, 243, 246, 154, 79, 10, 90, 194, 236, 31, 117, 170, 74, 29, 193, 41, 104, 24, 33, 182, 48, 211, 51, 117, 211, 159, 149, 56, 233, 13, 156, 192, 234, 245, 34, 31, 59, 77, 157, 149, 36, 78, 216, 212, 158, 53, 78, 10, 198, 173, 213, 195, 7, 153, 98, 53, 194, 73, 100, 123, 81, 181, 52, 171, 43, 223, 133, 69, 71, 37, 104, 224, 153, 177, 212, 57, 168, 2, 186, 82, 204, 205, 214, 208, 20, 202, 179, 133, 100, 106, 145, 34, 174, 85, 17, 49, 217, 15, 229, 98, 52, 161 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 106, 191, 52, 214, 40, 246, 124, 110, 162, 141, 168, 222, 91, 206, 235, 216, 34, 166, 15, 167, 4, 106, 56, 212, 167, 14, 48, 166, 180, 20, 47, 48, 193, 16, 1, 2, 15, 30, 38, 208, 54, 60, 70, 165, 187, 194, 12, 237, 136, 85, 164, 167, 229, 55, 141, 164, 148, 217, 143, 174, 179, 6, 139, 67 }, new byte[] { 213, 214, 58, 153, 73, 27, 119, 147, 47, 155, 44, 250, 242, 202, 223, 154, 119, 233, 211, 60, 62, 185, 162, 15, 195, 78, 75, 243, 246, 154, 79, 10, 90, 194, 236, 31, 117, 170, 74, 29, 193, 41, 104, 24, 33, 182, 48, 211, 51, 117, 211, 159, 149, 56, 233, 13, 156, 192, 234, 245, 34, 31, 59, 77, 157, 149, 36, 78, 216, 212, 158, 53, 78, 10, 198, 173, 213, 195, 7, 153, 98, 53, 194, 73, 100, 123, 81, 181, 52, 171, 43, 223, 133, 69, 71, 37, 104, 224, 153, 177, 212, 57, 168, 2, 186, 82, 204, 205, 214, 208, 20, 202, 179, 133, 100, 106, 145, 34, 174, 85, 17, 49, 217, 15, 229, 98, 52, 161 } });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("6d69c946-97ef-4819-a581-845d3bd0bda3"), new Guid("183ba9fa-ec6b-4b79-bb4a-9f6632a89b17"), new DateTime(2024, 7, 21, 18, 50, 21, 649, DateTimeKind.Utc).AddTicks(8610), null, "Baku", null },
                    { new Guid("c1087f03-0403-43c4-86df-ac94ca0ce01a"), new Guid("837f70ba-e67c-47dd-8fb7-c1a3d9fa6c88"), new DateTime(2024, 7, 21, 18, 50, 21, 651, DateTimeKind.Utc).AddTicks(6043), null, "Yevlakh", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "ParentId", "UpdatedDate" },
                values: new object[] { new Guid("ab61d90b-859e-427c-bfa8-75339ad879b5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asan əlaqə", "Telefon", new Guid("3461d6d8-38eb-4b5b-9e74-405002194a4e"), null });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "CityId", "CreatedDate", "DeletedDate", "Email", "Name", "PhoneNumber", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2f674c54-9e82-481b-bc51-e610dc631970"), "yyyyy", "aaaa", new Guid("6d69c946-97ef-4819-a581-845d3bd0bda3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "aaa@aaa.com", "ABC", "0554696363", null },
                    { new Guid("a5baa6df-34e7-49eb-8736-0936a6fa303e"), "aaaaaa", "aaaaaa", new Guid("c1087f03-0403-43c4-86df-ac94ca0ce01a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "avd@ads.com", "Telefon", "0554446655", null }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "BarcodeCode", "CompanyId", "CreatedDate", "DeletedDate", "Description", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("3514d4a2-f6fc-49b2-8cd4-898207598330"), "stajci satici", new Guid("2f674c54-9e82-481b-bc51-e610dc631970"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "0001", null, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("a5baa6df-34e7-49eb-8736-0936a6fa303e"));

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("232bb34f-3555-4b92-8de1-cc98dba57e9a"));

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("f3ad9925-41e6-4ecf-8f1a-3b07817ad2d4"));

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: new Guid("a0277573-d35b-42e6-8f06-e79af782c6d7"));

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: new Guid("da089afe-b428-45ce-9738-7f2185b746d0"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("52ebb90c-1345-4091-a182-9e0290b93e52"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("ab61d90b-859e-427c-bfa8-75339ad879b5"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("7d7a61e4-5b39-486e-b218-ed5919dcd33a"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("86188477-6697-426c-a9d7-205d895bfe08"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("c8805ab4-0408-4ba7-b7d8-70920dbd3546"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("3514d4a2-f6fc-49b2-8cd4-898207598330"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c1087f03-0403-43c4-86df-ac94ca0ce01a"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("2f674c54-9e82-481b-bc51-e610dc631970"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("3461d6d8-38eb-4b5b-9e74-405002194a4e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6d69c946-97ef-4819-a581-845d3bd0bda3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("837f70ba-e67c-47dd-8fb7-c1a3d9fa6c88"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("183ba9fa-ec6b-4b79-bb4a-9f6632a89b17"));

            migrationBuilder.DropColumn(
                name: "BarcodeCode",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "BarcodeCode",
                table: "Countries");

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
        }
    }
}
