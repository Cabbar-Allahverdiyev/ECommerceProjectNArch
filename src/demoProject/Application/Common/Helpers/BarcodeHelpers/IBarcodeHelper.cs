using System;

namespace Application.Common.Helpers.BarcodeHelpers;
public interface IBarcodeHelper
{
    Task<string> CreateBarcodeNumberEan13(string countryCode, string supplierCode);
    Task<string> GenerateBarcodeNumber(string countryCode, string supplierCode);
    int SeparateBarcodeNumberByProductCode(string barcodeNumber);
    int SeparateBarcodeNumberBySupplierCode(string barcodeNumber);
    int SeparateBarcodeNumberByCountryCode(string barcodeNumber);
    bool CheckChecksum(string barcodeNumber);
}
