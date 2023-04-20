﻿using CustomerMoghimiHome.Server.EntityFramework.Repositories.File;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.File;
using Microsoft.AspNetCore.Mvc;

namespace CustomerMoghimiHome.Server.Controllers.File;


[ApiController]
//[Authorize(Roles = "Adminstrator")]
public class ImageFileController : ControllerBase
{
    private readonly IImageRepo _imageRepo;

    public ImageFileController(IImageRepo imageRepo)
    {
        _imageRepo = imageRepo;
    }

    [HttpPost(FileRoutes.ImageFile)]
    public async Task Add(ImageDto imageDto)
    {
        try
        {
            await _imageRepo.AddImageAsync(imageDto);
        }
        catch (Exception e)
        {

            throw e;
        }
    }

    [HttpGet(FileRoutes.GetAllImageFile)]
    public async Task<List<ImageDto>> GetAll() => await _imageRepo.GetAllImages();
}
