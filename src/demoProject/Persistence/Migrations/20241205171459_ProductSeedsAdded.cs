using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ProductSeedsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("b5abfd50-68d8-40c7-9b7d-c5246d71d8d0"));

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("3d35b742-9231-45aa-991a-f0fa26dd4232"));

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("73bc3f4c-9848-42fd-994c-353140c8fcba"));

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: new Guid("49caef5c-3534-480d-8e1e-a1a531b54950"));

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: new Guid("bcc3405e-81e4-474e-907d-64821b394eb3"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("a2066cf4-f2aa-4903-9f7e-4e26b4c107e0"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("ba3c18af-a46f-48f3-a1ff-2a0adccd93d2"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("7ec23569-112e-4691-8acf-b726fa4d19eb"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("c15dd8dc-9afc-439d-b289-b889e00081af"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("f92549ec-3d4c-4854-8631-3a2bcc977b02"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("a9f27e28-09ac-4ed7-b8c0-7c7a264b45ca"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("226d9204-63d6-44ca-8847-0f752845d836"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("2579bfb6-0334-4840-b955-16d021c77618"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("a9a5c748-6049-4ee4-88d5-ef9f86e855a3"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e4783f21-617e-4505-b192-636b6cec6de9"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("28caed0b-799a-4fce-a4b0-e632ce01e6a2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("64e3dc90-8fac-410f-a505-8933f03ee1d4"));

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

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 105,
                column: "Name",
                value: "Shops.GetListByCompanyNameShopQuery");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 106,
                column: "Name",
                value: "Shops.GetByUserIdShop");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 107,
                column: "Name",
                value: "Shops.GetByCompanyIdShop");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 108,
                column: "Name",
                value: "Sellers.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 109,
                column: "Name",
                value: "Sellers.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 110,
                column: "Name",
                value: "Sellers.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 111,
                column: "Name",
                value: "Sellers.Add");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 112, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sellers.Update", null },
                    { 113, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sellers.Delete", null },
                    { 114, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seller", null },
                    { 115, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sellers.GetByShopIdSeller", null },
                    { 116, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sellers.GetByUserIdSeller", null }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 116);

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
                    { new Guid("28caed0b-799a-4fce-a4b0-e632ce01e6a2"), "869", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Turkey", null },
                    { new Guid("64e3dc90-8fac-410f-a505-8933f03ee1d4"), "476", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Azerbaijan", null }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "DiscountPercent", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("3d35b742-9231-45aa-991a-f0fa26dd4232"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", 25m, "Ela endirim", null },
                    { new Guid("73bc3f4c-9848-42fd-994c-353140c8fcba"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", 15m, "Ucuz endirim", null }
                });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 105,
                column: "Name",
                value: "Sellers.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 106,
                column: "Name",
                value: "Sellers.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 107,
                column: "Name",
                value: "Sellers.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 108,
                column: "Name",
                value: "Sellers.Add");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 109,
                column: "Name",
                value: "Sellers.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 110,
                column: "Name",
                value: "Sellers.Delete");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 111,
                column: "Name",
                value: "Seller");

            migrationBuilder.InsertData(
                table: "ProductBrands",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("49caef5c-3534-480d-8e1e-a1a531b54950"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Azzaro", null },
                    { new Guid("bcc3405e-81e4-474e-907d-64821b394eb3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sauvage", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "ParentId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("a9a5c748-6049-4ee4-88d5-ef9f86e855a3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "rahat dasimaq", "Elektronika", null, null },
                    { new Guid("ba3c18af-a46f-48f3-a1ff-2a0adccd93d2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asan əlaqə", "Telefon", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductColors",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("7ec23569-112e-4691-8acf-b726fa4d19eb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blue", null },
                    { new Guid("c15dd8dc-9afc-439d-b289-b889e00081af"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Red", null },
                    { new Guid("f92549ec-3d4c-4854-8631-3a2bcc977b02"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orange", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 50, 29, 24, 44, 63, 48, 142, 184, 104, 43, 188, 22, 22, 2, 192, 121, 156, 99, 215, 177, 49, 166, 91, 245, 169, 34, 53, 170, 117, 7, 142, 241, 31, 96, 178, 73, 22, 9, 227, 106, 209, 90, 185, 198, 26, 102, 210, 38, 173, 202, 224, 209, 77, 0, 167, 199, 64, 111, 2, 43, 39, 100, 230, 123 }, new byte[] { 198, 74, 231, 136, 35, 135, 244, 4, 115, 198, 233, 25, 112, 226, 201, 62, 78, 12, 123, 86, 138, 189, 180, 46, 193, 237, 181, 23, 29, 124, 249, 96, 94, 225, 119, 228, 38, 255, 46, 240, 181, 148, 73, 230, 51, 173, 141, 248, 55, 157, 99, 34, 47, 49, 117, 252, 48, 21, 80, 60, 221, 229, 233, 216, 250, 246, 32, 133, 4, 177, 143, 32, 47, 160, 21, 228, 207, 226, 69, 149, 56, 180, 253, 201, 185, 208, 250, 199, 149, 108, 159, 47, 127, 96, 229, 145, 181, 27, 246, 86, 67, 1, 5, 2, 27, 123, 10, 171, 26, 213, 154, 192, 87, 133, 132, 244, 169, 71, 153, 61, 217, 231, 69, 227, 114, 70, 91, 176 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 50, 29, 24, 44, 63, 48, 142, 184, 104, 43, 188, 22, 22, 2, 192, 121, 156, 99, 215, 177, 49, 166, 91, 245, 169, 34, 53, 170, 117, 7, 142, 241, 31, 96, 178, 73, 22, 9, 227, 106, 209, 90, 185, 198, 26, 102, 210, 38, 173, 202, 224, 209, 77, 0, 167, 199, 64, 111, 2, 43, 39, 100, 230, 123 }, new byte[] { 198, 74, 231, 136, 35, 135, 244, 4, 115, 198, 233, 25, 112, 226, 201, 62, 78, 12, 123, 86, 138, 189, 180, 46, 193, 237, 181, 23, 29, 124, 249, 96, 94, 225, 119, 228, 38, 255, 46, 240, 181, 148, 73, 230, 51, 173, 141, 248, 55, 157, 99, 34, 47, 49, 117, 252, 48, 21, 80, 60, 221, 229, 233, 216, 250, 246, 32, 133, 4, 177, 143, 32, 47, 160, 21, 228, 207, 226, 69, 149, 56, 180, 253, 201, 185, 208, 250, 199, 149, 108, 159, 47, 127, 96, 229, 145, 181, 27, 246, 86, 67, 1, 5, 2, 27, 123, 10, 171, 26, 213, 154, 192, 87, 133, 132, 244, 169, 71, 153, 61, 217, 231, 69, 227, 114, 70, 91, 176 } });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("226d9204-63d6-44ca-8847-0f752845d836"), new Guid("28caed0b-799a-4fce-a4b0-e632ce01e6a2"), new DateTime(2024, 11, 25, 17, 53, 54, 341, DateTimeKind.Utc).AddTicks(3724), null, "Yevlakh", null },
                    { new Guid("e4783f21-617e-4505-b192-636b6cec6de9"), new Guid("64e3dc90-8fac-410f-a505-8933f03ee1d4"), new DateTime(2024, 11, 25, 17, 53, 54, 341, DateTimeKind.Utc).AddTicks(3684), null, "Baku", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "ParentId", "UpdatedDate" },
                values: new object[] { new Guid("a2066cf4-f2aa-4903-9f7e-4e26b4c107e0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asan əlaqə", "Telefon", new Guid("a9a5c748-6049-4ee4-88d5-ef9f86e855a3"), null });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "CityId", "CreatedDate", "DeletedDate", "Email", "Name", "PhoneNumber", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2579bfb6-0334-4840-b955-16d021c77618"), "yyyyy", "aaaa", new Guid("e4783f21-617e-4505-b192-636b6cec6de9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "aaa@aaa.com", "ABC", "0554696363", null },
                    { new Guid("b5abfd50-68d8-40c7-9b7d-c5246d71d8d0"), "aaaaaa", "aaaaaa", new Guid("226d9204-63d6-44ca-8847-0f752845d836"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "avd@ads.com", "Telefon", "0554446655", null }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "BarcodeCode", "CompanyId", "CreatedDate", "DeletedDate", "Description", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("a9f27e28-09ac-4ed7-b8c0-7c7a264b45ca"), "0001", new Guid("2579bfb6-0334-4840-b955-16d021c77618"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "stajci satici", null, 1 });
        }
    }
}
