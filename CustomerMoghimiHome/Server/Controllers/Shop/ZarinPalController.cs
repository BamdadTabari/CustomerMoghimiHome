using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.ZarinPal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace CustomerMoghimiHome.Server.Controllers.Shop;
[ApiController]
public class ZarinPalController: ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUnitOfWork _unitOfWork;
    public ZarinPalController(IUnitOfWork unitOfWork,UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost(ShopRoutes.ZarinPal + CRUDRouts.RequestPayment)]
    public async Task RequestPayment(ZarinPalRequestModel model, object sender, EventArgs e)
    {
        // Set the necessary parameters for the payment
        string merchantID = "YOUR_MERCHANT_ID"; // Replace with your ZarinPal Merchant ID
        
        string callbackUrl = "http://example.com/VerifyPayment.aspx"; // Replace with the URL to your callback page

        // Generate a unique order ID for the payment
        string orderID = Guid.NewGuid().ToString();

        // Prepare the payment request parameters
        NameValueCollection data = new NameValueCollection();
        data["MerchantID"] = merchantID; // Merchant ID
        data["Amount"] = model.Amount; // Payment amount
        data["Description"] = "Payment description"; // Payment description
        data["CallbackURL"] = callbackUrl; // Callback URL to receive payment verification result
        data["Email"] = "user@example.com"; // Customer's email address
        data["Mobile"] = "09123456789"; // Customer's mobile number
        data["OrderId"] = orderID; // Unique order ID

        // Perform a POST request to ZarinPal API for payment request
        WebClient client = new WebClient();
        byte[] response = client.UploadValues("https://www.zarinpal.com/pg/rest/WebGate/PaymentRequest.json", "POST", data);

        // Decode the response JSON
        string result = Encoding.UTF8.GetString(response);
        dynamic json = JsonConvert.DeserializeObject(result);

        // Check if the payment request was successful
        if (json.Status == 100)
        {
            var user = await _userManager.FindByEmailAsync(model.UserName);
            var userBasket = await _unitOfWork.Baskets.GetByUserIdAsync(user.Id);
            _unitOfWork.Baskets.Remove(userBasket);
            // Redirect the user to ZarinPal payment gateway page for completing the payment
            string paymentURL = "https://www.zarinpal.com/pg/StartPay/" + json.Authority;
            Response.Redirect(paymentURL);
        }
        else
        {
            // Handle the errors if the payment request fails
            string errorCode = json.Status;
            string errorMessage = json.Message;
            // Display or log the error message
            await Response.WriteAsync("Payment request failed. Error code: " + errorCode + ", Message: " + errorMessage);
        }
    }

}
