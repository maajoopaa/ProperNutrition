﻿using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProperNutrition.Application.Models;
using ProperNutrition.Application.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProperNutrition.API.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IValidator<ProductRequest> _validator;

        public ProductController(IProductService productService, IValidator<ProductRequest> validator)
        {
            _productService = productService;
            _validator = validator;
        }

        [HttpPost]
        [Route("list")]
        public async Task<IActionResult> GetList([FromBody] PaginationModel model)
        {
            var products = await _productService.GetAllAsync(model);

            return products is not null ? Ok(products) : BadRequest();
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetList()
        {
            var products = await _productService.GetAllAsync();

            return products is not null ? Ok(products) : BadRequest();
        }

        [HttpGet("search/{query}")]
        public async Task<IActionResult> Search(string query)
        {
            var products = await _productService.SearchAsync(query);

            return products is not null ? Ok(products) : BadRequest();
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add([FromBody] ProductRequest model)
        {
            try
            {
                _validator.ValidateAndThrow(model);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var error = await _productService.AddAsync(model);

            return string.IsNullOrEmpty(error) ? Ok("Добавление продукта прошло успешно!") : BadRequest(error);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProductRequest model)
        {
            try
            {
                _validator.ValidateAndThrow(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var error = await _productService.UpdateAsync(id, model);

            return string.IsNullOrEmpty(error) ? Ok("Обновление продукта прошло успешно!") : BadRequest(error);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var error = await _productService.DeleteAsync(id);

            return string.IsNullOrEmpty(error) ? Ok("Удаление продукта прошло успешно!") : BadRequest(error);
        }
    }
}
