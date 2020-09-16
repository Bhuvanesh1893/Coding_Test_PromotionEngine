using PromotionEngine_Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotions.Adaptor
{
    public class PromoPriceCalAdaptor : NonPromoCal, IPromoPriceCal
    {
        public void Run_Promos_Cal_Total(List<LineItemPrice> lineItemPrices, out List<LineItemPrice> upLineItemPrices, out float CartTotal)
        {
            try
            {
                upLineItemPrices = ApplyPromotions(lineItemPrices);
                upLineItemPrices = CalNonPromoSkuTotal(upLineItemPrices);
                CartTotal = CalCartTotal(upLineItemPrices);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<LineItemPrice> ApplyPromotions(List<LineItemPrice> liItemPrices)
        {
            try
            {
                List<LineItemPrice> promoItemPrices = new List<LineItemPrice>();
                IPromotion1 iP1 = new Promotion1();
                promoItemPrices = iP1.BuyNSKUUnitsForFixed(liItemPrices);

                IPromotion2 iP2 = new Promotion2();
                promoItemPrices = iP2.BuyTwoSKUForFixed(promoItemPrices);

                return promoItemPrices;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public override List<LineItemPrice> CalNonPromoSkuTotal(List<LineItemPrice> lineItemPrices)
        {
            try
            {
                return base.CalNonPromoSkuTotal(lineItemPrices);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public override float CalCartTotal(List<LineItemPrice> lineItemPrices)
        {
            try
            {
                return base.CalCartTotal(lineItemPrices);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
