namespace Application.Features.Barcodes.Constants;

public static class BarcodesOperationClaims
{
    public const string Admin = "Barcodes.Admin";

    public const string Read = "Barcodes.Read";
    public const string Write = "Barcodes.Write";

    public const string Create = "Barcodes.Create";
    public const string Update = "Barcodes.Update";
    public const string Delete = "Barcodes.Delete";
    public const string GetByBarcodeNumber = "Barcodes.GetByBarcodeNumber";
    public const string GetListByDynamicBarcode = "Barcodes.GetListByDynamicBarcode";
}
