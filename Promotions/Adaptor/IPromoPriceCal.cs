using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotionEngine_Common.Models;

namespace Promotions.Adaptor
{
    public interface IPromoPriceCal
    {
        void Run_Promos_Cal_Total(List<LineItemPrice> lineItemPrices, out List<LineItemPrice> upLineItemPrices, out float CartTotal);
    }
}
