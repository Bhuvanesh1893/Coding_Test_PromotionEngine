using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promotions.Models;
using PromotionEngine_Common.Models;
using SkuPriceInfo;

namespace Promotions
{
    public class Promotion2 : IPromotion2
    {
        private List<BuyTwoSkuForX> _confBuyTwoForX;
        private Dictionary<string, float> _skuPriceInfo;

        private void ReadXmlBuyTwoSkuforY()
        {
            _confBuyTwoForX = new List<BuyTwoSkuForX>();
            _confBuyTwoForX.Add(new BuyTwoSkuForX { sku1 = "C", sku2 = "D", price = 30 });
        }

        public List<LineItemPrice> BuyTwoSKUForFixed(List<LineItemPrice> listItems)
        {
            ReadXmlBuyTwoSkuforY();
            ISkuPriceInfo skuPrices = new SkuPriceInfoAdaptor();
            _skuPriceInfo = skuPrices.GetSkuPriceInfo();
            foreach (var promo in _confBuyTwoForX)
            {
                var matchingItemsSkuId1 = listItems.Where(y => y.skuId == promo.sku1).ToList();
                var matchingItemsSkuId2 = listItems.Where(y => y.skuId == promo.sku2).ToList();
                if (matchingItemsSkuId1.Count > 0 && matchingItemsSkuId2.Count > 0)
                {
                    foreach (var li in listItems.Where(x => x.promoDesc == string.Empty && (x.skuId == promo.sku1 || x.skuId == promo.sku2)))
                    {
                        if (li.skuId == promo.sku1)
                        {
                            li.promoDesc = "Buy2SKUfor" + promo.price;
                            if (li.quantity > 1)
                            {
                                li.skuTotal = (li.quantity - 1) * _skuPriceInfo[li.skuId];
                            }
                        }
                        else if (li.skuId == promo.sku2)
                        {
                            li.promoDesc = "Buy2SKUfor" + promo.price;
                            if (li.quantity > 1)
                            {
                                li.skuTotal = promo.price + ((li.quantity - 1) * _skuPriceInfo[li.skuId]);
                            }
                            else
                            {
                                li.skuTotal = promo.price;
                            }
                        }
                    }

                }
            }

            return listItems;
        }
    }
}
