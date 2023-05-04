using AutoMapper;
using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CustomerMoghimiHome.Server.Controllers.Shop;
[ApiController]
public class BasketController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly UserManager<IdentityUser> _userManager;
    public BasketController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<IdentityUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _mapper = mapper;
    }

    [HttpPost(BasketRoutes.Basket + CRUDRouts.Create)]
    public async Task Create([FromBody] string data)
    {
        var dto = await Task.Run(() => JsonSerializer.Deserialize<BasketDto>(data));
        if (dto != null)
        {
            var user = await _userManager.GetUserAsync(User);
            //dto.UserId = user.;
            var entity = await Task.Run(() => _mapper.Map<BasketEntity>(dto));
            await _unitOfWork.Baskets.AddAsync(entity);
            
            foreach (var item in dto.BasketProductList)
            {
                
            }
            dto.CreateDate = DateTime.Now; dto.ModifiedDate = DateTime.Now;
            
            
            await _unitOfWork.CommitAsync();
        }
    }
}
