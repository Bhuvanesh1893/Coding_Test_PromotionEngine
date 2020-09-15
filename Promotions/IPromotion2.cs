using PromotionEngine_Common.Models;
using System.Collections.Generic;

namespace Promotions
{
    public interface IPromotion2
    {
        List<LineItemPrice> BuyTwoSKUForFixed(List<LineItemPrice> listItems);
    }
}