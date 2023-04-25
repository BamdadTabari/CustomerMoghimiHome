﻿using CustomerMoghimiHome.Shared.EntityFramework.Common;

namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
public class ProductDto : BaseDto
{
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string BuilderCompany { get; set; } = "Microlab";
    public string ProductDescription { get; set; } = string.Empty;
    public List<string> ImagePathList { get; set; }
    public List<long> ImageForProductList { get; set; }

    public long ProductCategoryEnityId { get; set; }
    public ProductCategoryDto ProductCategory { get; set; }
}
