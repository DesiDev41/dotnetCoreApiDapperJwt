using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiProject.Domain;
using ApiProject.Services;
using Microsoft.AspNetCore.Http;
using ApiProject.Services.product;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController : ControllerBase
    {

        protected readonly IProductServices _ProductService;

        public ProductController(IProductServices productService)
        {
            _ProductService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var products = await _ProductService.GetAllProductAsync();
            return Ok(products);
        }



        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int Id)
        {
            var product = await _ProductService.GetProductByIdAsync(Id);
            return Ok(product);
        }


        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBySlug(string Slug)
        {
            var product = await _ProductService.GetProductBySlugAsync(Slug);
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddProduct([FromBody] Product product)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _ProductService.AddProduct(product);
            return CreatedAtAction(nameof(GetById), new { Id = product.Id }, product);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateProduct([FromBody] Product product)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _ProductService.UpdateProduct(product);
            return Ok();
        }



        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteProduct(int Id)
        {
            _ProductService.DeleteProduct(Id);
            return Ok();
        }

    }
}