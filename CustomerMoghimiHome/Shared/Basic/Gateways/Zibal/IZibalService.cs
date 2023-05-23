using CustomerMoghimiHome.Shared.Basic.Gateways.Zibal.Dtos;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CustomerMoghimiHome.Shared.Basic.Gateways.Zibal;
public interface IZibalService
{
    Task<string> StartPay(ZibalPaymentRequest request);
    Task<ZibalVerifyResponse> VerifyPay(ZibalPaymentRequest request);
}

public class ZibalService : IZibalService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _options;
    public ZibalService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }


    public async Task<string> StartPay(ZibalPaymentRequest request)
    {
        var body = JsonSerializer.Serialize(request, _options);
        var content  = new StringContent(body, Encoding.UTF8, MediaTypeNames.Application.Json);
        var result = await _httpClient.PostAsync(ZibalOptions.RequestUrl, content);
        if (result.IsSuccessStatusCode)
        {
            var res = await result.Content.ReadAsStreamAsync();
            var response = await JsonSerializer.DeserializeAsync<ZibalPaymentResult>(res);
            if (response.Result == 100)
            {
                return $"{ZibalOptions.PaymentUrl}{response.TrackId}";
            }

            throw new InvalidDataException();
        }
        throw new Exception(result.StatusCode.ToString());
    }

    public async Task<ZibalVerifyResponse> VerifyPay(ZibalPaymentRequest request)
    {
        var body = JsonSerializer.Serialize(request, _options);
        var content = new StringContent(body, Encoding.UTF8, MediaTypeNames.Application.Json);
        var result = await _httpClient.PostAsync(ZibalOptions.VerifyUrl, content);
        if (result.IsSuccessStatusCode)
        {
            return await result.Content.ReadFromJsonAsync<ZibalVerifyResponse>();
        }
        throw new Exception(result.StatusCode.ToString());
    }
}