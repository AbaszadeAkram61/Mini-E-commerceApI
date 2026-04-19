using E_TicaretApI.Application.Repositories;
using E_TicaretApI.Application.ViewModel.Product;
using E_TicaretApI.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_TicaretApI.ApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Product> _repository;
        private readonly IValidator<Product> _validator;

        public ProductsController(IRepository<Product> repository, IValidator<Product> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_repository.GetAll().Select(p => new
            {
                p.Name,
                p.Price,
                p.Stock
            }));
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _repository.GetByIdAsync(id));

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {
            var product = new Product
            {
                Name = createProductDto.Name,
                Stock = createProductDto.Stock,
                Price = createProductDto.Price
            };
            var validationresult = _validator.Validate(product);
            if (!validationresult.IsValid)
            {
                return BadRequest(validationresult.Errors.Select(v => v.ErrorMessage));
            }
            await _repository.AddAsync(product);
            await _repository.SaveAsync();
            return Ok("Mehsul elave olundu");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProduct updateProduct)
        {
            var product = await _repository.GetByIdAsync(updateProduct.Id);
            product.Name = updateProduct.Name;
            product.Stock = updateProduct.Stock;
            product.Price = updateProduct.Price;
            var validationresult = _validator.Validate(product);
            if (!validationresult.IsValid)
            {
                return BadRequest(validationresult.Errors.Select(e => e.ErrorMessage));
            }
            await _repository.SaveAsync();
            return Ok("Melumat deyisdirildi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
           await _repository.RemoveAsync(id);
           await _repository.SaveAsync();
            return Ok("Melumat silindi");
        }

    }
}
