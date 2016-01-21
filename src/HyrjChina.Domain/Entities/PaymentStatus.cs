using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyrjChina.Domain.Entities
{
    public enum PaymentStatus
    {
        /// <summary>
        /// Pending
        /// </summary>
        等待处理 = 10,
        /// <summary>
        /// Authorized
        /// </summary>
        已审核 = 20,
        /// <summary>
        /// Paid
        /// </summary>
        已支付 = 30,
        /// <summary>
        /// Partially Refunded
        /// </summary>
        部分退款 = 35,
        /// <summary>
        /// Refunded
        /// </summary>
        退款 = 40,
        /// <summary>
        /// Voided
        /// </summary>
        空订单 = 50,
    }
}
