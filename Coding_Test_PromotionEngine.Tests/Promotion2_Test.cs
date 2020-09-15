using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using Promotions;
using PromotionEngine_Common.Models;
using NUnit.Framework;

namespace Coding_Test_PromotionEngine.Tests
{
    [TestFixture]
    public class Promotion2_Test
    {
        public void Promotion2_Test1() 
        {
            List<LineItemPrice> input = new List<LineItemPrice>()
            {
                new LineItemPrice{skuId="A", quantity=5, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="B", quantity=4, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="C", quantity=3, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="D", quantity=2, promoDesc="", skuTotal=0},
            };

            List<LineItemPrice> expResult = new List<LineItemPrice>()
            {
                new LineItemPrice{skuId="A", quantity=5, promoDesc="Buy3For130", skuTotal=230},
                new LineItemPrice{skuId="B", quantity=4, promoDesc="Buy2For45", skuTotal=90},
                new LineItemPrice{skuId="C", quantity=3, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="D", quantity=2, promoDesc="", skuTotal=0},
            };

            List<LineItemPrice> actResult = new List<LineItemPrice>();

            IPromotion2 iPr = new Promotion2();
            actResult = iPr.BuyTwoSkuForY(input);

            Assert.That(expResult, Is.EqualTo(actResult));
        }
    }
}
