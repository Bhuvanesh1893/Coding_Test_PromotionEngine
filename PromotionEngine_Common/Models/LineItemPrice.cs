using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine_Common.Models
{
    public class LineItemPrice:IEquatable<LineItemPrice>
    {
        private string _skuId;
        private int _quantity;
        private float _skuTotal;
        public string skuId 
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this._skuId = value;
                }
                else
                {
                    throw new Exception("No skuId");
                }
            }
            get
            {
                return this._skuId;
            }
        }

        public int quantity
        {
            set
            {
                if (value > 0)
                {
                    this._quantity = value;
                }
                else
                {
                    throw new Exception("Quantity cannot be negative or zero");
                }
            }
            get
            {
                return this._quantity;
            }
        }

        public string promoDesc { get; set; }

        public float skuTotal
        {
            set
            {
                if (value >= 0)
                {
                    this._skuTotal = value;
                }
                else
                {
                    throw new Exception("SkuTotal cannot be negative");
                }
            }
            get
            {
                return this._skuTotal;
            }
        }

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
