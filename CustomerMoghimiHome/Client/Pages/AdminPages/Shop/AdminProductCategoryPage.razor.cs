﻿using CustomerMoghimiHome.Client.Shared;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Shop;
using MudBlazor;
using System.Net;

namespace CustomerMoghimiHome.Client.Pages.AdminPages.Shop;

public partial class AdminProductCategoryPage
{
    #region Add
    ProductCategoryDto model = new();
    public async Task Add()
    {
        var response = await _httpService.PostValue(ShopRoutes.ProductCategory + CRUDRouts.Create, model);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            _snackbar.Add("Operation Done Succesfully", Severity.Success);
        }
        else
        {
            _snackbar.Add("Operation Failed", Severity.Error);
        }
    }
    #endregion

    #region Table

    private IEnumerable<ProductCategoryDto> pagedData;
    private MudTable<ProductCategoryDto> table;
    private string searchString = "";
    private ProductCategoryDto selectedItem = null;
    private bool isBusy = false;

    /// <summary>
    /// getting the paged, filtered and ordered data from the server
    /// </summary>
    private async Task<TableData<ProductCategoryDto>> ServerReload(TableState state)
    {
        DefaultPaginationFilter paginationFilter = new(state.Page, state.PageSize);
        var paginatedData = await _httpService.GetPagedValue<ProductCategoryDto>(ShopRoutes.ProductCategory + CRUDRouts.ReadListByFilter, paginationFilter);
        pagedData = paginatedData.Data;
        return new TableData<ProductCategoryDto>() { TotalItems = paginatedData.TotalCount, Items = pagedData };
    }

    #endregion

    #region Delete
    private async Task OnDelete(long id)
    {
        var parameters = new DialogParameters();
        parameters.Add("ContentText", "Do you really want to delete these records? all sub-records will be deleted!! This process cannot be undone.");
        parameters.Add("ButtonText", "Delete");
        parameters.Add("Color", Color.Error);
        var dialog = await _dialogService.ShowAsync<CommonDialog>("Delete", parameters);
        var dialogResult = await dialog.Result;
        if (dialogResult.Canceled == false)
        {
            var response = await _httpService.DeleteValue(ShopRoutes.ProductCategory + CRUDRouts.Delete + $"/{id}");
            if (response.IsSuccessStatusCode)
            {
                _snackbar.Add("Operation Done Succesfully", Severity.Success);
                await table.ReloadServerData();
            }
            else
            {
                _snackbar.Add("Operation Failed", Severity.Error);
            }
        }
        else
        {
            _snackbar.Add("Operation Canceled", Severity.Warning);

        }
    }
    #endregion

    #region Search
    private void OnSearch(string text)
    {
        searchString = text;
        table.ReloadServerData();
    }
    #endregion

    #region Edit
    private async Task Edit(long id)
    {
        _navigationManager.NavigateTo($"/pc-pc-cp-cp==cppc-edit/{id}");
    }
    #endregion
}
