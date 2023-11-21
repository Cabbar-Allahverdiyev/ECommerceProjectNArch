using Domain.Entities;

namespace Application.Common.Helpers.ProductHelpers;
public static class SkuHelper
{
    public async static Task<string> GenerateSKU(this Product product)
    {//name ler ile yaz bu metodu include edende gelir
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
