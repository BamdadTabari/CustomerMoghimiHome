﻿using CustomerMoghimiHome.Shared.EntityFramework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
public class BasketProductDto : BaseDto
{
    public long BasketId { get; set; }
    public long ProductId { get; set; }
    public ProductDto Product { get; set; }
    public BasketDto Basket { get; set; }
}
