using Coding_Test_PromotionEngine.Models;

namespace Coding_Test_PromotionEngine.Appplication
{
    public interface ICartCal
    {
        OrderResponse ProcessLineItems(OrderRequest ordReq);
    }
}