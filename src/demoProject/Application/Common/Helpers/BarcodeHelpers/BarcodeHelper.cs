using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Common.Helpers.BarcodeHelpers;
public class BarcodeHelper : IBarcodeHelper
{
    private readonly IBarcodeRepository _barcodeRepository;

    public BarcodeHelper(IBarcodeRepository barcodeRepository)
    {
        _barcodeRepository = barcodeRepository;
    }

    public async Task<string> CreateBarcodeNumberEan13(string countryCode, string supplierCode)
    {
        IPaginate<Barcode> barcodes = await _barcodeRepository.GetListAsync(
             b => b.BarcodeNumber.StartsWith(countryCode)
             && b.BarcodeNumber.Substring(3, 4) == supplierCode);

        IList<int> productCodes = barcodes.Items
            .Select(b => int.Parse(b.BarcodeNumber.Substring(7, 5)))
            .ToList();

        int newProductCode = productCodes.Any() ? productCodes.Max() + 1 : 0;
        string formattedProductCode = newProductCode.ToString("D5");

        string barcodeNumber = CalculateEan13(countryCode, supplierCode, formattedProductCode);
        return barcodeNumber;
    }

    public Task<string> GenerateBarcodeNumber(string countryCode, string supplierCode)
    {
        return CreateBarcodeNumberEan13(countryCode, supplierCode);
    }

    public int SeparateBarcodeNumberByCountryCode(string barcodeNumber)
    {
        return int.Parse(barcodeNumber[..3]);

    }

    public int SeparateBarcodeNumberBySupplierCode(string barcodeNumber)
    {
        return int.Parse(barcodeNumber.Substring(3, 4));
    }
    public int SeparateBarcodeNumberByProductCode(string barcodeNumber)
    {
        return int.Parse(barcodeNumber.Substring(7, 5));
    }

    public bool CheckChecksum(string barcodeNumber)
    {
        if (barcodeNumber != CalculateBarcodeChecksum(barcodeNumber[..^1])){
            return false;
        }
        return true;
    }

    private string CalculateBarcodeChecksum(string barcodeWithoutChecksum)
    {
        int sum = 0;
        for (int i = 0; i < barcodeWithoutChecksum.Length; i++)
        {
            int digit = int.Parse(barcodeWithoutChecksum[i].ToString());
            sum += (i % 2 == 0) ? digit : digit * 3;
        }
        int mod = sum % 10;
        int checkSum = (mod == 0) ? 0 : 10 - mod;
        return $"{barcodeWithoutChecksum}{checkSum}";
    }
    private string CalculateEan13(string country, string manufacturer, string product)
    {

        string barcodeWithoutChecksum = $"{country}{manufacturer}{product}";
        
        return this.CalculateBarcodeChecksum(barcodeWithoutChecksum);

        //string temp = $"{country}{manufacturer}{product}";
        //int sum = 0;
        //int digit = 0;
        //for (int i = temp.Length; i >= 1; i--)
        //{
        //    digit = Convert.ToInt32(temp.Substring(i - 1, 1));

        //    if (i % 2 == 0)
        //    {
        //        sum += digit * 3;
        //    }
        //    else
        //    {
        //        sum += digit * 1;
        //    }
        //}
        //int checkSum = (10 - (sum % 10)) % 10;
        //return $"{temp}{checkSum}";
    }
}
