using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine_Common.Models
{
    public class LineItem : IEquatable<LineItem>
    {
        private string _skuId;
        private int _quantity;
        
        public string skuId
        {
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    this._skuId = value;
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
                if(value>0)
                {
                    this.quantity = value;
                }
                else
                {
                    throw new Exception("Quantity cannot be null");
                }
            }
            get
            {
                return this._quantity;
            }
        }

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
