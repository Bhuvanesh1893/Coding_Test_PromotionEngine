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
        private List<BuyXforY> _confBuyXforY;
        private Dictionary<string, float> _skuPriceInfo;

        public List<LineItemPrice> BuyNSKUUnitsForFixed(List<LineItemPrice> LineItems)
        {
            try
            {
                ReadXmlBuyXforY();
                ISkuPriceInfo skuPrices = new SkuPriceInfoAdaptor();
                _skuPriceInfo = skuPrices.GetSkuPriceInfo();

                foreach (var i in _confBuyXforY)
                {
                    foreach (var li in LineItems.Where(x => x.promoDesc == string.Empty && x.skuId == i.sku && x.quantity >= i.quantity))
                    {
                        li.promoDesc = "Buy" + i.quantity.ToString() + "For" + i.price.ToString();
                        li.skuTotal = ((li.quantity / i.quantity) * i.price) + ((li.quantity % i.quantity) * _skuPriceInfo[li.skuId]);
                    }
                }
                return LineItems;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void ReadXmlBuyXforY()
        {
            try
            {
                _confBuyXforY = new List<BuyXforY>();
                _confBuyXforY.Add(new BuyXforY { sku = "A", quantity = 3, price = 130 });
                _confBuyXforY.Add(new BuyXforY { sku = "B", quantity = 2, price = 45 });
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
