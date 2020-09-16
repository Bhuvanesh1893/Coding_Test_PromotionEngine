using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coding_Test_PromotionEngine;
using Coding_Test_PromotionEngine.Controllers;
using PromotionEngine_Common.Models;
using Coding_Test_PromotionEngine.Models;

namespace Coding_Test_PromotionEngine.Tests.Controllers
{
    [TestFixture]
    public class Provided_UnitTestCase
    {
        private OrderRequest FactoryGetOrderRequest()
        {
            OrderRequest ordReq = new OrderRequest();
            return ordReq;
        }
        private OrderResponse FactoryGetOrderResponse()
        {
            OrderResponse ordRes = new OrderResponse();
            return ordRes;
        }
        private OrderController FactoryGetOrderController()
        {
            OrderController ordCont = new OrderController();
            return ordCont;
        }
        //Testcases provided
        [Test]
        public void Required_TestCases_1()
        {
            OrderController controller = FactoryGetOrderController();
            OrderRequest ordReq = FactoryGetOrderRequest();
            ordReq.LineItems = new List<LineItem>()
            {
                new LineItem {skuId = "A", quantity = 1},
                new LineItem {skuId = "B", quantity = 1},
                new LineItem {skuId = "C", quantity = 1}
            };

            OrderResponse expOrdResp = FactoryGetOrderResponse();
            expOrdResp.LineItemPrice = new List<LineItemPrice>()
            {
                new LineItemPrice { skuId = "A", quantity=1, promoDesc="", skuTotal=50},
                new LineItemPrice { skuId = "B", quantity=1, promoDesc="", skuTotal=30},
                new LineItemPrice { skuId = "C", quantity=1, promoDesc="", skuTotal=20}
            };
            expOrdResp.CartTotal = 100;
            expOrdResp.RespMessage.StatusCode = 200;
            expOrdResp.RespMessage.StatusMessage = "Success";

            OrderResponse actOrdResp = controller.Post(ordReq);

            //Assert
            Assert.That(expOrdResp.LineItemPrice, Is.EqualTo(actOrdResp.LineItemPrice));
            Assert.That(expOrdResp.CartTotal, Is.EqualTo(actOrdResp.CartTotal));
            Assert.That(expOrdResp.RespMessage, Is.EqualTo(actOrdResp.RespMessage));

        }

        [Test]
        public void Required_TestCases_2()
        {
            OrderController controller = FactoryGetOrderController();
            OrderRequest ordReq = FactoryGetOrderRequest();
            ordReq.LineItems = new List<LineItem>()
            {
                new LineItem {skuId = "A", quantity = 5},
                new LineItem {skuId = "B", quantity = 5},
                new LineItem {skuId = "C", quantity = 1}
            };

            OrderResponse expOrdResp = FactoryGetOrderResponse();
            expOrdResp.LineItemPrice = new List<LineItemPrice>()
            {
                new LineItemPrice { skuId = "A", quantity=5, promoDesc="Buy3For130", skuTotal=230},
                new LineItemPrice { skuId = "B", quantity=5, promoDesc="Buy2For45", skuTotal=120},
                new LineItemPrice { skuId = "C", quantity=1, promoDesc="", skuTotal=20}
            };
            expOrdResp.CartTotal = 370;
            expOrdResp.RespMessage.StatusCode = 200;
            expOrdResp.RespMessage.StatusMessage = "Success";

            OrderResponse actOrdResp = controller.Post(ordReq);

            //Assert
            Assert.That(expOrdResp.LineItemPrice, Is.EqualTo(actOrdResp.LineItemPrice));
            Assert.That(expOrdResp.CartTotal, Is.EqualTo(actOrdResp.CartTotal));
            Assert.That(expOrdResp.RespMessage, Is.EqualTo(actOrdResp.RespMessage));

        }

        public void Required_TestCases_3()
        {
            OrderController controller = FactoryGetOrderController();
            OrderRequest ordReq = FactoryGetOrderRequest();
            ordReq.LineItems = new List<LineItem>()
            {
                new LineItem {skuId = "A", quantity = 3},
                new LineItem {skuId = "B", quantity = 5},
                new LineItem {skuId = "C", quantity = 1},
                new LineItem {skuId = "D", quantity = 1},
            };

            OrderResponse expOrdResp = FactoryGetOrderResponse();
            expOrdResp.LineItemPrice = new List<LineItemPrice>()
            {
                new LineItemPrice { skuId = "A", quantity=3, promoDesc="Buy3For130", skuTotal=130},
                new LineItemPrice { skuId = "B", quantity=5, promoDesc="Buy2For45", skuTotal=120},
                new LineItemPrice { skuId = "C", quantity=1, promoDesc="Buy2SKUfor30", skuTotal=0},
                new LineItemPrice { skuId = "D", quantity=1, promoDesc="Buy2SKUfor30", skuTotal=30}
            };
            expOrdResp.CartTotal = 280;
            expOrdResp.RespMessage.StatusCode = 200;
            expOrdResp.RespMessage.StatusMessage = "Success";

            OrderResponse actOrdResp = controller.Post(ordReq);

            //Assert
            Assert.That(expOrdResp.LineItemPrice, Is.EqualTo(actOrdResp.LineItemPrice));
            Assert.That(expOrdResp.CartTotal, Is.EqualTo(actOrdResp.CartTotal));
            Assert.That(expOrdResp.RespMessage, Is.EqualTo(actOrdResp.RespMessage));

        }
    }
}
