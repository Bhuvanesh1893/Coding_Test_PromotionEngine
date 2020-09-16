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

        
    }
}
