using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IceDog.WebApi2Core.DataAccess.Models
{
    /// <summary>
    /// 产品类
    /// </summary>
    public class Product
    {
        /// <summary>
        /// 产品id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 是否停产
        /// </summary>
        public bool IsDiscontinued { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 产品描述
        /// </summary>
        public string Description { get; set; }
    }
}
