using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine_Common.Models
{
    public class LineItemPrice
    {
        public string skuId { get; set; }

        public int quantity { get; set; }

        public string promoDesc { get; set; }

        public float skuTotal { get; set; }
    }
}
