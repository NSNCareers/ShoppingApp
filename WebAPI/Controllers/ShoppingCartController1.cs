using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.DataContext;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("v1/shopping")]
    [ApiController]
    public class ShoppingCartController3 : ControllerBase
    {
        private readonly IShoppingManager _shoppingManager;

        public ShoppingCartController3(IShoppingManager shoppingManager)
        {
            _shoppingManager = shoppingManager;
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> RemoveFromShoppingCart([FromRoute]int id)
        {
            var results = await _shoppingManager.RemoveItem(id);

            return Ok(results.Message);
        }

        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllItemFromShoppingCart()
        {

            var results = await _shoppingManager.GetAllItem();

            return Ok(results);
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="shoppingCart"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddItemToShoppingCart([FromBody]ShoppingCart shoppingCart)
        {
            var results = await _shoppingManager.AddItem(shoppingCart);

            return Ok(results.Message);
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="shoppingCart"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateShoppingCart([FromBody]ShoppingCart shoppingCart)
        {
            var results = await _shoppingManager.UpdateItem(shoppingCart);

            return Ok(results.Message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetItemFromShoppingCart([FromRoute]int id)
        {
            List<ShoppingCart> results;

            results = await _shoppingManager.GetItem(id);

            return Ok(results);
        }
    }
}