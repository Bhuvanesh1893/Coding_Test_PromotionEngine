using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PromotionEngine_Common.Models;

namespace Coding_Test_PromotionEngine.Models
{
    public class OrderRequest
    {
        public List<LineItem> lineItems { get; set; }

    }
}