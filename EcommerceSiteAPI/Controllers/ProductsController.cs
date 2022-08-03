using EcommerceSiteAPI.Context;
using EcommerceSiteAPI.Context.Dtos.Product;
using EcommerceSiteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EcommerceSiteAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _context.Products.ToList();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest();
            }

            var product = new Product(productDto.Description, productDto.Price);

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] UpdateProductDto productDto, int id)
        {
            if (productDto == null)
            {
                return BadRequest();
            }

            var product = _context.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            product.Description = productDto.Description;
            product.Price = productDto.Price;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);

            if(product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
