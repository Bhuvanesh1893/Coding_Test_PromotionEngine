using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine_Common.Models
{
    public class LineItemPrice:IEquatable<LineItemPrice>
    {
        public string skuId { get; set; }

        public int quantity { get; set; }

        public string promoDesc { get; set; }

        public float skuTotal { get; set; }

        public bool Equals(LineItemPrice li)
        {
            if (li is null)
            {
                return false;
            }
            if (skuId == li.skuId && quantity == li.quantity && promoDesc == li.promoDesc && skuTotal == li.skuTotal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
