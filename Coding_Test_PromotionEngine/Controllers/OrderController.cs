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
                if (ordReq == null || ordReq.LineItems == null || ordReq.LineItems.Count() == 0)
                {
                    ordRes.RespMessage.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                    ordRes.RespMessage.StatusMessage = "Invalid Request";
                    return ordRes;
                }
                else
                {
                    SkuCheck skuCheck = new SkuCheck();
                    if (skuCheck.Check_Skus(ordReq))
                    {
                        CartCal cartCal = new CartCal();
                        ordRes = cartCal.ProcessLineItems(ordReq);
                        if(ordRes.RespMessage.StatusCode == 0 && String.IsNullOrEmpty(ordRes.RespMessage.StatusMessage))
                        {
                            ordRes.RespMessage.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                            ordRes.RespMessage.StatusMessage = "Success";
                        }
                        return ordRes;
                    }
                    else
                    {
                        ordRes.RespMessage.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                        ordRes.RespMessage.StatusMessage = "Invalid Items";
                        return ordRes;
                    }
                }
            }
            catch(Exception ex)
            {
                ordRes.RespMessage.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                ordRes.RespMessage.StatusMessage = ex.Message;
                return ordRes;
            }
        }
    }
}
