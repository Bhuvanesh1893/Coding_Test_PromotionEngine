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
        public HttpResponseMessage Post([FromBody] OrderRequest ordReq)
        {
            try
            {
                if(ordReq==null || ordReq.lineItems == null || ordReq.lineItems.Count()==0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, ordReq);
                }
                else
                {
                    OrderResponse ordRes = new OrderResponse(ordReq);
                    return Request.CreateResponse(HttpStatusCode.OK, ordRes);

                }
            }
            catch(Exception exp)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ordReq);
            }
        }
    }
}
