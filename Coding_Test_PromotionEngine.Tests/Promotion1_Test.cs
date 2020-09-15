using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using PromotionEngine_Common.Models;

namespace Coding_Test_PromotionEngine.Tests
{
    [TestFixture]
    public class Promotion1_Test
    {
        [Test]
        public void Promotion1_Test ()
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

            IPromotion1 iPr = new Promotion1();
            actResult = iPr.BuyXForY();

            Assert.That(expResult, Is.EqualTo(actResult));



        }

    }
}
