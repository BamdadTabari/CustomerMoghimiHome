using CustomerMoghimiHome.Server.EntityFramework.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;

public class UserOrderForAdminEntity: BaseEntity
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public long TotalPrice { get; set; }
    public List<UserBasketEntity> UserBasketEntities { get; set; }
}


public class UserOrderForAdminEntityConfiguration : IEntityTypeConfiguration<UserOrderForAdminEntity>
{
    public void Configure(EntityTypeBuilder<UserOrderForAdminEntity> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);
        builder.Property(e => e.UserName).IsRequired();
        #endregion
    }
}