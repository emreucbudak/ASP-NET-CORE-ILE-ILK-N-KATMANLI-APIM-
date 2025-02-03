using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace CokKatmanliDeneme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _context;
        private readonly ILoggerService _logger;

        public ProductsController(IServiceManager context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var x = _context.ProductService.GetProductsWithCategory(false);
            return Ok(x);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {

                var x = _context.ProductService.GetProductDtoById(id, false);
                if (x == null)
                {
                    return NotFound();
                }
                return Ok(x);
            

        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product product)
        {
            if (id != product.ID)
            {
                return BadRequest();
            }

            var x = _context.ProductService.GetProduct(id, false);
            if (x == null)
            {
                return BadRequest();
            }
            else
            {

            }


                x.ProductName = product.ProductName;
                _context.ProductService.ProductUpdate(id, x, false);



            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.ProductService.ProductAdd(product);


            return CreatedAtAction("GetProduct", new { id = product.ID }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = _context.ProductService.GetProduct(id, true);



            _context.ProductService.ProductRemove(id, false);

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.ProductService.ProductExists(id);
        }
    }
}
