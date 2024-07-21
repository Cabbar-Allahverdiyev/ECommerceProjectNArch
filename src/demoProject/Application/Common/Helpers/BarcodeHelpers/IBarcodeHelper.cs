using System;

namespace Application.Common.Helpers.BarcodeHelpers;
public interface IBarcodeHelper
{
    Task<string> CreateBarcodeNumberEan13(int countryCode, int supplierCode);
    Task<string> GenerateBarcodeNumber(int countryCode, int supplierCode);
    int SeparateBarcodeNumberByProductCode(string barcodeNumber);
    int SeparateBarcodeNumberBySupplierCode(string barcodeNumber);
    int SeparateBarcodeNumberByCountryCode(string barcodeNumber);
}
