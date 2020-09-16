using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coding_Test_PromotionEngine.Models
{
    public class ResponseMessage : IEquatable<ResponseMessage>
    {
        public int StatusCode { get; set; }

        public string StatusMessage { get; set; }

        public bool Equals(ResponseMessage resMsg)
        {
            if (StatusCode == resMsg.StatusCode && StatusMessage == resMsg.StatusMessage)
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