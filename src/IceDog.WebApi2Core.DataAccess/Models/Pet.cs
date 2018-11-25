using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IceDog.WebApi2Core.DataAccess.Models
{
    /// <summary>
    /// 宠物
    /// </summary>
    public class Pet
    {
        /// <summary>
        /// 宠物id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 品种
        /// </summary>
        [Required]
        public string Breed { get; set; }
        /// <summary>
        /// 宠物名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 宠物类型
        /// </summary>
        [Required]
        public PetType PetType { get; set; }
    }
    /// <summary>
    /// 宠物类型
    /// </summary>
    public enum PetType
    {
        /// <summary>
        /// 狗
        /// </summary>
        Dog = 0,
        /// <summary>
        /// 猫
        /// </summary>
        Cat = 1
    }
}
