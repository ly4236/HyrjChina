using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyrjChina.Domain.Entities
{
    /// <summary>
    /// Represents an order status enumeration
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Pending
        /// </summary>
        等待处理 = 10,
        /// <summary>
        /// Processing
        /// </summary>
        处理中 = 20,
        /// <summary>
        /// Complete
        /// </summary>
        完成 = 30,
        /// <summary>
        /// Cancelled
        /// </summary>
        取消 = 40
    }
}
