using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceDog.WebApi2Core.TodoApi.SwaggerHiddenApi
{
    /// <summary>
    /// swagger ui 文档隐藏api
    /// </summary>
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
    public class HiddenApiAttribute:Attribute
    {

    }
}
