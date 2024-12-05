using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BarcodeSeedsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("f3746916-b133-4685-8010-c2590255b857"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("3745d31c-3360-439a-a7dc-e3dd4645f617"));

            migrationBuilder.DeleteData(
                table: "ProductInventors",
                keyColumn: "Id",
                keyValue: new Guid("1e70af7b-092c-4ff4-8899-93c65f5a4ab9"));

            migrationBuilder.DeleteData(
                table: "ProductInventors",
                keyColumn: "Id",
                keyValue: new Guid("76d537e7-04c7-4739-9ecb-cb5787783ae3"));

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: new Guid("5beb0a81-ce69-4358-a555-1a16bf40981a"));

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: new Guid("91fececc-1df5-415e-b7a3-ceaae98d3643"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("27c73a9f-379e-435e-9160-a63d825c39ba"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e7f0b22a-2271-4a47-87e3-9e3c3bdf0ff0"));

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: new Guid("ebe29b8d-e9e3-43b7-8d1c-04146e83de27"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("eb205408-b1a6-41bd-8aad-3c5a15ff5171"));

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("80ff4451-7697-446f-893f-ac8c516b4e4b"));

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("867b9d81-77fe-4f6d-81b7-dffb95db6ec8"));

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: new Guid("31200a85-3b5e-4274-a506-70b3eb774c5c"));

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: new Guid("f6fbe3b5-eb10-4a0f-a688-04ee831988ad"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("43d46df9-b8cd-4054-b1b8-f8a12597db5d"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("9da5dc05-54a4-4d86-975f-dd380312416a"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("0179459f-5718-4970-b52a-21bb98e17649"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("46ad1253-57df-4457-8165-6423f14ad73a"));

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: new Guid("a05423a0-927a-4a6c-8212-e56e17eb93b5"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("0a17687f-df99-47a3-b584-876ca7c9ab5d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("cda6beb7-77f6-4cf0-ac29-a91720887ead"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("73848228-3d82-45a0-adee-33c8e4d9da4a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8a90e7fe-7999-4968-bc69-37fdd50a9109"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("317bcfbf-ad89-4ee6-85af-16802f9085e4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("56cf5dbf-0998-43be-80e6-afc5c2f88247"));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "BarcodeCode", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("afa37450-60fd-4f7c-aa38-05d7c79d8c93"), "869", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Turkey", null },
                    { new Guid("e304e27a-f9c9-423a-a79a-3bc2bbad4019"), "476", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Azerbaijan", null }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "DiscountPercent", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("10c17ccb-41c2-4369-a79f-50df6cd0703a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", 25m, "Ela endirim", null },
                    { new Guid("5414e976-3ddc-4b6d-89a2-26f3fe475aad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", 15m, "Ucuz endirim", null }
                });

            migrationBuilder.InsertData(
                table: "ProductBrands",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("66ed352f-9912-463d-be86-dbbef9283efc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sauvage", null },
                    { new Guid("bb74ba70-1210-4934-a4cf-9db1704166e8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Azzaro", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "ParentId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("ab333d50-01e1-4706-8408-ecd0e0388da1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "rahat dasimaq", "Elektronika", null, null },
                    { new Guid("fffc98a1-e37d-4da9-8f21-77934f60a69b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asan əlaqə", "Telefon", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductColors",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("73a72973-a0dc-466c-abdf-5624355dea97"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orange", null },
                    { new Guid("8032b4a9-8aae-4581-b711-f507dbf80452"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Red", null },
                    { new Guid("8690f5de-923b-4421-93a3-15351d4fa729"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blue", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 119, 74, 200, 77, 57, 94, 159, 17, 145, 46, 21, 160, 179, 230, 132, 200, 18, 126, 88, 103, 46, 130, 171, 101, 130, 106, 190, 72, 56, 95, 111, 35, 235, 250, 217, 255, 128, 15, 154, 94, 38, 215, 155, 16, 245, 11, 7, 105, 116, 8, 147, 111, 251, 124, 34, 223, 69, 221, 229, 104, 7, 46, 39, 186 }, new byte[] { 191, 176, 89, 42, 252, 126, 76, 148, 189, 176, 223, 248, 132, 139, 105, 48, 142, 117, 48, 154, 221, 226, 74, 203, 254, 23, 219, 195, 155, 177, 19, 56, 93, 160, 157, 146, 132, 161, 198, 57, 73, 12, 83, 19, 196, 191, 243, 154, 119, 35, 219, 226, 76, 117, 245, 255, 21, 34, 79, 28, 213, 216, 116, 21, 181, 206, 171, 53, 25, 59, 101, 113, 198, 158, 130, 168, 218, 6, 198, 248, 139, 149, 74, 90, 249, 176, 235, 173, 111, 144, 71, 241, 118, 137, 243, 161, 74, 140, 23, 7, 182, 68, 201, 239, 5, 94, 2, 193, 152, 112, 185, 118, 138, 19, 90, 229, 239, 131, 6, 251, 226, 188, 69, 28, 148, 43, 218, 249 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 119, 74, 200, 77, 57, 94, 159, 17, 145, 46, 21, 160, 179, 230, 132, 200, 18, 126, 88, 103, 46, 130, 171, 101, 130, 106, 190, 72, 56, 95, 111, 35, 235, 250, 217, 255, 128, 15, 154, 94, 38, 215, 155, 16, 245, 11, 7, 105, 116, 8, 147, 111, 251, 124, 34, 223, 69, 221, 229, 104, 7, 46, 39, 186 }, new byte[] { 191, 176, 89, 42, 252, 126, 76, 148, 189, 176, 223, 248, 132, 139, 105, 48, 142, 117, 48, 154, 221, 226, 74, 203, 254, 23, 219, 195, 155, 177, 19, 56, 93, 160, 157, 146, 132, 161, 198, 57, 73, 12, 83, 19, 196, 191, 243, 154, 119, 35, 219, 226, 76, 117, 245, 255, 21, 34, 79, 28, 213, 216, 116, 21, 181, 206, 171, 53, 25, 59, 101, 113, 198, 158, 130, 168, 218, 6, 198, 248, 139, 149, 74, 90, 249, 176, 235, 173, 111, 144, 71, 241, 118, 137, 243, 161, 74, 140, 23, 7, 182, 68, 201, 239, 5, 94, 2, 193, 152, 112, 185, 118, 138, 19, 90, 229, 239, 131, 6, 251, 226, 188, 69, 28, 148, 43, 218, 249 } });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("6e8fef91-95d5-4ecd-ae1c-a10b2ff18a6d"), new Guid("e304e27a-f9c9-423a-a79a-3bc2bbad4019"), new DateTime(2024, 12, 5, 17, 26, 55, 726, DateTimeKind.Utc).AddTicks(520), null, "Baku", null },
                    { new Guid("b9520df1-a270-4e38-9ab0-7f703e928008"), new Guid("afa37450-60fd-4f7c-aa38-05d7c79d8c93"), new DateTime(2024, 12, 5, 17, 26, 55, 726, DateTimeKind.Utc).AddTicks(559), null, "Yevlakh", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "ParentId", "UpdatedDate" },
                values: new object[] { new Guid("7f922eaa-ec9e-414f-b241-82dffb3d4984"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asan əlaqə", "Telefon", new Guid("ab333d50-01e1-4706-8408-ecd0e0388da1"), null });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "CityId", "CreatedDate", "DeletedDate", "Email", "Name", "PhoneNumber", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("5b6e2cd1-680a-4bdc-870b-3f27f34ef01a"), "yyyyy", "aaaa", new Guid("6e8fef91-95d5-4ecd-ae1c-a10b2ff18a6d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "aaa@aaa.com", "ABC", "0554696363", null },
                    { new Guid("edbf47e5-ca10-42b6-9a40-a6336c5db87e"), "aaaaaa", "aaaaaa", new Guid("b9520df1-a270-4e38-9ab0-7f703e928008"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "avd@ads.com", "Telefon", "0554446655", null }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "CompanyId", "CreatedDate", "DeletedDate", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("0e7e96a8-d6fa-4d34-b933-5318e6aca59d"), new Guid("edbf47e5-ca10-42b6-9a40-a6336c5db87e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2 },
                    { new Guid("e1b6242d-db93-42dd-bdbe-b95228795a44"), new Guid("5b6e2cd1-680a-4bdc-870b-3f27f34ef01a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "BarcodeCode", "CompanyId", "CreatedDate", "DeletedDate", "Description", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d3d56d0e-ab61-4a03-97fa-76854d19057c"), "0001", new Guid("5b6e2cd1-680a-4bdc-870b-3f27f34ef01a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "stajci satici", null, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedDate", "DeletedDate", "Description", "DiscountId", "IsDiscontinued", "Name", "ProductColorId", "PurchasePrice", "QuantityPerUnit", "ReorderLevel", "SKU", "ShopId", "SupplierId", "UnitPrice", "UnitsOnOrder", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1717d3c8-6c31-4f25-89fc-a73a3d9237aa"), new Guid("bb74ba70-1210-4934-a4cf-9db1704166e8"), new Guid("ab333d50-01e1-4706-8408-ecd0e0388da1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new Guid("5414e976-3ddc-4b6d-89a2-26f3fe475aad"), true, "Duxlu nausnik", new Guid("8032b4a9-8aae-4581-b711-f507dbf80452"), 6m, "1x1", 0, "DUX_NAUSNIK", new Guid("e1b6242d-db93-42dd-bdbe-b95228795a44"), new Guid("d3d56d0e-ab61-4a03-97fa-76854d19057c"), 9m, 0, null },
                    { new Guid("2e40863e-cd40-4246-a563-8147c673525b"), new Guid("66ed352f-9912-463d-be86-dbbef9283efc"), new Guid("fffc98a1-e37d-4da9-8f21-77934f60a69b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new Guid("10c17ccb-41c2-4369-a79f-50df6cd0703a"), true, "Duxlu nausnik 1", new Guid("8690f5de-923b-4421-93a3-15351d4fa729"), 6m, "1x1", 0, "DUX_NAUSNIK11", new Guid("e1b6242d-db93-42dd-bdbe-b95228795a44"), new Guid("d3d56d0e-ab61-4a03-97fa-76854d19057c"), 9m, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "ShopId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("773f4b01-465f-4f2e-aff8-d742ae0e4c98"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("e1b6242d-db93-42dd-bdbe-b95228795a44"), null, 1 },
                    { new Guid("d95b14fa-c01f-409f-979f-5e2dbc4d5b62"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("0e7e96a8-d6fa-4d34-b933-5318e6aca59d"), null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Barcodes",
                columns: new[] { "Id", "BarcodeNumber", "CreatedDate", "DeletedDate", "ProductId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0d68598c-d541-44c0-8cf6-393f069ba5e3"), "5901234123457", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2e40863e-cd40-4246-a563-8147c673525b"), null },
                    { new Guid("fef94740-8dee-4533-9ccb-651a08cd0a6b"), "6281020104549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("1717d3c8-6c31-4f25-89fc-a73a3d9237aa"), null }
                });

            migrationBuilder.InsertData(
                table: "ProductInventors",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "ProductId", "Quantity", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("58e94efb-49c1-4cad-ba06-76ef1ead7b88"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("1717d3c8-6c31-4f25-89fc-a73a3d9237aa"), 5, null },
                    { new Guid("85f82add-bfe7-466a-b8c4-f965ed0bccc6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2e40863e-cd40-4246-a563-8147c673525b"), 26, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barcodes",
                keyColumn: "Id",
                keyValue: new Guid("0d68598c-d541-44c0-8cf6-393f069ba5e3"));

            migrationBuilder.DeleteData(
                table: "Barcodes",
                keyColumn: "Id",
                keyValue: new Guid("fef94740-8dee-4533-9ccb-651a08cd0a6b"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("7f922eaa-ec9e-414f-b241-82dffb3d4984"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("73a72973-a0dc-466c-abdf-5624355dea97"));

            migrationBuilder.DeleteData(
                table: "ProductInventors",
                keyColumn: "Id",
                keyValue: new Guid("58e94efb-49c1-4cad-ba06-76ef1ead7b88"));

            migrationBuilder.DeleteData(
                table: "ProductInventors",
                keyColumn: "Id",
                keyValue: new Guid("85f82add-bfe7-466a-b8c4-f965ed0bccc6"));

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: new Guid("773f4b01-465f-4f2e-aff8-d742ae0e4c98"));

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: new Guid("d95b14fa-c01f-409f-979f-5e2dbc4d5b62"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1717d3c8-6c31-4f25-89fc-a73a3d9237aa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2e40863e-cd40-4246-a563-8147c673525b"));

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: new Guid("0e7e96a8-d6fa-4d34-b933-5318e6aca59d"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("edbf47e5-ca10-42b6-9a40-a6336c5db87e"));

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("10c17ccb-41c2-4369-a79f-50df6cd0703a"));

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("5414e976-3ddc-4b6d-89a2-26f3fe475aad"));

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: new Guid("66ed352f-9912-463d-be86-dbbef9283efc"));

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: new Guid("bb74ba70-1210-4934-a4cf-9db1704166e8"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("ab333d50-01e1-4706-8408-ecd0e0388da1"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("fffc98a1-e37d-4da9-8f21-77934f60a69b"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("8032b4a9-8aae-4581-b711-f507dbf80452"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("8690f5de-923b-4421-93a3-15351d4fa729"));

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: new Guid("e1b6242d-db93-42dd-bdbe-b95228795a44"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("d3d56d0e-ab61-4a03-97fa-76854d19057c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b9520df1-a270-4e38-9ab0-7f703e928008"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("5b6e2cd1-680a-4bdc-870b-3f27f34ef01a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6e8fef91-95d5-4ecd-ae1c-a10b2ff18a6d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("afa37450-60fd-4f7c-aa38-05d7c79d8c93"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e304e27a-f9c9-423a-a79a-3bc2bbad4019"));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "BarcodeCode", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("317bcfbf-ad89-4ee6-85af-16802f9085e4"), "869", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Turkey", null },
                    { new Guid("56cf5dbf-0998-43be-80e6-afc5c2f88247"), "476", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Azerbaijan", null }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "DiscountPercent", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("80ff4451-7697-446f-893f-ac8c516b4e4b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", 25m, "Ela endirim", null },
                    { new Guid("867b9d81-77fe-4f6d-81b7-dffb95db6ec8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", 15m, "Ucuz endirim", null }
                });

            migrationBuilder.InsertData(
                table: "ProductBrands",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("31200a85-3b5e-4274-a506-70b3eb774c5c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Azzaro", null },
                    { new Guid("f6fbe3b5-eb10-4a0f-a688-04ee831988ad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sauvage", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "ParentId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("43d46df9-b8cd-4054-b1b8-f8a12597db5d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asan əlaqə", "Telefon", null, null },
                    { new Guid("9da5dc05-54a4-4d86-975f-dd380312416a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "rahat dasimaq", "Elektronika", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductColors",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0179459f-5718-4970-b52a-21bb98e17649"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blue", null },
                    { new Guid("3745d31c-3360-439a-a7dc-e3dd4645f617"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orange", null },
                    { new Guid("46ad1253-57df-4457-8165-6423f14ad73a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Red", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 42, 117, 45, 50, 126, 135, 0, 129, 41, 45, 132, 34, 136, 63, 117, 54, 216, 173, 156, 39, 201, 218, 195, 129, 87, 161, 148, 13, 119, 12, 57, 209, 137, 201, 75, 18, 173, 202, 235, 240, 29, 213, 100, 24, 72, 118, 43, 141, 196, 41, 208, 214, 249, 159, 50, 154, 205, 148, 117, 185, 197, 26, 179, 100 }, new byte[] { 210, 136, 225, 155, 151, 191, 92, 224, 133, 8, 247, 173, 206, 114, 3, 184, 195, 191, 162, 126, 194, 234, 239, 141, 28, 244, 214, 254, 87, 59, 189, 133, 150, 48, 24, 151, 23, 169, 11, 165, 171, 163, 17, 189, 221, 171, 160, 177, 220, 120, 210, 166, 80, 16, 223, 221, 69, 32, 156, 253, 104, 92, 225, 202, 180, 232, 68, 130, 95, 37, 138, 72, 20, 83, 132, 246, 68, 53, 31, 110, 41, 213, 17, 212, 244, 127, 243, 241, 93, 207, 71, 169, 215, 73, 232, 232, 176, 240, 103, 102, 238, 101, 66, 80, 247, 230, 44, 4, 214, 62, 150, 192, 229, 94, 151, 142, 246, 18, 141, 36, 182, 142, 60, 142, 3, 71, 228, 55 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 42, 117, 45, 50, 126, 135, 0, 129, 41, 45, 132, 34, 136, 63, 117, 54, 216, 173, 156, 39, 201, 218, 195, 129, 87, 161, 148, 13, 119, 12, 57, 209, 137, 201, 75, 18, 173, 202, 235, 240, 29, 213, 100, 24, 72, 118, 43, 141, 196, 41, 208, 214, 249, 159, 50, 154, 205, 148, 117, 185, 197, 26, 179, 100 }, new byte[] { 210, 136, 225, 155, 151, 191, 92, 224, 133, 8, 247, 173, 206, 114, 3, 184, 195, 191, 162, 126, 194, 234, 239, 141, 28, 244, 214, 254, 87, 59, 189, 133, 150, 48, 24, 151, 23, 169, 11, 165, 171, 163, 17, 189, 221, 171, 160, 177, 220, 120, 210, 166, 80, 16, 223, 221, 69, 32, 156, 253, 104, 92, 225, 202, 180, 232, 68, 130, 95, 37, 138, 72, 20, 83, 132, 246, 68, 53, 31, 110, 41, 213, 17, 212, 244, 127, 243, 241, 93, 207, 71, 169, 215, 73, 232, 232, 176, 240, 103, 102, 238, 101, 66, 80, 247, 230, 44, 4, 214, 62, 150, 192, 229, 94, 151, 142, 246, 18, 141, 36, 182, 142, 60, 142, 3, 71, 228, 55 } });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("8a90e7fe-7999-4968-bc69-37fdd50a9109"), new Guid("56cf5dbf-0998-43be-80e6-afc5c2f88247"), new DateTime(2024, 12, 5, 17, 14, 57, 814, DateTimeKind.Utc).AddTicks(5865), null, "Baku", null },
                    { new Guid("cda6beb7-77f6-4cf0-ac29-a91720887ead"), new Guid("317bcfbf-ad89-4ee6-85af-16802f9085e4"), new DateTime(2024, 12, 5, 17, 14, 57, 814, DateTimeKind.Utc).AddTicks(5904), null, "Yevlakh", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "ParentId", "UpdatedDate" },
                values: new object[] { new Guid("f3746916-b133-4685-8010-c2590255b857"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asan əlaqə", "Telefon", new Guid("9da5dc05-54a4-4d86-975f-dd380312416a"), null });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "CityId", "CreatedDate", "DeletedDate", "Email", "Name", "PhoneNumber", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("73848228-3d82-45a0-adee-33c8e4d9da4a"), "yyyyy", "aaaa", new Guid("8a90e7fe-7999-4968-bc69-37fdd50a9109"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "aaa@aaa.com", "ABC", "0554696363", null },
                    { new Guid("eb205408-b1a6-41bd-8aad-3c5a15ff5171"), "aaaaaa", "aaaaaa", new Guid("cda6beb7-77f6-4cf0-ac29-a91720887ead"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "avd@ads.com", "Telefon", "0554446655", null }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "CompanyId", "CreatedDate", "DeletedDate", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("a05423a0-927a-4a6c-8212-e56e17eb93b5"), new Guid("73848228-3d82-45a0-adee-33c8e4d9da4a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1 },
                    { new Guid("ebe29b8d-e9e3-43b7-8d1c-04146e83de27"), new Guid("eb205408-b1a6-41bd-8aad-3c5a15ff5171"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "BarcodeCode", "CompanyId", "CreatedDate", "DeletedDate", "Description", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("0a17687f-df99-47a3-b584-876ca7c9ab5d"), "0001", new Guid("73848228-3d82-45a0-adee-33c8e4d9da4a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "stajci satici", null, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedDate", "DeletedDate", "Description", "DiscountId", "IsDiscontinued", "Name", "ProductColorId", "PurchasePrice", "QuantityPerUnit", "ReorderLevel", "SKU", "ShopId", "SupplierId", "UnitPrice", "UnitsOnOrder", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("27c73a9f-379e-435e-9160-a63d825c39ba"), new Guid("31200a85-3b5e-4274-a506-70b3eb774c5c"), new Guid("9da5dc05-54a4-4d86-975f-dd380312416a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new Guid("867b9d81-77fe-4f6d-81b7-dffb95db6ec8"), true, "Duxlu nausnik", new Guid("46ad1253-57df-4457-8165-6423f14ad73a"), 6m, "1x1", 0, "DUX_NAUSNIK", new Guid("a05423a0-927a-4a6c-8212-e56e17eb93b5"), new Guid("0a17687f-df99-47a3-b584-876ca7c9ab5d"), 9m, 0, null },
                    { new Guid("e7f0b22a-2271-4a47-87e3-9e3c3bdf0ff0"), new Guid("f6fbe3b5-eb10-4a0f-a688-04ee831988ad"), new Guid("43d46df9-b8cd-4054-b1b8-f8a12597db5d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", new Guid("80ff4451-7697-446f-893f-ac8c516b4e4b"), true, "Duxlu nausnik 1", new Guid("0179459f-5718-4970-b52a-21bb98e17649"), 6m, "1x1", 0, "DUX_NAUSNIK11", new Guid("a05423a0-927a-4a6c-8212-e56e17eb93b5"), new Guid("0a17687f-df99-47a3-b584-876ca7c9ab5d"), 9m, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "ShopId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("5beb0a81-ce69-4358-a555-1a16bf40981a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a05423a0-927a-4a6c-8212-e56e17eb93b5"), null, 1 },
                    { new Guid("91fececc-1df5-415e-b7a3-ceaae98d3643"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ebe29b8d-e9e3-43b7-8d1c-04146e83de27"), null, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductInventors",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "ProductId", "Quantity", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1e70af7b-092c-4ff4-8899-93c65f5a4ab9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("27c73a9f-379e-435e-9160-a63d825c39ba"), 5, null },
                    { new Guid("76d537e7-04c7-4739-9ecb-cb5787783ae3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("e7f0b22a-2271-4a47-87e3-9e3c3bdf0ff0"), 26, null }
                });
        }
    }
}
