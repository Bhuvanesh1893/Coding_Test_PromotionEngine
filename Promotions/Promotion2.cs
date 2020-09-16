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

        //Configurable parameters for the promotion - Can configure for any two skus for any fixed price
        private void ReadXmlBuyTwoSkuforY()
        {
            try 
            { 
                _confBuyTwoForX = new List<BuyTwoSkuForX>();
                _confBuyTwoForX.Add(new BuyTwoSkuForX { sku1 = "C", sku2 = "D", price = 30 });
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Promotion Logic - Buy 2 different skus for a fixed price
        public List<LineItemPrice> BuyTwoSKUForFixed(List<LineItemPrice> listItems)
        {
            try 
            { 
                ReadXmlBuyTwoSkuforY();
                int skuQuan1;
                int skuQuan2;
                ISkuPriceInfo skuPrices = new SkuPriceInfoAdaptor();
                _skuPriceInfo = skuPrices.GetSkuPriceInfo();
                foreach (var promo in _confBuyTwoForX)
                {
                    var matchingItemsSkuId1 = listItems.Where(y => y.skuId == promo.sku1 && y.promoDesc == string.Empty).ToList();
                    var matchingItemsSkuId2 = listItems.Where(y => y.skuId == promo.sku2 && y.promoDesc == string.Empty).ToList();

                    
                    if (matchingItemsSkuId1.Count > 0 && matchingItemsSkuId2.Count > 0)
                    {
                        skuQuan1 = matchingItemsSkuId1[0].quantity;
                        skuQuan2 = matchingItemsSkuId2[0].quantity;
                        if (skuQuan1 == skuQuan2)
                        {
                            foreach(var item in matchingItemsSkuId1)
                            {
                                item.promoDesc = "Buy2SKUfor" + promo.price;
                                item.skuTotal = 0;
                            }
                            foreach (var item in matchingItemsSkuId2)
                            {
                                item.promoDesc = "Buy2SKUfor" + promo.price;
                                item.skuTotal = item.quantity * promo.price;
                            }

                        }
                        else if (skuQuan1 > skuQuan2)
                        {
                            foreach (var item in matchingItemsSkuId1)
                            {
                                item.promoDesc = "Buy2SKUfor" + promo.price;
                                item.skuTotal = (skuQuan1 - skuQuan2) * _skuPriceInfo[item.skuId];
                            }
                            foreach (var item in matchingItemsSkuId2)
                            {
                                item.promoDesc = "Buy2SKUfor" + promo.price;
                                item.skuTotal = item.quantity * promo.price;
                            }
                        }
                        else
                        {
                            foreach (var item in matchingItemsSkuId1)
                            {
                                item.promoDesc = "Buy2SKUfor" + promo.price;
                                item.skuTotal = 0;
                            }
                            foreach (var item in matchingItemsSkuId2)
                            {
                                item.promoDesc = "Buy2SKUfor" + promo.price;
                                item.skuTotal =   (skuQuan1*promo.price) + (skuQuan2-skuQuan1) * _skuPriceInfo[item.skuId];
                            }
                        }

                    }
                }

                return listItems;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
