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

        public OrderResponse(OrderRequest req)
        {
            this.lineItemPrice = req.lineItems.ConvertAll(x => new LineItemPrice
            {
                skuId = x.skuId,
                quantity = x.quantity,
                promoDesc = "",
                skuTotal = 0
            });
            this.cartTotal = 0;
        }
    }
}