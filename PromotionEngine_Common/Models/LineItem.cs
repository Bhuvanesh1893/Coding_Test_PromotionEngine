using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine_Common.Models
{
    public class LineItem : IEquatable<LineItem>
    {
        public string skuId { get; set; }

        public int quantity { get; set; }

        public bool Equals(LineItem li)
        {
            if (li is null)
            {
                return false;
            }
            if (skuId == li.skuId && quantity == li.quantity)
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
