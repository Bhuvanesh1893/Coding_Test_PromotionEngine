using PromotionEngine_Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coding_Test_PromotionEngine.Models
{
    public class OrderResponse
    {
        public List<LineItemPrice> lineItemPrice { get; set; }

        public float cartTotal { get; set; }

        public ResponseMessage respMessage { get; set; }

        public OrderResponse()
        {
            this.lineItemPrice = new List<LineItemPrice>();
            this.cartTotal = 0F;
            this.respMessage = new ResponseMessage();
        }

        public OrderResponse AddLineItems(OrderRequest req)
        {
            OrderResponse ordRes = new OrderResponse();
            ordRes.lineItemPrice = req.lineItems.ConvertAll(x => new LineItemPrice
            {
                skuId = x.skuId,
                quantity = x.quantity,
                promoDesc = "",
                skuTotal = 0
            });
            ordRes.cartTotal = 0;
            return ordRes;
        }
    }
}