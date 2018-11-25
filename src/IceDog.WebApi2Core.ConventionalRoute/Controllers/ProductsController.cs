using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IceDog.WebApi2Core.DataAccess.Models;
using IceDog.WebApi2Core.DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IceDog.WebApi2Core.ConventionalRoute.Controllers
{
    /// <summary>
    /// 产品控制器
    /// </summary>
    public class ProductsController : BaseController//ControllerBase
    {
        private readonly ProductsRepository _repository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public ProductsController(ProductsRepository repository)
        {
            _repository = repository;
        }

        #region snippet_GetById
        /// <summary>
        /// 根据id获取产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Product>> GetByIdAsync(int id)
        {
            var product = await _repository.GetProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        #endregion

        #region snippet_BindingSourceAttributes
        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <param name="discontinuedOnly">是否只显示停产的</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAsync(
            [FromQuery] bool discontinuedOnly = false)
        {
            List<Product> products = null;

            if (discontinuedOnly)
            {
                products = await _repository.GetDiscontinuedProductsAsync();
            }
            else
            {
                products = await _repository.GetProductsAsync();
            }

            return products;
        }
        #endregion
        /// <summary>
        /// 创建产品
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Product>> CreateAsync(Product product)
        {
            await _repository.AddProductAsync(product);

            return CreatedAtAction(nameof(GetByIdAsync),
                new { id = product.Id }, product);
        }
    }
}