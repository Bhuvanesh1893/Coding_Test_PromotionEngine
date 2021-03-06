﻿using PromotionEngine_Common.Models;
using SkuPriceInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotions
{
    public class NonPromoCal
    {
        private Dictionary<string, float> _skuPriceInfo = new Dictionary<string, float>();
        public virtual List<LineItemPrice> CalNonPromoSkuTotal(List<LineItemPrice> lineItemPrices)
        {
            try 
            { 
                ISkuPriceInfo skuPr = new SkuPriceInfoAdaptor();
                _skuPriceInfo = skuPr.GetSkuPriceInfo();
                foreach(var li in lineItemPrices.Where(x=>x.promoDesc==""))
                {
                    li.skuTotal = li.quantity * _skuPriceInfo[li.skuId];
                }
                return lineItemPrices;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual float CalCartTotal(List<LineItemPrice> lineItemPrices)
        {
            try { 
                float cartTotal = 0F;
                foreach(var item in lineItemPrices)
            {
                cartTotal += item.skuTotal;
            }
                return cartTotal;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
