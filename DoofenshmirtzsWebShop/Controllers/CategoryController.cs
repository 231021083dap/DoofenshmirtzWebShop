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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> getAll()
        {
            try
            {
                List<CategoryResponse> categories = await _categoryService.getAllCategories();
                if (categories == null)
                {
                    return Problem("Problem encountered - unexpected");
                }
                if (categories.Count == 0)
                {
                    return NoContent();
                }
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{categoryID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> getByID([FromRoute] int categoryID)
        {
            try
            {
                CategoryResponse category = await _categoryService.getByID(categoryID);

                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //[Authorize(Role.Admin)]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> create([FromBody] NewCategory newCategory)
        {
            try
            {
                CategoryResponse category = await _categoryService.create(newCategory);
                if (category == null)
                {
                    return Problem("Category was not created - error occured");
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //[Authorize(Role.Admin)]
        [HttpPut("{categoryID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> update([FromRoute] int categoryID, [FromBody] UpdateCategory updateCategory)
        {
            try
            {
                CategoryResponse category = await _categoryService.update(categoryID, updateCategory);
                if (category == null)
                {
                    return Problem("Category wasn't updated - error occured");
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

       // [Authorize(Role.Admin)]
        [HttpDelete("{categoryID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> delete([FromRoute] int categoryID)
        {
            try
            {
                bool result = await _categoryService.delete(categoryID);
                if (!result)
                {
                    return Problem("Category wasn't deleted - error occured");
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
