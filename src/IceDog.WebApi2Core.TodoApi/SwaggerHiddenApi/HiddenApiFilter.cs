using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IceDog.WebApi2Core.TodoApi.SwaggerHiddenApi
{
    /// <summary>
    /// 
    /// </summary>
    public class HiddenApiFilter : IDocumentFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="context"></param>
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (ApiDescription apiDescription in context.ApiDescriptionsGroups.Items.SelectMany(e => e.Items))
            {
                if (!apiDescription.ControllerAttributes().OfType<HiddenApiAttribute>().Any()
                    && !apiDescription.ActionAttributes().OfType<HiddenApiAttribute>().Any())
                {
                    continue;
                }
                var key = "/" + apiDescription.RelativePath.TrimEnd('/');
                if (!key.Contains("/test/") && swaggerDoc.Paths.ContainsKey(key))
                    swaggerDoc.Paths.Remove(key);
            }
        }
    }
}
