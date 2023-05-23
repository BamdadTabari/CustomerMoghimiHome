using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMoghimiHome.Shared.Basic.Gateways.Zibal.Dtos;
public class ZibalVerifyResponse
{
    public DateTime PayedAt { get; set; }
    public int Amount { get; set; }
    public int Result { get; set; }
    public int Status { get; set; }
    public int? RefNumber { get; set; }
    public string Description { get; set; }
    public string CardNumber { get; set; }
    public string OrderId { get; set; }
    public string Message { get; set; }
}
