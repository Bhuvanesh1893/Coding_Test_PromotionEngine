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
            expOrdResp.respMessage.StatusCode = 400;
            expOrdResp.respMessage.StatusMessage = "Invalid Request";

            //Assert
            Assert.AreEqual(expOrdResp.respMessage, controller.Post(ordReq).respMessage);
        }

        //Test to run with valid input with invalid skus
        [Test]
        public void Post_Test3()
        {
            //Arrange
            OrderController controller = new OrderController();
            OrderRequest ordReq = new OrderRequest();
            ordReq.lineItems = new List<LineItem>()
            {
                new LineItem {skuId = "F", quantity = 2},
                new LineItem {skuId = "G", quantity = 2}
            };
            OrderResponse expOrdResp = new OrderResponse();
            expOrdResp.respMessage.StatusCode = 400;
            expOrdResp.respMessage.StatusMessage = "Invalid Items";



            //Assert
            Assert.AreEqual(expOrdResp.respMessage, controller.Post(ordReq).respMessage);
        }

        //Test to run with valid input with valid skus
        [Test]
        public void Post_Test4()
        {
            //Arrange
            OrderController controller = new OrderController();
            OrderRequest ordReq = new OrderRequest();
            ordReq.lineItems = new List<LineItem>()
            {
                new LineItem {skuId = "A", quantity = 2},
                new LineItem {skuId = "B", quantity = 2}
            };
            OrderResponse expOrdResp = new OrderResponse();
            expOrdResp.respMessage.StatusCode = 200;
            expOrdResp.respMessage.StatusMessage = "Success";



            //Assert
            Assert.AreEqual(expOrdResp.respMessage, controller.Post(ordReq).respMessage);
        }

    }
}
