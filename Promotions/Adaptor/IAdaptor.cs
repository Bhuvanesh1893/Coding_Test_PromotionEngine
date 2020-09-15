using PromotionEngine_Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotions.Adaptor
{
    public interface IAdaptor
    {
        void Run_Promos_Cal_Total(List<LineItemPrice> lineItemPrices, out List<LineItemPrice> upLineItemPrices, out float CartTotal);
    }
}
