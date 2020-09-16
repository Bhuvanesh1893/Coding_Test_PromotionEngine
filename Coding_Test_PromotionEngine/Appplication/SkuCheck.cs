using Coding_Test_PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Coding_Test_PromotionEngine.Appplication
{
    public class SkuCheck
    {

        public bool Check_Skus(OrderRequest ordReq)
        {
            List<string> activeSkus = new List<string>(){ "A", "B", "C", "D" };
            List<string> reqSkus = new List<string>();
            foreach(var item in ordReq.LineItems)
            {
                reqSkus.Add(item.skuId);
            }
            return !reqSkus.Except(activeSkus).Any();

        }
    }
}