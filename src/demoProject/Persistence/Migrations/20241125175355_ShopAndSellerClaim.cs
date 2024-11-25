using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ShopAndSellerClaim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("568313ff-e867-4004-9e61-aed91e03bc0a"));

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("d26159be-70b7-470c-9ff6-3b2c04c34e1a"));

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("ee01256e-4ef1-49c3-973f-848a175a60b4"));

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: new Guid("9d64dd91-85c5-4b32-bdb6-6fa254649b39"));

            migrationBuilder.DeleteData(
                table: "ProductBrands",
                keyColumn: "Id",
                keyValue: new Guid("d6a0db73-a685-4f35-86ce-881b060d2fa0"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("0422fd48-809e-4f26-91d3-b0b570db257d"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("d4da3e5b-a52e-40b3-ab5f-f4f8ab84591f"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("277cd150-3d0b-4394-bda4-ea1c97d02145"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("5dd61f0b-ea70-4cf3-be19-045916e10964"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("66c3eaf1-9be2-4734-8eeb-c9a71870f3ad"));

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: new Guid("25efed0a-52d4-441b-87bd-2c94c1725845"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("31f21266-b60f-4a44-9c98-4b1bea89d34f"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("0a3327dd-29dc-4ea0-bcd0-1309fc4a403a"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("7710fa7e-ff6b-4090-8854-e23f12905fb5"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("fdf16992-1e6b-4da2-9e8e-8666b42aa388"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f45bc3e9-8c5e-4885-bbb6-cfd0c0850907"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a9b76887-6b74-4ec0-8c11-688dd7f960ae"));

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
                keyValue: 104,
                column: "Name",
                value: "Shop");

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

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sellers.Delete", null },
                    { 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Seller", null }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 111);

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
                    { new Guid("a9b76887-6b74-4ec0-8c11-688dd7f960ae"), "476", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Azerbaijan", null },
                    { new Guid("f45bc3e9-8c5e-4885-bbb6-cfd0c0850907"), "869", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Turkey", null }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "DiscountPercent", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("d26159be-70b7-470c-9ff6-3b2c04c34e1a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", 25m, "Ela endirim", null },
                    { new Guid("ee01256e-4ef1-49c3-973f-848a175a60b4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", 15m, "Ucuz endirim", null }
                });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 104,
                column: "Name",
                value: "Sellers.Admin");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 105,
                column: "Name",
                value: "Sellers.Read");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 106,
                column: "Name",
                value: "Sellers.Write");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 107,
                column: "Name",
                value: "Sellers.Add");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 108,
                column: "Name",
                value: "Sellers.Update");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 109,
                column: "Name",
                value: "Sellers.Delete");

            migrationBuilder.InsertData(
                table: "ProductBrands",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("9d64dd91-85c5-4b32-bdb6-6fa254649b39"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sauvage", null },
                    { new Guid("d6a0db73-a685-4f35-86ce-881b060d2fa0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Azzaro", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "ParentId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0422fd48-809e-4f26-91d3-b0b570db257d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asan əlaqə", "Telefon", null, null },
                    { new Guid("7710fa7e-ff6b-4090-8854-e23f12905fb5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "rahat dasimaq", "Elektronika", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductColors",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("277cd150-3d0b-4394-bda4-ea1c97d02145"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Blue", null },
                    { new Guid("5dd61f0b-ea70-4cf3-be19-045916e10964"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Red", null },
                    { new Guid("66c3eaf1-9be2-4734-8eeb-c9a71870f3ad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orange", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 181, 217, 114, 142, 20, 65, 87, 99, 36, 208, 137, 3, 174, 114, 239, 56, 240, 50, 204, 150, 165, 85, 119, 126, 248, 177, 63, 56, 158, 255, 83, 230, 65, 136, 90, 105, 113, 236, 22, 60, 254, 238, 232, 196, 177, 216, 79, 162, 135, 16, 245, 147, 250, 238, 214, 196, 20, 210, 251, 160, 80, 102, 115, 57 }, new byte[] { 229, 127, 99, 159, 161, 221, 75, 173, 111, 45, 201, 42, 239, 25, 28, 236, 217, 122, 231, 233, 14, 93, 67, 19, 63, 104, 29, 205, 217, 233, 53, 170, 241, 12, 88, 79, 142, 67, 148, 156, 138, 181, 34, 190, 153, 180, 114, 238, 165, 145, 239, 56, 134, 202, 70, 71, 138, 163, 80, 30, 207, 29, 162, 62, 203, 229, 247, 170, 133, 146, 13, 125, 251, 106, 120, 105, 132, 190, 205, 89, 133, 145, 214, 136, 64, 49, 198, 243, 102, 115, 211, 164, 122, 145, 15, 188, 84, 183, 159, 69, 138, 54, 138, 212, 20, 84, 108, 20, 28, 149, 141, 132, 58, 220, 68, 150, 9, 158, 242, 210, 214, 228, 134, 18, 110, 161, 99, 108 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 181, 217, 114, 142, 20, 65, 87, 99, 36, 208, 137, 3, 174, 114, 239, 56, 240, 50, 204, 150, 165, 85, 119, 126, 248, 177, 63, 56, 158, 255, 83, 230, 65, 136, 90, 105, 113, 236, 22, 60, 254, 238, 232, 196, 177, 216, 79, 162, 135, 16, 245, 147, 250, 238, 214, 196, 20, 210, 251, 160, 80, 102, 115, 57 }, new byte[] { 229, 127, 99, 159, 161, 221, 75, 173, 111, 45, 201, 42, 239, 25, 28, 236, 217, 122, 231, 233, 14, 93, 67, 19, 63, 104, 29, 205, 217, 233, 53, 170, 241, 12, 88, 79, 142, 67, 148, 156, 138, 181, 34, 190, 153, 180, 114, 238, 165, 145, 239, 56, 134, 202, 70, 71, 138, 163, 80, 30, 207, 29, 162, 62, 203, 229, 247, 170, 133, 146, 13, 125, 251, 106, 120, 105, 132, 190, 205, 89, 133, 145, 214, 136, 64, 49, 198, 243, 102, 115, 211, 164, 122, 145, 15, 188, 84, 183, 159, 69, 138, 54, 138, 212, 20, 84, 108, 20, 28, 149, 141, 132, 58, 220, 68, 150, 9, 158, 242, 210, 214, 228, 134, 18, 110, 161, 99, 108 } });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("31f21266-b60f-4a44-9c98-4b1bea89d34f"), new Guid("f45bc3e9-8c5e-4885-bbb6-cfd0c0850907"), new DateTime(2024, 11, 12, 18, 30, 36, 76, DateTimeKind.Utc).AddTicks(2575), null, "Yevlakh", null },
                    { new Guid("fdf16992-1e6b-4da2-9e8e-8666b42aa388"), new Guid("a9b76887-6b74-4ec0-8c11-688dd7f960ae"), new DateTime(2024, 11, 12, 18, 30, 36, 76, DateTimeKind.Utc).AddTicks(2531), null, "Baku", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "Name", "ParentId", "UpdatedDate" },
                values: new object[] { new Guid("d4da3e5b-a52e-40b3-ab5f-f4f8ab84591f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "asan əlaqə", "Telefon", new Guid("7710fa7e-ff6b-4090-8854-e23f12905fb5"), null });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "CityId", "CreatedDate", "DeletedDate", "Email", "Name", "PhoneNumber", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0a3327dd-29dc-4ea0-bcd0-1309fc4a403a"), "yyyyy", "aaaa", new Guid("fdf16992-1e6b-4da2-9e8e-8666b42aa388"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "aaa@aaa.com", "ABC", "0554696363", null },
                    { new Guid("568313ff-e867-4004-9e61-aed91e03bc0a"), "aaaaaa", "aaaaaa", new Guid("31f21266-b60f-4a44-9c98-4b1bea89d34f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "avd@ads.com", "Telefon", "0554446655", null }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "BarcodeCode", "CompanyId", "CreatedDate", "DeletedDate", "Description", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("25efed0a-52d4-441b-87bd-2c94c1725845"), "0001", new Guid("0a3327dd-29dc-4ea0-bcd0-1309fc4a403a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "stajci satici", null, 1 });
        }
    }
}
