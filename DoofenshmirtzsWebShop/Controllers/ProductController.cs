using DoofenshmirtzsWebShop.Authorization;
using DoofenshmirtzsWebShop.DTOs.Requests;
using DoofenshmirtzsWebShop.DTOs.Responses;
using DoofenshmirtzsWebShop.Helpers;
using DoofenshmirtzsWebShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> getAllProducts()
        {
            try
            {
                List<ProductResponse> product = await _productService.getAllProducts();
                if (product == null)
                {
                    return Problem("It's empty. Wait... It's empty!? It's not supposed to be empty! let me check the script...");
                }
                if (product.Count == 0)
                {
                    return NoContent();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpGet("{productID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> getProductById([FromRoute] int productID)
        {
            try
            {
                ProductResponse product = await _productService.getProductById(productID);
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        
        [Authorize(Role.Admin)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> newProduct([FromBody] NewProduct newProduct)
        {
            try
            {
                ProductResponse product = await _productService.newProduct(newProduct);

                if (product == null)
                {
                    return Problem("Product was not created, something went wrong");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }

        [Authorize(Role.Admin)]
        [HttpPut("{productID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> updateProduct([FromRoute] int productID, [FromBody] UpdateProduct updateProduct)
        {
            try
            {
                ProductResponse product = await _productService.updateProduct(productID, updateProduct);

                if (product == null)
                {
                    return Problem("Product was not updated, Something went wrong.");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [Authorize(Role.Admin)]
        [HttpDelete("{productID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> deleteProduct([FromRoute] int productID)
        {
            try
            {
                bool result = await _productService.deleteProduct(productID);

                if (!result)
                {
                    return Problem("Product was not deleted, Something went wrong.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }


        
    }
}
