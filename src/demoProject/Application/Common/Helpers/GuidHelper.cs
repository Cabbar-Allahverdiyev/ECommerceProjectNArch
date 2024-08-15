
namespace Application.Common.Helpers;
public static class GuidHelper
{
    public async  static Task<int> ToInt(this Guid guid)
    {
         return BitConverter.ToInt32(guid.ToByteArray(),0);
    }
}
