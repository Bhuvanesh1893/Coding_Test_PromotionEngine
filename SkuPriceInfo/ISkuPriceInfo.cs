using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkuPriceInfo
{
    public interface ISkuPriceInfo
    {
        Dictionary<string, float> GetSkuPriceInfo();
    }
}
