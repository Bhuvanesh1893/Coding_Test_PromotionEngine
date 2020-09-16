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
            try
            {
                if (ordReq == null || ordReq.lineItems == null || ordReq.lineItems.Count() == 0)
                {
                    ordRes.respMessage.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                    ordRes.respMessage.StatusMessage = "Invalid Request";
                    return ordRes;
                }
                else
                {
                    SkuCheck skuCheck = new SkuCheck();
                    if (skuCheck.Check_Skus(ordReq))
                    {
                        ordRes = ordRes.AddLineItems(ordReq);
                        ordRes.respMessage.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                        ordRes.respMessage.StatusMessage = "Success";
                        return ordRes;
                    }
                    else
                    {
                        ordRes.respMessage.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                        ordRes.respMessage.StatusMessage = "Invalid Items";
                        return ordRes;
                    }
                }
            }
            catch(Exception ex)
            {
                ordRes.respMessage.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                ordRes.respMessage.StatusMessage = ex.Message;
                return ordRes;
            }
        }
    }
}
