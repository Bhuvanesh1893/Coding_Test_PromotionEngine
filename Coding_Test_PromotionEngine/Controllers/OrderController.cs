using Coding_Test_PromotionEngine.Appplication;
using Coding_Test_PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Coding_Test_PromotionEngine.Controllers
{
    public class OrderController : ApiController
    {

        // POST api/values
        public OrderResponse Post([FromBody] OrderRequest ordReq)
        {
            OrderResponse ordRes = new OrderResponse();
            return ordRes;
        }
    }
}
