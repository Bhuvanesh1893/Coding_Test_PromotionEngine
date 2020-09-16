using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using NUnit;
using Coding_Test_PromotionEngine;
using Coding_Test_PromotionEngine.Controllers;
using NUnit.Framework;
using PromotionEngine_Common.Models;
using Coding_Test_PromotionEngine.Models;

namespace Coding_Test_PromotionEngine.Tests.Controllers
{
    [TestFixture]
    public class OrderControllerTest
    {
        //Test to run return type
        [Test]
        public void Post_Test1()
        {
            //Arrange
           OrderController controller = new OrderController();
            OrderRequest ordReq = new OrderRequest();
            OrderResponse expOrdResp = new OrderResponse();

            //Assert
            Assert.IsInstanceOf(typeof(OrderResponse), controller.Post(ordReq));
        }


        //Test to run with invalid input or no line items
        [Test]
        public void Post_Test2()
        {
            //Arrange
            OrderController controller = new OrderController();
            OrderRequest ordReq = new OrderRequest();
            OrderResponse expOrdResp = new OrderResponse();
            expOrdResp.RespMessage.StatusCode = 400;
            expOrdResp.RespMessage.StatusMessage = "Invalid Request";

            //Assert
            Assert.AreEqual(expOrdResp.RespMessage, controller.Post(ordReq).RespMessage);
        }

        //Test to run with valid input with invalid skus
        [Test]
        public void Post_Test3()
        {
            //Arrange
            OrderController controller = new OrderController();
            OrderRequest ordReq = new OrderRequest();
            ordReq.LineItems = new List<LineItem>()
            {
                new LineItem {skuId = "F", quantity = 2},
                new LineItem {skuId = "G", quantity = 2}
            };
            OrderResponse expOrdResp = new OrderResponse();
            expOrdResp.RespMessage.StatusCode = 400;
            expOrdResp.RespMessage.StatusMessage = "Invalid Items";



            //Assert
            Assert.AreEqual(expOrdResp.RespMessage, controller.Post(ordReq).RespMessage);
        }

        //Test to run with valid input with valid skus
        [Test]
        public void Post_Test4()
        {
            //Arrange
            OrderController controller = new OrderController();
            OrderRequest ordReq = new OrderRequest();
            ordReq.LineItems = new List<LineItem>()
            {
                new LineItem {skuId = "A", quantity = 2},
                new LineItem {skuId = "B", quantity = 2}
            };
            OrderResponse expOrdResp = new OrderResponse();
            expOrdResp.RespMessage.StatusCode = 200;
            expOrdResp.RespMessage.StatusMessage = "Success";

            //Assert
            Assert.AreEqual(expOrdResp.RespMessage, controller.Post(ordReq).RespMessage);
        }

        //Test to run with valid input with valid skus - Compare cartTotal and Skutotals
        [Test]
        public void Post_Test5()
        {
            //Arrange
            OrderController controller = new OrderController();
            OrderRequest ordReq = new OrderRequest();
            ordReq.LineItems = new List<LineItem>()
            {
                new LineItem {skuId = "A", quantity = 1},
                new LineItem {skuId = "B", quantity = 1},
                new LineItem {skuId = "C", quantity = 1},
                new LineItem {skuId = "D", quantity = 1}
            };

            OrderResponse expOrdResp = new OrderResponse();
            expOrdResp.LineItemPrice = new List<LineItemPrice>()
            {
                new LineItemPrice { skuId = "A", quantity=1, promoDesc="", skuTotal=50},
                new LineItemPrice { skuId = "B", quantity=1, promoDesc="", skuTotal=30},
                new LineItemPrice { skuId = "C", quantity=1, promoDesc="Buy2SKUfor30", skuTotal=0},
                new LineItemPrice { skuId = "D", quantity=1, promoDesc="Buy2SKUfor30", skuTotal=30}
            };
            expOrdResp.CartTotal = 110;
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
