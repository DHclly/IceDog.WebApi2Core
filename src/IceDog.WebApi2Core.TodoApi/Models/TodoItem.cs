using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IceDog.WebApi2Core.TodoApi.Models
{
    /// <summary>
    /// 待办事项模型
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// 编号
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        [DefaultValue(false)]
        public bool IsComplete { get; set; }
    }
}
