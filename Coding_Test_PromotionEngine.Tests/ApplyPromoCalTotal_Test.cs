using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NUnit.Framework;
using PromotionEngine_Common.Models;
using Promotions.Adaptor;

namespace Coding_Test_PromotionEngine.Tests
{
    [TestFixture]
    public class ApplyPromoCalTotal_Test
    {
        [Test]
        public void Cal_CartTotal_With_Promo_Test()
        {
            IAdaptor cal = new PromotionsAdaptor();

            List<LineItemPrice> input = new List<LineItemPrice>()
            {
                new LineItemPrice{skuId="A", quantity=3, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="B", quantity=2, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="C", quantity=1, promoDesc="", skuTotal=0},
                new LineItemPrice{skuId="D", quantity=1, promoDesc="", skuTotal=0},
            };
            List<LineItemPrice> expResult = new List<LineItemPrice>()
            {
                new LineItemPrice{skuId="A", quantity=3, promoDesc="Buy3For130", skuTotal=130},
                new LineItemPrice{skuId="B", quantity=2, promoDesc="Buy2For45", skuTotal=45},
                new LineItemPrice{skuId="C", quantity=1, promoDesc="Buy2SKUfor30", skuTotal=0},
                new LineItemPrice{skuId="D", quantity=1, promoDesc="Buy2SKUfor30", skuTotal=30},
            };
            List<LineItemPrice> actResult = new List<LineItemPrice>();

            float actCartTotal;
            float expCartTotal = 205;

            cal.Run_Promos_Cal_Total(input, out actResult, out actCartTotal);

            Assert.That(expResult, Is.EqualTo(actResult));
            Assert.AreEqual(actCartTotal, expCartTotal);

        }
    }
}
