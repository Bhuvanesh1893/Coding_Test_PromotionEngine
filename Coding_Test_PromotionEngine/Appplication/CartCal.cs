using Coding_Test_PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PromotionEngine_Common.Models;
using Promotions;
using Promotions.Adaptor;

namespace Coding_Test_PromotionEngine.Appplication
{
    public class CartCal : ICartCal
    {
        /* Link between the API and the other projects
         * Uses the IPromoPriceCal interface and PromoPriceCalAdaptor to calculate the sku total and the cart total
         * Assigns the info to the OrderResponse object
         */
        public OrderResponse ProcessLineItems(OrderRequest ordReq)
        {
            OrderResponse ordRes = new OrderResponse();
            ordRes = AddLineItems(ordReq);
            ordRes = CalculateCartSkuTotal(ordRes);

            return ordRes;
        }

        private OrderResponse AddLineItems(OrderRequest req)
        {
            try
            {
                OrderResponse ordRes = new OrderResponse();
                ordRes.LineItemPrice = req.LineItems.ConvertAll(x => new LineItemPrice
                {
                    skuId = x.skuId,
                    quantity = x.quantity,
                    promoDesc = "",
                    skuTotal = 0
                });
                ordRes.CartTotal = 0;
                return ordRes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private OrderResponse CalculateCartSkuTotal(OrderResponse res)
        {
            OrderResponse oRes = new OrderResponse();
            List<LineItemPrice> outList = new List<LineItemPrice>();
            float cartTotal = 0f;

            try
            {
                IPromoPriceCal promoPriceCal = new PromoPriceCalAdaptor();
                promoPriceCal.Run_Promos_Cal_Total(res.LineItemPrice, out outList, out cartTotal);
                oRes.LineItemPrice = outList;
                oRes.CartTotal = cartTotal;
                return oRes;
            }
            catch (Exception ex)
            {
                oRes.RespMessage.StatusCode = 400;
                oRes.RespMessage.StatusMessage = ex.Message;
                return oRes;
            }



        }

    }
}