using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkuPriceInfo
{
    public class SkuPriceInfoAdaptor : SkuPriceInfo, ISkuPriceInfo
    {
        public Dictionary<string, float> GetSkuPriceInfo()
        {
            return GetSkuPriceInfoDetails();
        }

        public override Dictionary<string, float> GetSkuPriceInfoDetails()
        {
            return base.GetSkuPriceInfoDetails();
        }
    }
}
