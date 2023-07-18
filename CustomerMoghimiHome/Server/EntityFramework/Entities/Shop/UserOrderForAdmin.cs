using CustomerMoghimiHome.Server.EntityFramework.Common;

namespace CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;

public class UserOrderForAdmin: BaseEntity
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }


}
