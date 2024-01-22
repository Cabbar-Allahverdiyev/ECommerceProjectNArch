using Domain.Entities;

namespace Application.Common.Helpers.ProductHelpers;
public static class SkuHelper
{
    public async static Task<string> GenerateSKU(this Product product)
    {
        //SKU cox uzundur biraz qisalt meselen: "bbcad47a-6373-4904-a26c-51f1674d56ec9fefc339-0
        //ee7-441a-b68d-a025931cb2d9e9077bf5-3b56-41a5-bfcf-7b3fe097bf1cb08dd13b-8144-4198-a69c
        //-f1b435284d66a7a28416-3440-4dcf-b881-5b3b946a30cc-STR-005,00",

        //name ler ile yaz bu metodu include edende gelir
        //int categoryId= await product.CategoryId.ToInt();
        //int brandId= await product.BrandId.ToInt();
        //int supplierId= await product.SupplierId.ToInt();
        //int discountId= await product.DiscountId.ToInt();
        //int colorId= await product.ProductColorId.ToInt();
        string categoryBrandBrandSupplierDiscountColor = $"{product.CategoryId}{product.BrandId}{product.SupplierId}{product.DiscountId}{product.ProductColorId}";

        string productId = product.Name?.Length >= 3 ? product.Name.Substring(0, 3).ToUpper() : "000";
        string unitPrice = product.UnitPrice.ToString("N2").Replace(".", "").PadLeft(6, '0');

        string sku = $"{categoryBrandBrandSupplierDiscountColor}-{productId}-{unitPrice}";

        return sku;
    }
}
