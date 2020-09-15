using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using SkuPriceInfo;

namespace Coding_Test_PromotionEngine.Tests
{
    [TestFixture]
    public class SkuPriceInfo_Test
    {
        [Test]
        public void GetSkuPrices()
        {
            //Arrange
            Dictionary<string, float> expResult = new Dictionary<string, float>
            {
                { "A", 50 }, { "B", 30 }, { "C", 20 }, { "D", 15 }
            };
            Dictionary<string, float> actResult = new Dictionary<string, float>();

            ISkuPriceInfo skuPr = new SkuPriceInfoAdaptor();

            //Act
            actResult = skuPr.GetSkuPriceInfo();

            //Assert
            CollectionAssert.AreEquivalent(expResult, actResult);

        }
    }
}
