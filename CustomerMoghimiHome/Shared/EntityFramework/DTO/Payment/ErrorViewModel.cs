namespace CustomerMoghimiHome.Shared.EntityFramework.DTO.Payment;
public class ErrorViewModel
{
    public string RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
