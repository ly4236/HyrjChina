using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyrjChina.Domain.Entities
{
    public class Order
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "订单号")]
        public string OrderNumber { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Display(Name ="收货人姓名")]
        public string Name { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        [Display(Name = "订单创建时间")]
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateTime { get; set; }


        [Display(Name = "付款时间")]
        public DateTime? PaidTime { get; set; }

        [Display(Name = "最近更新时间")]
        public DateTime? UpdateTime { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public OrderStatus OrderStatus
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the order discount (applied to order total)
        /// </summary>
        public decimal OrderDiscount { get; set; }

        public PaymentStatus PaymentStatus
        {
            get; set;
        }


        /// <summary>
        /// Gets or sets the order total
        /// </summary>
        public decimal OrderTotal { get; set; }

        public ShippingStatus ShippingStatus
        {
            get; set;
        }
    }
}
