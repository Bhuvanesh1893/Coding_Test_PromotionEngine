using PromotionEngine_Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotions.Adaptor
{
    public class PromotionsAdaptor :NonPromoCal, IAdaptor
    {
        public void Run_Promos_Cal_Total(List<LineItemPrice> lineItemPrices, out List<LineItemPrice> upLineItemPrices, out float CartTotal)
        {
            upLineItemPrices = ApplyPromotions(lineItemPrices);
            upLineItemPrices = CalNonPromoSkuTotal(upLineItemPrices);
            CartTotal = CalCartTotal(upLineItemPrices);
        }

        private List<LineItemPrice> ApplyPromotions(List<LineItemPrice> liItemPrices)
        {
            List<LineItemPrice> promoItemPrices = new List<LineItemPrice>();
            IPromotion1 iP1 = new Promotion1();
            promoItemPrices = iP1.BuyNSKUUnitsForFixed(liItemPrices);

            IPromotion2 iP2 = new Promotion2();
            promoItemPrices = iP2.BuyTwoSKUForFixed(promoItemPrices);

            return promoItemPrices;
            
        }
        public override List<LineItemPrice> CalNonPromoSkuTotal(List<LineItemPrice> lineItemPrices)
        {
            return base.CalNonPromoSkuTotal(lineItemPrices);
        }
        public override float CalCartTotal(List<LineItemPrice> lineItemPrices)
        {
            return base.CalCartTotal(lineItemPrices);
        }
    }
}
