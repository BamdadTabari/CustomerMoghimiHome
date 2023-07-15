using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.ZarinPal;
using MudBlazor;

namespace CustomerMoghimiHome.Client.Pages.NormalPages.Shop;

public partial class ZarinPalPaymentVerify
{
    protected override async Task OnInitializedAsync()
    {
        var paymentModel = new ZarinPalRequestModel();
        using var response = await _httpService.PostValue(ShopRoutes.ZarinPal + CRUDRouts.VerifyPayment, paymentModel);
        if (response.IsSuccessStatusCode)
        {
            _snackbar.Add("عملیات با موفقیت انجام شد.", Severity.Success);
        }
        else
        {
            _snackbar.Add("خطایی رخ داده لطفا فیلد ها را به درستی پرکنید. درصورت خطای مجدد لطفا با ادمین تماس بگیرید.", Severity.Error);
        }
    }
}
