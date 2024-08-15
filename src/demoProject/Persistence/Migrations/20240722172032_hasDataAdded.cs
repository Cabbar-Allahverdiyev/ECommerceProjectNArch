using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class hasDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "BarcodeCode", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("371761a2-7d3f-4e19-9cf4-b239682bdfe6"), "869", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Turkey", null },
                    { new Guid("4d83615f-3f69-4bca-af67-0327732f1b16"), "476", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Azerbaijan", null }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "DiscountPercent", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("29cd040b-0fc0-4696-a576-ee1bc0eebd88"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", 25m, "Ela endirim", null },
                    { new Guid("fb6389c9-1be1-4ca6-afd5-c1f8cd7bd24b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", 15m, "Ucuz endirim", null }
                });

            migrationBuilder.InsertData(
                table: "ProductBrands",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("883115c1-4b59-49f8-a5c4-475ac35844de"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sauvage", null },
                    { new Guid("f53b5344-170c-405a-81a2-680f90b1f471"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Azzaro", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "ParentId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("30215044-9536-429f-b6d8-d903edac9a9c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "rahat dasimaq", "Elektronika", null, null },
                    { new Guid("a71686ff-6fc1-40f8-8945-c0970d379d66"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asan əlaqə", "Telefon", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductColors",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1f39f7f2-fad3-4f07-a594-9cd5e2476af4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Red", null },
                    { new Guid("7c25a489-22ba-45ed-a2d6-137099a3fec1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orange", null },
                    { new Guid("9c64e97a-9fb0-4468-afe2-ec2f1522422f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blue", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 197, 195, 107, 37, 158, 50, 178, 78, 209, 224, 88, 250, 47, 164, 133, 120, 99, 49, 27, 140, 89, 11, 9, 212, 48, 131, 123, 251, 102, 79, 202, 250, 163, 198, 236, 71, 221, 155, 137, 232, 28, 124, 119, 148, 171, 218, 140, 148, 6, 141, 175, 107, 184, 41, 247, 203, 74, 217, 144, 136, 234, 213, 111, 51 }, new byte[] { 208, 6, 151, 245, 143, 102, 157, 38, 195, 91, 185, 130, 85, 206, 179, 12, 244, 255, 74, 247, 47, 138, 189, 133, 165, 95, 196, 210, 136, 123, 217, 202, 204, 187, 207, 243, 110, 22, 98, 138, 187, 228, 186, 65, 140, 98, 145, 204, 144, 75, 41, 183, 39, 245, 35, 48, 46, 224, 96, 79, 63, 38, 166, 221, 99, 138, 214, 46, 67, 199, 121, 155, 247, 89, 133, 39, 229, 77, 20, 214, 26, 254, 15, 197, 199, 222, 223, 6, 192, 148, 84, 164, 48, 119, 194, 156, 15, 243, 63, 133, 25, 16, 120, 13, 192, 108, 35, 106, 58, 29, 169, 144, 219, 241, 205, 230, 41, 75, 111, 27, 35, 187, 6, 47, 48, 77, 27, 77 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 197, 195, 107, 37, 158, 50, 178, 78, 209, 224, 88, 250, 47, 164, 133, 120, 99, 49, 27, 140, 89, 11, 9, 212, 48, 131, 123, 251, 102, 79, 202, 250, 163, 198, 236, 71, 221, 155, 137, 232, 28, 124, 119, 148, 171, 218, 140, 148, 6, 141, 175, 107, 184, 41, 247, 203, 74, 217, 144, 136, 234, 213, 111, 51 }, new byte[] { 208, 6, 151, 245, 143, 102, 157, 38, 195, 91, 185, 130, 85, 206, 179, 12, 244, 255, 74, 247, 47, 138, 189, 133, 165, 95, 196, 210, 136, 123, 217, 202, 204, 187, 207, 243, 110, 22, 98, 138, 187, 228, 186, 65, 140, 98, 145, 204, 144, 75, 41, 183, 39, 245, 35, 48, 46, 224, 96, 79, 63, 38, 166, 221, 99, 138, 214, 46, 67, 199, 121, 155, 247, 89, 133, 39, 229, 77, 20, 214, 26, 254, 15, 197, 199, 222, 223, 6, 192, 148, 84, 164, 48, 119, 194, 156, 15, 243, 63, 133, 25, 16, 120, 13, 192, 108, 35, 106, 58, 29, 169, 144, 219, 241, 205, 230, 41, 75, 111, 27, 35, 187, 6, 47, 48, 77, 27, 77 } });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("11f2e239-099e-45ee-91fe-4e5395c4fa9c"), new Guid("4d83615f-3f69-4bca-af67-0327732f1b16"), new DateTime(2024, 7, 22, 17, 20, 31, 285, DateTimeKind.Utc).AddTicks(4484), null, "Baku", null },
                    { new Guid("3bb7dbc8-e8d6-4e5f-af28-3359e6ad48de"), new Guid("371761a2-7d3f-4e19-9cf4-b239682bdfe6"), new DateTime(2024, 7, 22, 17, 20, 31, 285, DateTimeKind.Utc).AddTicks(4543), null, "Yevlakh", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "ParentId", "UpdatedDate" },
                values: new object[] { new Guid("c39728de-00ca-4570-82a0-f10249f35b78"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asan əlaqə", "Telefon", new Guid("30215044-9536-429f-b6d8-d903edac9a9c"), null });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "CityId", "CreatedDate", "DeletedDate", "Email", "Name", "PhoneNumber", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("08d03584-74e9-4870-a067-04ad3f947843"), "yyyyy", "aaaa", new Guid("11f2e239-099e-45ee-91fe-4e5395c4fa9c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "aaa@aaa.com", "ABC", "0554696363", null },
                    { new Guid("79ad5fe6-f396-426a-b69d-5fe781e1a023"), "aaaaaa", "aaaaaa", new Guid("3bb7dbc8-e8d6-4e5f-af28-3359e6ad48de"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "avd@ads.com", "Telefon", "0554446655", null }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "BarcodeCode", "CompanyId", "CreatedDate", "DeletedDate", "Description", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e344460e-e26c-4b39-84f2-4ac148b988b7"), "0001", new Guid("08d03584-74e9-4870-a067-04ad3f947843"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "stajci satici", null, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedDate", "DeletedDate", "Description", "DiscountId", "IsDiscontinued", "Name", "ProductColorId", "PurchasePrice", "QuantityPerUnit", "ReorderLevel", "SKU", "SupplierId", "UnitPrice", "UnitsOnOrder", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("d9a74510-192d-4cca-9194-0c1ebdad60aa"), new Guid("883115c1-4b59-49f8-a5c4-475ac35844de"), new Guid("a71686ff-6fc1-40f8-8945-c0970d379d66"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new Guid("29cd040b-0fc0-4696-a576-ee1bc0eebd88"), true, "Duxlu nausnik 1", new Guid("9c64e97a-9fb0-4468-afe2-ec2f1522422f"), 6m, "1x1", 0, "DUX_NAUSNIK11", new Guid("e344460e-e26c-4b39-84f2-4ac148b988b7"), 9m, 0, null },
                    { new Guid("dc725763-5c8c-4096-ba15-ae149132ef9c"), new Guid("f53b5344-170c-405a-81a2-680f90b1f471"), new Guid("30215044-9536-429f-b6d8-d903edac9a9c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new Guid("fb6389c9-1be1-4ca6-afd5-c1f8cd7bd24b"), true, "Duxlu nausnik", new Guid("1f39f7f2-fad3-4f07-a594-9cd5e2476af4"), 6m, "1x1", 0, "DUX_NAUSNIK", new Guid("e344460e-e26c-4b39-84f2-4ac148b988b7"), 9m, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Barcodes",
                columns: new[] { "Id", "BarcodeNumber", "CreatedDate", "DeletedDate", "ProductId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("59b9b6a0-c5ef-48e9-bcf3-da25fa3109e2"), "6281020104549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("dc725763-5c8c-4096-ba15-ae149132ef9c"), null },
                    { new Guid("f380a73e-c2c1-453a-8f5c-577050bacc4e"), "5901234123457", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("d9a74510-192d-4cca-9194-0c1ebdad60aa"), null }
                });

            migrationBuilder.InsertData(
                table: "ProductInventors",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "ProductId", "Quantity", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0849bc9c-39ab-449a-ae1d-a8c363d62948"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("d9a74510-192d-4cca-9194-0c1ebdad60aa"), 26, null },
                    { new Guid("0997f786-62cb-4709-bad6-7e393cd756fe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("dc725763-5c8c-4096-ba15-ae149132ef9c"), 5, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barcodes",
                keyColumn: "Id",
                keyValue: new Guid("59b9b6a0-c5ef-48e9-bcf3-da25fa3109e2"));

            migrationBuilder.DeleteData(
                table: "Barcodes",
                keyColumn: "Id",
                keyValue: new Guid("f380a73e-c2c1-453a-8f5c-577050bacc4e"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("79ad5fe6-f396-426a-b69d-5fe781e1a023"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("c39728de-00ca-4570-82a0-f10249f35b78"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("7c25a489-22ba-45ed-a2d6-137099a3fec1"));

            migrationBuilder.DeleteData(
                table: "ProductInventors",
                keyColumn: "Id",
                keyValue: new Guid("0849bc9c-39ab-449a-ae1d-a8c363d62948"));

            migrationBuilder.DeleteData(
                table: "ProductInventors",
                keyColumn: "Id",
                keyValue: new Guid("0997f786-62cb-4709-bad6-7e393cd756fe"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3bb7dbc8-e8d6-4e5f-af28-3359e6ad48de"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d9a74510-192d-4cca-9194-0c1ebdad60aa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dc725763-5c8c-4096-ba15-ae149132ef9c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("371761a2-7d3f-4e19-9cf4-b239682bdfe6"));

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("29cd040b-0fc0-4696-a576-ee1bc0eebd88"));

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("fb6389c9-1be1-4ca6-afd5-c1f8cd7bd24b"));

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: new Guid("883115c1-4b59-49f8-a5c4-475ac35844de"));

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: new Guid("f53b5344-170c-405a-81a2-680f90b1f471"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("30215044-9536-429f-b6d8-d903edac9a9c"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("a71686ff-6fc1-40f8-8945-c0970d379d66"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("1f39f7f2-fad3-4f07-a594-9cd5e2476af4"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("9c64e97a-9fb0-4468-afe2-ec2f1522422f"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("e344460e-e26c-4b39-84f2-4ac148b988b7"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("08d03584-74e9-4870-a067-04ad3f947843"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("11f2e239-099e-45ee-91fe-4e5395c4fa9c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4d83615f-3f69-4bca-af67-0327732f1b16"));

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
    }
}
