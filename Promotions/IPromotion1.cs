using PromotionEngine_Common.Models;
using System.Collections.Generic;

namespace Promotions
{
    public interface IPromotion1
    {
        List<LineItemPrice> BuyNSKUUnitsForFixed(List<LineItemPrice> LineItems);
    }
}