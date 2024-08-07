namespace Application.Features.Suppliers.Constants;

public static class SuppliersOperationClaims
{
    public const string Admin = "Suppliers.Admin";

    public const string Read = "Suppliers.Read";
    public const string Write = "Suppliers.Write";

    public const string Create = "Suppliers.Create";
    public const string Update = "Suppliers.Update";
    public const string Delete = "Suppliers.Delete";
    public const string GetByUserIdSupplier = "Suppliers.GetByUserIdSupplier";
    public const string GetByCompanyIdSuppier = "Suppliers.GetByCompanyIdSuppier";
    public const string GetListByDynamicSupplier = "Suppliers.GetListByDynamicSupplier";
}
