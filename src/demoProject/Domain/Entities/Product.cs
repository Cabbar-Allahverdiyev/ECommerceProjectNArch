using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Product : Entity<Guid>
{
    public Guid CategoryId { get; set; }
    public Guid BrandId { get; set; }
    public Guid SupplierId { get; set; }
    public Guid DiscountId { get; set; }
    public Guid InventorId { get; set; }
    public int UnitsOnOrder { get; set; }
    public int ReorderLevel { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal UnitPrice { get; set; }
    public string Name { get; set; }
    public string QuantityPerUnit { get; set; }
    public string SKU { get; set; }
    public string Description { get; set; }
    public bool IsDiscontinued { get; set; }

    public virtual ProductCategory? Category { get; set; }
    public virtual ProductBrand? Brand { get; set; }
    public virtual Supplier? Supplier { get; set; }
    public virtual Discount? Discount { get; set; }
    public virtual ProductInventor? Inventor { get; set; }

    public Product()
    {

    }

    public Product(Guid id,
                 Guid categoryId,
                 Guid brandId,
                 Guid supplierId,
                 Guid discountId,
                 Guid ınventorId,
                 int unitsOnOrder,
                 int reorderLevel,
                 decimal purchasePrice,
                 decimal unitPrice,
                 string name,
                 string quantityPerUnit,
                 string sKU,
                 string description,
                 bool ısDiscontinued
                ) : this()
    {
        Id = id;
        CategoryId = categoryId;
        BrandId = brandId;
        SupplierId = supplierId;
        DiscountId = discountId;
        InventorId = ınventorId;
        UnitsOnOrder = unitsOnOrder;
        ReorderLevel = reorderLevel;
        PurchasePrice = purchasePrice;
        UnitPrice = unitPrice;
        Name = name;
        QuantityPerUnit = quantityPerUnit;
        SKU = sKU;
        Description = description;
        IsDiscontinued = ısDiscontinued;
    }
}
