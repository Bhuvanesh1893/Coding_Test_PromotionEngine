using PromotionEngine_Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coding_Test_PromotionEngine.Models
{
    public class OrderResponse
    {
        public List<LineItemPrice> LineItemPrice { get; set; }

        public float CartTotal { get; set; }

        public ResponseMessage RespMessage { get; set; }

        public OrderResponse()
        {
            this.LineItemPrice = new List<LineItemPrice>();
            this.CartTotal = 0F;
            this.RespMessage = new ResponseMessage();
        }
    }
}