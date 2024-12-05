namespace Application.Features.Barcodes.Constants;

public static class BarcodesBusinessMessages
{
    public const string BarcodeNotExists = "Barcode not exists.";
    public const string BarcodeNumberMustContainOnlyDigits = "Barcode number must contain only digits.";
    public const string BarcodeExists = "Barcode exists.";
    public const string BarcodeNumberAlreadyExists = "Barcode number already exists.";
    public const string BarcodeNumberNotInCorrectFormat = "Barcode number not correct format. Fix the checksum. Checksum is the last digit of the barcode number";
    public const string BarcodeIsNull = "Barcode is null.";
    public const string BarcodeNumberMustBeNumeric = "Barcode number must be numeric.";

    public const string SupplierNotExist = "Supplier not exist.";
    
}