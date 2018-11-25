using System;
using System.Collections.Generic;
using System.Text;

namespace IceDog.WebApi2Core.DataAccess.Models
{
    /// <summary>
    /// 订单类
    /// </summary>
    public class Order
    {
        /// <summary>
        /// 订单id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 订单描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime OrderDate { get; set; }
    }
}
