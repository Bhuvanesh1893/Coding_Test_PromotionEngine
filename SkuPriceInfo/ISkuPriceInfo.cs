using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkuPriceInfo
{
    public interface ISkuPriceInfo
    {
        //Functions exposed to the consumer
        Dictionary<string, float> GetSkuPriceInfo();
    }
}
