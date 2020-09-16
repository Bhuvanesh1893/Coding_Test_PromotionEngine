using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkuPriceInfo
{
    public class SkuPriceInfo
    {
        private Dictionary<string, float> skuPriceInfo = new Dictionary<string, float>();

        //Base class method to get the SKU Price info - DB related code can be written
        public virtual Dictionary<string, float> GetSkuPriceInfoDetails()
        {
            try
            {
                skuPriceInfo.Add("A", 50);
                skuPriceInfo.Add("B", 30);
                skuPriceInfo.Add("C", 20);
                skuPriceInfo.Add("D", 15);

                return skuPriceInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
