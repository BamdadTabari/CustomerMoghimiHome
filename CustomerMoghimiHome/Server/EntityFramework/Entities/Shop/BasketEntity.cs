using CustomerMoghimiHome.Server.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;

public class BasketEntity : BaseEntity
{
    public Guid UserId { get; set; }
    public bool IsDone { get; set; }

    public List<BasketProductEntity> BasketProduct { get; set; }
}


public class BasketEntityConfiguration : IEntityTypeConfiguration<BasketEntity>
{
    public void Configure(EntityTypeBuilder<BasketEntity> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);
        builder.Property(e => e.UserId).IsRequired();

        #endregion
    }
}