using CustomerMoghimiHome.Server.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;

public class BasketProductEntity : BaseEntity
{
    public long BasketId { get; set; }
    public long ProductId { get; set; }
    public ProductEntity Product { get; set; }
    public BasketEntity Basket { get; set; }
}

public class BasketProductEntityConfiguration : IEntityTypeConfiguration<BasketProductEntity>
{
    public void Configure(EntityTypeBuilder<BasketProductEntity> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);

        #endregion

        builder.HasOne(x => x.Product).WithMany(x => x.BasketProduct)
            .HasForeignKey(x => x.BasketId).OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Basket).WithMany(x => x.BasketProduct)
            .HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Cascade);
    }
}