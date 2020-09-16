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
            try
            {
                return GetSkuPriceInfoDetails();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override Dictionary<string, float> GetSkuPriceInfoDetails()
        {
            try
            {
                return base.GetSkuPriceInfoDetails();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
