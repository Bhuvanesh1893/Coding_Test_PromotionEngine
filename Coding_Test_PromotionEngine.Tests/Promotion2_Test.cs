using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using Promotions;
using PromotionEngine_Common.Models;
using NUnit.Framework;
using System.Web.Http.Routing.Constraints;

namespace Coding_Test_PromotionEngine.Tests
{
    [TestFixture]
    public class Promotion2_Test
    {
        [TestCase(2, 2, 0, 60)]
        [TestCase(3,2,20,60)]
        [TestCase(2, 3, 0, 75)]
        public void Promotion2_Test3(int a , int b, float c, float d)
        {
            List<LineItemPrice> input = new List<LineItemPrice>()
            {
                new LineItemPrice{skuId="A", quantity=5, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="B", quantity=4, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="C", quantity=a, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="D", quantity=b, promoDesc="", skuTotal=0},
            };

            List<LineItemPrice> expResult = new List<LineItemPrice>()
            {
                new LineItemPrice{skuId="A", quantity=5, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="B", quantity=4, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="C", quantity=a, promoDesc="Buy2SKUfor30", skuTotal=c},
                new LineItemPrice{skuId="D", quantity=b, promoDesc="Buy2SKUfor30", skuTotal=d},
            };

            List<LineItemPrice> actResult = new List<LineItemPrice>();

            IPromotion2 iPr = new Promotion2();
            actResult = iPr.BuyTwoSKUForFixed(input);

            Assert.That(expResult, Is.EqualTo(actResult));
        }


    }
}
