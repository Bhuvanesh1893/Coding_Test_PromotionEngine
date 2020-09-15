using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotionEngine_Common.Models;
using SkuPriceInfo;
using System.Xml;
using Promotions.Models;

namespace Promotions
{
    public class Promotion1 : IPromotion1
    {
        private List<BuyXforY> confBuyXforY;
        private Dictionary<string, float> skuPriceInfo;

        public List<LineItemPrice> BuyNSKUUnitsForFixed(List<LineItemPrice> LineItems)
        {
            ReadXmlBuyXforY();
            ISkuPriceInfo skuPrices = new SkuPriceInfoAdaptor();
            skuPriceInfo = skuPrices.GetSkuPriceInfo();

            foreach (var i in confBuyXforY)
            {
                foreach (var li in LineItems.Where(x => x.promoDesc == string.Empty && x.skuId == i.sku && x.quantity >= i.quantity))
                {
                    li.promoDesc = "Buy" + i.quantity.ToString() + "For" + i.price.ToString();
                    li.skuTotal = ((li.quantity / i.quantity) * i.price) + ((li.quantity % i.quantity) * skuPriceInfo[li.skuId]);
                }
            }
            return LineItems;
        }
        private void ReadXmlBuyXforY()
        {
            confBuyXforY = new List<BuyXforY>();
            confBuyXforY.Add(new BuyXforY { sku = "A", quantity = 3, price = 130 });
            confBuyXforY.Add(new BuyXforY { sku = "B", quantity = 2, price = 45 });
        }

    }
}
