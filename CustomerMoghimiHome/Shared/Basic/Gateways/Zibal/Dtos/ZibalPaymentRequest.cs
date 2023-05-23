using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMoghimiHome.Shared.Basic.Gateways.Zibal.Dtos;
public class ZibalPaymentRequest
{
    public ZibalPaymentRequest(string merchant, long trackId)
    {
        Merchant = merchant;
        TrackId = trackId;
    }

    public string Merchant { get; private set; }
    public long TrackId { get; private set; }
}
