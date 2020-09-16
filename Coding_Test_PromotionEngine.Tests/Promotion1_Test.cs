using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using PromotionEngine_Common.Models;
using Promotions;

namespace Coding_Test_PromotionEngine.Tests
{
    [TestFixture]
    public class Promotion1_Test
    {
        //Basic TestCase with Skus A and B eligible
        [TestCase(3,2,130,45)]
        [TestCase(4, 3, 180, 75)]
        [TestCase(5, 4, 230, 90)]
        [TestCase(6, 5, 260, 120)]
        public void Promotion1_Test1( int a, int b, float c, float d)
        {
            List<LineItemPrice> input = new List<LineItemPrice>()
            {
                new LineItemPrice{skuId="A", quantity=a, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="B", quantity=b, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="C", quantity=3, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="D", quantity=2, promoDesc="", skuTotal=0},
            };

            List<LineItemPrice> expResult = new List<LineItemPrice>()
            {
                new LineItemPrice{skuId="A", quantity=a, promoDesc="Buy3For130", skuTotal=c},
                new LineItemPrice{skuId="B", quantity=b, promoDesc="Buy2For45", skuTotal=d},
                new LineItemPrice{skuId="C", quantity=3, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="D", quantity=2, promoDesc="", skuTotal=0},
            };

            List<LineItemPrice> actResult = new List<LineItemPrice>();

            IPromotion1 iPr = new Promotion1();
            actResult = iPr.BuyNSKUUnitsForFixed(input);

            Assert.That(expResult, Is.EqualTo(actResult));

        }

        //Basic testcase with none of the skus eligible
        [Test]
        public void Promotion1_Test2()
        {
            List<LineItemPrice> input = new List<LineItemPrice>()
            {
                new LineItemPrice{skuId="A", quantity=1, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="B", quantity=1, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="C", quantity=1, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="D", quantity=1, promoDesc="", skuTotal=0},
            };

            List<LineItemPrice> expResult = new List<LineItemPrice>()
            {
                new LineItemPrice{skuId="A", quantity=1, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="B", quantity=1, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="C", quantity=1, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="D", quantity=1, promoDesc="", skuTotal=0},
            };

            List<LineItemPrice> actResult = new List<LineItemPrice>();

            IPromotion1 iPr = new Promotion1();
            actResult = iPr.BuyNSKUUnitsForFixed(input);

            Assert.That(expResult, Is.EqualTo(actResult));

        }

        //TestCase with SkuId E not in list-Promotion does not apply
        [Test]
        public void Promotion1_Test3()
        {
            List<LineItemPrice> input = new List<LineItemPrice>()
            {
                new LineItemPrice{skuId="A", quantity=5, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="B", quantity=4, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="E", quantity=3, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="D", quantity=2, promoDesc="", skuTotal=0},
            };

            List<LineItemPrice> expResult = new List<LineItemPrice>()
            {
                new LineItemPrice{skuId="A", quantity=5, promoDesc="Buy3For130", skuTotal=230},
                new LineItemPrice{skuId="B", quantity=4, promoDesc="Buy2For45", skuTotal=90},
                new LineItemPrice{skuId="E", quantity=3, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="D", quantity=2, promoDesc="", skuTotal=0},
            };

            List<LineItemPrice> actResult = new List<LineItemPrice>();

            IPromotion1 iPr = new Promotion1();
            actResult = iPr.BuyNSKUUnitsForFixed(input);

            Assert.That(expResult, Is.EqualTo(actResult));

        }



    }
}
