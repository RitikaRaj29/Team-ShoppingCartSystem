﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCartSystem.Models;
using OnlineShoppingCartSystem.Repository;
using OnlineShoppingCartSystem.Services.Admin;

namespace OnlineShoppingCartSystem.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var categories = await _productService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetById(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var product = await _productService.GetByName(name);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] Product entity)
        {
            var p = await _productService.Insert(entity);
            await _productService.Save();
            return Ok(p);
            

        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct( [FromBody] Product product)
        {
            await _productService.Update(product);
            return Ok(product);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromBody] Product product)
        {
            await _productService.Delete(product);
            return Ok();
        }
    }
}
