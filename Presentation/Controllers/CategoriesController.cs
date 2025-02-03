using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Services.Contracts;
using DTOLAR;

namespace CokKatmanliDeneme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CategoriesController(IServiceManager manager)
        {
            _manager = manager;
        }



        // GET: api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<CategoryDTO>> GetCategory()
        {
            return _manager.CategoryService.GetAllCategoriesWithProduct(false).ToList();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var x = _manager.CategoryService.GetCategory(id, false);
            if (x == null)
            {
                return NotFound();
            }
            var y = _manager.CategoryService.GetCategoryWithProduct(id, false);
            return Ok(y);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.CategoryID)
            {
                return BadRequest();
            }
            var x = _manager.CategoryService.GetCategory(id, false);
            if (x == null)
            {
                return BadRequest();
            }

                x.CategoryName = category.CategoryName;
                _manager.CategoryService.UpdateCategoryFromService(x);
                return NoContent();




        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Category> PostCategory(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            _manager.CategoryService.AddCategoryFromService(category);
            return NoContent();

        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var x = _manager.CategoryService.GetCategory(id, false);
            _manager.CategoryService.DeleteCategoryFromService(x);
            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _manager.CategoryService.ProductExists(id);
        }
    }
}
