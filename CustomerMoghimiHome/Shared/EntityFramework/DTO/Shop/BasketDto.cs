using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
public class BasketDto
{
    public Guid UserId { get; set; }
    public bool IsDone { get; set; }

    public List<BasketProductDto> BasketProduct { get; set; }
}
